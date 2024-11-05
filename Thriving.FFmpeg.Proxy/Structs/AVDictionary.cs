using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe class AVDictionary:ProxyObject
    {
        internal AVDictionary(IntPtr handle) : base(handle) { }

        public AVDictionary()
        {
            _handle = IntPtr.Zero;
        }

        ~AVDictionary()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.av_dict_free(ref _handle);
            }
        }

        public int Count
        {
            get => Core.av_dict_count(_handle);
        }

        public int Set(string key, string value, AVDictionaryFlags flags=0)
        {
            return Core.av_dict_set(ref _handle, key, value, flags);
        }

        public int SetInt(string key, long value, AVDictionaryFlags flags=0)
        {
            return Core.av_dict_set_int(ref _handle, key, value, flags);
        }

        public IList<AVDictionaryEntry> GetAll()
        {
            var result = new List<AVDictionaryEntry>();
            var pre = IntPtr.Zero;
            IntPtr temp;
            while ((temp = Core.av_dict_iterate(_handle, pre)) != IntPtr.Zero)
            {
                result.Add(new AVDictionaryEntry(temp));
                pre=temp;
            }
            return result;
        }


        public AVDictionaryEntry Get(string key, AVDictionaryFlags flags)
        {
            var ptr = Core.av_dict_get(_handle, key, IntPtr.Zero, flags);
            return new AVDictionaryEntry(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key_val_seg">key-value之间分隔符</param>
        /// <param name="pairs_seg">字典项之间分隔符</param>
        /// <returns></returns>
        public string ToString(char key_val_seg, char pairs_seg)
        {
            var buffer = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>());
            var ret = Core.av_dict_get_string(_handle, buffer, key_val_seg, pairs_seg);
            if (ret >= 0)
            {
                var data = Marshal.ReadIntPtr(buffer);
                Marshal.FreeHGlobal(buffer);
                return Marshal.PtrToStringAnsi(data);
            }
            Marshal.FreeHGlobal(buffer);
            throw FFmpegException.FromErrorCode(ret);
        }


    }
}