using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// 解码后帧数据
    /// </summary>
    public class AVFrame:ProxyObject
    {
        private const int AV_NUM_DATA_POINTERS = 8;

        internal AVFrame(IntPtr handle):base(handle) { }

        public AVFrame()
        {
            _handle = Core.av_frame_alloc();
        }

        ~AVFrame()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.av_frame_free(ref _handle);
            }
        }

        public bool IsWritable()
        {
            var ret = Core.av_frame_is_writable(_handle);
            return ret > 0;
        }

        public void MakeWritable()
        {
            var res = Core.av_frame_make_writable(_handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public bool Copy(AVFrame src)
        {
            var res = Core.av_frame_copy(_handle, src.Handle);
            return res >= 0;
        }

        public bool Ref(AVFrame src)
        {
            var res = Core.av_frame_ref(_handle, src.Handle);
            return res == 0;
        }

        public void UnRef()
        {
            Core.av_frame_unref(_handle);
        }

        public bool Replace(AVFrame src)
        {
            var res = Core.av_frame_replace(_handle, src.Handle);
            return res == 0;
        }

        /// <summary>
        /// Allocate new buffer(s) for audio or video data
        /// <code>  
        /// The following fields must be set on frame before calling this function:
        ///  - format(pixel format for video, sample format for audio)
        ///  - width and height for video
        ///  - nb_samples and ch_layout for audio
        ///  </code>
        ///  <code>
        /// This function will fill AVFrame.data and AVFrame.buf arrays and, 
        ///  if  necessary, allocate and fill AVFrame.extended_data and AVFrame.extended_buf. 
        ///  For planar formats, one buffer will be allocated for each plane.
        ///  </code>
        /// </summary>
        /// <param name="align"> It is highly recommended to pass 0 here unless you know what you are doing</param>
        /// <returns></returns>
        public bool AllocateBuffer(int align = 0)
        {
            var res = Core.av_frame_get_buffer(_handle, align);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return res == 0;
        }

        public AVBufferRef GetPlaneBuffer(int plane)
        {
            var ptr = Core.av_frame_get_plane_buffer(_handle, plane);
            return new AVBufferRef(ptr);
        }


        /// <summary>
        /// 进行&运算结果大于0则包含
        /// </summary>
        public AVFrameFlags Flags
        {
            get => (AVFrameFlags)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32(), (int)value);
        }

        public int Width
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.width)).ToInt32());
            set=> Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.width)).ToInt32(),value);
        }

        public int Height
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.height)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.height)).ToInt32(), value);
        }

        public long PacketPos
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pkt_pos)).ToInt32());
        }

        public AVPictureType AVPictureType
        {
            get => (AVPictureType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pict_type)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pict_type)).ToInt32(), (int)value);
        }

        public AVChannelLayout ChannelLayout
        {
            get
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.height)).ToInt32();
                return new AVChannelLayout(ptr);
            }
            set
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.height)).ToInt32();
                Core.av_channel_layout_copy(ptr,ref value);
            }
        }


        public AVRational SampleAspectRatio
        {
            get
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.sample_aspect_ratio)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(ptr);
            }
        }

        public int SampleRate
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_rate)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_rate)).ToInt32(), value);
        }


        public AVRational TimeBase
        {
            get
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(ptr);
            }
            set
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                Marshal.StructureToPtr<AVRational>(value, ptr, true);
            }
        }

        /// <summary>
        /// 显示时间，以AVCodecContext.Timebase为准
        /// </summary>
        public long PTS
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pts)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pts)).ToInt32(), value);
        }

        /// <summary>
        /// 显示时长
        /// </summary>
        public long Duration
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.duration)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.duration)).ToInt32(), value);
        }

        public int NbSamples
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_samples)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_samples)).ToInt32(), value);
        }

        public AVPixelFormat PixelFormat
        {
            get => (AVPixelFormat)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32(), (int)value);
        }

        public AVSampleFormat SampleFormat
        {
            get => (AVSampleFormat)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32(), (int)value);
        }

        public bool KeyFrame
        {
            get
            {
                var flags = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32());
                return (flags & (int)AVFrameFlags.AV_FRAME_FLAG_KEY) == (int)AVFrameFlags.AV_FRAME_FLAG_KEY;
            }
        }

        /// <summary>
        /// 以AVStream.TimeBase为准
        /// </summary>
        public long PacketDTS
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pkt_dts)).ToInt32());
        }


        public long PacketPosition
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pkt_pos)).ToInt32());
        }

        public int Quality
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.quality)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.quality)).ToInt32(), value);
        }


        public AVColorRange ColorRange
        {
            get => (AVColorRange)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_range)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_range)).ToInt32(), (int)value);
        }


        public AVColorPrimaries ColorPrimaries
        {
            get => (AVColorPrimaries)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_primaries)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_primaries)).ToInt32(), (int)value);
        }


        public AVColorTransferCharacteristic ColorTrc
        {
            get
            {
                var color_trc = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_trc)).ToInt32());
                return (AVColorTransferCharacteristic)color_trc;
            }
        }


        public AVColorSpace Colorspace
        {
            get
            {
                var colorspace = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.colorspace)).ToInt32());
                return (AVColorSpace)colorspace;
            }
            set
            {
                Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.colorspace)).ToInt32(), (int)value);
            }
        }


        public AVChromaLocation ChromaLocation
        {
            get
            {
                var chroma_location = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.chroma_location)).ToInt32());
                return (AVChromaLocation)chroma_location;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr[] Data
        {
            get
            {
                var result = new IntPtr[AV_NUM_DATA_POINTERS];
                if (_handle != IntPtr.Zero)
                {
                    var data = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.data)).ToInt32();
                    for (int i = 0; i < AV_NUM_DATA_POINTERS; i++)
                    {
                        result[i] = Marshal.ReadIntPtr(data, i * Marshal.SizeOf<IntPtr>());
                    }
                }
                return result;
            }
        }

        public AVBufferRef[] Buf
        {
            get
            {
                var result = new AVBufferRef[AV_NUM_DATA_POINTERS];
                if (_handle != IntPtr.Zero)
                {
                    var buf = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf)).ToInt32());
                    for (int i = 0; i < AV_NUM_DATA_POINTERS; i++)
                    {
                        result[i] = new AVBufferRef(buf + i * Marshal.SizeOf<AVBufferRef.Internal>());
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// <code>For video, a positive or negative value, which is typically indicating the size in bytes of each picture line,
        ///         but it can also be:        
        ///                  the negative byte size of lines for vertical flipping(with data[n] pointing to the end of the data      
        ///                  a positive or negative multiple of the byte size as for accessing even and odd fields of a frame (possibly flipped)
        /// </code>
        /// <code>For audio, only linesize[0] may be set. For planar audio, each channel plane must be the same size</code>
        /// </summary>
        public int[] Linesize
        {
            get
            {
                var result = new int[AV_NUM_DATA_POINTERS];
                if (_handle != IntPtr.Zero)
                {
                    var linesize = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.linesize)).ToInt32();
                    for (var i = 0; i < AV_NUM_DATA_POINTERS; i++)
                    {
                        result[i] = Marshal.ReadInt32(linesize, i * Marshal.SizeOf<int>());
                    }
                }
                return result;
            }
        }

        public AVDictionary Metadata
        {
            get
            {
                var metadata = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.metadata)).ToInt32());
                return new AVDictionary(metadata);
            }
        }


        [StructLayout(LayoutKind.Explicit, Size = 440)]
        readonly struct Internal
        {
            /**
             * pointer to the picture/channel planes.
             * This might be different from the first allocated byte. For video,
             * it could even point to the end of the image data.
             *
             * All pointers in data and extended_data must point into one of the
             * AVBufferRef in buf or extended_buf.
             *
             * Some decoders access areas outside 0,0 - width,height, please
             * see avcodec_align_dimensions2(). Some filters and swscale can read
             * up to 16 bytes beyond the planes, if these filters are to be used,
             * then 16 extra bytes must be allocated.
             *
             * NOTE: Pointers not needed by the format MUST be set to NULL.
             *
             * @attention In case of video, the data[] pointers can point to the
             * end of image data in order to reverse line order, when used in
             * combination with negative values in the linesize[] array.
             */
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_NUM_DATA_POINTERS)]
            internal readonly IntPtr[] data;

            /**
             * For video, a positive or negative value, which is typically indicating
             * the size in bytes of each picture line, but it can also be:
             * - the negative byte size of lines for vertical flipping
             *   (with data[n] pointing to the end of the data
             * - a positive or negative multiple of the byte size as for accessing
             *   even and odd fields of a frame (possibly flipped)
             *
             * For audio, only linesize[0] may be set. For planar audio, each channel
             * plane must be the same size.
             *
             * For video the linesizes should be multiples of the CPUs alignment
             * preference, this is 16 or 32 for modern desktop CPUs.
             * Some code requires such alignment other code can be slower without
             * correct alignment, for yet other it makes no difference.
             *
             * @note The linesize may be larger than the size of usable data -- there
             * may be extra padding present for performance reasons.
             *
             * @attention In case of video, line size values can be negative to achieve
             * a vertically inverted iteration over image lines.
             */
            [FieldOffset(64)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_NUM_DATA_POINTERS)]
            internal readonly int[] linesize;

            /**
             * pointers to the data planes/channels.
             *
             * For video, this should simply point to data[].
             *
             * For planar audio, each channel has a separate data pointer, and
             * linesize[0] contains the size of each channel buffer.
             * For packed audio, there is just one data pointer, and linesize[0]
             * contains the total size of the buffer for all channels.
             *
             * Note: Both data and extended_data should always be set in a valid frame,
             * but for planar audio with more channels that can fit in data,
             * extended_data must be used in order to access all channels.
             */
            [FieldOffset(96)]
            internal readonly IntPtr extended_data;

            /**
             * @name Video dimensions
             * Video frames only. The coded dimensions (in pixels) of the video frame,
             * i.e. the size of the rectangle that contains some well-defined values.
             *
             * @note The part of the frame intended for display/presentation is further
             * restricted by the @ref cropping "Cropping rectangle".
             * @{
             */
            [FieldOffset(104)]
            internal readonly int width;

            [FieldOffset(108)]
            internal readonly int height;

            /**
             * number of audio samples (per channel) described by this frame
             */
            [FieldOffset(112)]
            internal readonly int nb_samples;

            /**
             * format of the frame, -1 if unknown or unset
             * Values correspond to enum AVPixelFormat for video frames,
             * enum AVSampleFormat for audio)
             */
            [FieldOffset(116)]
            internal readonly int format;

            /**
             * 1 -> keyframe, 0-> not
             *
             * @deprecated Use AV_FRAME_FLAG_KEY instead
             */
            [FieldOffset(120)]
            internal readonly int key_frame;


            /**
             * Picture type of the frame.
             */
            [FieldOffset(124)]
            internal readonly AVPictureType pict_type;

            /**
             * Sample aspect ratio for the video frame, 0/1 if unknown/unspecified.
             */
            [FieldOffset(128)]
            internal readonly AVRational sample_aspect_ratio;

            /**
             * Presentation timestamp in time_base units (time when frame should be shown to user).
             */
            [FieldOffset(136)]
            internal readonly long pts;

            /**
             * DTS copied from the AVPacket that triggered returning this frame. (if frame threading isn't used)
             * This is also the Presentation time of this AVFrame calculated from
             * only AVPacket.dts values without pts values.
             */
            [FieldOffset(144)]
            internal readonly long pkt_dts;

            /**
             * Time base for the timestamps in this frame.
             * In the future, this field may be set on frames output by decoders or
             * filters, but its value will be by default ignored on input to encoders
             * or filters.
             */
            [FieldOffset(152)]
            internal readonly AVRational time_base;

            /**
             * quality (between 1 (good) and FF_LAMBDA_MAX (bad))
             */
            [FieldOffset(160)]
            internal readonly int quality;

            /**
             * Frame owner's internal data.
             *
             * This field may be set by the code that allocates/owns the frame data.
             * It is then not touched by any library functions, except:
             * - it is copied to other references by av_frame_copy_props() (and hence by
             *   av_frame_ref());
             * - it is set to NULL when the frame is cleared by av_frame_unref()
             * - on the caller's explicit request. E.g. libavcodec encoders/decoders
             *   will copy this field to/from @ref AVPacket "AVPackets" if the caller sets
             *   @ref AV_CODEC_FLAG_COPY_OPAQUE.
             *
             * @see opaque_ref the reference-counted analogue
             */
            [FieldOffset(168)]
            internal readonly IntPtr opaque;

            /**
             * Number of fields in this frame which should be repeated, i.e. the total
             * duration of this frame should be repeat_pict + 2 normal field durations.
             *
             * For interlaced frames this field may be set to 1, which signals that this
             * frame should be presented as 3 fields: beginning with the first field (as
             * determined by AV_FRAME_FLAG_TOP_FIELD_FIRST being set or not), followed
             * by the second field, and then the first field again.
             *
             * For progressive frames this field may be set to a multiple of 2, which
             * signals that this frame's duration should be (repeat_pict + 2) / 2
             * normal frame durations.
             *
             * @note This field is computed from MPEG2 repeat_first_field flag and its
             * associated flags, H.264 pic_struct from picture timing SEI, and
             * their analogues in other codecs. Typically it should only be used when
             * higher-layer timing information is not available.
             */
            [FieldOffset(176)]
            internal readonly int repeat_pict;

            [FieldOffset(180)]
            internal readonly int interlaced_frame;

            [FieldOffset(184)]
            internal readonly int top_field_first;


            [FieldOffset(188)]
            internal readonly int palette_has_changed;


            /**
             * Sample rate of the audio data.
             */
            [FieldOffset(192)]
            internal readonly int sample_rate;

            /**
             * AVBuffer references backing the data for this frame. All the pointers in
             * data and extended_data must point inside one of the buffers in buf or
             * extended_buf. This array must be filled contiguously -- if buf[i] is
             * non-NULL then buf[j] must also be non-NULL for all j < i.
             *
             * There may be at most one AVBuffer per data plane, so for video this array
             * always contains all the references. For planar audio with more than
             * AV_NUM_DATA_POINTERS channels, there may be more buffers than can fit in
             * this array. Then the extra AVBufferRef pointers are stored in the
             * extended_buf array.
             */
            [FieldOffset(200)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_NUM_DATA_POINTERS)]
            internal readonly IntPtr[] buf;


            /**
             * For planar audio which requires more than AV_NUM_DATA_POINTERS
             * AVBufferRef pointers, this array will hold all the references which
             * cannot fit into AVFrame.buf.
             *
             * Note that this is different from AVFrame.extended_data, which always
             * contains all the pointers. This array only contains the extra pointers,
             * which cannot fit into AVFrame.buf.
             *
             * This array is always allocated using av_malloc() by whoever constructs
             * the frame. It is freed in av_frame_unref().
             */
            [FieldOffset(264)]
            internal readonly IntPtr extended_buf;
            /**
             * Number of elements in extended_buf.
             */
            [FieldOffset(272)]
            internal readonly int nb_extended_buf;

            [FieldOffset(280)]
            internal readonly IntPtr side_data;

            [FieldOffset(288)]
            internal readonly int nb_side_data;


            /**
             * Frame flags, a combination of @ref lavu_frame_flags
             */
            [FieldOffset(292)]
            internal readonly AVFrameFlags flags;

            /**
             * MPEG vs JPEG YUV range.
             * - encoding: Set by user
             * - decoding: Set by libavcodec
             */
            [FieldOffset(296)]
            internal readonly AVColorRange color_range;

            [FieldOffset(300)]
            internal readonly AVColorPrimaries color_primaries;

            [FieldOffset(304)]
            internal readonly AVColorTransferCharacteristic color_trc;

            /**
             * YUV colorspace type.
             * - encoding: Set by user
             * - decoding: Set by libavcodec
             */
            [FieldOffset(308)]
            internal readonly AVColorSpace colorspace;

            [FieldOffset(312)]
            internal readonly AVChromaLocation chroma_location;

            /**
             * frame timestamp estimated using various heuristics, in stream time base
             * - encoding: unused
             * - decoding: set by libavcodec, read by user.
             */
            [FieldOffset(320)]
            internal readonly long best_effort_timestamp;

            [FieldOffset(328)]
            internal readonly long pkt_pos;


            /**
             * metadata.
             * - encoding: Set by user.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(336)]
            internal readonly IntPtr metadata;

            /**
             * decode error flags of the frame, set to a combination of
             * FF_DECODE_ERROR_xxx flags if the decoder produced a frame, but there
             * were errors during the decoding.
             * - encoding: unused
             * - decoding: set by libavcodec, read by user.
             */
            [FieldOffset(344)]
            internal readonly int decode_error_flags;



            /**
             * size of the corresponding packet containing the compressed
             * frame.
             * It is set to a negative value if unknown.
             * - encoding: unused
             * - decoding: set by libavcodec, read by user.
             * @deprecated use AV_CODEC_FLAG_COPY_OPAQUE to pass through arbitrary user
             *             data from packets to frames
             */
            [FieldOffset(348)]
            internal readonly int pkt_size;


            /**
             * For hwaccel-format frames, this should be a reference to the
             * AVHWFramesContext describing the frame.
             */
            [FieldOffset(352)]
            internal readonly IntPtr hw_frames_ctx;

            /**
             * Frame owner's internal data.
             *
             * This field may be set by the code that allocates/owns the frame data.
             * It is then not touched by any library functions, except:
             * - a new reference to the underlying buffer is propagated by
             *   av_frame_copy_props() (and hence by av_frame_ref());
             * - it is unreferenced in av_frame_unref();
             * - on the caller's explicit request. E.g. libavcodec encoders/decoders
             *   will propagate a new reference to/from @ref AVPacket "AVPackets" if the
             *   caller sets @ref AV_CODEC_FLAG_COPY_OPAQUE.
             *
             * @see opaque the plain pointer analogue
             */
            [FieldOffset(360)]
            internal readonly IntPtr opaque_ref;

            /**
             * @anchor cropping
             * @name Cropping
             * Video frames only. The number of pixels to discard from the the
             * top/bottom/left/right border of the frame to obtain the sub-rectangle of
             * the frame intended for presentation.
             * @{
             */
            [FieldOffset(368)]
            internal readonly long crop_top;

            [FieldOffset(376)]
            internal readonly long crop_bottom;

            [FieldOffset(384)]
            internal readonly long crop_left;

            [FieldOffset(392)]
            internal readonly long crop_right;
            /**
             * @}
             */

            /**
             * AVBufferRef for internal use by a single libav* library.
             * Must not be used to transfer data between libraries.
             * Has to be NULL when ownership of the frame leaves the respective library.
             *
             * Code outside the FFmpeg libs should never check or change the contents of the buffer ref.
             *
             * FFmpeg calls av_buffer_unref() on it when the frame is unreferenced.
             * av_frame_copy_props() calls create a new reference with av_buffer_ref()
             * for the target frame's internal_ref field.
             */
            [FieldOffset(400)]
            internal readonly IntPtr internal_ref;

            /**
             * Channel layout of the audio data.
             */
            [FieldOffset(408)]
            internal readonly AVChannelLayout ch_layout;

            /**
             * Duration of the frame, in the same units as pts. 0 if unknown.
             */
            [FieldOffset(432)]
            internal readonly long duration;
        }
    }
}