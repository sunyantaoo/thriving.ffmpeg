using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIAMFAudioElement : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            [FieldOffset(4)] internal IntPtr layers;
            /**
             * Number of layers, or channel groups, in the Audio Element.
             * There may be 6 layers at most, and for @ref audio_element_type
             * AV_IAMF_AUDIO_ELEMENT_TYPE_SCENE, there may be exactly 1.
             *
             * Set by av_iamf_audio_element_add_layer(), must not be
             * modified by any other code.
             */
            [FieldOffset(8)] internal uint nb_layers;

            /**
             * Demixing information used to reconstruct a scalable channel audio
             * representation.
             * The @ref AVIAMFParamDefinition.type "type" must be
             * AV_IAMF_PARAMETER_DEFINITION_DEMIXING.
             */
            [FieldOffset(12)] internal IntPtr demixing_info;
            /**
             * Recon gain information used to reconstruct a scalable channel audio
             * representation.
             * The @ref AVIAMFParamDefinition.type "type" must be
             * AV_IAMF_PARAMETER_DEFINITION_RECON_GAIN.
             */
            [FieldOffset(16)] internal IntPtr recon_gain_info;

            /**
             * Audio element type as defined in section 3.6 of IAMF.
             */
            [FieldOffset(20)] internal AVIAMFAudioElementType audio_element_type;

            /**
             * Default weight value as defined in section 3.6 of IAMF.
             */
            [FieldOffset(24)] internal uint default_w;
        }

    }


}