using System.Runtime.InteropServices;
using Thriving.FFmpeg.Proxy;

namespace Thriving.Proxy.Test
{
    public class FFmpeg_Encoder_Test
    {
        /// <summary>
        /// 视频编码
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            var codec = AVCodec.FindEncoder(AVCodecID.AV_CODEC_ID_H264);
            var codec_ctx = new AVCodecContext(codec)
            {
                PixelFormat = AVPixelFormat.AV_PIX_FMT_YUV420P,
                Width = 960,
                Height = 720,
                TimeBase = new AVRational(1, 25),
                FrameRate = new AVRational(25, 1),
                BitRate = 400000,
                GopSize = 10,
                MaxBFrames = 1
            };

            codec_ctx.Open(codec, new AVDictionary());

            var frame = new AVFrame()
            {
                PixelFormat = codec_ctx.PixelFormat,
                Width = 960,
                Height = 720
            };

            frame.AllocateBuffer(1);

            for (int i = 0; i < 30; i++)
            {
                if (!frame.IsWritable()) frame.MakeWritable();

                for (int y = 0; y < frame.Height; y++)
                {
                    for (int x = 0; x < frame.Width; x++)
                    {
                        Marshal.WriteInt32(frame.Data[0], y * frame.Linesize[0] + x, x + y + i * 3);
                    }
                }

                /* Cb and Cr */
                for (int y = 0; y < frame.Height / 2; y++)
                {
                    for (int x = 0; x < frame.Width / 2; x++)
                    {
                        Marshal.WriteInt32(frame.Data[1], y * frame.Linesize[1] + x, 128 + y + i * 2);
                        Marshal.WriteInt32(frame.Data[2], y * frame.Linesize[2] + x, 64 + x + i * 5);
                    }
                }

                frame.PTS = i;

                AVPacket pkt = new AVPacket();
                while (true)
                {
                    codec_ctx.SendFrame(frame);
                    var ret = codec_ctx.ReceivePacket(pkt);
                    if (ret == (int)AVError.AGAIN) continue;

                    //   pkt.Data
                    //  pkt.Size
                    break;
                }
                pkt.UnRef();
            }

            frame.UnRef();
            codec_ctx.Close();
        }

        /// <summary>
        /// 音频编码
        /// </summary>
        [Fact]
        public void TestMethod2()
        {
            var codec = AVCodec.FindEncoder(AVCodecID.AV_CODEC_ID_AAC);
            var codec_ctx = new AVCodecContext(codec)
            {
                SampleFormat = AVSampleFormat.AV_SAMPLE_FMT_FLTP,
                SampleRate = 44100,
                BitRate = 64000,
                ChannelLayout = AVChannelLayout.AV_CHANNEL_LAYOUT_STEREO,
            };

            codec_ctx.Open(codec, new AVDictionary());

            var frame = new AVFrame()
            {
                SampleFormat = codec_ctx.SampleFormat,
                NbSamples = codec_ctx.FrameSize,
                ChannelLayout = codec_ctx.ChannelLayout,
            };

            var packet = new AVPacket();

            frame.AllocateBuffer(0);

            for (int i = 0; i < 30; i++)
            {
                if (!frame.IsWritable()) frame.MakeWritable();

                // AVFrame
                //  frame.Data
                //  frame.Linesize
                //  frame.PTS

                codec_ctx.SendFrame(frame);
                AVPacket pkt = new AVPacket();
                codec_ctx.ReceivePacket(pkt);
                {
                    //   pkt.Data
                    //  pkt.Size

                    pkt.UnRef();
                }
            }

            codec_ctx.Close();
        }

        [Fact]
        public void TestMethod3()
        {
            var dest_file = "E:\\abc.mp4";

            var fmt_ctx = AVFormatContext.OpenOutput(null, "mp4", dest_file);
            var video_codec = AVCodec.FindEncoder(fmt_ctx.OutputFormat.VideoCodecID);

            var video_codec_ctx = new AVCodecContext(video_codec)
            {
                BitRate = 400000,
                Width = 960,
                Height = 680,
                TimeBase = new AVRational(1, 25),
                FrameRate = new AVRational(25, 1),
                GopSize = 12,
                MaxBFrames = 2,
                PixelFormat = AVPixelFormat.AV_PIX_FMT_YUV420P,
            };
            video_codec_ctx.Open(video_codec);

            var video_Stream = fmt_ctx.AddStream(video_codec);
            video_Stream.TimeBase = new AVRational(1, 20000);
            video_Stream.Codecpar = video_codec_ctx.GetParameters();

            var io_ctx = AVIOContext.Open(dest_file, AVIOFlags.AVIO_FLAG_WRITE);
            fmt_ctx.IOContext = io_ctx;

            //   fmt_ctx.InitOutput();
            fmt_ctx.WriteHeader();

            AVFrame frame = new AVFrame()
            {
                PixelFormat = video_codec_ctx.PixelFormat,
                Width = video_codec_ctx.Width,
                Height = video_codec_ctx.Height,
            };

            frame.AllocateBuffer();

            var duration = 1.0 / 25; // 每帧播放时长
            var pts = 0.0; // 当前帧播放时刻

            for (int i = 0; i < 60; i++)
            {
                if (!frame.IsWritable()) frame.MakeWritable();

                {
                    // 将颜色块写入AVFrame
                    for (int y = 0; y < frame.Height; y++)
                    {
                        for (int x = 0; x < frame.Width; x++)
                        {
                            Marshal.WriteInt32(frame.Data[0], y * frame.Linesize[0] + x, x + y + i * 3);
                        }
                    }
                    for (int y = 0; y < frame.Height / 2; y++)
                    {
                        for (int x = 0; x < frame.Width / 2; x++)
                        {
                            Marshal.WriteInt32(frame.Data[1], y * frame.Linesize[1] + x, 128 + y + i * 2);
                            Marshal.WriteInt32(frame.Data[2], y * frame.Linesize[2] + x, 64 + x + i * 5);
                        }
                    }
                }

                AVPacket packet = new AVPacket();
                while (true)
                {
                    video_codec_ctx.SendFrame(frame);
                    var t = video_codec_ctx.ReceivePacket(packet);
                    if (t == -11) continue;

                    packet.Duration = video_Stream.TimeBase.GetMoment(duration);
                    packet.PTS = video_Stream.TimeBase.GetMoment(pts);

                    packet.StreamIndex = video_Stream.Index;

                    fmt_ctx.WriteFrameInterleaved(packet);

                    break;
                }
                packet.UnRef();

                pts += duration;
            }
            frame.UnRef();

            fmt_ctx.WriteTrailer();

            fmt_ctx.CloseInput();
        }
    }
}