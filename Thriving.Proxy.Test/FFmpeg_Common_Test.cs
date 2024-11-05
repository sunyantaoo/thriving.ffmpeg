using Thriving.FFmpeg.Proxy;

namespace Thriving.Proxy.Test
{
    public class FFmpeg_Common_Test
    {
        [Fact]
        public void TestMethod1()
        {
            var server = AVIOContext.Open("https://www.w3school.com.cn/example/html5/mov_bbb.mp4", AVIOFlags.AVIO_FLAG_WRITE);
            var client = AVIOContext.Accept(server);

            client.HandShake();

            server.Close();
        }


        [Fact]
        public void TestMethod2()
        {
            AVCodecDescriptor prev = null;
            while (AVCodecDescriptor.Next(prev, out AVCodecDescriptor next))
            {

                prev = next;
            }
        }


        [Fact]
        public void TestMethod3()
        {
            AVImage image = new AVImage(8, 6, AVPixelFormat.AV_PIX_FMT_YUV420P);

            image.FillColor(new uint[] { 255, 120, 32, 0 });

            var data = image.GetBuffer(1);
        }

        /// <summary>
        /// rtmp协议
        /// </summary>
        [Fact]
        public void TestMethod4()
        {
            var opt = new AVDictionary();
            var fmt_ctx = AVFormatContext.OpenInput(null, "rtmp://liteavapp.qcloud.com/live/liteavdemoplayerstreamid", opt);

            AVPacket packet = new AVPacket();
            fmt_ctx.ReadFrame(packet);

            fmt_ctx.CloseInput();
        }


        [Fact]
        public void TestMethod5()
        {
            var name = AVSampleUtils.GetName(AVSampleFormat.AV_SAMPLE_FMT_DBL);

            long MKTAG(char a, char b, char c, char d)
            {
                return (a) | ((b) << 8) | ((c) << 16) | ((uint)d << 24);
            }

            var x = MKTAG('E', 'O', 'F', ' ');
        }
    }
}