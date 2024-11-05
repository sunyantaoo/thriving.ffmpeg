using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public interface IOptionObject
    {
        /// <summary>
        ///  Set the values of all AVOption fields to their default values
        /// </summary>
        public void SetDefault();

        /// <summary>
        /// <code>
        /// Set the values of all AVOption fields to their default values
        /// Only these AVOption fields for which(opt->flags & mask) == flags will have their default applied to s.
        /// </code>
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="flags"></param>
        public void SetDefault(int mask, int flags);

        /// <summary>
        /// Free all allocated objects in obj
        /// </summary>
        public void Free();

        /// <summary>
        ///  Iterate over all AVOptions belonging to obj.
        /// </summary>
        /// <param name="prev"></param>
        /// <returns></returns>
        public AVOption Next(AVOption? prev = null);

        /// <summary>
        /// <code>
        /// Look for an option in an object
        /// Consider only options which have all the specified flags set
        /// </code>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="unit"></param>
        /// <param name="opt_flags"></param>
        /// <param name="search_flags"></param>
        /// <returns></returns>
        public AVOption Find(string name, string unit, AVOptionFlags opt_flags, AVOptionSearchFlags search_flags);

        public AVOption Find(string name, string unit, AVOptionFlags opt_flags, AVOptionSearchFlags search_flags, IntPtr target_obj);

        public void Copy(ProxyOptionObject src);

        public void Set(string name, string val, AVOptionSearchFlags search_flags);
        public void Set(AVDictionary dict);
        public void Set(AVDictionary dict, AVOptionSearchFlags search_flags);

        public void Set(string name, long val, AVOptionSearchFlags search_flags);

        public void Set(string name, double val, AVOptionSearchFlags search_flags);

        public void Set(string name, AVRational val, AVOptionSearchFlags search_flags);
        public void Set(string name, byte[] val, AVOptionSearchFlags search_flags);

        public void Set(string name, AVPixelFormat val, AVOptionSearchFlags search_flags);
        public void Set(string name, AVSampleFormat val, AVOptionSearchFlags search_flags);
        public void Set(string name, AVChannelLayout val, AVOptionSearchFlags search_flags);
        public void SetVideoRate(string name, AVRational val, AVOptionSearchFlags search_flags);
        public void SetImageSize(string name, int w, int h, AVOptionSearchFlags search_flags);


        public T Get<T>(string name, AVOptionSearchFlags search_flags) where T : struct;



    }
    public abstract class ProxyOptionObject : ProxyObject, IOptionObject
    {
        protected ProxyOptionObject() { }

        protected ProxyOptionObject(IntPtr handle) : base(handle) { }

        /// <summary>
        ///
        /// </summary>
        public void SetDefault()
        {
            Core.av_opt_set_defaults(_handle);
        }

        public void SetDefault(int mask, int flags)
        {
            Core.av_opt_set_defaults2(_handle, mask, flags);
        }
        public void Free()
        {
            Core.av_opt_free(_handle);
        }

        public AVOption Next(AVOption? prev = null)
        {
            var handle = Core.av_opt_next(_handle, prev == null ? IntPtr.Zero : prev._handle);
            return new AVOption(handle);
        }

        public AVOption Find(string name, string unit, AVOptionFlags opt_flags, AVOptionSearchFlags search_flags)
        {
            var handle = Core.av_opt_find(_handle, name, unit, opt_flags, search_flags);
            return new AVOption(handle);
        }

        public AVOption Find(string name, string unit, AVOptionFlags opt_flags, AVOptionSearchFlags search_flags, IntPtr target_obj)
        {
            var handle = Core.av_opt_find2(_handle, name, unit, opt_flags, search_flags, target_obj);
            return new AVOption(handle);
        }

        public void Copy(ProxyOptionObject src)
        {
            Core.av_opt_copy(_handle, src._handle);
        }

        public void Set(string name, string val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set(_handle, name, val, search_flags);
        }
        public void Set(AVDictionary dict)
        {
            Core.av_opt_set_dict(_handle, ref dict._handle);
        }
        public void Set(AVDictionary dict, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_dict2(_handle, ref dict._handle, search_flags);
        }

        public void Set(string name, long val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_int(_handle, name, val, search_flags);
        }

        public void Set(string name, double val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_double(_handle, name, val, search_flags);
        }

        public void Set(string name, AVRational val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_q(_handle, name, val, search_flags);
        }
        public void Set(string name, byte[] val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_bin(_handle, name, val, val.Length, search_flags);
        }

        public void Set(string name, AVPixelFormat val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_pixel_fmt(_handle, name, val, search_flags);
        }
        public void Set(string name, AVSampleFormat val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_sample_fmt(_handle, name, val, search_flags);
        }
        public void Set(string name, AVChannelLayout val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_chlayout(_handle, name, ref val, search_flags);
        }
        public void SetVideoRate(string name, AVRational val, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_video_rate(_handle, name, val, search_flags);
        }

        public void SetImageSize(string name, int w, int h, AVOptionSearchFlags search_flags)
        {
            Core.av_opt_set_image_size(_handle, name, w, h, search_flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">int,long ,double,AVRational,AVPixelFormat,AVSampleFormat,AVChannelLayout</typeparam>
        /// <param name="name"></param>
        /// <param name="search_flags"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T Get<T>(string name, AVOptionSearchFlags search_flags) where T : struct
        {
            var type = typeof(T);

            if (type == typeof(int) || type == typeof(long))
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<long>());
                Core.av_opt_get_int(_handle, name, search_flags, ptr);
                var result = Marshal.PtrToStructure<T>(ptr);
                Marshal.FreeHGlobal(ptr);
                return result;
            }
            if (type == typeof(double) || type == typeof(float))
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<double>());
                Core.av_opt_get_double(_handle, name, search_flags, ptr);
                var result = Marshal.PtrToStructure<T>(ptr);
                Marshal.FreeHGlobal(ptr);
                return result;
            }
            if (type == typeof(AVRational))
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<double>());
                Core.av_opt_get_q(_handle, name, search_flags, ptr);
                var result = Marshal.PtrToStructure<T>(ptr);
                Marshal.FreeHGlobal(ptr);
                return result;
            }
            if (type == typeof(AVPixelFormat))
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<double>());
                Core.av_opt_get_pixel_fmt(_handle, name, search_flags, ptr);
                var result = Marshal.PtrToStructure<T>(ptr);
                Marshal.FreeHGlobal(ptr);
                return result;
            }
            if (type == typeof(AVSampleFormat))
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<double>());
                Core.av_opt_get_sample_fmt(_handle, name, search_flags, ptr);
                var result = Marshal.PtrToStructure<T>(ptr);
                Marshal.FreeHGlobal(ptr);
                return result;
            }
            if (type == typeof(AVChannelLayout))
            {
                var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<double>());
                Core.av_opt_get_chlayout(_handle, name, search_flags, ptr);
                var result = Marshal.PtrToStructure<T>(ptr);
                Marshal.FreeHGlobal(ptr);
                return result;
            }

            throw new NotImplementedException();
        }

    }

}