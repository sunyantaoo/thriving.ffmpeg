namespace Thriving.FFmpeg.Proxy
{
    public enum AVIAMFParamDefinitionType
    {
        /**
         * Subblocks are of struct type AVIAMFMixGain
         */
        AV_IAMF_PARAMETER_DEFINITION_MIX_GAIN,
        /**
         * Subblocks are of struct type AVIAMFDemixingInfo
         */
        AV_IAMF_PARAMETER_DEFINITION_DEMIXING,
        /**
         * Subblocks are of struct type AVIAMFReconGain
         */
        AV_IAMF_PARAMETER_DEFINITION_RECON_GAIN,
    }
}