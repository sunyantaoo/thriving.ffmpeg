namespace Thriving.FFmpeg.Proxy
{
    public class FFmpegException : Exception
    {
        internal FFmpegException(string message) : base(message)
        {

        }

        public static FFmpegException FromErrorCode(int errorCode)
        {
            var builder = new StringBuilder();
            Core.av_strerror(errorCode, builder);
            return new FFmpegException(builder.ToString());
        }
    }
}