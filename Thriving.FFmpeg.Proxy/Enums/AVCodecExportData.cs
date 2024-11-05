namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// These flags can be passed in AVCodecContext.export_side_data before initialization.
    /// </summary>
    public enum AVCodecExportData
    {  
        /**
         * Export motion vectors through frame side data
         */
        AV_CODEC_EXPORT_DATA_MVS = (1 << 0),
        /**
         * Export encoder Producer Reference Time through packet side data
         */
        AV_CODEC_EXPORT_DATA_PRFT = (1 << 1),
        /**
         * Decoding only.
         * Export the AVVideoEncParams structure through frame side data.
         */
        AV_CODEC_EXPORT_DATA_VIDEO_ENC_PARAMS = (1 << 2),
        /**
         * Decoding only.
         * Do not apply film grain, export it instead.
         */
        AV_CODEC_EXPORT_DATA_FILM_GRAIN = (1 << 3),
    }
}