﻿namespace Thriving.FFmpeg.Proxy
{
    public enum AVPictureType
    {
        AV_PICTURE_TYPE_NONE = 0, ///< Undefined
        AV_PICTURE_TYPE_I,     ///< Intra
        AV_PICTURE_TYPE_P,     ///< Predicted
        AV_PICTURE_TYPE_B,     ///< Bi-dir predicted
        AV_PICTURE_TYPE_S,     ///< S(GMC)-VOP MPEG-4
        AV_PICTURE_TYPE_SI,    ///< Switching Intra
        AV_PICTURE_TYPE_SP,    ///< Switching Predicted
        AV_PICTURE_TYPE_BI,    ///< BI type
    }
}