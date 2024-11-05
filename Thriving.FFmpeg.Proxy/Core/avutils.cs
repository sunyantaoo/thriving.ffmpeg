using System.Runtime.InteropServices;
using System.Transactions;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe partial class Core
    {
        private const string _libavutil = "avutil-59.dll";

        [DllImport(_libavutil)] public static extern void av_add_i();
        [DllImport(_libavutil)] public static extern void av_add_q();
        [DllImport(_libavutil)] public static extern void av_add_stable();
        [DllImport(_libavutil)] public static extern void av_adler32_update();
        [DllImport(_libavutil)] public static extern void av_aes_alloc();
        [DllImport(_libavutil)] public static extern void av_aes_crypt();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_alloc();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_crypt();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_free();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_get_iv();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_increment_iv();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_init();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_set_full_iv();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_set_iv();
        [DllImport(_libavutil)] public static extern void av_aes_ctr_set_random_iv();
        [DllImport(_libavutil)] public static extern void av_aes_init();
        [DllImport(_libavutil)] public static extern void av_aes_size();
        [DllImport(_libavutil)] public static extern void av_ambient_viewing_environment_alloc();
        [DllImport(_libavutil)] public static extern void av_ambient_viewing_environment_create_side_data();
        [DllImport(_libavutil)] public static extern void av_append_path_component();
        [DllImport(_libavutil)] public static extern void av_asprintf();
        [DllImport(_libavutil)] public static extern void av_assert0_fpu();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_alloc();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_drain();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_free();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_peek();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_peek_at();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_read();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_realloc();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_reset();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_size();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_space();
        [DllImport(_libavutil)] public static extern void av_audio_fifo_write();
        [DllImport(_libavutil)] public static extern void av_base64_decode();
        [DllImport(_libavutil)] public static extern void av_base64_encode();
        [DllImport(_libavutil)] public static extern void av_basename();
        [DllImport(_libavutil)] public static extern void av_bessel_i0();
        [DllImport(_libavutil)] public static extern void av_blowfish_alloc();
        [DllImport(_libavutil)] public static extern void av_blowfish_crypt();
        [DllImport(_libavutil)] public static extern void av_blowfish_crypt_ecb();
        [DllImport(_libavutil)] public static extern void av_blowfish_init();
        [DllImport(_libavutil)] public static extern void av_bmg_get();
        [DllImport(_libavutil)] public static extern void av_bprint_append_data();
        [DllImport(_libavutil)] public static extern void av_bprint_chars();
        [DllImport(_libavutil)] public static extern void av_bprint_clear();
        [DllImport(_libavutil)] public static extern void av_bprint_escape();
        [DllImport(_libavutil)] public static extern void av_bprint_finalize();
        [DllImport(_libavutil)] public static extern void av_bprint_get_buffer();
        [DllImport(_libavutil)] public static extern void av_bprint_init();
        [DllImport(_libavutil)] public static extern void av_bprint_init_for_buffer();
        [DllImport(_libavutil)] public static extern void av_bprint_strftime();
        [DllImport(_libavutil)] public static extern void av_bprintf();

        [DllImport(_libavutil)] public static extern void av_buffer_alloc();
        [DllImport(_libavutil)] public static extern void av_buffer_allocz();
        [DllImport(_libavutil)] public static extern void av_buffer_create();
        [DllImport(_libavutil)] public static extern void av_buffer_default_free();
        [DllImport(_libavutil)] public static extern void av_buffer_get_opaque();
        [DllImport(_libavutil)] public static extern void av_buffer_get_ref_count();
        [DllImport(_libavutil)] public static extern void av_buffer_is_writable();
        [DllImport(_libavutil)] public static extern void av_buffer_make_writable();
        [DllImport(_libavutil)] public static extern void av_buffer_pool_buffer_get_opaque();
        [DllImport(_libavutil)] public static extern void av_buffer_pool_get();
        [DllImport(_libavutil)] public static extern void av_buffer_pool_init();
        [DllImport(_libavutil)] public static extern void av_buffer_pool_init2();
        [DllImport(_libavutil)] public static extern void av_buffer_pool_uninit();
        [DllImport(_libavutil)] public static extern void av_buffer_realloc();
        [DllImport(_libavutil)] public static extern void av_buffer_ref();
        [DllImport(_libavutil)] public static extern void av_buffer_replace();
        [DllImport(_libavutil)] public static extern void av_buffer_unref();

        [DllImport(_libavutil)] public static extern void av_camellia_alloc();
        [DllImport(_libavutil)] public static extern void av_camellia_crypt();
        [DllImport(_libavutil)] public static extern void av_camellia_init();
        [DllImport(_libavutil)] public static extern void av_camellia_size();

        [DllImport(_libavutil)] public static extern void av_cast5_alloc();
        [DllImport(_libavutil)] public static extern void av_cast5_crypt();
        [DllImport(_libavutil)] public static extern void av_cast5_crypt2();
        [DllImport(_libavutil)] public static extern void av_cast5_init();
        [DllImport(_libavutil)] public static extern void av_cast5_size();

     
        [DllImport(_libavutil)] public static extern AVChannel av_channel_layout_channel_from_index(IntPtr AVChannelLayout,uint idx);
        [DllImport(_libavutil)] public static extern AVChannel av_channel_layout_channel_from_string(IntPtr AVChannelLayout,[MarshalAs(UnmanagedType.LPStr)]string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVChannelLayout">AVChannelLayout*</param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_channel_layout_check(ref AVChannelLayout chlayout);
        [DllImport(_libavutil)] public static extern int av_channel_layout_compare(IntPtr ch1,IntPtr ch2);
        [DllImport(_libavutil)] public static extern int av_channel_layout_copy(IntPtr dest,ref AVChannelLayout src);
        [DllImport(_libavutil)] public static extern int av_channel_layout_custom_init(IntPtr AVChannelLayout,int nb_channels);
        [DllImport(_libavutil)] public static extern void av_channel_layout_default(out AVChannelLayout layout,int nb_channels);
        [DllImport(_libavutil)] public static extern int av_channel_layout_describe(IntPtr AVChannelLayout,[Out][MarshalAs(UnmanagedType.LPStr)]StringBuilder builder,long buf_size);
        [DllImport(_libavutil)] public static extern int av_channel_layout_describe_bprint(IntPtr AVChannelLayout,IntPtr bprint);
        [DllImport(_libavutil)] public static extern int av_channel_layout_from_mask(IntPtr AVChannelLayout,long mask);
        [DllImport(_libavutil)] public static extern int av_channel_layout_from_string(IntPtr AVChannelLayout, [MarshalAs(UnmanagedType.LPStr)] string str );
        [DllImport(_libavutil)] public static extern int av_channel_layout_index_from_channel(IntPtr AVChannelLayout,AVChannel channel);
        [DllImport(_libavutil)] public static extern int av_channel_layout_index_from_string(IntPtr AVChannelLayout, [MarshalAs(UnmanagedType.LPStr)]string name);
        [DllImport(_libavutil)] public static extern int av_channel_layout_retype(IntPtr AVChannelLayout,AVChannelOrder order,int flags);

        [DllImport(_libavutil)] public static extern IntPtr av_channel_layout_standard(ref int opaque);
        [DllImport(_libavutil)] public static extern long av_channel_layout_subset(IntPtr AVChannelLayout,long mask);
        [DllImport(_libavutil)] public static extern void av_channel_layout_uninit(IntPtr AVChannelLayout);
       
        [DllImport(_libavutil)] public static extern int av_channel_description([MarshalAs(UnmanagedType.LPStr)]StringBuilder builder,long size,AVChannel channel);
        [DllImport(_libavutil)] public static extern void av_channel_description_bprint(IntPtr bprint, AVChannel channel);
        [DllImport(_libavutil)] public static extern AVChannel av_channel_from_string([MarshalAs(UnmanagedType.LPStr)]string name);
        [DllImport(_libavutil)] public static extern int av_channel_name([MarshalAs(UnmanagedType.LPStr)] StringBuilder buf,long size,AVChannel channel);
        [DllImport(_libavutil)] public static extern void av_channel_name_bprint(IntPtr bprint, AVChannel channel);

        [DllImport(_libavutil)] public static extern void av_chroma_location_enum_to_pos();
        [DllImport(_libavutil)] public static extern void av_chroma_location_from_name();
        [DllImport(_libavutil)] public static extern void av_chroma_location_name();
        [DllImport(_libavutil)] public static extern void av_chroma_location_pos_to_enum();

        [DllImport(_libavutil)] public static extern void av_cmp_i();
        [DllImport(_libavutil)] public static extern void av_color_primaries_from_name();
        [DllImport(_libavutil)] public static extern void av_color_primaries_name();
        [DllImport(_libavutil)] public static extern void av_color_range_from_name();
        [DllImport(_libavutil)] public static extern void av_color_range_name();
        [DllImport(_libavutil)] public static extern void av_color_space_from_name();
        [DllImport(_libavutil)] public static extern void av_color_space_name();
        [DllImport(_libavutil)] public static extern void av_color_transfer_from_name();
        [DllImport(_libavutil)] public static extern void av_color_transfer_name();

        [DllImport(_libavutil)] public static extern void av_compare_mod();
        [DllImport(_libavutil)] public static extern void av_compare_ts();

        [DllImport(_libavutil)] public static extern void av_content_light_metadata_alloc();
        [DllImport(_libavutil)] public static extern void av_content_light_metadata_create_side_data();
        /// <summary>
        /// cpu核心数
        /// </summary>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_cpu_count();
        [DllImport(_libavutil)] public static extern void av_cpu_force_count(int count);
        [DllImport(_libavutil)] public static extern long av_cpu_max_align();

        [DllImport(_libavutil)] public static extern void av_crc();
        [DllImport(_libavutil)] public static extern void av_crc_get_table();
        [DllImport(_libavutil)] public static extern void av_crc_init();

        [DllImport(_libavutil)] public static extern void av_csp_approximate_trc_gamma();
        [DllImport(_libavutil)] public static extern void av_csp_luma_coeffs_from_avcsp();
        [DllImport(_libavutil)] public static extern void av_csp_primaries_desc_from_id();
        [DllImport(_libavutil)] public static extern void av_csp_primaries_id_from_desc();
        [DllImport(_libavutil)] public static extern void av_csp_trc_func_from_id();

        [DllImport(_libavutil)] public static extern void av_d2q();

        [DllImport(_libavutil)] public static extern void av_default_get_category();
        [DllImport(_libavutil)] public static extern void av_default_item_name();

        [DllImport(_libavutil)] public static extern void av_des_alloc();
        [DllImport(_libavutil)] public static extern void av_des_crypt();
        [DllImport(_libavutil)] public static extern void av_des_init();
        [DllImport(_libavutil)] public static extern void av_des_mac();

        [DllImport(_libavutil)] public static extern void av_detection_bbox_alloc();
        [DllImport(_libavutil)] public static extern void av_detection_bbox_create_side_data();


        [DllImport(_libavutil)] public static extern int av_dict_copy(ref IntPtr dest, IntPtr src, AVDictionaryFlags flags);

        [DllImport(_libavutil)] public static extern int av_dict_count(IntPtr AVDictionary);

        [DllImport(_libavutil)] public static extern void av_dict_free(ref IntPtr AVDictionary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="key"></param>
        /// <param name="prev">AVDictionaryEntry *</param>
        /// <param name="flags"></param>
        /// <returns>AVDictionaryEntry *</returns>
        [DllImport(_libavutil)] public static extern IntPtr av_dict_get(IntPtr m, string  key, IntPtr prev, AVDictionaryFlags flags);
        
        /// <summary>
        /// 获取字典所有内容
        /// </summary>
        /// <param name="AVDictionary"></param>
        /// <param name="buffer"></param>
        /// <param name="key_val_sep">key value 之间分隔符</param>
        /// <param name="pairs_sep"> paris 之间分隔符</param>
        /// <returns>  >= 0 on success, negative on error</returns>
        [DllImport(_libavutil)] public static extern int av_dict_get_string(IntPtr AVDictionary,[Out] IntPtr buffer, char key_val_sep, char pairs_sep);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="AVDictionary"></param>
       /// <param name="prev"></param>
       /// <returns></returns>
        [DllImport(_libavutil)] public static extern IntPtr av_dict_iterate(IntPtr AVDictionary, IntPtr prev);
        [DllImport(_libavutil)] public static extern int av_dict_parse_string(ref IntPtr AVDictionary, char* str, char* key_val_sep, char* pairs_sep, AVDictionaryFlags flags);
        
        [DllImport(_libavutil)] public static extern int av_dict_set(ref IntPtr AVDictionary,[MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value,  AVDictionaryFlags flags);
        [DllImport(_libavutil)] public static extern int av_dict_set_int(ref IntPtr AVDictionary, [MarshalAs(UnmanagedType.LPStr)] string key, long value, AVDictionaryFlags flags);

        [DllImport(_libavutil)] public static extern void av_dirname();

        [DllImport(_libavutil)] public static extern void av_display_matrix_flip();
        [DllImport(_libavutil)] public static extern void av_display_rotation_get();
        [DllImport(_libavutil)] public static extern void av_display_rotation_set();

        [DllImport(_libavutil)] public static extern void av_div_i();
        [DllImport(_libavutil)] public static extern void av_div_q();

        [DllImport(_libavutil)] public static extern void av_dovi_alloc();
        [DllImport(_libavutil)] public static extern void av_dovi_metadata_alloc();
        [DllImport(_libavutil)] public static extern void av_downmix_info_update_side_data();

        [DllImport(_libavutil)] public static extern void av_dynamic_hdr_plus_alloc();
        [DllImport(_libavutil)] public static extern void av_dynamic_hdr_plus_create_side_data();
        [DllImport(_libavutil)] public static extern void av_dynamic_hdr_plus_from_t35();
        [DllImport(_libavutil)] public static extern void av_dynamic_hdr_plus_to_t35();
        [DllImport(_libavutil)] public static extern void av_dynamic_hdr_vivid_alloc();
        [DllImport(_libavutil)] public static extern void av_dynamic_hdr_vivid_create_side_data();

        [DllImport(_libavutil)] public static extern void av_dynarray2_add();
        [DllImport(_libavutil)] public static extern void av_dynarray_add();
        [DllImport(_libavutil)] public static extern void av_dynarray_add_nofree();

        [DllImport(_libavutil)] public static extern void av_encryption_info_add_side_data();
        [DllImport(_libavutil)] public static extern void av_encryption_info_alloc();
        [DllImport(_libavutil)] public static extern void av_encryption_info_clone();
        [DllImport(_libavutil)] public static extern void av_encryption_info_free();
        [DllImport(_libavutil)] public static extern void av_encryption_info_get_side_data();
        [DllImport(_libavutil)] public static extern void av_encryption_init_info_add_side_data();
        [DllImport(_libavutil)] public static extern void av_encryption_init_info_alloc();
        [DllImport(_libavutil)] public static extern void av_encryption_init_info_free();
        [DllImport(_libavutil)] public static extern void av_encryption_init_info_get_side_data();

        [DllImport(_libavutil)] public static extern void av_escape();
        [DllImport(_libavutil)] public static extern void av_executor_alloc();
        [DllImport(_libavutil)] public static extern void av_executor_execute();
        [DllImport(_libavutil)] public static extern void av_executor_free();

        [DllImport(_libavutil)] public static extern void av_expr_count_func();
        [DllImport(_libavutil)] public static extern void av_expr_count_vars();
        [DllImport(_libavutil)] public static extern void av_expr_eval();
        [DllImport(_libavutil)] public static extern void av_expr_free();
        [DllImport(_libavutil)] public static extern void av_expr_parse();
        [DllImport(_libavutil)] public static extern void av_expr_parse_and_eval();

        [DllImport(_libavutil)] public static extern void av_fast_malloc();
        [DllImport(_libavutil)] public static extern void av_fast_mallocz();
        [DllImport(_libavutil)] public static extern void av_fast_realloc();

        [DllImport(_libavutil)] public static extern void av_fifo_alloc2();
        [DllImport(_libavutil)] public static extern void av_fifo_auto_grow_limit();
        [DllImport(_libavutil)] public static extern void av_fifo_can_read();
        [DllImport(_libavutil)] public static extern void av_fifo_can_write();
        [DllImport(_libavutil)] public static extern void av_fifo_drain2();
        [DllImport(_libavutil)] public static extern void av_fifo_elem_size();
        [DllImport(_libavutil)] public static extern void av_fifo_freep2();
        [DllImport(_libavutil)] public static extern void av_fifo_grow2();
        [DllImport(_libavutil)] public static extern void av_fifo_peek();
        [DllImport(_libavutil)] public static extern void av_fifo_peek_to_cb();
        [DllImport(_libavutil)] public static extern void av_fifo_read();
        [DllImport(_libavutil)] public static extern void av_fifo_read_to_cb();
        [DllImport(_libavutil)] public static extern void av_fifo_reset2();
        [DllImport(_libavutil)] public static extern void av_fifo_write();
        [DllImport(_libavutil)] public static extern void av_fifo_write_from_cb();

        [DllImport(_libavutil)] public static extern void av_file_map();
        [DllImport(_libavutil)] public static extern void av_file_unmap();

        [DllImport(_libavutil)] public static extern void av_film_grain_params_alloc();
        [DllImport(_libavutil)] public static extern void av_film_grain_params_create_side_data();
        [DllImport(_libavutil)] public static extern void av_film_grain_params_select();

        [DllImport(_libavutil)] public static extern void av_find_best_pix_fmt_of_2();
        [DllImport(_libavutil)] public static extern void av_find_info_tag();
        [DllImport(_libavutil)] public static extern void av_find_nearest_q_idx();

        [DllImport(_libavutil)] public static extern void av_force_cpu_flags();
        [DllImport(_libavutil)] public static extern void av_fourcc_make_string();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>AVFrame*</returns>
        [DllImport(_libavutil)] public static extern IntPtr av_frame_alloc();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame">AVFrame**</param>
        [DllImport(_libavutil)] public static extern void av_frame_free(ref IntPtr frame);

        [DllImport(_libavutil)] public static extern void av_frame_apply_cropping();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFrame">AVFrame*</param>
        /// <returns>AVFrame*</returns>
        [DllImport(_libavutil)] public static extern IntPtr av_frame_clone(IntPtr AVFrame);
        [DllImport(_libavutil)] public static extern int av_frame_copy(IntPtr dst, IntPtr src);
        [DllImport(_libavutil)] public static extern void av_frame_copy_props();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame">AVFrame*</param>
        /// <param name="align"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_frame_get_buffer(IntPtr  frame, int align);
        [DllImport(_libavutil)] public static extern IntPtr av_frame_get_plane_buffer(IntPtr frame,int plane);
        [DllImport(_libavutil)] public static extern void av_frame_get_side_data();
        [DllImport(_libavutil)] public static extern int av_frame_is_writable(IntPtr frame);
        [DllImport(_libavutil)] public static extern int av_frame_make_writable(IntPtr frame);
     
        [DllImport(_libavutil)] public static extern void av_frame_new_side_data();
        [DllImport(_libavutil)] public static extern void av_frame_new_side_data_from_buf();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dst">AVFrame*</param>
        /// <param name="src">AVFrame*</param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_frame_ref(IntPtr  dst, IntPtr  src);
        [DllImport(_libavutil)] public static extern int av_frame_replace(IntPtr dst, IntPtr src);
        [DllImport(_libavutil)] public static extern void av_frame_unref(IntPtr AVFrame);
        [DllImport(_libavutil)] public static extern void av_frame_move_ref(IntPtr dst, IntPtr src);

        [DllImport(_libavutil)] public static extern void av_frame_remove_side_data();
        [DllImport(_libavutil)] public static extern void av_frame_side_data_clone();
        [DllImport(_libavutil)] public static extern void av_frame_side_data_free();
        [DllImport(_libavutil)] public static extern void av_frame_side_data_get_c();
        [DllImport(_libavutil)] public static extern void av_frame_side_data_name();
        [DllImport(_libavutil)] public static extern void av_frame_side_data_new();
    

        [DllImport(_libavutil)] public static extern void av_free(IntPtr ptr);
        [DllImport(_libavutil)] public static extern void av_freep(IntPtr ptr);
        [DllImport(_libavutil)] public static extern void av_gcd();
        [DllImport(_libavutil)] public static extern void av_gcd_q();

        [DllImport(_libavutil)] public static extern void av_get_bits_per_pixel();
        [DllImport(_libavutil)] public static extern void av_get_cpu_flags();
        [DllImport(_libavutil)] public static extern void av_get_known_color_name();
        [DllImport(_libavutil)] public static extern void av_get_media_type_string();

        [DllImport(_libavutil)] public static extern void av_get_padded_bits_per_pixel();
        [DllImport(_libavutil)] public static extern char av_get_picture_type_char(AVPictureType pict_type);


        [DllImport(_libavutil)] public static extern AVPixelFormat av_get_pix_fmt([MarshalAs(UnmanagedType.LPStr)]string name);
        [DllImport(_libavutil)] public static extern void av_get_pix_fmt_loss();
        [DllImport(_libavutil)] public static extern IntPtr av_get_pix_fmt_name(AVPixelFormat pix_fmt);
        [DllImport(_libavutil)] public static extern IntPtr av_get_pix_fmt_string(IntPtr buf,int buf_size,AVPixelFormat pix_fmt);

        /// <summary>
        /// Get a seed to use in conjunction with random functions
        /// </summary>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern uint av_get_random_seed();
        /// <summary>
        /// Generate cryptographically secure random data
        /// </summary>
        /// <param name="buf">buffer into which the random data will be written</param>
        /// <param name="len"> size of buf in bytes</param>
        /// <returns> success, len bytes of random data was written  into buf</returns>
        [DllImport(_libavutil)] public static extern int av_random_bytes(IntPtr buf,long len);

        /// <summary>
        /// Return the fractional representation of the internal time base
        /// </summary>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern AVRational av_get_time_base_q();
        [DllImport(_libavutil)] public static extern void av_get_token();

        /// <summary>
        /// Get the current time in microseconds
        /// </summary>
        [DllImport(_libavutil)] public static extern long av_gettime();
        /// <summary>
        /// Get the current time in microseconds since some unspecified starting point
        /// </summary>
        [DllImport(_libavutil)] public static extern long av_gettime_relative();
        /// <summary>
        /// Indicates with a boolean result if the av_gettime_relative() time source is monotonic
        /// </summary>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_gettime_relative_is_monotonic();
        /// <summary>
        /// <code>
        /// Sleep for a period of time
        /// Although the duration is expressed in microseconds, the actual delay may be rounded to the precision of the system timer
        /// </code>
        /// </summary>
        /// <param name="usec"></param>
        /// <returns> zero on success or (negative) error code</returns>
        [DllImport(_libavutil)] public static extern int av_usleep(uint usec);

        [DllImport(_libavutil)] public static extern void av_hash_alloc();
        [DllImport(_libavutil)] public static extern void av_hash_final();
        [DllImport(_libavutil)] public static extern void av_hash_final_b64();
        [DllImport(_libavutil)] public static extern void av_hash_final_bin();
        [DllImport(_libavutil)] public static extern void av_hash_final_hex();
        [DllImport(_libavutil)] public static extern void av_hash_freep();
        [DllImport(_libavutil)] public static extern void av_hash_get_name();
        [DllImport(_libavutil)] public static extern void av_hash_get_size();
        [DllImport(_libavutil)] public static extern void av_hash_init();
        [DllImport(_libavutil)] public static extern void av_hash_names();
        [DllImport(_libavutil)] public static extern void av_hash_update();

        [DllImport(_libavutil)] public static extern void av_hmac_alloc();
        [DllImport(_libavutil)] public static extern void av_hmac_calc();
        [DllImport(_libavutil)] public static extern void av_hmac_final();
        [DllImport(_libavutil)] public static extern void av_hmac_free();
        [DllImport(_libavutil)] public static extern void av_hmac_init();
        [DllImport(_libavutil)] public static extern void av_hmac_update();

        [DllImport(_libavutil)] public static extern void av_hwdevice_ctx_alloc();
        [DllImport(_libavutil)] public static extern void av_hwdevice_ctx_create();
        [DllImport(_libavutil)] public static extern void av_hwdevice_ctx_create_derived();
        [DllImport(_libavutil)] public static extern void av_hwdevice_ctx_create_derived_opts();
        [DllImport(_libavutil)] public static extern void av_hwdevice_ctx_init();
        [DllImport(_libavutil)] public static extern void av_hwdevice_find_type_by_name();
        [DllImport(_libavutil)] public static extern void av_hwdevice_get_hwframe_constraints();
        [DllImport(_libavutil)] public static extern void av_hwdevice_get_type_name();
        [DllImport(_libavutil)] public static extern void av_hwdevice_hwconfig_alloc();
        [DllImport(_libavutil)] public static extern void av_hwdevice_iterate_types();
        [DllImport(_libavutil)] public static extern void av_hwframe_constraints_free();
        [DllImport(_libavutil)] public static extern void av_hwframe_ctx_alloc();
        [DllImport(_libavutil)] public static extern void av_hwframe_ctx_create_derived();
        [DllImport(_libavutil)] public static extern void av_hwframe_ctx_init();
        [DllImport(_libavutil)] public static extern void av_hwframe_get_buffer();
        [DllImport(_libavutil)] public static extern void av_hwframe_map();
        [DllImport(_libavutil)] public static extern void av_hwframe_transfer_data();
        [DllImport(_libavutil)] public static extern void av_hwframe_transfer_get_formats();

        [DllImport(_libavutil)] public static extern void av_i2int();

        [DllImport(_libavutil)] public static extern void av_iamf_audio_element_add_layer();
        [DllImport(_libavutil)] public static extern void av_iamf_audio_element_alloc();
        [DllImport(_libavutil)] public static extern void av_iamf_audio_element_free();
        [DllImport(_libavutil)] public static extern void av_iamf_audio_element_get_class();
        [DllImport(_libavutil)] public static extern void av_iamf_mix_presentation_add_submix();
        [DllImport(_libavutil)] public static extern void av_iamf_mix_presentation_alloc();
        [DllImport(_libavutil)] public static extern void av_iamf_mix_presentation_free();
        [DllImport(_libavutil)] public static extern void av_iamf_mix_presentation_get_class();
        [DllImport(_libavutil)] public static extern void av_iamf_param_definition_alloc();
        [DllImport(_libavutil)] public static extern void av_iamf_param_definition_get_class();
        [DllImport(_libavutil)] public static extern void av_iamf_submix_add_element();
        [DllImport(_libavutil)] public static extern void av_iamf_submix_add_layout();

        #region AVImage

        /// <summary>
        /// Allocate an image with size w and h and pixel format pix_fmt, and fill pointers and linesizes accordingly
        /// <code>The allocated image buffer has to be freed by using av_freep(&pointers[0])</code>
        /// </summary>
        /// <param name="pointers"></param>
        /// <param name="linesize"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="pix_fmt"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        [DllImport(_libavutil)]
        public static extern int av_image_alloc(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] pointers,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize,
            int w, int h,
            AVPixelFormat pix_fmt, int align);
        /// <summary>
        /// Check if the given sample aspect ratio of an image is valid
        /// </summary>
        /// <param name="w">width of the image</param>
        /// <param name="h">height of the image</param>
        /// <param name="sar">sample aspect ratio of the image</param>
        /// <returns>return 0 if valid, a negative AVERROR code otherwise</returns>
        [DllImport(_libavutil)] public static extern int av_image_check_sar(uint w,uint h,AVRational sar);
        /// <summary>
        /// Check if the given dimension of an image is valid, meaning that all bytes of the image can be addressed with a signed int
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="max_pixels"></param>
        /// <param name="pix_fmt"></param>
        /// <param name="log_offset"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_image_check_size(uint w, uint h,int log_offset,IntPtr log_ctx);
        /// <summary>
        /// Check if the given dimension of an image is valid, meaning that all bytes of a plane of an image with the specified pix_fmt can be addressed with a signed int
        /// </summary> 
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="max_pixels"></param>
        /// <param name="pix_fmt"></param>
        /// <param name="log_offset"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_image_check_size2(uint w, uint h, long max_pixels, AVPixelFormat pix_fmt, int log_offset, IntPtr log_ctx);
        /// <summary>
        /// Copy image in src_data to dst_data.
        /// </summary>
        /// <param name="dst_data">destination image data buffer to copy to</param>
        /// <param name="dst_linesize">linesizes for the image in dst_data</param>
        /// <param name="src_data">source image data buffer to copy from</param>
        /// <param name="src_linesize">linesizes for the image in src_data</param>
        /// <param name="pix_fmt"> the AVPixelFormat of the image</param>
        /// <param name="width"> width of the image in pixels</param>
        /// <param name="height">  height of the image in pixels</param>
        [DllImport(_libavutil)]
        public static extern void av_image_copy(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] dst_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] dst_linesize,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] src_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] src_linesize,
            AVPixelFormat pix_fmt, int width, int height);
        /// <summary>
        /// Copy image plane from src to dst
        /// </summary>
        /// <param name="dst"> destination plane to copy to</param>
        /// <param name="dst_linesize"> linesize for the image plane in dst</param>
        /// <param name="src"> source plane to copy from</param>
        /// <param name="src_linesize">linesize for the image plane in src</param>
        /// <param name="bytewidth">must be contained by both absolute values of dst_linesize and src_linesize, otherwise the function behavior is undefined</param>
        /// <param name="height">height (number of lines) of the plane</param>
        [DllImport(_libavutil)] public static extern void av_image_copy_plane(IntPtr dst,int dst_linesize,IntPtr src,int src_linesize,int bytewidth,int height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="dst_linesize"></param>
        /// <param name="src"></param>
        /// <param name="src_linesize"></param>
        /// <param name="bytewidth"></param>
        /// <param name="height"></param>
        [DllImport(_libavutil)] public static extern void av_image_copy_plane_uc_from(IntPtr dest,long dst_linesize,IntPtr src,long src_linesize,long bytewidth,int height);
        /// <summary>
        /// Copy image data from an image into a buffer.
        /// </summary>
        /// <param name="dst"> a buffer into which picture data will be copied</param>
        /// <param name="dst_size">the size in bytes of dst</param>
        /// <param name="src_data">pointers containing the source image data</param>
        /// <param name="src_linesize">linesizes for the image in src_data</param>
        /// <param name="pix_fmt">the pixel format of the source image</param>
        /// <param name="width"> the width of the source image in pixels</param>
        /// <param name="height"> the height of the source image in pixels</param>
        /// <param name="align"> the assumed linesize alignment for dst</param>
        /// <returns>return the number of bytes written to dst, or a negative value on error</returns>
        [DllImport(_libavutil)]
        public static extern int av_image_copy_to_buffer(
            byte[] dst, int dst_size,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] src_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] src_linesize,
            AVPixelFormat pix_fmt, int width, int height, int align);

        [DllImport(_libavutil)]
        public static extern int av_image_copy_uc_from(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] dst_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] long[] dst_linesize,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] src_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] long[] src_linesize,
            AVPixelFormat pix_fmt, int width, int height);
        /// <summary>
        /// Setup the data pointers and linesizes based on the specified image parameters and the provided array
        /// </summary>
        /// <param name="dst_data">data pointers to be filled in</param>
        /// <param name="dst_linesize">linesizes for the image in dst_data to be filled in</param>
        /// <param name="src">  buffer which will contain or contains the actual image data, can be NULL</param>
        /// <param name="pix_fmt">the pixel format of the image</param>
        /// <param name="width">   the width of the image in pixels</param>
        /// <param name="height">the height of the image in pixels</param>
        /// <param name="align">the value used in src for linesize alignment</param>
        /// <returns>return the size in bytes required for src, a negative error code in case of failure</returns>
        [DllImport(_libavutil)]
        public static extern int av_image_fill_arrays(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] dst_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] dst_linesize,
            IntPtr src, AVPixelFormat pix_fmt, int width, int height, int align);

        [DllImport(_libavutil)]
        public static extern int av_image_fill_black(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] des_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] long[] dst_linesize,
            AVPixelFormat pix_fmt, AVColorRange range, int width, int height);

        [DllImport(_libavutil)]
        public static extern int av_image_fill_color(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] des_data,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] long[] dst_linesize,
            AVPixelFormat pix_fmt,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] clolor,
            int width, int height, int flags);

        /// <summary> 
        /// Fill plane linesizes for an image with pixel format pix_fmt and width
        /// </summary>
        /// <param name="linesize"> array to be filled with the linesize for each plane</param>
        /// <param name="pix_fmt">the AVPixelFormat of the image</param>
        /// <param name="width">width of the image in pixels</param>
        /// <returns>>= 0 in case of success, a negative error code otherwise</returns>
        [DllImport(_libavutil)]
        public static extern int av_image_fill_linesizes(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize,
            AVPixelFormat pix_fmt, int width);
        /// <summary>
        /// Compute the max pixel step for each plane of an image with a format described by pixdesc
        /// </summary>
        /// <param name="max_pixsteps"></param>
        /// <param name="max_pixstep_comps"></param>
        /// <param name="AVPixFmtDescription"></param>
        [DllImport(_libavutil)]
        public static extern void av_image_fill_max_pixsteps(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] max_pixsteps,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] max_pixstep_comps,
            IntPtr AVPixFmtDescription);
        /// <summary>
        /// Fill plane sizes for an image with pixel format pix_fmt and height
        /// </summary>
        /// <param name="size">the array to be filled with the size of each image plane</param>
        /// <param name="pix_fmt">the AVPixelFormat of the image</param>
        /// <param name="height">height of the image in pixels</param>
        /// <param name="linesize"> the array containing the linesize for each plane, should be filled by av_image_fill_linesizes()</param>
        /// <returns></returns>
        [DllImport(_libavutil)]
        public static extern int av_image_fill_plane_sizes(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] long[] size,
            AVPixelFormat pix_fmt, int height,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] long[] linesize);
        /// <summary>
        /// Fill plane data pointers for an image with pixel format pix_fmt and height height.
        /// </summary>
        /// <param name="data">pointers array to be filled with the pointer for each image plane</param>
        /// <param name="pix_fmt">the AVPixelFormat of the image</param>
        /// <param name="height">height of the image in pixels</param>
        /// <param name="ptr">the pointer to a buffer which will contain the image</param>
        /// <param name="linesize">the array containing the linesize for each plane, should be filled by av_image_fill_linesizes()</param>
        /// <returns></returns>
        [DllImport(_libavutil)]
        public static extern int av_image_fill_pointers(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data,
            AVPixelFormat pix_fmt, int height, IntPtr ptr,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize);
        /// <summary>
        /// Return the size in bytes of the amount of data required to store an image with the given parameters
        /// </summary>
        /// <param name="pix_fmt">the pixel format of the image</param>
        /// <param name="width">the width of the image in pixels</param>
        /// <param name="height">the height of the image in pixels</param>
        /// <param name="align">the assumed linesize alignment</param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_image_get_buffer_size(AVPixelFormat pix_fmt,int width,int height,int align);
        /// <summary>
        /// Compute the size of an image line with format pix_fmt and width for the plane
        /// </summary>
        /// <param name="pix_fmt"></param>
        /// <param name="width"></param>
        /// <param name="plane"></param>
        /// <returns>the computed size in bytes</returns>
        [DllImport(_libavutil)] public static extern int av_image_get_linesize(AVPixelFormat pix_fmt,int width,int plane);

        [DllImport(_libavutil)] public static extern void av_read_image_line(IntPtr dest, [MarshalAs(UnmanagedType.LPArray,SizeConst =4)]IntPtr[] data, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize,IntPtr AVPixFmtDescriptor,int x,int y,int c,int w,int read_pal_component,int dest_element_size) ;
        [DllImport(_libavutil)] public static extern void av_read_image_line2(IntPtr dest, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize, IntPtr AVPixFmtDescriptor, int x, int y, int c, int w, int read_pal_component);
        [DllImport(_libavutil)] public static extern void av_write_image_line(IntPtr src, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize, IntPtr AVPixFmtDescriptor, int x, int y, int c, int w, int read_pal_component);
        [DllImport(_libavutil)] public static extern void av_write_image_line2(IntPtr src, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] IntPtr[] data, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] int[] linesize, IntPtr AVPixFmtDescriptor, int x, int y, int c, int w);

        #endregion

        [DllImport(_libavutil)] public static extern void av_int2i();
        [DllImport(_libavutil)] public static extern void av_int_list_length_for_size();
        [DllImport(_libavutil)] public static extern void av_lfg_init();
        [DllImport(_libavutil)] public static extern void av_lfg_init_from_data();

        [DllImport(_libavutil)] public static extern void av_log();
        [DllImport(_libavutil)] public static extern void av_log2();
        [DllImport(_libavutil)] public static extern void av_log2_16bit();
        [DllImport(_libavutil)] public static extern void av_log2_i();
        [DllImport(_libavutil)] public static extern void av_log_default_callback();
        [DllImport(_libavutil)] public static extern void av_log_format_line();
        [DllImport(_libavutil)] public static extern void av_log_format_line2();
        [DllImport(_libavutil)] public static extern void av_log_get_flags();
        [DllImport(_libavutil)] public static extern int av_log_get_level();
        [DllImport(_libavutil)] public static extern void av_log_once();
        [DllImport(_libavutil)] public static extern void av_log_set_callback();
        [DllImport(_libavutil)] public static extern void av_log_set_flags();
        [DllImport(_libavutil)] public static extern void av_log_set_level(int level);

        [DllImport(_libavutil)] public static extern void av_lzo1x_decode();
      
        /// <summary>
        /// Allocate a memory block with alignment suitable for all memory accesses
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern IntPtr av_malloc(long size);

        /// <summary>
        /// Allocate a memory block for an array with av_malloc().
        /// </summary>
        /// <param name="nmemb"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern IntPtr av_malloc_array(long nmemb,long size);
        /// <summary>
        /// Allocate a memory block with alignment suitable for all memory accesses  and zero all the bytes of the block
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern IntPtr av_mallocz(long size);
        /// <summary>
        /// Allocate a memory block for an array with av_mallocz().
        /// </summary>
        /// <param name="nmemb"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern IntPtr av_calloc(long nmemb, long size);

        [DllImport(_libavutil)] public static extern IntPtr av_realloc(IntPtr ptr,long size);
        [DllImport(_libavutil)] public static extern IntPtr av_realloc_array(IntPtr ptr, long nmemb, long size);
        [DllImport(_libavutil)] public static extern void av_realloc_f();
        [DllImport(_libavutil)] public static extern void av_reallocp();
        [DllImport(_libavutil)] public static extern void av_reallocp_array();

        [DllImport(_libavutil)] public static extern void av_mastering_display_metadata_alloc();
        [DllImport(_libavutil)] public static extern void av_mastering_display_metadata_create_side_data();

        [DllImport(_libavutil)] public static extern void av_match_list();
        [DllImport(_libavutil)] public static extern void av_match_name();

        /// <summary>
        /// Set the maximum size that may be allocated in one block
        /// </summary>
        /// <param name="max"></param>
        [DllImport(_libavutil)] public static extern void av_max_alloc(long max);

        [DllImport(_libavutil)] public static extern void av_md5_alloc();
        [DllImport(_libavutil)] public static extern void av_md5_final();
        [DllImport(_libavutil)] public static extern void av_md5_init();
        [DllImport(_libavutil)] public static extern void av_md5_size();
        [DllImport(_libavutil)] public static extern void av_md5_sum();
        [DllImport(_libavutil)] public static extern void av_md5_update();

        [DllImport(_libavutil)] public static extern void av_memcpy_backptr();
        [DllImport(_libavutil)] public static extern void av_memdup();
        [DllImport(_libavutil)] public static extern void av_mod_i();
        [DllImport(_libavutil)] public static extern void av_mul_i();
        [DllImport(_libavutil)] public static extern void av_mul_q();
        [DllImport(_libavutil)] public static extern void av_murmur3_alloc();
        [DllImport(_libavutil)] public static extern void av_murmur3_final();
        [DllImport(_libavutil)] public static extern void av_murmur3_init();
        [DllImport(_libavutil)] public static extern void av_murmur3_init_seeded();
        [DllImport(_libavutil)] public static extern void av_murmur3_update();

        [DllImport(_libavutil)] public static extern void av_nearer_q();

        [DllImport(_libavutil)] public static extern void av_opt_child_class_iterate();
        [DllImport(_libavutil)] public static extern IntPtr av_opt_child_next(IntPtr obj,IntPtr prev);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="src"></param>
        /// <returns>return 0 on success, negative on error</returns>
        [DllImport(_libavutil)] public static extern int av_opt_copy(IntPtr dest,IntPtr src);

        [DllImport(_libavutil)] public static extern int av_opt_eval_double(IntPtr obj,IntPtr AVOption,[MarshalAs(UnmanagedType.LPStr)]string val,double* double_out);
        [DllImport(_libavutil)] public static extern int av_opt_eval_flags(IntPtr obj, IntPtr AVOption, [MarshalAs(UnmanagedType.LPStr)] string val,int* flags_out);
        [DllImport(_libavutil)] public static extern int av_opt_eval_float(IntPtr obj, IntPtr AVOption, [MarshalAs(UnmanagedType.LPStr)] string val, float* float_out);
        [DllImport(_libavutil)] public static extern int av_opt_eval_int(IntPtr obj, IntPtr AVOption, [MarshalAs(UnmanagedType.LPStr)] string val, int* int_out);
        [DllImport(_libavutil)] public static extern int av_opt_eval_int64(IntPtr obj, IntPtr AVOption, [MarshalAs(UnmanagedType.LPStr)] string val, long* int64_out);
        [DllImport(_libavutil)] public static extern int av_opt_eval_q(IntPtr obj, IntPtr AVOption, [MarshalAs(UnmanagedType.LPStr)] string val, AVRational* q_out);
        /// <summary>
        ///  Look for an option in an object. Consider only options which have all the specified flags set.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="unit"></param>
        /// <param name="opt_flags"></param>
        /// <param name="search_flags"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern IntPtr av_opt_find(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string unit,AVOptionFlags opt_flags,AVOptionSearchFlags search_flags);
        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="unit"></param>
        /// <param name="opt_flags"></param>
        /// <param name="search_flags"></param>
        /// <param name="target_obj"></param>
        /// <returns>AVOption *</returns>
        [DllImport(_libavutil)] public static extern IntPtr av_opt_find2(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string unit, AVOptionFlags opt_flags, AVOptionSearchFlags search_flags, IntPtr target_obj);
       
        [DllImport(_libavutil)] public static extern int av_opt_flag_is_set(IntPtr obj,string field_name,string flag_name);
        [DllImport(_libavutil)] public static extern void av_opt_free(IntPtr obj);
        [DllImport(_libavutil)] public static extern void av_opt_freep_ranges();

        [DllImport(_libavutil)] public static extern int av_opt_get(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags,IntPtr out_val);
        [DllImport(_libavutil)] public static extern int av_opt_get_chlayout(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags,IntPtr AVChannelLayout);
        [DllImport(_libavutil)] public static extern int av_opt_get_dict_val(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags,IntPtr* AVDictionary);
        [DllImport(_libavutil)] public static extern int av_opt_get_double(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags, IntPtr out_val);
        [DllImport(_libavutil)] public static extern int av_opt_get_image_size(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags, IntPtr w_out, IntPtr h_out);
        [DllImport(_libavutil)] public static extern int av_opt_get_int(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags,IntPtr out_val);
        [DllImport(_libavutil)] public static extern int av_opt_get_key_value(string[] ropts,string key_val_sep,string pairs_sep,AVOptionFlags flags, string[] rkey, string[] rval);
        [DllImport(_libavutil)] public static extern int av_opt_get_pixel_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags,IntPtr AVPixelFormat);
        [DllImport(_libavutil)] public static extern int av_opt_get_q(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags,IntPtr AVRational );
        [DllImport(_libavutil)] public static extern int av_opt_get_sample_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags, IntPtr AVSampleFormat );
        [DllImport(_libavutil)] public static extern int av_opt_get_video_rate(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags, IntPtr AVRational);

        [DllImport(_libavutil)] public static extern int av_opt_is_set_to_default(IntPtr obj,IntPtr AVOption);
        [DllImport(_libavutil)] public static extern int av_opt_is_set_to_default_by_name(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVOptionSearchFlags search_flags);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="AVOption">prev AVOption *</param>
        /// <returns>AVOption *</returns>
        [DllImport(_libavutil)] public static extern IntPtr av_opt_next(IntPtr obj,IntPtr AVOption);
        [DllImport(_libavutil)] public static extern IntPtr av_opt_ptr(IntPtr AVClass,IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(_libavutil)] public static extern void av_opt_query_ranges();
        [DllImport(_libavutil)] public static extern void av_opt_query_ranges_default();
        [DllImport(_libavutil)] public static extern int av_opt_serialize(IntPtr obj,AVOptionFlags opt_flags,AVOptionSeriallize flags, IntPtr buffer,char key_val_sep,char pairs_sep);
      
        [DllImport(_libavutil)] public static extern int av_opt_set(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)]string name, [MarshalAs(UnmanagedType.LPStr)]string val, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_bin(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPArray)] byte[] val,int size, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_chlayout(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, ref AVChannelLayout layout, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern void av_opt_set_defaults(IntPtr s);
        [DllImport(_libavutil)] public static extern void av_opt_set_defaults2(IntPtr s,int mask,int flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_dict(IntPtr obj,ref IntPtr AVDictionary);
        [DllImport(_libavutil)] public static extern int av_opt_set_dict2(IntPtr ojb,ref IntPtr AVDictionary,AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_dict_val(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr AVDictionary, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_double(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name,  double val, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_from_string(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string opts,IntPtr shorthand, [MarshalAs(UnmanagedType.LPStr)] string key_value_sep, [MarshalAs(UnmanagedType.LPStr)] string pairs_sep);
        [DllImport(_libavutil)] public static extern int av_opt_set_image_size(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, int w,int h, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_int(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name,  long val, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_pixel_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVPixelFormat val, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_q(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVRational val, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_sample_fmt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVSampleFormat val, AVOptionSearchFlags search_flags);
        [DllImport(_libavutil)] public static extern int av_opt_set_video_rate(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVRational val, AVOptionSearchFlags search_flags);

        [DllImport(_libavutil)] public static extern int av_opt_show2(IntPtr obj,IntPtr av_log_obj,int req_flags,int rej_flags);

        /// <summary>
        /// 从字符串解析颜色
        /// </summary>
        /// <param name="rgba_color"></param>
        /// <param name="color_string"></param>
        /// <param name="slen"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_parse_color(IntPtr rgba_color, [MarshalAs(UnmanagedType.LPStr)] string color_string,int slen,IntPtr log_ctx);
        /// <summary>
        /// 解析cpu性能
        /// </summary>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_parse_cpu_caps(IntPtr flags, [MarshalAs(UnmanagedType.LPStr)] string s);
        /// <summary>
        /// 从字符串解析比例
        /// </summary>
        /// <param name="AVRational"></param>
        /// <param name="str"></param>
        /// <param name="max"></param>
        /// <param name="log_offset"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_parse_ratio(IntPtr AVRational, [MarshalAs(UnmanagedType.LPStr)] string str,int max,int log_offset,IntPtr log_ctx);
        /// <summary>
        /// 从字符串解析时间
        /// </summary>
        /// <param name="timeval"></param>
        /// <param name="timestr"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_parse_time(IntPtr timeval, [MarshalAs(UnmanagedType.LPStr)] string timestr,int duration);
        /// <summary>
        /// 从字符串解析视频比例
        /// </summary>
        /// <param name="AVRational"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_parse_video_rate(IntPtr AVRational, [MarshalAs(UnmanagedType.LPStr)] string str);
        /// <summary>
        /// 从字符串解析视频尺寸
        /// </summary>
        /// <param name="width_ptr"></param>
        /// <param name="height_ptr"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_parse_video_size(IntPtr width_ptr,IntPtr height_ptr, [MarshalAs(UnmanagedType.LPStr)] string str);

        [DllImport(_libavutil)] public static extern void av_pix_fmt_count_planes();
        [DllImport(_libavutil)] public static extern IntPtr av_pix_fmt_desc_get(AVPixelFormat pix_fmt);
        [DllImport(_libavutil)] public static extern AVPixelFormat av_pix_fmt_desc_get_id(IntPtr AVPixFmtDescriptor);
        [DllImport(_libavutil)] public static extern IntPtr av_pix_fmt_desc_next(IntPtr prev);
        [DllImport(_libavutil)] public static extern void av_pix_fmt_get_chroma_sub_sample();
        [DllImport(_libavutil)] public static extern void av_pix_fmt_swap_endianness();

        [DllImport(_libavutil)] public static extern void av_pixelutils_get_sad_fn();
        [DllImport(_libavutil)] public static extern void av_q2intfloat();

      
        [DllImport(_libavutil)] public static extern void av_rc4_alloc();
        [DllImport(_libavutil)] public static extern void av_rc4_crypt();
        [DllImport(_libavutil)] public static extern void av_rc4_init();


        [DllImport(_libavutil)] public static extern void av_reduce();
        /// <summary>
        /// Rescale a 64-bit integer with rounding to nearest
        /// The operation is mathematically equivalent to `a * b / c`, but writing that directly can overflow
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern long av_rescale(long a,long b,long c);
        /// <summary>
        /// Rescale a 64-bit integer with rounding to nearest
        /// The operation is mathematically equivalent to `a * b / c`, but writing that directly can overflow,and does not support different rounding methods
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="rounding"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern long av_rescale_rnd(long a, long b, long c, AVRounding rounding);

        [DllImport(_libavutil)] public static extern long av_rescale_delta(AVRational in_tb,long in_ts,AVRounding fs_tb,int duration,out long last,AVRational out_tb );
        [DllImport(_libavutil)] public static extern long av_rescale_q(long a,AVRational bq,AVRational cq);
        [DllImport(_libavutil)] public static extern long av_rescale_q_rnd(long a, AVRational bq, AVRational cq,AVRounding rounding);
    

        [DllImport(_libavutil)] public static extern void av_ripemd_alloc();
        [DllImport(_libavutil)] public static extern void av_ripemd_final();
        [DllImport(_libavutil)] public static extern void av_ripemd_init();
        [DllImport(_libavutil)] public static extern void av_ripemd_size();
        [DllImport(_libavutil)] public static extern void av_ripemd_update();

        #region AVSample

        [DllImport(_libavutil)] public static extern AVSampleFormat av_get_alt_sample_fmt(AVSampleFormat sample_fmt, int planar);
        [DllImport(_libavutil)] public static extern AVSampleFormat av_get_packed_sample_fmt(AVSampleFormat sample_fmt);
        [DllImport(_libavutil)] public static extern AVSampleFormat av_get_planar_sample_fmt(AVSampleFormat sample_fmt);
        [DllImport(_libavutil)] public static extern AVSampleFormat av_get_sample_fmt([MarshalAs(UnmanagedType.LPStr)]string name);

        [DllImport(_libavutil)]
        public static extern IntPtr av_get_sample_fmt_name(AVSampleFormat sample_fmt);

        /// <summary>
        /// Generate a string corresponding to the sample format with sample_fmt, or a header if sample_fmt is negative
        /// </summary>
        /// <param name="buf">the buffer where to write the string</param>
        /// <param name="buf_size">the size of buf</param>
        /// <param name="sample_fmt"></param>
        /// <returns>the pointer to the filled buffer or NULL if sample_fmt is unknown or in case of other errors</returns>
        [DllImport(_libavutil)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string av_get_sample_fmt_string([MarshalAs(UnmanagedType.LPStr)] string buf, int buf_size, AVSampleFormat sample_fmt);

        /// <summary>
        /// Return number of bytes per sample.
        /// </summary>
        /// <param name="sample_fmt"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_get_bytes_per_sample(AVSampleFormat sample_fmt);

        /// <summary>
        /// Check if the sample format is planar
        /// </summary>
        /// <param name="sample_fmt"></param>
        /// <returns>return 1 if the sample format is planar, 0 if it is interleaved</returns>
        [DllImport(_libavutil)] public static extern int av_sample_fmt_is_planar(AVSampleFormat sample_fmt);
        /// <summary>
        /// <code>
        /// Allocate a samples buffer for <paramref name="nb_samples"/> samples, and fill data pointers and linesize accordingly
        /// The allocated samples buffer can be freed by using av_freep(&audio_data[0])
        /// Allocated data will be initialized to silence
        /// </code>
        /// </summary>
        /// <param name="audio_data">array to be filled with the pointer for each channel</param>
        /// <param name="linesize">aligned size for audio buffer(s), may be NULL</param>
        /// <param name="nb_channels">   number of audio channels</param>
        /// <param name="nb_samples">number of samples per channel</param>
        /// <param name="sample_fmt">    the sample format</param>
        /// <param name="allign"> buffer size alignment (0 = default, 1 = no alignment)</param>
        /// <returns> >=0 on success or a negative error code on failure</returns>
        [DllImport(_libavutil)] public static extern int av_samples_alloc( IntPtr[] audio_data, int[] linesize,int nb_channels,int nb_samples,AVSampleFormat sample_fmt,int allign);

        /// <summary>
        /// Allocate a data pointers array samples buffer for <paramref name="nb_samples"/>  samples, and fill data pointers and linesize accordingly.
        /// </summary>
        /// <param name="audio_data"></param>
        /// <param name="linesize"></param>
        /// <param name="nb_channels"></param>
        /// <param name="nb_samples"></param>
        /// <param name="sample_fmt"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_samples_alloc_array_and_samples(IntPtr[] audio_data, int[] linesize, int nb_channels,                                       int nb_samples,  AVSampleFormat sample_fmt, int align);

        /// <summary>
        /// Copy samples from src to dst.
        /// </summary>
        /// <param name="dest">destination array of pointers to data planes</param>
        /// <param name="src">source array of pointers to data planes</param>
        /// <param name="dest_offset">offset in samples at which the data will be written to dst</param>
        /// <param name="src_offset">offset in samples at which the data will be read from src</param>
        /// <param name="nb_samples">number of samples to be copied</param>
        /// <param name="nb_channels"> number of audio channels</param>
        /// <param name="sample_fmt"> audio sample format</param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_samples_copy(IntPtr[] dest, IntPtr[] src, int dest_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);

        /// <summary>
        /// Fill plane data pointers and linesize for samples with sample format
        /// </summary>
        /// <param name="audio_data">array to be filled with the pointer for each channel</param>
        /// <param name="linesize">calculated linesize, may be NULL</param>
        /// <param name="buff"> the pointer to a buffer containing the samples</param>
        /// <param name="nb_channels"> the number of channels</param>
        /// <param name="nb_samples"> the number of samples in a single channel</param>
        /// <param name="sample_fmt">the sample format</param>
        /// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
        /// <returns>minimum size in bytes required for the buffer on success or a negative error code on failure</returns>
        [DllImport(_libavutil)] public static extern int av_samples_fill_arrays(IntPtr[] audio_data, int[] linesize, byte[] buff, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linesize">linesize calculated linesize, may be NULL</param>
        /// <param name="nb_channels">the number of channels</param>
        /// <param name="nb_samples">the number of samples in a single channel</param>
        /// <param name="sample_fmt">the sample format</param>
        /// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
        /// <returns>required buffer size, or negative error code on failure</returns>
        [DllImport(_libavutil)] public static extern int av_samples_get_buffer_size(out int linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

        /// <summary>
        /// Fill an audio buffer with silence
        /// </summary>
        /// <param name="audio_data">array of pointers to data planes</param>
        /// <param name="offset">offset in samples at which to start filling</param>
        /// <param name="nb_samples">number of samples to fill</param>
        /// <param name="nb_channels">number of audio channels</param>
        /// <param name="sample_fmt"> audio sample format</param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_samples_set_silence(IntPtr[] audio_data, int offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);

        #endregion


        [DllImport(_libavutil)] public static extern int av_set_options_string(IntPtr obj,string opts,string key_val_sep,string pairs_sep);

        [DllImport(_libavutil)] public static extern void av_sha512_alloc();
        [DllImport(_libavutil)] public static extern void av_sha512_final();
        [DllImport(_libavutil)] public static extern void av_sha512_init();
        [DllImport(_libavutil)] public static extern void av_sha512_size();
        [DllImport(_libavutil)] public static extern void av_sha512_update();

        [DllImport(_libavutil)] public static extern void av_sha_alloc();
        [DllImport(_libavutil)] public static extern void av_sha_final();
        [DllImport(_libavutil)] public static extern void av_sha_init();
        [DllImport(_libavutil)] public static extern void av_sha_size();
        [DllImport(_libavutil)] public static extern void av_sha_update();

        [DllImport(_libavutil)] public static extern void av_shr_i();
        [DllImport(_libavutil)] public static extern int av_size_mult(long a,long b,[Out]IntPtr r);
        [DllImport(_libavutil)] public static extern void av_small_strptime();

        [DllImport(_libavutil)] public static extern void av_spherical_alloc();
        [DllImport(_libavutil)] public static extern void av_spherical_from_name();
        [DllImport(_libavutil)] public static extern void av_spherical_projection_name();
        [DllImport(_libavutil)] public static extern void av_spherical_tile_bounds();

        [DllImport(_libavutil)] public static extern void av_sscanf();
        [DllImport(_libavutil)] public static extern void av_stereo3d_alloc();
        [DllImport(_libavutil)] public static extern void av_stereo3d_create_side_data();
        [DllImport(_libavutil)] public static extern void av_stereo3d_from_name();
        [DllImport(_libavutil)] public static extern void av_stereo3d_type_name();
        [DllImport(_libavutil)] public static extern void av_strcasecmp();
        [DllImport(_libavutil)] public static extern void av_strdup();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errStr"></param>
        /// <param name="errSize">AV_ERROR_MAX_STRING_SIZE=64</param>
        /// <returns></returns>
        [DllImport(_libavutil)] public static extern int av_strerror(int error, [MarshalAs(UnmanagedType.LPStr)] StringBuilder errStr, int errSize = 64);
        [DllImport(_libavutil)] public static extern void av_strireplace();
        [DllImport(_libavutil)] public static extern void av_stristart();
        [DllImport(_libavutil)] public static extern void av_stristr();
        [DllImport(_libavutil)] public static extern void av_strlcat();
        [DllImport(_libavutil)] public static extern void av_strlcatf();
        [DllImport(_libavutil)] public static extern void av_strlcpy();
        [DllImport(_libavutil)] public static extern void av_strncasecmp();
        [DllImport(_libavutil)] public static extern void av_strndup();
        [DllImport(_libavutil)] public static extern void av_strnstr();
        [DllImport(_libavutil)] public static extern void av_strstart();
        [DllImport(_libavutil)] public static extern void av_strtod();
        [DllImport(_libavutil)] public static extern void av_strtok();
        [DllImport(_libavutil)] public static extern void av_sub_i();
        [DllImport(_libavutil)] public static extern void av_sub_q();
        [DllImport(_libavutil)] public static extern void av_tea_alloc();
        [DllImport(_libavutil)] public static extern void av_tea_crypt();
        [DllImport(_libavutil)] public static extern void av_tea_init();
        [DllImport(_libavutil)] public static extern void av_tea_size();

        [DllImport(_libavutil)] public static extern void av_thread_message_flush();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_alloc();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_free();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_nb_elems();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_recv();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_send();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_set_err_recv();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_set_err_send();
        [DllImport(_libavutil)] public static extern void av_thread_message_queue_set_free_func();

        [DllImport(_libavutil)] public static extern void av_timecode_adjust_ntsc_framenum2();
        [DllImport(_libavutil)] public static extern void av_timecode_check_frame_rate();
        [DllImport(_libavutil)] public static extern void av_timecode_get_smpte();
        [DllImport(_libavutil)] public static extern void av_timecode_get_smpte_from_framenum();
        [DllImport(_libavutil)] public static extern void av_timecode_init();
        [DllImport(_libavutil)] public static extern void av_timecode_init_from_components();
        [DllImport(_libavutil)] public static extern void av_timecode_init_from_string();
        [DllImport(_libavutil)] public static extern void av_timecode_make_mpeg_tc_string();
        [DllImport(_libavutil)] public static extern void av_timecode_make_smpte_tc_string();
        [DllImport(_libavutil)] public static extern void av_timecode_make_smpte_tc_string2();
        [DllImport(_libavutil)] public static extern void av_timecode_make_string();
        [DllImport(_libavutil)] public static extern void av_timegm();

        [DllImport(_libavutil)] public static extern void av_tree_destroy();
        [DllImport(_libavutil)] public static extern void av_tree_enumerate();
        [DllImport(_libavutil)] public static extern void av_tree_find();
        [DllImport(_libavutil)] public static extern void av_tree_insert();
        [DllImport(_libavutil)] public static extern void av_tree_node_alloc();
        [DllImport(_libavutil)] public static extern void av_tree_node_size();

        [DllImport(_libavutil)] public static extern void av_ts_make_time_string2();
        [DllImport(_libavutil)] public static extern void av_twofish_alloc();
        [DllImport(_libavutil)] public static extern void av_twofish_crypt();
        [DllImport(_libavutil)] public static extern void av_twofish_init();
        [DllImport(_libavutil)] public static extern void av_twofish_size();
        [DllImport(_libavutil)] public static extern void av_tx_init();
        [DllImport(_libavutil)] public static extern void av_tx_uninit();
   
        [DllImport(_libavutil)] public static extern void av_utf8_decode();
        [DllImport(_libavutil)] public static extern void av_util_ffversion();

        [DllImport(_libavutil)] public static extern void av_uuid_parse();
        [DllImport(_libavutil)] public static extern void av_uuid_parse_range();
        [DllImport(_libavutil)] public static extern void av_uuid_unparse();
        [DllImport(_libavutil)] public static extern void av_uuid_urn_parse();

        [DllImport(_libavutil)] public static extern void av_vbprintf();
        [DllImport(_libavutil)] public static extern void av_version_info();

        [DllImport(_libavutil)] public static extern void av_video_enc_params_alloc();
        [DllImport(_libavutil)] public static extern void av_video_enc_params_create_side_data();
        [DllImport(_libavutil)] public static extern void av_video_hint_alloc();
        [DllImport(_libavutil)] public static extern void av_video_hint_create_side_data();

        [DllImport(_libavutil)] public static extern void av_vk_frame_alloc();
        [DllImport(_libavutil)] public static extern void av_vkfmt_from_pixfmt();
        [DllImport(_libavutil)] public static extern void av_vlog();

        [DllImport(_libavutil)] public static extern void av_xtea_alloc();
        [DllImport(_libavutil)] public static extern void av_xtea_crypt();
        [DllImport(_libavutil)] public static extern void av_xtea_init();
        [DllImport(_libavutil)] public static extern void av_xtea_le_crypt();
        [DllImport(_libavutil)] public static extern void av_xtea_le_init();

        [DllImport(_libavutil)] public static extern void avpriv_alloc_fixed_dsp();
        [DllImport(_libavutil)] public static extern void avpriv_cga_font();
        [DllImport(_libavutil)] public static extern void avpriv_dict_set_timestamp();
        [DllImport(_libavutil)] public static extern void avpriv_float_dsp_alloc();
        [DllImport(_libavutil)] public static extern void avpriv_fopen_utf8();
        [DllImport(_libavutil)] public static extern void avpriv_init_lls();
        [DllImport(_libavutil)] public static extern void avpriv_open();
        [DllImport(_libavutil)] public static extern void avpriv_report_missing_feature();
        [DllImport(_libavutil)] public static extern void avpriv_request_sample();
        [DllImport(_libavutil)] public static extern void avpriv_scalarproduct_float_c();
        [DllImport(_libavutil)] public static extern void avpriv_set_systematic_pal2();
        [DllImport(_libavutil)] public static extern void avpriv_slicethread_create();
        [DllImport(_libavutil)] public static extern void avpriv_slicethread_execute();
        [DllImport(_libavutil)] public static extern void avpriv_slicethread_free();
        [DllImport(_libavutil)] public static extern void avpriv_solve_lls();
        [DllImport(_libavutil)] public static extern void avpriv_tempfile();
        [DllImport(_libavutil)] public static extern void avpriv_vga16_font();

        [return:MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavutil)] public static extern string avutil_configuration();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavutil)] public static extern string avutil_license();

        [DllImport(_libavutil)] public static extern uint avutil_version();
    }
}