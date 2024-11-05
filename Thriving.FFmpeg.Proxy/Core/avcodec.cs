using System;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe partial class Core
    {
        private const string _libavcodec = "avcodec-61.dll";

        [DllImport(_libavcodec)] public static extern IntPtr avcodec_get_class();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavcodec)] public static extern string avcodec_license();
        [DllImport(_libavcodec)] public static extern uint avcodec_version();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavcodec)] public static extern string avcodec_configuration();

        [DllImport(_libavcodec)] public static extern void av_ac3_parse_header();
        [DllImport(_libavcodec)] public static extern void av_adts_header_parse();
        [DllImport(_libavcodec)] public static extern void av_bsf_alloc();
        [DllImport(_libavcodec)] public static extern void av_bsf_flush();
        [DllImport(_libavcodec)] public static extern void av_bsf_free();
        [DllImport(_libavcodec)] public static extern void av_bsf_get_by_name();
        [DllImport(_libavcodec)] public static extern void av_bsf_get_class();
        [DllImport(_libavcodec)] public static extern void av_bsf_get_null_filter();
        [DllImport(_libavcodec)] public static extern void av_bsf_init();
        [DllImport(_libavcodec)] public static extern void av_bsf_iterate();
        [DllImport(_libavcodec)] public static extern void av_bsf_list_alloc();
        [DllImport(_libavcodec)] public static extern void av_bsf_list_append();
        [DllImport(_libavcodec)] public static extern void av_bsf_list_append2();
        [DllImport(_libavcodec)] public static extern void av_bsf_list_finalize();
        [DllImport(_libavcodec)] public static extern void av_bsf_list_free();
        [DllImport(_libavcodec)] public static extern void av_bsf_list_parse_str();
        [DllImport(_libavcodec)] public static extern void av_bsf_receive_packet();
        [DllImport(_libavcodec)] public static extern void av_bsf_send_packet();

        [DllImport(_libavcodec)] public static extern void av_codec_ffversion();
        [DllImport(_libavcodec)] public static extern int av_codec_is_decoder(IntPtr AVCodec);
        [DllImport(_libavcodec)] public static extern int av_codec_is_encoder(IntPtr AVCodec);
        [DllImport(_libavcodec)] public static extern IntPtr av_codec_iterate(ref int opaque);
        [DllImport(_libavcodec)] public static extern void av_cpb_properties_alloc();
        [DllImport(_libavcodec)] public static extern void av_d3d11va_alloc_context();
        [DllImport(_libavcodec)] public static extern void av_dct_calc();
        [DllImport(_libavcodec)] public static extern void av_dct_end();
        [DllImport(_libavcodec)] public static extern void av_dct_init();
        [DllImport(_libavcodec)] public static extern void av_dirac_parse_sequence_header();
        [DllImport(_libavcodec)] public static extern void av_dv_codec_profile();
        [DllImport(_libavcodec)] public static extern void av_dv_codec_profile2();
        [DllImport(_libavcodec)] public static extern void av_dv_frame_profile();
        [DllImport(_libavcodec)] public static extern void av_fast_padded_malloc();
        [DllImport(_libavcodec)] public static extern void av_fast_padded_mallocz();
        [DllImport(_libavcodec)] public static extern void av_fft_calc();
        [DllImport(_libavcodec)] public static extern void av_fft_end();
        [DllImport(_libavcodec)] public static extern void av_fft_init(); 
        [DllImport(_libavcodec)] public static extern void av_fft_permute();
        [DllImport(_libavcodec)] public static extern void av_get_audio_frame_duration();
        [DllImport(_libavcodec)] public static extern void av_get_audio_frame_duration2();
        [DllImport(_libavcodec)] public static extern void av_get_bits_per_sample();
        [DllImport(_libavcodec)] public static extern void av_get_exact_bits_per_sample();
        [DllImport(_libavcodec)] public static extern void av_get_pcm_codec();
        [DllImport(_libavcodec)] public static extern string av_get_profile_name(IntPtr AVCodec,int profile);

        [DllImport(_libavcodec)] public static extern void av_imdct_calc();
        [DllImport(_libavcodec)] public static extern void av_imdct_half();
        [DllImport(_libavcodec)] public static extern void av_init_packet();
        [DllImport(_libavcodec)] public static extern void av_jni_get_java_vm();
        [DllImport(_libavcodec)] public static extern void av_jni_set_java_vm();

        [DllImport(_libavcodec)] public static extern void av_mdct_calc();
        [DllImport(_libavcodec)] public static extern void av_mdct_end();
        [DllImport(_libavcodec)] public static extern void av_mdct_init();

        [DllImport(_libavcodec)] public static extern void av_mediacodec_alloc_context();
        [DllImport(_libavcodec)] public static extern void av_mediacodec_default_free();
        [DllImport(_libavcodec)] public static extern void av_mediacodec_default_init();
        [DllImport(_libavcodec)] public static extern void av_mediacodec_release_buffer();
        [DllImport(_libavcodec)] public static extern void av_mediacodec_render_buffer_at_time();
        
        [DllImport(_libavcodec)] public static extern int av_grow_packet(IntPtr AVPacket, int grow_by);
        [DllImport(_libavcodec)] public static extern void av_shrink_packet(IntPtr AVPacket, int size);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVPacket">AVPacket*</param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavcodec)] public static extern int av_new_packet(IntPtr AVPacket,int size);
        [DllImport(_libavcodec)] public static extern void av_packet_add_side_data();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AVPacket *</returns>
        [DllImport(_libavcodec)] public static extern IntPtr av_packet_alloc();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVPacket">AVPacket**</param>
        [DllImport(_libavcodec)] public static extern void av_packet_free(ref IntPtr AVPacket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVPacket">AVPacket*</param>
        /// <returns>AVPacket*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr av_packet_clone(IntPtr AVPacket);
        [DllImport(_libavcodec)] public static extern int av_packet_copy_props(IntPtr dest,IntPtr src);


        [DllImport(_libavcodec)] public static extern int av_packet_from_data(IntPtr pkt, [MarshalAs(UnmanagedType.LPArray)]byte[] data,int size);

        [DllImport(_libavcodec)] public static extern int av_packet_make_refcounted(IntPtr AVPacket);
        [DllImport(_libavcodec)] public static extern int av_packet_make_writable(IntPtr AVPacket);
        
   
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest">AVPacket*</param>
        /// <param name="src">AVPacket*</param>
        /// <returns></returns>
        [DllImport(_libavcodec)] public static extern int av_packet_ref(IntPtr dest,IntPtr src);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVPacket">AVPacket*</param>
        [DllImport(_libavcodec)] public static extern void av_packet_unref(IntPtr AVPacket);
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest">AVPacket*</param>
        /// <param name="src">AVPacket*</param>
        [DllImport(_libavcodec)] public static extern void av_packet_move_ref(IntPtr dest, IntPtr src);

        /// <summary>
        /// <code>  Convert valid timing fields (timestamps / durations) in a packet from one timebase to another</code>
        /// <code>Timestamps with unknown values (AV_NOPTS_VALUE) will be ignored</code>
        /// </summary>
        /// <param name="packet">packet on which the conversion will be performed</param>
        /// <param name="tb_src">source timebase, in which the timing fields in pkt are expressed</param>
        /// <param name="tb_dst">destination timebase, to which the timing fields will be converted</param>
        [DllImport(_libavcodec)] public static extern void av_packet_rescale_ts(IntPtr packet,AVRational tb_src,AVRational tb_dst);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVPacket">AVPacket *</param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <returns>byte*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr av_packet_new_side_data(IntPtr AVPacket,AVPacketSideDataType type,long size);
        [DllImport(_libavcodec)] public static extern int av_packet_shrink_side_data(IntPtr AVPacket, AVPacketSideDataType type, long size);
        [DllImport(_libavcodec)] public static extern void av_packet_free_side_data(IntPtr AVPacket);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVPacket">AVPacket *</param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <returns>byte*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr av_packet_get_side_data(IntPtr AVPacket, AVPacketSideDataType type, long size);

        [DllImport(_libavcodec)] public static extern void av_packet_pack_dictionary();
        [DllImport(_libavcodec)] public static extern void av_packet_unpack_dictionary();
        [DllImport(_libavcodec)] public static extern void av_packet_side_data_new();
        [DllImport(_libavcodec)] public static extern void av_packet_side_data_free();
        [DllImport(_libavcodec)] public static extern void av_packet_side_data_get();
        [DllImport(_libavcodec)] public static extern void av_packet_side_data_name();
        [DllImport(_libavcodec)] public static extern void av_packet_side_data_remove();
        [DllImport(_libavcodec)] public static extern void av_packet_side_data_add();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">AVCodecParserContext *s</param>
        [DllImport(_libavcodec)] public static extern void av_parser_close(IntPtr AVCodecParserContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codec_id"></param>
        /// <returns>AVCodecParserContext *</returns>
        [DllImport(_libavcodec)] public static extern IntPtr av_parser_init(AVCodecID codec_id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opaque">void **</param>
        /// <returns>AVCodecParser *</returns>
        [DllImport(_libavcodec)] public static extern IntPtr av_parser_iterate(ref int opaque);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVCodecParserContext">AVCodecParserContext*</param>
        /// <param name="AVCodecContext">AVCodecContext*</param>
        /// <param name="poutbuf">byte*</param>
        /// <param name="poutbuf_size"></param>
        /// <param name="buf">byte*</param>
        /// <param name="buf_size"></param>
        /// <param name="pts"></param>
        /// <param name="dts"></param>
        /// <param name="pos"></param>
        [DllImport(_libavcodec)]
        public static extern void av_parser_parse2(
                     IntPtr AVCodecParserContext, IntPtr AVCodecContext,
                     IntPtr[] poutbuf, int[] poutbuf_size,
                     IntPtr buf, int buf_size,
                     long pts,
                     long dts,
                     long pos);

        [DllImport(_libavcodec)] public static extern void av_qsv_alloc_context();
        [DllImport(_libavcodec)] public static extern void av_rdft_calc();
        [DllImport(_libavcodec)] public static extern void av_rdft_end();
        [DllImport(_libavcodec)] public static extern void av_rdft_init();

        [DllImport(_libavcodec)] public static extern void av_vorbis_parse_frame();
        [DllImport(_libavcodec)] public static extern void av_vorbis_parse_frame_flags();
        [DllImport(_libavcodec)] public static extern void av_vorbis_parse_free();
        [DllImport(_libavcodec)] public static extern void av_vorbis_parse_init();
        [DllImport(_libavcodec)] public static extern void av_vorbis_parse_reset();
        [DllImport(_libavcodec)] public static extern void av_xiphlacing();

        [DllImport(_libavcodec)] public static extern void avcodec_align_dimensions();
        [DllImport(_libavcodec)] public static extern void avcodec_align_dimensions2();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVCodec"></param>
        /// <returns>AVCodecContext*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_alloc_context3(IntPtr AVCodec);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVCodecContext">AVCodecContext*</param>
        /// <returns></returns>
        [Obsolete("Opening and closing a codec context multiple times is not supported anymore -- use multiple codec contexts instead")]
        [DllImport(_libavcodec)] public static extern int avcodec_close(IntPtr AVCodecContext);
     
        [DllImport(_libavcodec)] public static extern void avcodec_dct_alloc();
        [DllImport(_libavcodec)] public static extern void avcodec_dct_get_class();
        [DllImport(_libavcodec)] public static extern void avcodec_dct_init();

        [DllImport(_libavcodec)] public static extern void avcodec_default_execute();
        [DllImport(_libavcodec)] public static extern void avcodec_default_execute2();
        [DllImport(_libavcodec)] public static extern void avcodec_default_get_buffer2();
        [DllImport(_libavcodec)] public static extern void avcodec_default_get_encode_buffer();
        [DllImport(_libavcodec)] public static extern void avcodec_default_get_format();
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codecID"></param>
        /// <returns>AVCodecDescriptor*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_descriptor_get(AVCodecID codecID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>AVCodecDescriptor*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_descriptor_get_by_name([MarshalAs(UnmanagedType.LPStr)]string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prev">AVCodecDescriptor*</param>
        /// <returns>AVCodecDescriptor*</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_descriptor_next(IntPtr prev);


        /// <summary>
        /// If no subtitle could be decompressed, got_sub_ptr is zero.Otherwise, the subtitle is stored in *sub.
        /// </summary>
        /// <param name="AVCodecContext"></param>
        /// <param name="AVSubtitle"></param>
        /// <param name="got_sub_ptr">Zero if no subtitle could be decompressed, otherwise, it is nonzero</param>
        /// <param name="AVPacket">The input AVPacket containing the input buffer</param>
        /// <returns>Return a negative value on error, otherwise return the number of bytes used</returns>
        [DllImport(_libavcodec)] public static extern int avcodec_decode_subtitle2(IntPtr AVCodecContext,[Out]IntPtr AVSubtitle, ref int got_sub_ptr,IntPtr AVPacket);
        [DllImport(_libavcodec)] public static extern int avcodec_encode_subtitle(IntPtr AVCodecContext,IntPtr buf,int buf_size,IntPtr AVSubtitle);
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_get_subtitle_rect_class();
        [DllImport(_libavcodec)] public static extern void avsubtitle_free(IntPtr AVSubtitle);

        [DllImport(_libavcodec)] public static extern void avcodec_fill_audio_frame();
        [DllImport(_libavcodec)] public static extern void avcodec_find_best_pix_fmt_of_list();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AVCodec *</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_find_decoder(AVCodecID id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>AVCodec *</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_find_decoder_by_name([MarshalAs(UnmanagedType.LPStr)]string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AVCodec *</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_find_encoder(AVCodecID id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">AVCodec *</param>
        /// <returns></returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_find_encoder_by_name([MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(_libavcodec)] public static extern void avcodec_flush_buffers(IntPtr AVCodecContext);
        [DllImport(_libavcodec)] public static extern void avcodec_free_context(ref IntPtr AVCodecContext);

        [DllImport(_libavcodec)] public static extern void avcodec_get_hw_config();
        [DllImport(_libavcodec)] public static extern void avcodec_get_hw_frames_parameters();
        [DllImport(_libavcodec)] public static extern string avcodec_get_name(AVCodecID codec_id);

        [DllImport(_libavcodec)] public static extern AVMediaType avcodec_get_type(AVCodecID codec_id);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVCodecContext"></param>
        /// <returns>return a positive value if AVCodecContext is open, 0 otherwise</returns>
        [DllImport(_libavcodec)] public static extern int avcodec_is_open(IntPtr AVCodecContext);
  

        [DllImport(_libavcodec)] public static extern int avcodec_open2(IntPtr AVCodecContext,IntPtr codec,ref IntPtr AVDictionary);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>AVCodecParameters</returns>
        [DllImport(_libavcodec)] public static extern IntPtr avcodec_parameters_alloc();
        [DllImport(_libavcodec)] public static extern int avcodec_parameters_copy(IntPtr dest,IntPtr src);
        [DllImport(_libavcodec)] public static extern void avcodec_parameters_free(IntPtr* AVCodecParameters);
        [DllImport(_libavcodec)] public static extern int avcodec_parameters_from_context(IntPtr param,IntPtr AVCodecContext);
        [DllImport(_libavcodec)] public static extern int avcodec_parameters_to_context(IntPtr AVCodecContext,IntPtr AVCodecParameters );

        [DllImport(_libavcodec)] public static extern void avcodec_pix_fmt_to_codec_tag();

        [DllImport(_libavcodec)] public static extern IntPtr avcodec_profile_name(AVCodecID codec_id,AVProfileID profile);

        [DllImport(_libavcodec)] public static extern int avcodec_receive_frame(IntPtr AVCodecContext, IntPtr AVFrame);
        [DllImport(_libavcodec)] public static extern int avcodec_receive_packet(IntPtr AVCodecContext, IntPtr AVPacket);
        [DllImport(_libavcodec)] public static extern int avcodec_send_frame(IntPtr AVCodecContext,IntPtr AVFrame);
        [DllImport(_libavcodec)] public static extern int avcodec_send_packet(IntPtr AVCodecContext,IntPtr AVPacket);

        [DllImport(_libavcodec)] public static extern void avcodec_string(IntPtr buf,int buf_size,IntPtr AVCodecContext,int encode);

        [DllImport(_libavcodec)] public static extern void avpriv_ac3_parse_header();
        [DllImport(_libavcodec)] public static extern void avpriv_adts_header_parse();
        [DllImport(_libavcodec)] public static extern void avpriv_codec_get_cap_skip_frame_fill_param();
        [DllImport(_libavcodec)] public static extern void avpriv_dca_convert_bitstream();
        [DllImport(_libavcodec)] public static extern void avpriv_dca_parse_core_frame_header();
        [DllImport(_libavcodec)] public static extern void avpriv_elbg_do();
        [DllImport(_libavcodec)] public static extern void avpriv_elbg_free();
        [DllImport(_libavcodec)] public static extern void avpriv_exif_decode_ifd();
        [DllImport(_libavcodec)] public static extern void avpriv_find_start_code();
        [DllImport(_libavcodec)] public static extern void avpriv_fits_header_init();
        [DllImport(_libavcodec)] public static extern void avpriv_fits_header_parse_line();
        [DllImport(_libavcodec)] public static extern void avpriv_get_raw_pix_fmt_tags();
        [DllImport(_libavcodec)] public static extern void avpriv_h264_has_num_reorder_frames();
        [DllImport(_libavcodec)] public static extern void avpriv_mpeg4audio_get_config2();
        [DllImport(_libavcodec)] public static extern void avpriv_mpegaudio_decode_header();
        [DllImport(_libavcodec)] public static extern void avpriv_packet_list_free();
        [DllImport(_libavcodec)] public static extern void avpriv_packet_list_get();
        [DllImport(_libavcodec)] public static extern void avpriv_packet_list_put();
        [DllImport(_libavcodec)] public static extern void avpriv_pix_fmt_find();
        [DllImport(_libavcodec)] public static extern void avpriv_split_xiph_headers();
        [DllImport(_libavcodec)] public static extern void avpriv_tak_parse_streaminfo();

    }
}