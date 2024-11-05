namespace Thriving.FFmpeg.Proxy
{
    public  enum AVPictureStructure
    {
        AV_PICTURE_STRUCTURE_UNKNOWN,      ///< unknown
        AV_PICTURE_STRUCTURE_TOP_FIELD,    ///< coded as top field
        AV_PICTURE_STRUCTURE_BOTTOM_FIELD, ///< coded as bottom field
        AV_PICTURE_STRUCTURE_FRAME,        ///< coded as frame
    };
}