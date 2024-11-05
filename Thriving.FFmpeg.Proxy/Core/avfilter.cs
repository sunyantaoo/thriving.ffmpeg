using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public partial class Core
    {
        private const string _libavfilter = "avfilter-10.dll";

        [DllImport(_libavfilter)] public static extern void FT_Activate_Size();
        [DllImport(_libavfilter)] public static extern void FT_Add_Default_Modules();
        [DllImport(_libavfilter)] public static extern void FT_Add_Module();
        [DllImport(_libavfilter)] public static extern void FT_Angle_Diff();
        [DllImport(_libavfilter)] public static extern void FT_Atan2();
        [DllImport(_libavfilter)] public static extern void FT_Attach_File();
        [DllImport(_libavfilter)] public static extern void FT_Attach_Stream();

        [DllImport(_libavfilter)] public static extern void FT_Bitmap_Blend();
        [DllImport(_libavfilter)] public static extern void FT_Bitmap_Convert();
        [DllImport(_libavfilter)] public static extern void FT_Bitmap_Copy();
        [DllImport(_libavfilter)] public static extern void FT_Bitmap_Done();
        [DllImport(_libavfilter)] public static extern void FT_Bitmap_Embolden();
        [DllImport(_libavfilter)] public static extern void FT_Bitmap_Init();
        [DllImport(_libavfilter)] public static extern void FT_Bitmap_New();

        [DllImport(_libavfilter)] public static extern void FT_CeilFix();
        [DllImport(_libavfilter)] public static extern void FT_Cos();
        [DllImport(_libavfilter)] public static extern void FT_DivFix();

        [DllImport(_libavfilter)] public static extern void FT_Done_Face();
        [DllImport(_libavfilter)] public static extern void FT_Done_FreeType();
        [DllImport(_libavfilter)] public static extern void FT_Done_Glyph();
        [DllImport(_libavfilter)] public static extern void FT_Done_Library();
        [DllImport(_libavfilter)] public static extern void FT_Done_MM_Var();
        [DllImport(_libavfilter)] public static extern void FT_Done_Size();

        [DllImport(_libavfilter)] public static extern void FT_Error_String();

        [DllImport(_libavfilter)] public static extern void FT_Face_GetCharVariantIndex();
        [DllImport(_libavfilter)] public static extern void FT_Face_GetCharVariantIsDefault();
        [DllImport(_libavfilter)] public static extern void FT_Face_GetCharsOfVariant();
        [DllImport(_libavfilter)] public static extern void FT_Face_GetVariantSelectors();
        [DllImport(_libavfilter)] public static extern void FT_Face_GetVariantsOfChar();
        [DllImport(_libavfilter)] public static extern void FT_Face_Properties();

        [DllImport(_libavfilter)] public static extern void FT_FloorFix();

        [DllImport(_libavfilter)] public static extern void FT_Get_Advance();
        [DllImport(_libavfilter)] public static extern void FT_Get_Advances();
        [DllImport(_libavfilter)] public static extern void FT_Get_BDF_Charset_ID();
        [DllImport(_libavfilter)] public static extern void FT_Get_BDF_Property();
        [DllImport(_libavfilter)] public static extern void FT_Get_CMap_Format();
        [DllImport(_libavfilter)] public static extern void FT_Get_CMap_Language_ID();
        [DllImport(_libavfilter)] public static extern void FT_Get_Char_Index();
        [DllImport(_libavfilter)] public static extern void FT_Get_Charmap_Index();
        [DllImport(_libavfilter)] public static extern void FT_Get_Color_Glyph_ClipBox();
        [DllImport(_libavfilter)] public static extern void FT_Get_Color_Glyph_Layer();
        [DllImport(_libavfilter)] public static extern void FT_Get_Color_Glyph_Paint();
        [DllImport(_libavfilter)] public static extern void FT_Get_Colorline_Stops();
        [DllImport(_libavfilter)] public static extern void FT_Get_Default_Named_Instance();
        [DllImport(_libavfilter)] public static extern void FT_Get_First_Char();
        [DllImport(_libavfilter)] public static extern void FT_Get_Font_Format();
        [DllImport(_libavfilter)] public static extern void FT_Get_Glyph();
        [DllImport(_libavfilter)] public static extern void FT_Get_Glyph_Name();
        [DllImport(_libavfilter)] public static extern void FT_Get_Kerning();
        [DllImport(_libavfilter)] public static extern void FT_Get_MM_Blend_Coordinates();
        [DllImport(_libavfilter)] public static extern void FT_Get_MM_Var();
        [DllImport(_libavfilter)] public static extern void FT_Get_MM_WeightVector();
        [DllImport(_libavfilter)] public static extern void FT_Get_Module();
        [DllImport(_libavfilter)] public static extern void FT_Get_Multi_Master();
        [DllImport(_libavfilter)] public static extern void FT_Get_Name_Index();
        [DllImport(_libavfilter)] public static extern void FT_Get_Next_Char();
        [DllImport(_libavfilter)] public static extern void FT_Get_PS_Font_Info();
        [DllImport(_libavfilter)] public static extern void FT_Get_PS_Font_Private();
        [DllImport(_libavfilter)] public static extern void FT_Get_PS_Font_Value();
        [DllImport(_libavfilter)] public static extern void FT_Get_Paint();
        [DllImport(_libavfilter)] public static extern void FT_Get_Paint_Layers();
        [DllImport(_libavfilter)] public static extern void FT_Get_Postscript_Name();
        [DllImport(_libavfilter)] public static extern void FT_Get_Renderer();
        [DllImport(_libavfilter)] public static extern void FT_Get_Sfnt_LangTag();
        [DllImport(_libavfilter)] public static extern void FT_Get_Sfnt_Name();
        [DllImport(_libavfilter)] public static extern void FT_Get_Sfnt_Name_Count();
        [DllImport(_libavfilter)] public static extern void FT_Get_Sfnt_Table();
        [DllImport(_libavfilter)] public static extern void FT_Get_SubGlyph_Info();
        [DllImport(_libavfilter)] public static extern void FT_Get_Track_Kerning();
        [DllImport(_libavfilter)] public static extern void FT_Get_Transform();
        [DllImport(_libavfilter)] public static extern void FT_Get_TrueType_Engine_Type();
        [DllImport(_libavfilter)] public static extern void FT_Get_Var_Axis_Flags();
        [DllImport(_libavfilter)] public static extern void FT_Get_Var_Blend_Coordinates();
        [DllImport(_libavfilter)] public static extern void FT_Get_Var_Design_Coordinates();
        [DllImport(_libavfilter)] public static extern void FT_Get_X11_Font_Format();

        [DllImport(_libavfilter)] public static extern void FT_GlyphSlot_Own_Bitmap();

        [DllImport(_libavfilter)] public static extern void FT_Glyph_Copy();
        [DllImport(_libavfilter)] public static extern void FT_Glyph_Get_CBox();
        [DllImport(_libavfilter)] public static extern void FT_Glyph_Stroke();
        [DllImport(_libavfilter)] public static extern void FT_Glyph_StrokeBorder();
        [DllImport(_libavfilter)] public static extern void FT_Glyph_To_Bitmap();
        [DllImport(_libavfilter)] public static extern void FT_Glyph_Transform();
        [DllImport(_libavfilter)] public static extern void FT_Has_PS_Glyph_Names();
        [DllImport(_libavfilter)] public static extern void FT_Init_FreeType();

        [DllImport(_libavfilter)] public static extern void FT_Library_SetLcdFilter();
        [DllImport(_libavfilter)] public static extern void FT_Library_SetLcdFilterWeights();
        [DllImport(_libavfilter)] public static extern void FT_Library_SetLcdGeometry();
        [DllImport(_libavfilter)] public static extern void FT_Library_Version();

        [DllImport(_libavfilter)] public static extern void FT_List_Add();
        [DllImport(_libavfilter)] public static extern void FT_List_Finalize();
        [DllImport(_libavfilter)] public static extern void FT_List_Find();
        [DllImport(_libavfilter)] public static extern void FT_List_Insert();
        [DllImport(_libavfilter)] public static extern void FT_List_Iterate();
        [DllImport(_libavfilter)] public static extern void FT_List_Remove();
        [DllImport(_libavfilter)] public static extern void FT_List_Up();

        [DllImport(_libavfilter)] public static extern void FT_Load_Char();
        [DllImport(_libavfilter)] public static extern void FT_Load_Glyph();
        [DllImport(_libavfilter)] public static extern void FT_Load_Sfnt_Table();

        [DllImport(_libavfilter)] public static extern void FT_Matrix_Invert();
        [DllImport(_libavfilter)] public static extern void FT_Matrix_Multiply();

        [DllImport(_libavfilter)] public static extern void FT_MulDiv();
        [DllImport(_libavfilter)] public static extern void FT_MulFix();

        [DllImport(_libavfilter)] public static extern void FT_New_Face();
        [DllImport(_libavfilter)] public static extern void FT_New_Glyph();
        [DllImport(_libavfilter)] public static extern void FT_New_Library();
        [DllImport(_libavfilter)] public static extern void FT_New_Memory_Face();
        [DllImport(_libavfilter)] public static extern void FT_New_Size();

        [DllImport(_libavfilter)] public static extern void FT_Open_Face();

        [DllImport(_libavfilter)] public static extern void FT_Outline_Check();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Copy();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Decompose();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Done();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Embolden();
        [DllImport(_libavfilter)] public static extern void FT_Outline_EmboldenXY();
        [DllImport(_libavfilter)] public static extern void FT_Outline_GetInsideBorder();
        [DllImport(_libavfilter)] public static extern void FT_Outline_GetOutsideBorder();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Get_Bitmap();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Get_CBox();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Get_Orientation();
        [DllImport(_libavfilter)] public static extern void FT_Outline_New();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Render();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Reverse();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Transform();
        [DllImport(_libavfilter)] public static extern void FT_Outline_Translate();

        [DllImport(_libavfilter)] public static extern void FT_Palette_Data_Get();
        [DllImport(_libavfilter)] public static extern void FT_Palette_Select();
        [DllImport(_libavfilter)] public static extern void FT_Palette_Set_Foreground_Color();

        [DllImport(_libavfilter)] public static extern void FT_Property_Get();
        [DllImport(_libavfilter)] public static extern void FT_Property_Set();

        [DllImport(_libavfilter)] public static extern void FT_Reference_Face();
        [DllImport(_libavfilter)] public static extern void FT_Reference_Library();

        [DllImport(_libavfilter)] public static extern void FT_Remove_Module();
        [DllImport(_libavfilter)] public static extern void FT_Render_Glyph();
        [DllImport(_libavfilter)] public static extern void FT_Request_Size();
        [DllImport(_libavfilter)] public static extern void FT_RoundFix();
        [DllImport(_libavfilter)] public static extern void FT_Select_Charmap();
        [DllImport(_libavfilter)] public static extern void FT_Select_Size();

        [DllImport(_libavfilter)] public static extern void FT_Set_Char_Size();
        [DllImport(_libavfilter)] public static extern void FT_Set_Charmap();
        [DllImport(_libavfilter)] public static extern void FT_Set_Debug_Hook();
        [DllImport(_libavfilter)] public static extern void FT_Set_Default_Log_Handler();
        [DllImport(_libavfilter)] public static extern void FT_Set_Default_Properties();
        [DllImport(_libavfilter)] public static extern void FT_Set_Log_Handler();
        [DllImport(_libavfilter)] public static extern void FT_Set_MM_Blend_Coordinates();
        [DllImport(_libavfilter)] public static extern void FT_Set_MM_Design_Coordinates();
        [DllImport(_libavfilter)] public static extern void FT_Set_MM_WeightVector();
        [DllImport(_libavfilter)] public static extern void FT_Set_Named_Instance();
        [DllImport(_libavfilter)] public static extern void FT_Set_Pixel_Sizes();
        [DllImport(_libavfilter)] public static extern void FT_Set_Renderer();
        [DllImport(_libavfilter)] public static extern void FT_Set_Transform();
        [DllImport(_libavfilter)] public static extern void FT_Set_Var_Blend_Coordinates();
        [DllImport(_libavfilter)] public static extern void FT_Set_Var_Design_Coordinates();

        [DllImport(_libavfilter)] public static extern void FT_Sfnt_Table_Info();
        [DllImport(_libavfilter)] public static extern void FT_Sin();
        [DllImport(_libavfilter)] public static extern void FT_Stream_OpenLZW();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_BeginSubPath();

        [DllImport(_libavfilter)] public static extern void FT_Stroker_ConicTo();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_CubicTo();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_Done();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_EndSubPath();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_Export();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_ExportBorder();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_GetBorderCounts();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_GetCounts();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_LineTo();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_New();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_ParseOutline();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_Rewind();
        [DllImport(_libavfilter)] public static extern void FT_Stroker_Set();

        [DllImport(_libavfilter)] public static extern void FT_Tan();
        [DllImport(_libavfilter)] public static extern void FT_Trace_Set_Default_Level();
        [DllImport(_libavfilter)] public static extern void FT_Trace_Set_Level();

        [DllImport(_libavfilter)] public static extern void FT_Vector_From_Polar();
        [DllImport(_libavfilter)] public static extern void FT_Vector_Length();
        [DllImport(_libavfilter)] public static extern void FT_Vector_Polarize();
        [DllImport(_libavfilter)] public static extern void FT_Vector_Rotate();
        [DllImport(_libavfilter)] public static extern void FT_Vector_Transform();
        [DllImport(_libavfilter)] public static extern void FT_Vector_Unit();

        [DllImport(_libavfilter)] public static extern void TT_New_Context();
        [DllImport(_libavfilter)] public static extern void TT_RunIns();

        [DllImport(_libavfilter)] public static extern int av_buffersink_get_ch_layout(IntPtr AVFilterContext,IntPtr ch_layout);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_channels(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern AVColorRange av_buffersink_get_color_range(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern AVColorSpace av_buffersink_get_colorspace(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_format(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_frame(IntPtr AVFilterContext,IntPtr AVFrame);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_frame_flags(IntPtr AVFilterContext,IntPtr AVFrame,int flags);
        [DllImport(_libavfilter)] public static extern AVRational av_buffersink_get_frame_rate(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_h(IntPtr AVFilterContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterContext"></param>
        /// <returns>AVBufferRef * </returns>
        [DllImport(_libavfilter)] public static extern IntPtr av_buffersink_get_hw_frames_ctx(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern AVRational av_buffersink_get_sample_aspect_ratio(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_sample_rate(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_samples(IntPtr AVFilterContext,IntPtr AVFrame,int nb_samples);
        [DllImport(_libavfilter)] public static extern AVRational av_buffersink_get_time_base(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern AVMediaType av_buffersink_get_type(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern int av_buffersink_get_w(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern void av_buffersink_set_frame_size(IntPtr AVFilterContext,uint frame_size);
       
        
        [DllImport(_libavfilter)] public static extern int av_buffersrc_add_frame(IntPtr AVFilterContext,IntPtr AVFrame);
        [DllImport(_libavfilter)] public static extern int av_buffersrc_add_frame_flags(IntPtr AVFilterContext,IntPtr AVFrame,int flags);
        [DllImport(_libavfilter)] public static extern int av_buffersrc_close(IntPtr AVFilterContext,long pts,uint flags);
        [DllImport(_libavfilter)] public static extern void av_buffersrc_get_nb_failed_requests();
        [DllImport(_libavfilter)] public static extern IntPtr av_buffersrc_parameters_alloc();
        [DllImport(_libavfilter)] public static extern int av_buffersrc_parameters_set(IntPtr AVFilterContext,IntPtr AVBufferSrcParameters);
        [DllImport(_libavfilter)] public static extern int av_buffersrc_write_frame(IntPtr AVFilterContext,IntPtr AVFrame);
       
        [DllImport(_libavfilter)] public static extern void av_filter_ffversion();
        [DllImport(_libavfilter)] public static extern IntPtr av_filter_iterate(ref IntPtr opaque);
        [Obsolete("this function should never be called by users")]
        [DllImport(_libavfilter)] public static extern int avfilter_config_links(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern void avfilter_configuration();
        [DllImport(_libavfilter)] public static extern void avfilter_filter_pad_count();
        [DllImport(_libavfilter)] public static extern void avfilter_free(IntPtr AVFilterContext);
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_get_by_name(string name);
        [DllImport(_libavfilter)] public static extern void avfilter_get_class();
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_graph_alloc();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterGraph"></param>
        /// <param name="AVFilter"></param>
        /// <param name="name"></param>
        /// <returns>AVFilterContext*</returns>
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_graph_alloc_filter(IntPtr AVFilterGraph,IntPtr AVFilter,string name);
        [DllImport(_libavfilter)] public static extern void avfilter_graph_config();
        [DllImport(_libavfilter)] public static extern int avfilter_graph_create_filter(ref IntPtr AVFilterContext,IntPtr AVFilter,string name,string args,IntPtr opaque,IntPtr AVFilterGraph);
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_graph_dump(IntPtr AVfilterGraph,string options);
        [DllImport(_libavfilter)] public static extern void avfilter_graph_free(ref IntPtr AVFilterGraph);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterGraph"></param>
        /// <param name="name"></param>
        /// <returns>AVFilterContext*</returns>
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_graph_get_filter(IntPtr AVFilterGraph,string name);
        [DllImport(_libavfilter)] public static extern int avfilter_graph_parse();
        [DllImport(_libavfilter)] public static extern void avfilter_graph_parse2();
        [DllImport(_libavfilter)] public static extern void avfilter_graph_parse_ptr();
        [DllImport(_libavfilter)] public static extern int avfilter_graph_queue_command(IntPtr AVFilterGraph,string target,string cmd,string args,int flags,double ts);
        [DllImport(_libavfilter)] public static extern void avfilter_graph_request_oldest();
        [DllImport(_libavfilter)] public static extern void avfilter_graph_segment_apply();
        [DllImport(_libavfilter)] public static extern int avfilter_graph_segment_apply_opts(IntPtr AVFilterGraphSegment,int flags);
        [DllImport(_libavfilter)] public static extern int avfilter_graph_segment_create_filters(IntPtr AVFilterGraphSegment, int flags);
        [DllImport(_libavfilter)] public static extern void avfilter_graph_segment_free(ref IntPtr AVFilterGraphSegment);

        [DllImport(_libavfilter)] public static extern int avfilter_graph_segment_init(IntPtr AVFilterGraphSegment, int flags);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterGraphSegment">AVFilterGraphSegment*</param>
        /// <param name="flags"></param>
        /// <param name="inputs">AVFilterInOut**</param>
        /// <param name="outputs">AVFilterInOut**</param>
        /// <returns></returns>
        [DllImport(_libavfilter)] public static extern int avfilter_graph_segment_link(IntPtr AVFilterGraphSegment, int flags,ref IntPtr inputs,ref IntPtr outputs );
        [DllImport(_libavfilter)] public static extern void avfilter_graph_segment_parse();
        [DllImport(_libavfilter)] public static extern int avfilter_graph_send_command(IntPtr AVFilterGraph,string target,string cmd,string args,IntPtr res,int res_len,int flags);
        [DllImport(_libavfilter)] public static extern void avfilter_graph_set_auto_convert();
        [DllImport(_libavfilter)] public static extern int avfilter_init_dict(IntPtr AVFilterContext,ref IntPtr AVDictionary);
        [DllImport(_libavfilter)] public static extern int avfilter_init_str(IntPtr AVFilterContext,string args);
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_inout_alloc();
        [DllImport(_libavfilter)] public static extern void avfilter_inout_free(ref IntPtr AVFilterInOut);
        [DllImport(_libavfilter)] public static extern void avfilter_insert_filter();
        [DllImport(_libavfilter)] public static extern void avfilter_license();
        [DllImport(_libavfilter)] public static extern void avfilter_link();
        [Obsolete(" this function should never be called by users")]
        [DllImport(_libavfilter)] public static extern void avfilter_link_free(ref IntPtr AVFilterLink);
        [DllImport(_libavfilter)] public static extern IntPtr avfilter_pad_get_name(IntPtr AVFilterPad,int pad_idx);
        [DllImport(_libavfilter)] public static extern AVMediaType avfilter_pad_get_type(IntPtr AVFilterPad, int pad_idx);
        [DllImport(_libavfilter)] public static extern int avfilter_process_command(IntPtr AVFilterContext,string command,string args,IntPtr res,int res_len,int flags);
        [DllImport(_libavfilter)] public static extern void avfilter_version();

        [DllImport(_libavfilter)] public static extern void flite_lang_list();
        [DllImport(_libavfilter)] public static extern void flite_lang_list_length();
        [DllImport(_libavfilter)] public static extern void flite_voice_list();

        [DllImport(_libavfilter)] public static extern void memcpy_layout();

        [DllImport(_libavfilter)] public static extern void pl_alpha_overlay();
        [DllImport(_libavfilter)] public static extern void pl_bit_encoding_equal();

        [DllImport(_libavfilter)] public static extern void pl_buf_copy();
        [DllImport(_libavfilter)] public static extern void pl_buf_create();
        [DllImport(_libavfilter)] public static extern void pl_buf_destroy();
        [DllImport(_libavfilter)] public static extern void pl_buf_export();
        [DllImport(_libavfilter)] public static extern void pl_buf_poll();
        [DllImport(_libavfilter)] public static extern void pl_buf_read();
        [DllImport(_libavfilter)] public static extern void pl_buf_recreate();
        [DllImport(_libavfilter)] public static extern void pl_buf_write();

        [DllImport(_libavfilter)] public static extern void pl_cache_create();
        [DllImport(_libavfilter)] public static extern void pl_cache_default_params();
        [DllImport(_libavfilter)] public static extern void pl_cache_destroy();
        [DllImport(_libavfilter)] public static extern void pl_cache_get();
        [DllImport(_libavfilter)] public static extern void pl_cache_iterate();
        [DllImport(_libavfilter)] public static extern void pl_cache_load();
        [DllImport(_libavfilter)] public static extern void pl_cache_load_ex();
        [DllImport(_libavfilter)] public static extern void pl_cache_objects();
        [DllImport(_libavfilter)] public static extern void pl_cache_reset();
        [DllImport(_libavfilter)] public static extern void pl_cache_save();
        [DllImport(_libavfilter)] public static extern void pl_cache_save_ex();
        [DllImport(_libavfilter)] public static extern void pl_cache_set();
        [DllImport(_libavfilter)] public static extern void pl_cache_signature();
        [DllImport(_libavfilter)] public static extern void pl_cache_size();
        [DllImport(_libavfilter)] public static extern void pl_cache_try_set();

        [DllImport(_libavfilter)] public static extern void pl_chroma_location_offset();

        [DllImport(_libavfilter)] public static extern void pl_color_adjustment_neutral();
        [DllImport(_libavfilter)] public static extern void pl_color_delinearize();
        [DllImport(_libavfilter)] public static extern void pl_color_levels_guess();
        [DllImport(_libavfilter)] public static extern void pl_color_linearize();
        [DllImport(_libavfilter)] public static extern void pl_color_map_default_params();
        [DllImport(_libavfilter)] public static extern void pl_color_map_high_quality_params();
        [DllImport(_libavfilter)] public static extern void pl_color_primaries_guess();
        [DllImport(_libavfilter)] public static extern void pl_color_primaries_is_wide_gamut();
        [DllImport(_libavfilter)] public static extern void pl_color_primaries_name();
        [DllImport(_libavfilter)] public static extern void pl_color_primaries_names();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_decode();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_equal();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_hdtv();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_jpeg();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_merge();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_normalize();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_rgb();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_sdtv();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_uhdtv();
        [DllImport(_libavfilter)] public static extern void pl_color_repr_unknown();
        [DllImport(_libavfilter)] public static extern void pl_color_space_bt2020_hlg();
        [DllImport(_libavfilter)] public static extern void pl_color_space_bt709();
        [DllImport(_libavfilter)] public static extern void pl_color_space_equal();
        [DllImport(_libavfilter)] public static extern void pl_color_space_hdr10();
        [DllImport(_libavfilter)] public static extern void pl_color_space_infer();
        [DllImport(_libavfilter)] public static extern void pl_color_space_infer_map();
        [DllImport(_libavfilter)] public static extern void pl_color_space_infer_ref();
        [DllImport(_libavfilter)] public static extern void pl_color_space_is_black_scaled();
        [DllImport(_libavfilter)] public static extern void pl_color_space_is_hdr();
        [DllImport(_libavfilter)] public static extern void pl_color_space_merge();
        [DllImport(_libavfilter)] public static extern void pl_color_space_monitor();
        [DllImport(_libavfilter)] public static extern void pl_color_space_nominal_luma_ex();
        [DllImport(_libavfilter)] public static extern void pl_color_space_srgb();
        [DllImport(_libavfilter)] public static extern void pl_color_space_unknown();
        [DllImport(_libavfilter)] public static extern void pl_color_system_guess_ycbcr();
        [DllImport(_libavfilter)] public static extern void pl_color_system_is_linear();
        [DllImport(_libavfilter)] public static extern void pl_color_system_is_ycbcr_like();
        [DllImport(_libavfilter)] public static extern void pl_color_system_name();
        [DllImport(_libavfilter)] public static extern void pl_color_system_names();
        [DllImport(_libavfilter)] public static extern void pl_color_transfer_name();
        [DllImport(_libavfilter)] public static extern void pl_color_transfer_names();
        [DllImport(_libavfilter)] public static extern void pl_color_transfer_nominal_peak();

        [DllImport(_libavfilter)] public static extern void pl_deband_default_params();
        [DllImport(_libavfilter)] public static extern void pl_deinterlace_default_params();
        [DllImport(_libavfilter)] public static extern void pl_desc_access_glsl_name();
        [DllImport(_libavfilter)] public static extern void pl_desc_namespace();
       
        [DllImport(_libavfilter)] public static extern void pl_dispatch_abort();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_begin();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_callback();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_compute();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_create();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_destroy();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_finish();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_load();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_reset_frame();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_save();
        [DllImport(_libavfilter)] public static extern void pl_dispatch_vertex();
       
        [DllImport(_libavfilter)] public static extern void pl_distort_default_params();
        [DllImport(_libavfilter)] public static extern void pl_dither_default_params();
      
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_atkinson();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_burkes();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_false_fs();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_floyd_steinberg();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_jarvis_judice_ninke();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_kernels();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_shmem_req();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_sierra2();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_sierra3();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_sierra_lite();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_simple();
        [DllImport(_libavfilter)] public static extern void pl_error_diffusion_stucki();
       
        [DllImport(_libavfilter)] public static extern void pl_filter_bicubic();
        [DllImport(_libavfilter)] public static extern void pl_filter_bilinear();
        [DllImport(_libavfilter)] public static extern void pl_filter_box();
        [DllImport(_libavfilter)] public static extern void pl_filter_catmull_rom();
        [DllImport(_libavfilter)] public static extern void pl_filter_config_eq();
        [DllImport(_libavfilter)] public static extern void pl_filter_configs();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_ginseng();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_hann();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_jinc();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_lanczos();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_lanczos4sharpest();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_lanczossharp();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_robidoux();
        [DllImport(_libavfilter)] public static extern void pl_filter_ewa_robidouxsharp();
        [DllImport(_libavfilter)] public static extern void pl_filter_free();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_bcspline();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_bicubic();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_blackman();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_bohman();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_box();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_catmull_rom();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_cosine();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_cubic();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_eq();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_gaussian();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_hamming();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_hann();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_hermite();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_jinc();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_kaiser();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_mitchell();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_oversample();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_presets();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_quadratic();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_robidoux();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_robidouxsharp();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_sinc();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_sphinx();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_spline16();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_spline36();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_spline64();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_triangle();
        [DllImport(_libavfilter)] public static extern void pl_filter_function_welch();
        [DllImport(_libavfilter)] public static extern void pl_filter_functions();
        [DllImport(_libavfilter)] public static extern void pl_filter_gaussian();
        [DllImport(_libavfilter)] public static extern void pl_filter_generate();
        [DllImport(_libavfilter)] public static extern void pl_filter_ginseng();
        [DllImport(_libavfilter)] public static extern void pl_filter_hermite();
        [DllImport(_libavfilter)] public static extern void pl_filter_lanczos();
        [DllImport(_libavfilter)] public static extern void pl_filter_mitchell();
        [DllImport(_libavfilter)] public static extern void pl_filter_mitchell_clamp();
        [DllImport(_libavfilter)] public static extern void pl_filter_nearest();
        [DllImport(_libavfilter)] public static extern void pl_filter_oversample();
        [DllImport(_libavfilter)] public static extern void pl_filter_presets();
        [DllImport(_libavfilter)] public static extern void pl_filter_robidoux();
        [DllImport(_libavfilter)] public static extern void pl_filter_robidouxsharp();
        [DllImport(_libavfilter)] public static extern void pl_filter_sample();
        [DllImport(_libavfilter)] public static extern void pl_filter_sinc();
        [DllImport(_libavfilter)] public static extern void pl_filter_spline16();
        [DllImport(_libavfilter)] public static extern void pl_filter_spline36();
        [DllImport(_libavfilter)] public static extern void pl_filter_spline64();
        
        [DllImport(_libavfilter)] public static extern void pl_find_error_diffusion_kernel();
        [DllImport(_libavfilter)] public static extern void pl_find_filter_config();
        [DllImport(_libavfilter)] public static extern void pl_find_filter_function();
        [DllImport(_libavfilter)] public static extern void pl_find_filter_function_preset();
        [DllImport(_libavfilter)] public static extern void pl_find_filter_preset();
        [DllImport(_libavfilter)] public static extern void pl_find_fmt();
        [DllImport(_libavfilter)] public static extern void pl_find_fourcc();
        [DllImport(_libavfilter)] public static extern void pl_find_gamut_map_function();
        [DllImport(_libavfilter)] public static extern void pl_find_named_fmt();
        [DllImport(_libavfilter)] public static extern void pl_find_option();
        [DllImport(_libavfilter)] public static extern void pl_find_tone_map_function();
        [DllImport(_libavfilter)] public static extern void pl_find_vertex_fmt();

        [DllImport(_libavfilter)] public static extern void pl_fix_ver();

        [DllImport(_libavfilter)] public static extern void pl_fmt_has_modifier();
        [DllImport(_libavfilter)] public static extern void pl_fmt_is_float();
        [DllImport(_libavfilter)] public static extern void pl_fmt_is_ordered();
       
        [DllImport(_libavfilter)] public static extern void pl_frame_clear_rgba();
        [DllImport(_libavfilter)] public static extern void pl_frame_clear_tiles();
        [DllImport(_libavfilter)] public static extern void pl_frame_from_swapchain();
        [DllImport(_libavfilter)] public static extern void pl_frame_is_cropped();
        [DllImport(_libavfilter)] public static extern void pl_frame_mix_current();
        [DllImport(_libavfilter)] public static extern void pl_frame_mix_nearest();
        [DllImport(_libavfilter)] public static extern void pl_frame_mixers();
        [DllImport(_libavfilter)] public static extern void pl_frame_set_chroma_location();
        [DllImport(_libavfilter)] public static extern void pl_frames_infer();
        [DllImport(_libavfilter)] public static extern void pl_frames_infer_mix();
       
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_absolute();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_clip();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_darken();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_desaturate();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_functions();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_generate();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_highlight();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_linear();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_params_equal();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_params_noop();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_perceptual();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_relative();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_sample();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_saturation();
        [DllImport(_libavfilter)] public static extern void pl_gamut_map_softclip();
       
        [DllImport(_libavfilter)] public static extern void pl_generate_bayer_matrix();
        [DllImport(_libavfilter)] public static extern void pl_generate_blue_noise();
        [DllImport(_libavfilter)] public static extern void pl_get_adaptation_matrix();
        [DllImport(_libavfilter)] public static extern void pl_get_color_mapping_matrix();
        [DllImport(_libavfilter)] public static extern void pl_get_cone_matrix();
        [DllImport(_libavfilter)] public static extern void pl_get_detected_hdr_metadata();
        [DllImport(_libavfilter)] public static extern void pl_get_rgb2xyz_matrix();
        [DllImport(_libavfilter)] public static extern void pl_get_xyz2rgb_matrix();
       
        [DllImport(_libavfilter)] public static extern void pl_gpu_finish();
        [DllImport(_libavfilter)] public static extern void pl_gpu_flush();
        [DllImport(_libavfilter)] public static extern void pl_gpu_is_failed();
        [DllImport(_libavfilter)] public static extern void pl_gpu_set_cache();
        
        [DllImport(_libavfilter)] public static extern void pl_hdr_metadata_contains();
        [DllImport(_libavfilter)] public static extern void pl_hdr_metadata_empty();
        [DllImport(_libavfilter)] public static extern void pl_hdr_metadata_equal();
        [DllImport(_libavfilter)] public static extern void pl_hdr_metadata_hdr10();
        [DllImport(_libavfilter)] public static extern void pl_hdr_metadata_merge();
        [DllImport(_libavfilter)] public static extern void pl_hdr_rescale();
       
        [DllImport(_libavfilter)] public static extern void pl_icc_close();
        [DllImport(_libavfilter)] public static extern void pl_icc_decode();
        [DllImport(_libavfilter)] public static extern void pl_icc_default_params();
        [DllImport(_libavfilter)] public static extern void pl_icc_encode();
        [DllImport(_libavfilter)] public static extern void pl_icc_open();
        [DllImport(_libavfilter)] public static extern void pl_icc_profile_compute_signature();
        [DllImport(_libavfilter)] public static extern void pl_icc_profile_equal();
        [DllImport(_libavfilter)] public static extern void pl_icc_update();

        [DllImport(_libavfilter)] public static extern void pl_ipt_ipt2lms();
        [DllImport(_libavfilter)] public static extern void pl_ipt_lms2ipt();
        [DllImport(_libavfilter)] public static extern void pl_ipt_lms2rgb();
        [DllImport(_libavfilter)] public static extern void pl_ipt_rgb2lms();

        [DllImport(_libavfilter)] public static extern void pl_log_color();
        [DllImport(_libavfilter)] public static extern void pl_log_create_349();
        [DllImport(_libavfilter)] public static extern void pl_log_default_params();
        [DllImport(_libavfilter)] public static extern void pl_log_destroy();
        [DllImport(_libavfilter)] public static extern void pl_log_level_update();
        [DllImport(_libavfilter)] public static extern void pl_log_simple();
        [DllImport(_libavfilter)] public static extern void pl_log_update();

        [DllImport(_libavfilter)] public static extern void pl_lut_free();
        [DllImport(_libavfilter)] public static extern void pl_lut_parse_cube();

        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_apply();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_apply_rc();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_identity();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_invert();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_mul();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_rmul();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_rotation();
        [DllImport(_libavfilter)] public static extern void pl_matrix2x2_scale();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_apply();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_apply_rc();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_identity();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_invert();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_mul();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_rmul();
        [DllImport(_libavfilter)] public static extern void pl_matrix3x3_scale();

        [DllImport(_libavfilter)] public static extern void pl_mpv_user_shader_destroy();
        [DllImport(_libavfilter)] public static extern void pl_mpv_user_shader_parse();

        [DllImport(_libavfilter)] public static extern void pl_needs_film_grain();

        [DllImport(_libavfilter)] public static extern void pl_num_error_diffusion_kernels();
        [DllImport(_libavfilter)] public static extern void pl_num_filter_configs();
        [DllImport(_libavfilter)] public static extern void pl_num_filter_function_presets();
        [DllImport(_libavfilter)] public static extern void pl_num_filter_functions();
        [DllImport(_libavfilter)] public static extern void pl_num_filter_presets();
        [DllImport(_libavfilter)] public static extern void pl_num_frame_mixers();
        [DllImport(_libavfilter)] public static extern void pl_num_gamut_map_functions();
        [DllImport(_libavfilter)] public static extern void pl_num_scale_filters();
        [DllImport(_libavfilter)] public static extern void pl_num_tone_map_functions();

        [DllImport(_libavfilter)] public static extern void pl_option_count();
        [DllImport(_libavfilter)] public static extern void pl_option_list();
        [DllImport(_libavfilter)] public static extern void pl_options_add_hook();
        [DllImport(_libavfilter)] public static extern void pl_options_alloc();
        [DllImport(_libavfilter)] public static extern void pl_options_free();
        [DllImport(_libavfilter)] public static extern void pl_options_get();
        [DllImport(_libavfilter)] public static extern void pl_options_insert_hook();
        [DllImport(_libavfilter)] public static extern void pl_options_iterate();
        [DllImport(_libavfilter)] public static extern void pl_options_load();
        [DllImport(_libavfilter)] public static extern void pl_options_remove_hook_at();
        [DllImport(_libavfilter)] public static extern void pl_options_reset();
        [DllImport(_libavfilter)] public static extern void pl_options_save();
        [DllImport(_libavfilter)] public static extern void pl_options_set_str();

        [DllImport(_libavfilter)] public static extern void pl_pass_create();
        [DllImport(_libavfilter)] public static extern void pl_pass_destroy();
        [DllImport(_libavfilter)] public static extern void pl_pass_run();

        [DllImport(_libavfilter)] public static extern void pl_peak_detect_default_params();
        [DllImport(_libavfilter)] public static extern void pl_peak_detect_high_quality_params();

        [DllImport(_libavfilter)] public static extern void pl_plane_data_align();
        [DllImport(_libavfilter)] public static extern void pl_plane_data_from_comps();
        [DllImport(_libavfilter)] public static extern void pl_plane_data_from_mask();
        [DllImport(_libavfilter)] public static extern void pl_plane_find_fmt();

        [DllImport(_libavfilter)] public static extern void pl_primaries_clip();
        [DllImport(_libavfilter)] public static extern void pl_primaries_compatible();
        [DllImport(_libavfilter)] public static extern void pl_primaries_superset();
        [DllImport(_libavfilter)] public static extern void pl_primaries_valid();

        [DllImport(_libavfilter)] public static extern void pl_queue_create();
        [DllImport(_libavfilter)] public static extern void pl_queue_destroy();
        [DllImport(_libavfilter)] public static extern void pl_queue_estimate_fps();
        [DllImport(_libavfilter)] public static extern void pl_queue_estimate_vps();
        [DllImport(_libavfilter)] public static extern void pl_queue_num_frames();
        [DllImport(_libavfilter)] public static extern void pl_queue_peek();
        [DllImport(_libavfilter)] public static extern void pl_queue_pts_offset();
        [DllImport(_libavfilter)] public static extern void pl_queue_push();
        [DllImport(_libavfilter)] public static extern void pl_queue_push_block();
        [DllImport(_libavfilter)] public static extern void pl_queue_reset();
        [DllImport(_libavfilter)] public static extern void pl_queue_update();

        [DllImport(_libavfilter)] public static extern void pl_raw_primaries_equal();
        [DllImport(_libavfilter)] public static extern void pl_raw_primaries_get();
        [DllImport(_libavfilter)] public static extern void pl_raw_primaries_merge();
        [DllImport(_libavfilter)] public static extern void pl_raw_primaries_similar();

        [DllImport(_libavfilter)] public static extern void pl_recreate_plane();

        [DllImport(_libavfilter)] public static extern void pl_rect2d_normalize();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_aspect();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_aspect_fit();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_aspect_set();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_normalize();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_offset();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_rotate();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_round();
        [DllImport(_libavfilter)] public static extern void pl_rect2df_stretch();
        [DllImport(_libavfilter)] public static extern void pl_rect3d_normalize();
        [DllImport(_libavfilter)] public static extern void pl_rect3df_normalize();
        [DllImport(_libavfilter)] public static extern void pl_rect3df_round();

        [DllImport(_libavfilter)] public static extern void pl_render_default_params();
        [DllImport(_libavfilter)] public static extern void pl_render_fast_params();
        [DllImport(_libavfilter)] public static extern void pl_render_high_quality_params();
        [DllImport(_libavfilter)] public static extern void pl_render_image();
        [DllImport(_libavfilter)] public static extern void pl_render_image_mix();

        [DllImport(_libavfilter)] public static extern void pl_renderer_create();
        [DllImport(_libavfilter)] public static extern void pl_renderer_destroy();
        [DllImport(_libavfilter)] public static extern void pl_renderer_flush_cache();
        [DllImport(_libavfilter)] public static extern void pl_renderer_get_errors();
        [DllImport(_libavfilter)] public static extern void pl_renderer_get_hdr_metadata();
        [DllImport(_libavfilter)] public static extern void pl_renderer_load();
        [DllImport(_libavfilter)] public static extern void pl_renderer_reset_errors();
        [DllImport(_libavfilter)] public static extern void pl_renderer_save();

        [DllImport(_libavfilter)] public static extern void pl_reset_detected_peak();
        [DllImport(_libavfilter)] public static extern void pl_scale_filters();

        [DllImport(_libavfilter)] public static extern void pl_shader_alloc();
        [DllImport(_libavfilter)] public static extern void pl_shader_color_map();
        [DllImport(_libavfilter)] public static extern void pl_shader_color_map_ex();
        [DllImport(_libavfilter)] public static extern void pl_shader_cone_distort();
        [DllImport(_libavfilter)] public static extern void pl_shader_custom_lut();
        [DllImport(_libavfilter)] public static extern void pl_shader_deband();
        [DllImport(_libavfilter)] public static extern void pl_shader_decode_color();
        [DllImport(_libavfilter)] public static extern void pl_shader_deinterlace();
        [DllImport(_libavfilter)] public static extern void pl_shader_delinearize();
        [DllImport(_libavfilter)] public static extern void pl_shader_detect_peak();
        [DllImport(_libavfilter)] public static extern void pl_shader_distort();
        [DllImport(_libavfilter)] public static extern void pl_shader_dither();
        [DllImport(_libavfilter)] public static extern void pl_shader_dovi_reshape();
        [DllImport(_libavfilter)] public static extern void pl_shader_encode_color();
        [DllImport(_libavfilter)] public static extern void pl_shader_error_diffusion();
        [DllImport(_libavfilter)] public static extern void pl_shader_extract_features();
        [DllImport(_libavfilter)] public static extern void pl_shader_film_grain();
        [DllImport(_libavfilter)] public static extern void pl_shader_finalize();
        [DllImport(_libavfilter)] public static extern void pl_shader_free();
        [DllImport(_libavfilter)] public static extern void pl_shader_info_deref();
        [DllImport(_libavfilter)] public static extern void pl_shader_info_ref();
        [DllImport(_libavfilter)] public static extern void pl_shader_is_compute();
        [DllImport(_libavfilter)] public static extern void pl_shader_is_failed();
        [DllImport(_libavfilter)] public static extern void pl_shader_linearize();
        [DllImport(_libavfilter)] public static extern void pl_shader_obj_destroy();
        [DllImport(_libavfilter)] public static extern void pl_shader_output_size();
        [DllImport(_libavfilter)] public static extern void pl_shader_reset();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_bicubic();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_bilinear();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_direct();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_gaussian();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_hermite();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_nearest();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_ortho2();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_oversample();
        [DllImport(_libavfilter)] public static extern void pl_shader_sample_polar();
        [DllImport(_libavfilter)] public static extern void pl_shader_set_alpha();
        [DllImport(_libavfilter)] public static extern void pl_shader_sigmoidize();
        [DllImport(_libavfilter)] public static extern void pl_shader_unsigmoidize();

        [DllImport(_libavfilter)] public static extern void pl_sigmoid_default_params();
        [DllImport(_libavfilter)] public static extern void pl_std140_layout();
        [DllImport(_libavfilter)] public static extern void pl_std430_layout();

        [DllImport(_libavfilter)] public static extern void pl_tex_blit();
        [DllImport(_libavfilter)] public static extern void pl_tex_clear();
        [DllImport(_libavfilter)] public static extern void pl_tex_clear_ex();
        [DllImport(_libavfilter)] public static extern void pl_tex_create();
        [DllImport(_libavfilter)] public static extern void pl_tex_destroy();
        [DllImport(_libavfilter)] public static extern void pl_tex_download();
        [DllImport(_libavfilter)] public static extern void pl_tex_invalidate();
        [DllImport(_libavfilter)] public static extern void pl_tex_poll();
        [DllImport(_libavfilter)] public static extern void pl_tex_recreate();
        [DllImport(_libavfilter)] public static extern void pl_tex_upload();

        [DllImport(_libavfilter)] public static extern void pl_timer_create();
        [DllImport(_libavfilter)] public static extern void pl_timer_destroy();
        [DllImport(_libavfilter)] public static extern void pl_timer_query();

        [DllImport(_libavfilter)] public static extern void pl_tone_map_bt2390();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_bt2446a();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_clip();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_functions();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_gamma();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_generate();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_hable();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_linear();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_linear_light();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_mobius();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_params_equal();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_params_infer();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_params_noop();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_reinhard();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_sample();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_spline();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_st2094_10();
        [DllImport(_libavfilter)] public static extern void pl_tone_map_st2094_40();

        [DllImport(_libavfilter)] public static extern void pl_transform2x2_apply();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_apply_rc();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_bounds();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_identity();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_invert();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_mul();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_rmul();
        [DllImport(_libavfilter)] public static extern void pl_transform2x2_scale();
        [DllImport(_libavfilter)] public static extern void pl_transform3x3_apply();
        [DllImport(_libavfilter)] public static extern void pl_transform3x3_apply_rc();
        [DllImport(_libavfilter)] public static extern void pl_transform3x3_identity();
        [DllImport(_libavfilter)] public static extern void pl_transform3x3_invert();
        [DllImport(_libavfilter)] public static extern void pl_transform3x3_scale();

        [DllImport(_libavfilter)] public static extern void pl_upload_plane();

        [DllImport(_libavfilter)] public static extern void pl_var_float();
        [DllImport(_libavfilter)] public static extern void pl_var_from_fmt();
        [DllImport(_libavfilter)] public static extern void pl_var_glsl_type_name();
        [DllImport(_libavfilter)] public static extern void pl_var_glsl_types();
        [DllImport(_libavfilter)] public static extern void pl_var_host_layout();
        [DllImport(_libavfilter)] public static extern void pl_var_int();
        [DllImport(_libavfilter)] public static extern void pl_var_ivec2();
        [DllImport(_libavfilter)] public static extern void pl_var_ivec3();
        [DllImport(_libavfilter)] public static extern void pl_var_ivec4();
        [DllImport(_libavfilter)] public static extern void pl_var_mat2();
        [DllImport(_libavfilter)] public static extern void pl_var_mat2x3();
        [DllImport(_libavfilter)] public static extern void pl_var_mat2x4();
        [DllImport(_libavfilter)] public static extern void pl_var_mat3();
        [DllImport(_libavfilter)] public static extern void pl_var_mat3x4();
        [DllImport(_libavfilter)] public static extern void pl_var_mat4();
        [DllImport(_libavfilter)] public static extern void pl_var_mat4x2();
        [DllImport(_libavfilter)] public static extern void pl_var_mat4x3();
        [DllImport(_libavfilter)] public static extern void pl_var_type_size();
        [DllImport(_libavfilter)] public static extern void pl_var_uint();
        [DllImport(_libavfilter)] public static extern void pl_var_uvec2();
        [DllImport(_libavfilter)] public static extern void pl_var_uvec3();
        [DllImport(_libavfilter)] public static extern void pl_var_uvec4();
        [DllImport(_libavfilter)] public static extern void pl_var_vec2();
        [DllImport(_libavfilter)] public static extern void pl_var_vec3();
        [DllImport(_libavfilter)] public static extern void pl_var_vec4();

        [DllImport(_libavfilter)] public static extern void pl_version();

        [DllImport(_libavfilter)] public static extern void pl_vision_achromatopsia();
        [DllImport(_libavfilter)] public static extern void pl_vision_deuteranomaly();
        [DllImport(_libavfilter)] public static extern void pl_vision_deuteranopia();
        [DllImport(_libavfilter)] public static extern void pl_vision_monochromacy();
        [DllImport(_libavfilter)] public static extern void pl_vision_normal();
        [DllImport(_libavfilter)] public static extern void pl_vision_protanomaly();
        [DllImport(_libavfilter)] public static extern void pl_vision_protanopia();
        [DllImport(_libavfilter)] public static extern void pl_vision_tritanomaly();
        [DllImport(_libavfilter)] public static extern void pl_vision_tritanopia();

        [DllImport(_libavfilter)] public static extern void pl_vk_inst_create();
        [DllImport(_libavfilter)] public static extern void pl_vk_inst_default_params();
        [DllImport(_libavfilter)] public static extern void pl_vk_inst_destroy();

        [DllImport(_libavfilter)] public static extern void pl_vulkan_choose_device();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_create();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_default_params();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_destroy();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_get();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_hold_ex();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_import();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_num_recommended_extensions();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_recommended_extensions();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_recommended_features();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_release_ex();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_required_features();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_sem_create();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_sem_destroy();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_unwrap();
        [DllImport(_libavfilter)] public static extern void pl_vulkan_wrap();

        [DllImport(_libavfilter)] public static extern void pl_white_from_tem();
    }
}