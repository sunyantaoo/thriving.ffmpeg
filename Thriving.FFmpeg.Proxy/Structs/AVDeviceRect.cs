using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public readonly struct AVDeviceRect
    {
        /// <summary>
        /// x coordinate of top left corner
        /// </summary>
        [FieldOffset(0)] internal readonly int x;
        /// <summary>
        /// y coordinate of top left corner
        /// </summary>
        [FieldOffset(4)] internal readonly int y;
        [FieldOffset(8)] internal readonly int width;
        [FieldOffset(12)] internal readonly int height;
    }
}