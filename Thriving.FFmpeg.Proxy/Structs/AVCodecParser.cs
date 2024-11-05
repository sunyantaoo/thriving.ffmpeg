using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVCodecParser : ProxyObject
    {
        internal AVCodecParser(IntPtr handle):base(handle) { }

        public static IList<AVCodecParser> GetAll()
        {
            var result = new List<AVCodecParser>();

            int state = 0;
            IntPtr data;
            while ((data = Core.av_parser_iterate(ref state)) != IntPtr.Zero)
            {
                result.Add(new AVCodecParser(data));
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle">AVCodecParserContext*</param>
        /// <returns></returns>
        public delegate int ParserInit(IntPtr handle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle">AVCodecParserContext*</param>
        /// <param name="avctx"> AVCodecContext *</param>
        /// <param name="poutbuf">uint8_t **</param>
        /// <param name="poutbuf_size"> int *</param>
        /// <param name="buf">uint8_t *</param>
        /// <param name="buf_size"></param>
        /// <returns></returns>
        public delegate int ParserParse(IntPtr handle, IntPtr avctx, IntPtr poutbuf, IntPtr poutbuf_size, IntPtr buf, int buf_size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle">AVCodecParserContext*</param>
        public delegate void ParserClose(IntPtr handle);

        public delegate int Split(IntPtr avctx, IntPtr buf, int buf_size);

        [StructLayout(LayoutKind.Explicit, Size = 64)]
        struct Internal
        {
            /// <summary>
            /// several codec IDs are permitted 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            [FieldOffset(0)] int[] codec_ids;
            [FieldOffset(28)] int priv_data_size;
            /// <summary>
            /// This callback never returns an error, a negative value means that  the frame start was in a previous packet
            /// </summary>
            [FieldOffset(32)] ParserInit parser_init;
            [FieldOffset(40)] ParserParse parser_parse;
            [FieldOffset(48)] ParserClose parser_close;
            [FieldOffset(56)] Split split;
        }
    }
}