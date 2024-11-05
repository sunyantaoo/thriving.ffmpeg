using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct AVRational
    {
        public AVRational(int num,int den)
        {
            this._num = num;
            this._den = den;
        }

        [FieldOffset(0)] private int _num;
        [FieldOffset(4)] private int _den;

        /// <summary>
        /// 分子
        /// </summary>
        public int Num
        {
            readonly get => _num;
            set { _num = value; }
        }

        /// <summary>
        /// 分母
        /// </summary>
        public int Den
        {
            get => _den;
            set { _den = value; }
        }

        /// <summary>
        /// 根据时间获取表示秒数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public readonly double GetSecond(long time)
        {
            return (double)(time * _num) / _den;
        }

        /// <summary>
        /// 根据秒数获取表示的刻度
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public readonly long GetMoment(double second)
        {
            return (long)(second * _den);
        }






    }
}