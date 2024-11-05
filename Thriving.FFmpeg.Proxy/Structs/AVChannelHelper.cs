namespace Thriving.FFmpeg.Proxy
{
    public static class AVChannelHelper
    {
        public static string GetDescription(AVChannel channel)
        {
            var builder = new StringBuilder();
            Core.av_channel_description(builder, 64, channel);
            return builder.ToString();
        }

        public static AVChannel GetChannel(string name)
        {
            return Core.av_channel_from_string(name);
        }

        public static string GetName(AVChannel channel)
        {
            var builder = new StringBuilder();
            Core.av_channel_name(builder, 32, channel);
            return builder.ToString();
        }

    }
}