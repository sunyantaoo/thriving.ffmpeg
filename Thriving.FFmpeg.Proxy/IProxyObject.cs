namespace Thriving.FFmpeg.Proxy
{
    public interface IProxyObject
    {
        public IntPtr Handle { get; }

    }


    public abstract class ProxyObject : IProxyObject
    {
        internal IntPtr _handle;

        protected ProxyObject(IntPtr handle)
        {
            _handle = handle;
        }

        protected ProxyObject()
        {

        }

        /// <summary>
        /// C中为 T*
        /// </summary>
        public IntPtr Handle { get => _handle; }
    }


}