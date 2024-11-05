namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVIOFlags
    {
        /**
        * @name URL open modes
        * The flags argument to avio_open must be one of the following
        * constants, optionally ORed with other flags.
        * @{
        */
        AVIO_FLAG_READ = 1,                      
        AVIO_FLAG_WRITE = 2,                              
        AVIO_FLAG_READ_WRITE = (AVIO_FLAG_READ | AVIO_FLAG_WRITE),  

        /**
         * Use non-blocking mode.
         * If this flag is set, operations on the context will return
         * AVERROR(EAGAIN) if they can not be performed immediately.
         * If this flag is not set, operations on the context will never return
         * AVERROR(EAGAIN).
         * Note that this flag does not affect the opening/connecting of the
         * context. Connecting a protocol will always block if necessary (e.g. on
         * network protocols) but never hang (e.g. on busy devices).
         * Warning: non-blocking protocols is work-in-progress; this flag may be
         * silently ignored.
         */
        AVIO_FLAG_NONBLOCK = 8,

        /**
         * Use direct mode.
         * avio_read and avio_write should if possible be satisfied directly
         * instead of going through a buffer, and avio_seek will always
         * call the underlying seek function directly.
         */
        AVIO_FLAG_DIRECT = 0x8000,

    }
}