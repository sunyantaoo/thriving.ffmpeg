using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIAMFLayer : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 56)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            [FieldOffset(8)] internal AVChannelLayout ch_layout;

            /**
             * A bitmask which may contain a combination of AV_IAMF_LAYER_FLAG_* flags.
             */
            [FieldOffset(32)] internal uint flags;
            /**
             * Output gain channel flags as defined in section 3.6.2 of IAMF.
             *
             * This field is defined only if @ref AVIAMFAudioElement.audio_element_type
             * "the parent's Audio Element type" is AV_IAMF_AUDIO_ELEMENT_TYPE_CHANNEL,
             * must be 0 otherwise.
             */
            [FieldOffset(36)] internal uint output_gain_flags;
            /**
             * Output gain as defined in section 3.6.2 of IAMF.
             *
             * Must be 0 if @ref output_gain_flags is 0.
             */
            [FieldOffset(40)] internal AVRational output_gain;
            /**
             * Ambisonics mode as defined in section 3.6.3 of IAMF.
             *
             * This field is defined only if @ref AVIAMFAudioElement.audio_element_type
             * "the parent's Audio Element type" is AV_IAMF_AUDIO_ELEMENT_TYPE_SCENE.
             *
             * If AV_IAMF_AMBISONICS_MODE_MONO, channel_mapping is defined implicitly
             * (Ambisonic Order) or explicitly (Custom Order with ambi channels) in
             * @ref ch_layout.
             * If AV_IAMF_AMBISONICS_MODE_PROJECTION, @ref demixing_matrix must be set.
             */
            [FieldOffset(48)] internal AVIAMFAmbisonicsMode ambisonics_mode;

            /**
             * Demixing matrix as defined in section 3.6.3 of IAMF.
             *
             * The length of the array is ch_layout.nb_channels multiplied by the sum of
             * the amount of streams in the group plus the amount of streams in the group
             * that are stereo.
             *
             * May be set only if @ref ambisonics_mode == AV_IAMF_AMBISONICS_MODE_PROJECTION,
             * must be NULL otherwise.
             */
            [FieldOffset(52)] internal IntPtr demixing_matrix;
        }
    }


}