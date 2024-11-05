using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Thriving.FFmpeg.Proxy
{

    /**
     * 2.0音响系统，左右双声道，每个单元都采用了一个独立的中低频单元和一个高频单元
     * 2.1音响系统，分为一个独立的低音单元和两个中高音单元
     * 5.1音响系统，包括6个音响：2个前置音箱、2个后置音箱、1个中置环绕音箱、1个重低音音箱
     * 7.1音响系统，包括8个音箱：2个前置音箱、2个后置音箱、1个前中置环绕音箱、2个后中置环绕音箱、1个重低音音箱
     */

    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct AVChannelLayout
    {
        public AVChannelLayout(int nb_channels, AVChannelMask mask)
        {
            // 类似 Marshall.PtrToStructure()
            this.order = AVChannelOrder.AV_CHANNEL_ORDER_NATIVE;
            this.nb_channels = nb_channels;
            this.details = new IntPtr((long)mask);
        }

        internal AVChannelLayout(IntPtr handle)
        {
            this.order = (AVChannelOrder)Marshal.ReadInt32(handle, Marshal.OffsetOf<AVChannelLayout>(nameof(order)).ToInt32());
            this.nb_channels = Marshal.ReadInt32(handle, Marshal.OffsetOf<AVChannelLayout>(nameof(nb_channels)).ToInt32());
            this.details = Marshal.ReadIntPtr(handle, Marshal.OffsetOf<AVChannelLayout>(nameof(details)).ToInt32());
            this.opaque = Marshal.ReadIntPtr(handle, Marshal.OffsetOf<AVChannelLayout>(nameof(opaque)).ToInt32());
        }

        /// <summary>
        /// Channel order used in this layout. Mandatory field.
        /// </summary>
        [FieldOffset(0)]
        internal AVChannelOrder order;

        ///<summary>
        /// Number of channels in this layout. Mandatory field.
        ///</summary>
        [FieldOffset(4)]
        internal int nb_channels;

        /// <summary>
        /// <code>Details about which channels are present in this layout</code> 
        /// <code>For AV_CHANNEL_ORDER_UNSPEC, this field is undefined and must not be used</code>
        /// <code>For AV_CHANNEL_ORDER_CUSTOM,this field is a nb_channels-sized array, 
        ///                 with each element signalling the presence of the AVChannel </code>
        /// <code>For AV_CHANNEL_ORDER_NATIVE or for AV_CHANNEL_ORDER_AMBISONIC to signal non-diegetic channels .
        ///                 It is a bitmask, where the position of each set bit means that the AVChannel with the corresponding value is present</code>
        /// </summary>
        [FieldOffset(8)]
        internal IntPtr details;

        /**
         * For some internal data of the user.
         */
        [FieldOffset(16)]
        internal IntPtr opaque;


        public AVChannelOrder Order
        {
            readonly get => order;
            set => order = value;
        }

        public int NbChannels
        {
            readonly get => nb_channels;
            set => nb_channels = value;
        }

        public readonly AVChannelCustom[] Map
        {
            get
            {
                if (order == AVChannelOrder.AV_CHANNEL_ORDER_CUSTOM && details != IntPtr.Zero)
                {
                    var result = new AVChannelCustom[nb_channels];
                    for (int i = 0; i < nb_channels; i++)
                    {
                        result[i] = new AVChannelCustom(details + i * Marshal.SizeOf<AVChannelCustom>());
                    }
                }
                return [];
            }
        }

        public readonly AVChannelMask Mask
        {
            get
            {
                if (order == AVChannelOrder.AV_CHANNEL_ORDER_NATIVE || Order == AVChannelOrder.AV_CHANNEL_ORDER_AMBISONIC)
                {
                    return (AVChannelMask)details;
                }
                return 0;
            }
        }

        public static IList<AVChannelLayout> GetAllStandard()
        {
            var result = new List<AVChannelLayout>();

            int state = 0;
            IntPtr data;
            while ((data = Core.av_channel_layout_standard(ref state)) != IntPtr.Zero)
            {
                result.Add(new AVChannelLayout(data));
            }
            return result;
        }

        /// <summary>
        /// Check whether a channel layout is valid
        /// </summary>
        //public bool Check()
        //{
        //    var res = Core.av_channel_layout_check(_handle);
        //    return res == 1;
        //}

        //public AVChannel GetChannel(uint index)
        //{
        //    return Core.av_channel_layout_channel_from_index(_handle, index);
        //}

        //public uint GetIndex(AVChannel channel)
        //{
        //    var res = Core.av_channel_layout_index_from_channel(_handle, channel);
        //    if (res < 0) throw FFmpegException.FromErrorCode(res);
        //    return (uint)res;
        //}

        //public uint GetIndex(string name)
        //{
        //    var res = Core.av_channel_layout_index_from_string(_handle, name);
        //    if (res < 0) throw FFmpegException.FromErrorCode(res);
        //    return (uint)res;
        //}

        //public AVChannel GetChannel(string name)
        //{
        //    return Core.av_channel_layout_channel_from_string(_handle, name);
        //}

        //public bool Compare(AVChannelLayout other)
        //{
        //    var res = Core.av_channel_layout_compare(_handle, other._handle);
        //    return res == 1;
        //}

        //public void Copy(AVChannelLayout other)
        //{
        //    var res = Core.av_channel_layout_copy(_handle, other.Handle);
        //}



        public static AVChannelLayout GetDefault(int nb_channels)
        {
            Core.av_channel_layout_default(out AVChannelLayout layout, nb_channels);
            return layout;
        }

        public static AVChannelLayout AV_CHANNEL_LAYOUT_MONO
        {
            get => new AVChannelLayout(1, AVChannelMask.AV_CH_LAYOUT_MONO);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_STEREO
        {
            get => new AVChannelLayout(2, AVChannelMask.AV_CH_LAYOUT_STEREO);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_2POINT1
        {
            get => new AVChannelLayout(3, AVChannelMask.AV_CH_LAYOUT_2POINT1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_2_1
        {
            get => new AVChannelLayout(3, AVChannelMask.AV_CH_LAYOUT_2_1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_SURROUND
        {
            get => new AVChannelLayout(3, AVChannelMask.AV_CH_LAYOUT_SURROUND);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_3POINT1
        {
            get => new AVChannelLayout(4, AVChannelMask.AV_CH_LAYOUT_3POINT1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_4POINT0
        {
            get => new AVChannelLayout(4, AVChannelMask.AV_CH_LAYOUT_4POINT0);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_4POINT1
        {
            get => new AVChannelLayout(5, AVChannelMask.AV_CH_LAYOUT_4POINT1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_2_2
        {
            get => new AVChannelLayout(4, AVChannelMask.AV_CH_LAYOUT_2_2);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_QUAD
        {
            get => new AVChannelLayout(4, AVChannelMask.AV_CH_LAYOUT_QUAD);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT0
        {
            get => new AVChannelLayout(5, AVChannelMask.AV_CH_LAYOUT_5POINT0);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT1
        {
            get => new AVChannelLayout(6, AVChannelMask.AV_CH_LAYOUT_5POINT1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT0_BACK
        {
            get => new AVChannelLayout(5, AVChannelMask.AV_CH_LAYOUT_5POINT0_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT1_BACK
        {
            get => new AVChannelLayout(6, AVChannelMask.AV_CH_LAYOUT_5POINT1_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT0
        {
            get => new AVChannelLayout(6, AVChannelMask.AV_CH_LAYOUT_6POINT0);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT0_FRONT
        {
            get => new AVChannelLayout(6, AVChannelMask.AV_CH_LAYOUT_6POINT0_FRONT);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_3POINT1POINT2
        {
            get => new AVChannelLayout(6, AVChannelMask.AV_CH_LAYOUT_3POINT1POINT2);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_HEXAGONAL
        {
            get => new AVChannelLayout(6, AVChannelMask.AV_CH_LAYOUT_HEXAGONAL);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT1
        {
            get => new AVChannelLayout(7, AVChannelMask.AV_CH_LAYOUT_6POINT1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT1_BACK
        {
            get => new AVChannelLayout(7, AVChannelMask.AV_CH_LAYOUT_6POINT1_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT1_FRONT
        {
            get => new AVChannelLayout(7, AVChannelMask.AV_CH_LAYOUT_6POINT1_FRONT);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT0
        {
            get => new AVChannelLayout(7, AVChannelMask.AV_CH_LAYOUT_7POINT0);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT0_FRONT
        {
            get => new AVChannelLayout(7, AVChannelMask.AV_CH_LAYOUT_7POINT0_FRONT);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1
        {
            get => new AVChannelLayout(8, AVChannelMask.AV_CH_LAYOUT_7POINT1);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1_WIDE
        {
            get => new AVChannelLayout(8, AVChannelMask.AV_CH_LAYOUT_7POINT1_WIDE);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1_WIDE_BACK
        {
            get => new AVChannelLayout(8, AVChannelMask.AV_CH_LAYOUT_7POINT1_WIDE_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT1POINT2_BACK
        {
            get => new AVChannelLayout(8, AVChannelMask.AV_CH_LAYOUT_5POINT1POINT2_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_OCTAGONAL
        {
            get => new AVChannelLayout(8, AVChannelMask.AV_CH_LAYOUT_OCTAGONAL);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_CUBE
        {
            get => new AVChannelLayout(8, AVChannelMask.AV_CH_LAYOUT_CUBE);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT1POINT4_BACK
        {
            get => new AVChannelLayout(10, AVChannelMask.AV_CH_LAYOUT_5POINT1POINT4_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1POINT2
        {
            get => new AVChannelLayout(10, AVChannelMask.AV_CH_LAYOUT_7POINT1POINT2);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1POINT4
        {
            get => new AVChannelLayout(12, AVChannelMask.AV_CH_LAYOUT_7POINT1POINT4_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT2POINT3
        {
            get => new AVChannelLayout(12, AVChannelMask.AV_CH_LAYOUT_7POINT2POINT3);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_9POINT1POINT4_BACK
        {
            get => new AVChannelLayout(14, AVChannelMask.AV_CH_LAYOUT_9POINT1POINT4_BACK);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_HEXADECAGONAL
        {
            get => new AVChannelLayout(16, AVChannelMask.AV_CH_LAYOUT_HEXADECAGONAL);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_STEREO_DOWNMIX
        {
            get => new AVChannelLayout(2, AVChannelMask.AV_CH_LAYOUT_STEREO_DOWNMIX);
        }
        public static AVChannelLayout AV_CHANNEL_LAYOUT_22POINT2
        {
            get => new AVChannelLayout(24, AVChannelMask.AV_CH_LAYOUT_22POINT2);
        }

    }
}