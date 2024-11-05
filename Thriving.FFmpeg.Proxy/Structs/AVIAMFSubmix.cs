using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIAMFSubmix : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            /**
             * Array of submix elements.
             *
             * Set by av_iamf_submix_add_element(), must not be modified by any
             * other code.
             */
            [FieldOffset(4)] internal IntPtr elements;
            /**
             * Number of elements in the submix.
             *
             * Set by av_iamf_submix_add_element(), must not be modified by any
             * other code.
             */
            [FieldOffset(8)] internal uint nb_elements;

            /**
             * Array of submix layouts.
             *
             * Set by av_iamf_submix_add_layout(), must not be modified by any
             * other code.
             */
            [FieldOffset(12)] internal IntPtr layouts;
            /**
             * Number of layouts in the submix.
             *
             * Set by av_iamf_submix_add_layout(), must not be modified by any
             * other code.
             */
            [FieldOffset(16)] internal uint nb_layouts;

            /**
             * Information required for post-processing the mixed audio signal to
             * generate the audio signal for playback.
             * The @ref AVIAMFParamDefinition.type "type" must be
             * AV_IAMF_PARAMETER_DEFINITION_MIX_GAIN.
             */
            [FieldOffset(20)] internal IntPtr output_mix_config;

            /**
             * Default mix gain value to apply when there are no AVIAMFParamDefinition
             * with @ref output_mix_config "output_mix_config's"
             * @ref AVIAMFParamDefinition.parameter_id "parameter_id" available for a
             * given audio frame.
             */
            [FieldOffset(24)] internal AVRational default_mix_gain;
        }
    }
}