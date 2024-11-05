using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIAMFMixPresentation : ProxyObject
    {



        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            /**
             * Array of submixes.
             *
             * Set by av_iamf_mix_presentation_add_submix(), must not be modified
             * by any other code.
             */
            [FieldOffset(4)] internal IntPtr submixes;
            /**
             * Number of submixes in the presentation.
             *
             * Set by av_iamf_mix_presentation_add_submix(), must not be modified
             * by any other code.
             */
            [FieldOffset(8)] internal uint nb_submixes;

            /**
             * A dictionary of strings describing the mix in different languages.
             * Must have the same amount of entries as every
             * @ref AVIAMFSubmixElement.annotations "Submix element annotations",
             * stored in the same order, and with the same key strings.
             *
             * @ref AVDictionaryEntry.key "key" is a string conforming to BCP-47
             * that specifies the language for the string stored in
             * @ref AVDictionaryEntry.value "value".
             */
            [FieldOffset(12)] internal IntPtr annotations;
        }
    }
}