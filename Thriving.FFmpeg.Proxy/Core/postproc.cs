using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public partial class Core
    {
        private const string _libpostproc = "postproc-58.dll";

        [DllImport(_libpostproc)] public static extern void postproc_configuration();
        [DllImport(_libpostproc)] public static extern void postproc_ffversion();
        [DllImport(_libpostproc)] public static extern void postproc_license();
        [DllImport(_libpostproc)] public static extern void postproc_version();
        [DllImport(_libpostproc)] public static extern void pp_free_context();
        [DllImport(_libpostproc)] public static extern void pp_free_mode();
        [DllImport(_libpostproc)] public static extern void pp_get_context();
        [DllImport(_libpostproc)] public static extern void pp_get_mode_by_name_and_quality();
        [DllImport(_libpostproc)] public static extern void pp_help();
        [DllImport(_libpostproc)] public static extern void pp_postprocess();
    }
}