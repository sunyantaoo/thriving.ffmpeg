using System;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{

    public unsafe partial class Core
    {
        private const string _libavformat = "avformat-61.dll";

        [DllImport(_libavformat)] public static extern int  av_add_index_entry(IntPtr AVStream,long pos,long timestamp,int size,int distance,int flags);
        [DllImport(_libavformat)] public static extern void av_append_packet();
        [DllImport(_libavformat)] public static extern void av_codec_get_id();
        [DllImport(_libavformat)] public static extern void av_codec_get_tag();
        [DllImport(_libavformat)] public static extern void av_codec_get_tag2();
     
        [DllImport(_libavformat)] public static extern void av_disposition_from_string();
        [DllImport(_libavformat)] public static extern void av_disposition_to_string();
        /// <summary>
        /// 批量打印格式信息
        /// </summary>
        /// <param name="AVFormatContext"></param>
        /// <param name="index"></param>
        /// <param name="url"></param>
        /// <param name="is_output"></param>
        [DllImport(_libavformat)] public static extern void av_dump_format(IntPtr AVFormatContext, int index,[MarshalAs(UnmanagedType.LPStr)]string url,int is_output);
        [DllImport(_libavformat)] public static extern void av_filename_number_test();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFormatContext"></param>
        /// <param name="type"></param>
        /// <param name="wanted_stream_nb"></param>
        /// <param name="related_stream"></param>
        /// <param name="AVCodec"></param>
        /// <param name="flags">none are currently defined</param>
        /// <returns>成功则返回流索引，失败则返回error code</returns>
        [DllImport(_libavformat)] public static extern int av_find_best_stream(IntPtr AVFormatContext, AVMediaType type, int wanted_stream_nb, int related_stream,ref IntPtr AVCodec, int flags);
       
        [DllImport(_libavformat)] public static extern int av_find_default_stream_index(IntPtr AVFormatContext);

        [DllImport(_libavformat)] public static extern IntPtr av_find_input_format([MarshalAs(UnmanagedType.LPStr)]string short_name);

        [DllImport(_libavformat)] public static extern IntPtr av_find_program_from_stream(IntPtr AVFormatContext,IntPtr AVProgram,int s);

        [DllImport(_libavformat)] public static extern void av_fmt_ctx_get_duration_estimation_method();
        [DllImport(_libavformat)] public static extern void av_format_ffversion();
        [DllImport(_libavformat)] public static extern void av_format_inject_global_side_data();
        [DllImport(_libavformat)] public static extern void av_get_frame_filename();
        [DllImport(_libavformat)] public static extern void av_get_frame_filename2();
        [DllImport(_libavformat)] public static extern void av_get_output_timestamp();
        [DllImport(_libavformat)] public static extern int av_get_packet(IntPtr AVIOContext,IntPtr AVPacket,int size);
        [DllImport(_libavformat)] public static extern int av_guess_codec(IntPtr AVOutputFormat, [MarshalAs(UnmanagedType.LPStr)] string short_name, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string mime_type,AVMediaType type);
        [DllImport(_libavformat)] public static extern IntPtr av_guess_format([MarshalAs(UnmanagedType.LPStr)]string short_name, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string mime_type);
        [DllImport(_libavformat)] public static extern AVRational av_guess_frame_rate(IntPtr AVFormatContext,IntPtr AVStream,IntPtr AVFrame);
        [DllImport(_libavformat)] public static extern AVRational av_guess_sample_aspect_ratio(IntPtr AVFormatContext,IntPtr AVStream,IntPtr AAVFrame);
        [DllImport(_libavformat)] public static extern void av_hex_dump();
        [DllImport(_libavformat)] public static extern void av_hex_dump_log();
        [DllImport(_libavformat)] public static extern void av_index_search_timestamp();
        [DllImport(_libavformat)] public static extern int av_interleaved_write_frame(IntPtr AVFormatContex, IntPtr AVPacket);
        [DllImport(_libavformat)] public static extern int av_interleaved_write_uncoded_frame(IntPtr AVFormatContex,int stream_index, IntPtr AVPacket);
        [DllImport(_libavformat)] public static extern void av_match_ext();

        [DllImport(_libavformat)] public static extern IntPtr av_demuxer_iterate(ref IntPtr opaque);
        [DllImport(_libavformat)] public static extern IntPtr av_muxer_iterate(ref IntPtr opaque);

        [DllImport(_libavformat)] public static extern IntPtr av_new_program(IntPtr AVFormatContext,int id);
        [DllImport(_libavformat)] public static extern void av_pkt_dump2();
        [DllImport(_libavformat)] public static extern void av_pkt_dump_log2();
        
        [DllImport(_libavformat)] public static extern void av_probe_input_buffer();
        [DllImport(_libavformat)] public static extern void av_probe_input_buffer2();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVProbeData">AVProbeData *</param>
        /// <param name="is_opened"></param>
        /// <returns>AVInputFormat *</returns>
        [DllImport(_libavformat)] public static extern IntPtr av_probe_input_format(IntPtr AVProbeData, int is_opened);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVProbeData">AVProbeData *</param>
        /// <param name="is_opened"></param>
        /// <param name="score_max"></param>
        /// <returns>AVInputFormat *</returns>
        [DllImport(_libavformat)] public static extern IntPtr av_probe_input_format2(IntPtr AVProbeData, int is_opened, int[] score_max);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVProbeData">AVProbeData *</param>
        /// <param name="is_opened"></param>
        /// <param name="score_ret"></param>
        /// <returns>AVInputFormat *</returns>
        [DllImport(_libavformat)] public static extern IntPtr av_probe_input_format3(IntPtr AVProbeData, int is_opened, int[] score_ret);
        
        [DllImport(_libavformat)] public static extern void av_program_add_stream_index(IntPtr AVFormatContext,int progId,uint idx);
        [DllImport(_libavformat)] public static extern int av_read_frame(IntPtr AVFormatContext,IntPtr AVPacket);
        [DllImport(_libavformat)] public static extern int  av_read_pause(IntPtr AVFormatContext);
        [DllImport(_libavformat)] public static extern int av_read_play(IntPtr AVFormatContext);
        [DllImport(_libavformat)] public static extern void av_sdp_create();
        [DllImport(_libavformat)] public static extern int av_seek_frame(IntPtr AVFormatContex,int stream_index,DateTime timestamp,int flags);
        [DllImport(_libavformat)] public static extern void av_stream_add_side_data();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AVClass*</returns>
        [DllImport(_libavformat)] public static extern IntPtr av_stream_get_class();
        [DllImport(_libavformat)] public static extern void av_stream_get_codec_timebase();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVStream">AVCodecParserContext*</param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern IntPtr av_stream_get_parser(IntPtr AVStream);
        [DllImport(_libavformat)] public static extern void av_stream_get_side_data();
        [DllImport(_libavformat)] public static extern void av_stream_group_get_class();
        [DllImport(_libavformat)] public static extern void av_stream_new_side_data();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proto">the buffer for the protocol</param>
        /// <param name="proto_size">the size of the protocol buffer</param>
        /// <param name="authorization">the buffer for the authorization</param>
        /// <param name="authorization_size">the size of the authorization buffer</param>
        /// <param name="hostname">the buffer for the host name</param>
        /// <param name="hostname_size">the size of the hostname buffer</param>
        /// <param name="port_ptr">a pointer to store the port number in</param>
        /// <param name="path">the buffer for the path</param>
        /// <param name="path_size">the size of the path buffer</param>
        /// <param name="url"> the URL to split</param>
        [DllImport(_libavformat)]
        public static extern void av_url_split(IntPtr proto, int proto_size,
            IntPtr authorization, int authorization_size,
            IntPtr hostname, int hostname_size,
            int[] port_ptr,
            IntPtr path, int path_size, string url);

        [DllImport(_libavformat)] public static extern int av_write_frame(IntPtr AVFormatContex,IntPtr AVPacket);
        [DllImport(_libavformat)] public static extern int av_write_trailer(IntPtr AVFormatContex);
        [DllImport(_libavformat)] public static extern int av_write_uncoded_frame(IntPtr AVFormatContex,int stream_index,IntPtr AVFrame);
        [DllImport(_libavformat)] public static extern int av_write_uncoded_frame_query(IntPtr AVFormatContex, int stream_index);
        [DllImport(_libavformat)] public static extern IntPtr avformat_alloc_context();
        [DllImport(_libavformat)] public static extern int avformat_alloc_output_context2(ref IntPtr AVFormatContext,IntPtr AVOutputFormat,
            [MarshalAs(UnmanagedType.LPStr)]string format_name, 
            [MarshalAs(UnmanagedType.LPStr)] string filename);
        
        [return:MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavformat)] public static extern string avformat_configuration();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavformat)] public static extern string avformat_license();
        [DllImport(_libavformat)] public static extern uint avformat_version();

        [DllImport(_libavformat)] public static extern int avformat_find_stream_info(IntPtr AVFormatContext,ref IntPtr AVDictionary);
        
        /// <summary>
        /// Discard all internally buffered data
        /// </summary>
        /// <param name="AVFormatContext"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avformat_flush(IntPtr AVFormatContext);
        [DllImport(_libavformat)] public static extern void avformat_free_context(IntPtr AVFormatContext);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AVClass*</returns>
        [DllImport(_libavformat)] public static extern IntPtr avformat_get_class();

        [DllImport(_libavformat)] public static extern void avformat_get_mov_audio_tags();
        [DllImport(_libavformat)] public static extern void avformat_get_mov_video_tags();
        [DllImport(_libavformat)] public static extern void avformat_get_riff_audio_tags();
        [DllImport(_libavformat)] public static extern void avformat_get_riff_video_tags();
        [DllImport(_libavformat)] public static extern int avformat_index_get_entries_count(IntPtr AVStream);
        [DllImport(_libavformat)] public static extern IntPtr avformat_index_get_entry(IntPtr AVStream,int idx);
        [DllImport(_libavformat)] public static extern IntPtr avformat_index_get_entry_from_timestamp(IntPtr AVStream, long wanted_timestamp, int flags);

        [DllImport(_libavformat)] public static extern int avformat_init_output(IntPtr AVFormatContext,ref IntPtr AVDictionary);


        [DllImport(_libavformat)] public static extern int avformat_match_stream_specifier(IntPtr AVFormatContext,IntPtr AVStream,[MarshalAs(UnmanagedType.LPStr)]string spec);
        
        [DllImport(_libavformat)] public static extern int avformat_network_deinit();
        /// <summary>
        /// Do global initialization of network libraries. This is optional and not recommended anymore.
        /// </summary>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avformat_network_init();

        [DllImport(_libavformat)] public static extern IntPtr avformat_new_stream(IntPtr AVFormatContext, IntPtr AVCodec);

        [DllImport(_libavformat)] public static extern int avformat_open_input(ref IntPtr AVFormatContext, [MarshalAs(UnmanagedType.LPStr)] string url, IntPtr AVInputFormat,ref IntPtr AVDictionary);
        
        [DllImport(_libavformat)] public static extern void avformat_close_input(ref IntPtr AVFormatContext);

        [DllImport(_libavformat)] public static extern int avformat_query_codec(IntPtr AVOutputFormat,AVCodecID codec_id, AVCompliance std_compliance);
        [DllImport(_libavformat)] public static extern int avformat_queue_attached_pictures(IntPtr AVOutputFormat);
        [DllImport(_libavformat)] public static extern int avformat_seek_file(IntPtr AVFormatContext,int stream_index,DateTime min_ts, DateTime ts, DateTime max_ts,int flags);
        [DllImport(_libavformat)] public static extern int avformat_stream_group_add_stream(IntPtr AVStreamGroup,IntPtr AVStream);
        [DllImport(_libavformat)] public static extern IntPtr avformat_stream_group_create(IntPtr AVFormatContext,AVStreamGroupParamsType type ,ref IntPtr AVDictionary);
        [DllImport(_libavformat)] public static extern IntPtr avformat_stream_group_name(AVStreamGroupParamsType type);
        [DllImport(_libavformat)] public static extern void avformat_transfer_internal_stream_timing_info();
      
        [DllImport(_libavformat)] public static extern int avformat_write_header(IntPtr AVFormatContext,ref IntPtr AVDictionary);


        /// <summary>
        /// Accept and allocate a client context on a server context
        /// </summary>
        /// <param name="server">the server context</param>
        /// <param name="client">the client context, must be unallocated</param>
        /// <returns> >= 0 on success or a negative value corresponding  to an AVERROR on failure</returns>
        [DllImport(_libavformat)] public static extern int avio_accept(IntPtr server, ref IntPtr client);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AVIOContext*</returns>
        [DllImport(_libavformat)] public static extern IntPtr avio_alloc_context(IntPtr buffer,int buffer_size,int write_flag,IntPtr opaque,ReadPacket? readPacket,WritePacket? writePacket,SeekPacket? seekPacket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext**</param>
        [DllImport(_libavformat)] public static extern void avio_context_free(ref IntPtr AVIOContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern AVIOFlags avio_check([MarshalAs(UnmanagedType.LPStr)]string url,AVIOFlags flags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext**</param>
        /// <param name="url"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_open(ref IntPtr AVIOContext,string url,AVIOFlags flags);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext**</param>
        /// <param name="url"></param>
        /// <param name="flags"></param>
        /// <param name="AVIOInterruptCB">AVIOInterruptCB*</param> 
        /// <param name="AVDictionary">AVDictionary**</param>
        [DllImport(_libavformat)] public static extern int avio_open2(ref IntPtr AVIOContext,[MarshalAs(UnmanagedType.LPStr)] string url, AVIOFlags flags,IntPtr AVIOInterruptCB,ref IntPtr AVDictionary);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIODirContext**</param>
        /// <param name="url"></param>
        /// <param name="AVDictionary">AVDictionary**</param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_open_dir(ref IntPtr AVIODirContext, [MarshalAs(UnmanagedType.LPStr)]string url,ref IntPtr AVDictionary);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext**</param>
        [DllImport(_libavformat)] public static extern int avio_open_dyn_buf(ref IntPtr AVIOContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        [DllImport(_libavformat)] public static extern int avio_close(IntPtr AVIOContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIODirContext">AVIODirContext**</param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_close_dir(ref IntPtr AVIODirContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        /// <param name="pbuffer">byte**</param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_close_dyn_buf(IntPtr AVIOContext,IntPtr pbuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext**</param>
        [DllImport(_libavformat)] public static extern int avio_closep(ref IntPtr AVIOContext);

        [DllImport(_libavformat)] public static extern IntPtr avio_enum_protocols(ref IntPtr opaque,int output);

        [DllImport(_libavformat)] public static extern void avio_feof();

        [DllImport(_libavformat)] public static extern IntPtr avio_find_protocol_name([MarshalAs(UnmanagedType.LPStr)]string url);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        [DllImport(_libavformat)] public static extern void avio_flush(IntPtr AVIOContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIODirEntry">AVIODirEntry**</param>
        [DllImport(_libavformat)] public static extern void avio_free_directory_entry(ref IntPtr AVIODirEntry);

        [DllImport(_libavformat)] public static extern void avio_get_dyn_buf();
        [DllImport(_libavformat)] public static extern int avio_get_str(IntPtr AVIOContext,int maxlen,IntPtr buf,int buflen);
        [DllImport(_libavformat)] public static extern void avio_get_str16be();
        [DllImport(_libavformat)] public static extern void avio_get_str16le();

        /// <summary>
        /// Perform one step of the protocol handshake to accept a new client
        /// </summary>
        /// <param name="AVIOContext"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_handshake(IntPtr AVIOContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        /// <param name="pause">pause 1 for pause, 0 for resume</param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_pause(IntPtr AVIOContext, int pause);
        [DllImport(_libavformat)] public static extern void avio_print_string_array();
        [DllImport(_libavformat)] public static extern void avio_printf();
        [DllImport(_libavformat)] public static extern void avio_vprintf();

        [DllImport(_libavformat)] public static extern IntPtr avio_protocol_get_class([MarshalAs(UnmanagedType.LPStr)]string name);

        [DllImport(_libavformat)] public static extern int avio_put_str(IntPtr AVIOContext,[MarshalAs(UnmanagedType.LPStr)]string str);
        [DllImport(_libavformat)] public static extern int avio_put_str16be(IntPtr AVIOContext, [MarshalAs(UnmanagedType.LPStr)] string str);
        [DllImport(_libavformat)] public static extern int avio_put_str16le(IntPtr AVIOContext, [MarshalAs(UnmanagedType.LPStr)] string str);
    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        /// <param name="buf">byte*</param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_read(IntPtr AVIOContext,IntPtr buf,int size);

        [DllImport(_libavformat)] public static extern int avio_read_dir(IntPtr AVIODirContext,ref IntPtr AVIODirEntry);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        /// <param name="buf">byte*</param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_read_partial(IntPtr AVIOContext, IntPtr buf, int size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVIOContext">AVIOContext*</param>
        /// <param name="pb">AVBPrint*</param>
        /// <param name="max_size"></param>
        /// <returns></returns>
        [DllImport(_libavformat)] public static extern int avio_read_to_bprint(IntPtr AVIOContext,IntPtr pb,long max_size);

        [DllImport(_libavformat)] public static extern int avio_r8(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern uint avio_rb16(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern uint avio_rb24(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern uint avio_rb32(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern long avio_rb64(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern uint avio_rl16(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern uint avio_rl24(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern uint avio_rl32(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern long avio_rl64(IntPtr AVIOContext);

        [DllImport(_libavformat)] public static extern long avio_seek(IntPtr AVIOContext,long offset,int whence);
        [DllImport(_libavformat)] public static extern long avio_seek_time(IntPtr AVIOContext, int stream_index, long timestamp, int flags);
        [DllImport(_libavformat)] public static extern long avio_size(IntPtr AVIOContext);
        [DllImport(_libavformat)] public static extern long avio_skip(IntPtr AVIOContext,long offset);
    

        [DllImport(_libavformat)] public static extern void avio_w8(IntPtr AVIOContext,int b);
        [DllImport(_libavformat)] public static extern void avio_wb16(IntPtr AVIOContext, uint val);
        [DllImport(_libavformat)] public static extern void avio_wb24(IntPtr AVIOContext, uint val);
        [DllImport(_libavformat)] public static extern void avio_wb32(IntPtr AVIOContext, uint val);
        [DllImport(_libavformat)] public static extern void avio_wb64(IntPtr AVIOContext,long val);
        [DllImport(_libavformat)] public static extern void avio_wl16(IntPtr AVIOContext, uint val);
        [DllImport(_libavformat)] public static extern void avio_wl24(IntPtr AVIOContext, uint val);
        [DllImport(_libavformat)] public static extern void avio_wl32(IntPtr AVIOContext,uint val);
        [DllImport(_libavformat)] public static extern void avio_wl64(IntPtr AVIOContext,long val);
        [DllImport(_libavformat)] public static extern void avio_write(IntPtr AVIOContext,[MarshalAs(UnmanagedType.LPArray)]byte[] buf,int size);
       
        [DllImport(_libavformat)] public static extern int avio_write_marker(IntPtr AVIOContext,long time,AVIODataMarkerType type);

        [DllImport(_libavformat)] public static extern void avpriv_dv_get_packet();
        [DllImport(_libavformat)] public static extern void avpriv_dv_init_demux();
        [DllImport(_libavformat)] public static extern void avpriv_dv_produce_packet();
        [DllImport(_libavformat)] public static extern void avpriv_mpegts_parse_close();
        [DllImport(_libavformat)] public static extern void avpriv_mpegts_parse_open();
        [DllImport(_libavformat)] public static extern void avpriv_mpegts_parse_packet();
        [DllImport(_libavformat)] public static extern void avpriv_new_chapter();
        [DllImport(_libavformat)] public static extern void avpriv_register_devices();
        [DllImport(_libavformat)] public static extern void avpriv_set_pts_info();
        [DllImport(_libavformat)] public static extern void avpriv_stream_set_need_parsing();
        [DllImport(_libavformat)] public static extern void avpriv_update_cur_dts();

        [DllImport(_libavformat)] public static extern void gme_ay_type();
        [DllImport(_libavformat)] public static extern void gme_clear_playlist();
        [DllImport(_libavformat)] public static extern void gme_delete();
        [DllImport(_libavformat)] public static extern void gme_enable_accuracy();
        [DllImport(_libavformat)] public static extern void gme_equalizer();
        [DllImport(_libavformat)] public static extern void gme_free_info();
        [DllImport(_libavformat)] public static extern void gme_gbs_type();
        [DllImport(_libavformat)] public static extern void gme_gym_type();
        [DllImport(_libavformat)] public static extern void gme_hes_type();
        [DllImport(_libavformat)] public static extern void gme_identify_extension();
        [DllImport(_libavformat)] public static extern void gme_identify_file();
        [DllImport(_libavformat)] public static extern void gme_identify_header();
        [DllImport(_libavformat)] public static extern void gme_ignore_silence();
        [DllImport(_libavformat)] public static extern void gme_kss_type();
        [DllImport(_libavformat)] public static extern void gme_load_custom();
        [DllImport(_libavformat)] public static extern void gme_load_data();
        [DllImport(_libavformat)] public static extern void gme_load_file();
        [DllImport(_libavformat)] public static extern void gme_multi_channel();
        [DllImport(_libavformat)] public static extern void gme_mute_voice();
        [DllImport(_libavformat)] public static extern void gme_mute_voices();
        [DllImport(_libavformat)] public static extern void gme_new_emu();
        [DllImport(_libavformat)] public static extern void gme_new_emu_multi_channel();
        [DllImport(_libavformat)] public static extern void gme_nsf_type();
        [DllImport(_libavformat)] public static extern void gme_nsfe_type();
        [DllImport(_libavformat)] public static extern void gme_open_data();
        [DllImport(_libavformat)] public static extern void gme_open_file();
        [DllImport(_libavformat)] public static extern void gme_play();
        [DllImport(_libavformat)] public static extern void gme_sap_type();
        [DllImport(_libavformat)] public static extern void gme_seek();
        [DllImport(_libavformat)] public static extern void gme_seek_samples();
        [DllImport(_libavformat)] public static extern void gme_set_autoload_playback_limit();
        [DllImport(_libavformat)] public static extern void gme_set_equalizer();
        [DllImport(_libavformat)] public static extern void gme_set_fade();
        [DllImport(_libavformat)] public static extern void gme_set_stereo_depth();
        [DllImport(_libavformat)] public static extern void gme_set_tempo();
        [DllImport(_libavformat)] public static extern void gme_set_user_cleanup();
        [DllImport(_libavformat)] public static extern void gme_set_user_data();
        [DllImport(_libavformat)] public static extern void gme_spc_type();
        [DllImport(_libavformat)] public static extern void gme_start_track();
        [DllImport(_libavformat)] public static extern void gme_tell();
        [DllImport(_libavformat)] public static extern void gme_tell_samples();
        [DllImport(_libavformat)] public static extern void gme_track_count();
        [DllImport(_libavformat)] public static extern void gme_track_ended();
        [DllImport(_libavformat)] public static extern void gme_track_info();
        [DllImport(_libavformat)] public static extern void gme_type();
        [DllImport(_libavformat)] public static extern void gme_type_extension();
        [DllImport(_libavformat)] public static extern void gme_type_list();
        [DllImport(_libavformat)] public static extern void gme_type_multitrack();
        [DllImport(_libavformat)] public static extern void gme_type_system();
        [DllImport(_libavformat)] public static extern void gme_user_data();
        [DllImport(_libavformat)] public static extern void gme_vgm_type();
        [DllImport(_libavformat)] public static extern void gme_vgz_type();
        [DllImport(_libavformat)] public static extern void gme_voice_count();
        [DllImport(_libavformat)] public static extern void gme_voice_name();
        [DllImport(_libavformat)] public static extern void gme_warning();
        [DllImport(_libavformat)] public static extern void gme_wrong_file_type();
    }
}