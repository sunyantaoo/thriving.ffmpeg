namespace Thriving.FFmpeg.Proxy
{
    public  class AVIODirContext:ProxyObject
    {
        internal AVIODirContext(IntPtr handle):base(handle) { }

        ~AVIODirContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avio_free_directory_entry(ref _handle);
            }
        }

        public static AVIODirContext Open(string dirPath, AVDictionary? options=null)
        {
            var handle = IntPtr.Zero;
            var dictPtr = options == null ? IntPtr.Zero : options._handle;
            var res = Core.avio_open_dir(ref handle, dirPath, ref dictPtr);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return new AVIODirContext(handle);
        }

        public IList<AVIODirEntry> ReadAll()
        {
            var result = new List<AVIODirEntry>();

            var next = IntPtr.Zero;
            while (Core.avio_read_dir(_handle, ref next) >= 0)
            {
                result.Add(new AVIODirEntry(next));
            }
            return result;
        }

        public AVIODirEntry? ReadNext()
        {
            var next = IntPtr.Zero;
            if (Core.avio_read_dir(_handle, ref next) >= 0)
            {
                return new AVIODirEntry(next);
            }
            return null;
        }


        public void Close()
        {
            var res = Core.avio_close_dir(ref _handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

    }
}