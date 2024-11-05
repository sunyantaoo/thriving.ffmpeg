using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// A link between two filters
    /// </summary>
    public class AVFilterLink : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 272)]
        struct Internal
        {
            [FieldOffset(0)] internal IntPtr src;       ///< source filter   AVFilterContext*
            [FieldOffset(8)] internal IntPtr srcpad;        ///< output pad on the source filter   AVFilterPad*

            [FieldOffset(16)] internal IntPtr dst;       ///< dest filter     AVFilterContext*
            [FieldOffset(24)] internal IntPtr dstpad;        ///< input pad on the dest filter   AVFilterPad*

            [FieldOffset(32)] internal AVMediaType type;      ///< filter media type

            [FieldOffset(36)] internal int format;                 ///< agreed upon media format

            /* These parameters apply only to video */
            [FieldOffset(40)] internal int w;                      ///< agreed upon image width
            [FieldOffset(44)] internal int h;                      ///< agreed upon image height
            [FieldOffset(48)] internal AVRational sample_aspect_ratio; ///< agreed upon sample aspect ratio
            /**
             * For non-YUV links, these are respectively set to fallback values (as
             * appropriate for that colorspace).
             *
             * Note: This includes grayscale formats, as these are currently treated
             * as forced full range always.
             */
            [FieldOffset(56)] internal AVColorSpace colorspace;   ///< agreed upon YUV color space
            [FieldOffset(60)] internal AVColorRange color_range;  ///< agreed upon YUV color range

            /* These parameters apply only to audio */
            [FieldOffset(64)] internal int sample_rate;            ///< samples per second
            [FieldOffset(72)] internal AVChannelLayout ch_layout;  ///< channel layout of current buffer (see libavutil/channel_layout.h)

            /**
             * Define the time base used by the PTS of the frames/samples
             * which will pass through this link.
             * During the configuration stage, each filter is supposed to
             * change only the output timebase, while the timebase of the
             * input link is assumed to be an unchangeable property.
             */
            [FieldOffset(96)] internal AVRational time_base;

            /*****************************************************************
             * All fields below this line are not part of the public API. They
             * may not be used outside of libavfilter and can be changed and
             * removed at will.
             * New public fields should be added right above.
             *****************************************************************
             */

            /**
             * Lists of supported formats / etc. supported by the input filter.
             */
            [FieldOffset(104)] internal AVFilterFormatsConfig.Internal incfg;

            /**
             * Lists of supported formats / etc. supported by the output filter.
             */
            [FieldOffset(144)] internal AVFilterFormatsConfig.Internal outcfg;

            /**
             * Graph the filter belongs to.
             */
            [FieldOffset(184)] internal IntPtr graph;  //   AVFilterGraph *

            /**
             * Current timestamp of the link, as defined by the most recent
             * frame(s), in link time_base units.
             */
            [FieldOffset(192)] internal long current_pts;

            /**
             * Current timestamp of the link, as defined by the most recent
             * frame(s), in AV_TIME_BASE units.
             */
            [FieldOffset(200)] internal long current_pts_us;

            /**
             * Frame rate of the stream on the link, or 1/0 if unknown or variable;
             * if left to 0/0, will be automatically copied from the first input
             * of the source filter if it exists.
             *
             * Sources should set it to the best estimation of the real frame rate.
             * If the source frame rate is unknown or variable, set this to 1/0.
             * Filters should update it if necessary depending on their function.
             * Sinks can use it to set a default output frame rate.
             * It is similar to the r_frame_rate field in AVStream.
             */
            [FieldOffset(208)] internal AVRational frame_rate;

            /**
             * Minimum number of samples to filter at once. If filter_frame() is
             * called with fewer samples, it will accumulate them in fifo.
             * This field and the related ones must not be changed after filtering
             * has started.
             * If 0, all related fields are ignored.
             */
            [FieldOffset(216)] internal int min_samples;

            /**
             * Maximum number of samples to filter at once. If filter_frame() is
             * called with more samples, it will split them.
             */
            [FieldOffset(220)] internal int max_samples;

            /**
             * Number of past frames sent through the link.
             */
            [FieldOffset(224)] internal long frame_count_in;

            [FieldOffset(232)] internal long frame_count_out;

            /**
             * Number of past samples sent through the link.
             */
            [FieldOffset(240)] internal long sample_count_in;

            [FieldOffset(248)] internal long sample_count_out;

            /**
             * True if a frame is currently wanted on the output of this filter.
             * Set when ff_request_frame() is called by the output,
             * cleared when a frame is filtered.
             */
            [FieldOffset(256)] internal int frame_wanted_out;

            /**
             * For hwaccel pixel formats, this should be a reference to the
             * AVHWFramesContext describing the frames.
             */
            [FieldOffset(264)] internal IntPtr hw_frames_ctx; // AVBufferRef*
        }

    }

}