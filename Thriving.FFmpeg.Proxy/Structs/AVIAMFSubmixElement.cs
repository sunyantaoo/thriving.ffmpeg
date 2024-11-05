using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIAMFSubmixElement : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            /**
             * The id of the Audio Element this submix element references.
             */
            [FieldOffset(4)] internal uint audio_element_id;

            /**
             * Information required required for applying any processing to the
             * referenced and rendered Audio Element before being summed with other
             * processed Audio Elements.
             * The @ref AVIAMFParamDefinition.type "type" must be
             * AV_IAMF_PARAMETER_DEFINITION_MIX_GAIN.
             */
            [FieldOffset(8)] internal IntPtr element_mix_config;

            /**
             * Default mix gain value to apply when there are no AVIAMFParamDefinition
             * with @ref element_mix_config "element_mix_config's"
             * @ref AVIAMFParamDefinition.parameter_id "parameter_id" available for a
             * given audio frame.
             */
            [FieldOffset(12)] internal AVRational default_mix_gain;

            /**
             * A value that indicates whether the referenced channel-based Audio Element
             * shall be rendered to stereo loudspeakers or spatialized with a binaural
             * renderer when played back on headphones.
             * If the Audio Element is not of @ref AVIAMFAudioElement.audio_element_type
             * "type" AV_IAMF_AUDIO_ELEMENT_TYPE_CHANNEL, then this field is undefined.
             */
            [FieldOffset(20)] internal AVIAMFHeadphonesMode headphones_rendering_mode;

            /**
             * A dictionary of strings describing the submix in different languages.
             * Must have the same amount of entries as
             * @ref AVIAMFMixPresentation.annotations "the mix's annotations", stored
             * in the same order, and with the same key strings.
             *
             * @ref AVDictionaryEntry.key "key" is a string conforming to BCP-47 that
             * specifies the language for the string stored in
             * @ref AVDictionaryEntry.value "value".
             */
            [FieldOffset(24)] internal IntPtr annotations;
        }

    }
}