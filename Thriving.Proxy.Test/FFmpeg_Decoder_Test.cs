using Thriving.FFmpeg.Proxy;

namespace Thriving.Proxy.Test
{
    public class FFmpeg_Decoder_Test
    {
        /// <summary>
        /// 视频解码
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            string filePath = @"E:\abc.mp4";
            var formtCtxRef = AVFormatContext.OpenInput(null, filePath, new AVDictionary());
            Core.av_dump_format(formtCtxRef.Handle, 0, filePath, 0);

            var videoStream = formtCtxRef.Streams.FirstOrDefault(x => x.Codecpar.CodecType == AVMediaType.AVMEDIA_TYPE_VIDEO);

            var codec = AVCodec.FindDecoder(videoStream.Codecpar.CodecId);

            var codecCtxRef = new AVCodecContext(codec);
            codecCtxRef.SetParameters(videoStream.Codecpar);
            codecCtxRef.Open(codec, new AVDictionary());

            var pkt = new AVPacket();

            while (formtCtxRef.ReadFrame(pkt))
            {
                var frame = new AVFrame();

                var p_pts = videoStream.TimeBase.GetSecond(pkt.PTS);
                var p_dts = videoStream.TimeBase.GetSecond(pkt.DTS);
                var p_duration = videoStream.TimeBase.GetSecond(pkt.Duration);

                if (pkt.StreamIndex == videoStream.Index)
                {
                    codecCtxRef.SendPacket(pkt);
                    codecCtxRef.ReceiveFrame(frame);

                    var duration = videoStream.TimeBase.GetSecond(frame.Duration);
                    var f_pts = videoStream.TimeBase.GetSecond(frame.PTS);

                    switch (frame.PixelFormat)
                    {
                        case AVPixelFormat.AV_PIX_FMT_YUV420P:
                            {
                                //var size = Core.av_image_get_buffer_size(frame.PixelFormat, frame.Width, frame.Height, 1);
                                //var data = new byte[size];
                                //Core.av_image_copy_to_buffer(data, size, frame.Data, frame.Linesize, frame.PixelFormat, frame.Width, frame.Height, 1);

                                //CVImage img = CVImage.Create(frame.Height * 3 / 2, frame.Width, 1, data, DataType.CV_8U, 0);
                                //img = img.ConvertColor(ColorConversionCode.COLOR_YUV420p2RGB);
                                //img.Write($"E:\\test\\{DateTime.Now.Ticks}.jpg", null);
                            }
                            break;
                        case AVPixelFormat.AV_PIX_FMT_YUV422P:
                            {


                            }
                            break;
                        case AVPixelFormat.AV_PIX_FMT_YUV444P:
                            {


                            }
                            break;
                    }

                    Core.av_frame_unref(frame.Handle);
                }
                Core.av_packet_unref(pkt.Handle);
            }
            codecCtxRef.Close();
            formtCtxRef.CloseInput();
        }

        /// <summary>
        /// 音频解码
        /// </summary>
        [Fact]
        public void TestMethod2()
        {
            string filePath = @"E:\1234abcd.mp4";
            var formtCtxRef = AVFormatContext.OpenInput(null, filePath, new AVDictionary());
            Core.av_dump_format(formtCtxRef.Handle, 0, filePath, 0);

            var audioStream = formtCtxRef.Streams.FirstOrDefault(x => x.Codecpar.CodecType == AVMediaType.AVMEDIA_TYPE_AUDIO);

            var codec = AVCodec.FindDecoder(audioStream.Codecpar.CodecId);

            var codecCtxRef = new AVCodecContext(codec);
            codecCtxRef.SetParameters(audioStream.Codecpar);
            codecCtxRef.Open(codec, new AVDictionary());

            var pkt = new AVPacket();

            while (formtCtxRef.ReadFrame(pkt))
            {
                var frame = new AVFrame();

                if (pkt.StreamIndex == audioStream.Index)
                {
                    codecCtxRef.SendPacket(pkt);
                    while (codecCtxRef.ReceiveFrame(frame))
                    {
                        /// 持续时长
                        var duration = (double)(frame.Duration * audioStream.TimeBase.Num) / audioStream.TimeBase.Den;
                        /// 展示时刻
                        var pts = (double)(frame.PTS * audioStream.TimeBase.Num) / audioStream.TimeBase.Den;


                        var t = frame.Buf;
                        switch (frame.SampleFormat)
                        {
                            case AVSampleFormat.AV_SAMPLE_FMT_FLTP:

                                break;
                        }
                        frame.UnRef();
                    }
                }
                pkt.UnRef();
            }
            codecCtxRef.Close();
            formtCtxRef.CloseInput();
        }

        /// <summary>
        /// 录频
        /// </summary>
        [Fact]
        public void TestMethod3()
        {
            Core.avdevice_register_all();
            // var ifmt0 = AVInputFormat.FindInputFormat("dshow");
            // var ifmt1 = AVInputFormat.FindInputFormat("lavfi");
            // var ifmt2 = AVInputFormat.FindInputFormat("vfwcap");
            // var ifmt3 = AVInputFormat.FindInputFormat("openal");
            var inputFormat = AVInputFormat.FindInputFormat("gdigrab");
            AVDictionary dict = new AVDictionary();
            dict.SetInt("offset_x", 10);
            dict.SetInt("offset_y", 10);
            // dict.SetInt("framerate", 25);
            dict.SetInt("show_region", 1); // 录屏时是否在屏幕显示边框
            dict.SetInt("draw_mouse", 1); // 是否包含鼠标
            dict.Set("video_size", "960x680");

            var fmt_ctx = AVFormatContext.OpenInput(inputFormat, "desktop", dict);
            // var fmt_ctx = AVFormatContext.OpenInput(inputFormat, "title={窗口名称}", dict);

            var videoStream = fmt_ctx.Streams.FirstOrDefault(x => x.Codecpar.CodecType == AVMediaType.AVMEDIA_TYPE_VIDEO);

            var codec = AVCodec.FindDecoder(videoStream.Codecpar.CodecId);

            var codec_ctx = new AVCodecContext(codec);
            codec_ctx.SetParameters(videoStream.Codecpar);
            codec_ctx.Open(codec, new AVDictionary());

            AVPacket packet = new AVPacket();
            int i = 0;
            while (fmt_ctx.ReadFrame(packet))
            {
                if (i >= 20) break;
                codec_ctx.SendPacket(packet);

                if (packet.StreamIndex == videoStream.Index)
                {
                    AVFrame frame = new AVFrame();
                    codec_ctx.ReceiveFrame(frame);

                    if (frame.PixelFormat == AVPixelFormat.AV_PIX_FMT_BGRA)
                    {
                        //var data = AVImageUtils.GetBuffer(frame);
                        //CVImage img = CVImage.Create(frame.Height, frame.Width, 4, data, DataType.CV_8U);
                        //img.Write($"E:\\test\\{DateTime.Now.Ticks}.jpeg", new Dictionary<ImwriteFlag, int>());
                    }
                    frame.UnRef();
                }
                packet.UnRef();
                i++;
            }
            fmt_ctx.CloseInput();
        }
    }
}