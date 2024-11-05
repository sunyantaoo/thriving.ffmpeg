namespace Thriving.FFmpeg.Proxy
{
    public class AVBufferSrcParameters : ProxyObject
    {

        public AVBufferSrcParameters()
        {
            this._handle = Core.av_buffersrc_parameters_alloc();
        }

        ~AVBufferSrcParameters()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.av_free(_handle);
            }
        }

        struct Internal
        {
            /**
             * video: the pixel format, value corresponds to enum AVPixelFormat
             * audio: the sample format, value corresponds to enum AVSampleFormat
             */
            int format;
            /**
             * The timebase to be used for the timestamps on the input frames.
             */
            AVRational time_base;

            /**
             * Video only, the display dimensions of the input frames.
             */
            int width, height;

            /**
             * Video only, the sample (pixel) aspect ratio.
             */
            AVRational sample_aspect_ratio;

            /**
             * Video only, the frame rate of the input video. This field must only be
             * set to a non-zero value if input stream has a known constant framerate
             * and should be left at its initial value if the framerate is variable or
             * unknown.
             */
            AVRational frame_rate;

            /**
             * Video with a hwaccel pixel format only. This should be a reference to an
             * AVHWFramesContext instance describing the input frames.
             */
            IntPtr hw_frames_ctx; // AVBufferRef*

            /**
             * Audio only, the audio sampling rate in samples per second.
             */
            int sample_rate;

            /**
             * Audio only, the audio channel layout
             */
            AVChannelLayout ch_layout;

            /**
             * Video only, the YUV colorspace and range.
             */
            AVColorSpace color_space;
            AVColorRange color_range;
        }
    }
}