using System;
namespace CNDP.Basic
{
    public class TimeCodeConvertBase
    {
        /// <summary>
        ///   把百纳秒和帧率转换为帧。
        /// </summary>
        /// <param name = "vaule">百纳秒。</param>
        /// <param name = "fps">帧率。</param>
        /// <returns>返回帧。</returns>
        public static long GetFrames(long vaule, double fps)
        {
            return TimeCodeConvertHelper.L100Ns2Frame(vaule, fps);
        }

        /// <summary>
        ///   帧转换成百纳秒
        /// </summary>
        /// <param name = "frame"></param>
        /// <param name = "fps"></param>
        /// <returns></returns>
        public static long Get100NS(long frame, double fps)
        {
            return TimeCodeConvertHelper.Frame2L100Ns(frame, fps);
        }

        /// <summary>
        /// 百纳秒转换为时码
        /// </summary>
        /// <param name="l100Ns"></param>
        /// <param name="dropFrame"></param>
        /// <returns></returns>
        public static string GetTimeCode(long l100Ns, bool dropFrame)
        {
            return TimeCodeConvertHelper.L100Ns2Tc(l100Ns, dropFrame);
        }

        /// <summary>
        /// 百纳秒转换为时码
        /// </summary>
        /// <param name="l100Ns"></param>
        /// <param name="frameRate">帧率</param>
        /// <param name="dropFrame"></param>
        /// <returns></returns>
        public static string GetTimeCode(long l100Ns, double frameRate, bool dropFrame)
        {
            return TimeCodeConvertHelper.L100Ns2Tc(l100Ns, frameRate, dropFrame);
        }

        /// <summary>
        /// 帧转换为时码
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="frameRate"></param>
        /// <param name="frameScale"></param>
        /// <returns></returns>
        public static string GetTimeCode(long frame, double frameRate, long frameScale, bool isDorpFrame = true)
        {
            return TimeCodeConvertHelper.Frame2Tc(frame, frameRate, frameScale, isDorpFrame);
        }

        public static string TimeCodeAdd(string timeCode1, string timeCode2)
        {
            TimeSpan ts1;
            TimeSpan ts2;
            TimeSpan.TryParse(timeCode1.Remove(timeCode1.LastIndexOf(':')), out ts1);
            TimeSpan.TryParse(timeCode2.Remove(timeCode2.LastIndexOf(':')), out ts2);
            return ts1.Add(ts2).ToString(@"hh\:mm\:ss") + ":00";
        }

        /// <summary>
        /// 100NS转时间格式,仅仅转时分秒,没有帧
        /// </summary>
        /// <param name="l100Ns">100NS</param>
        /// <returns></returns>
        public static string L100Ns2TimeCode(long l100Ns)
        {
            long s = (long)Math.Floor(l100Ns / Math.Pow(10, 7));

            long h = (long)(s * 1.0 / 3600);
            long m = (long)Math.Floor((s * 1.0 % 3600) / 60);
            long ss = (long)(s - h * 3600 - m * 60);

            string tc = $"{h}:{m}:{ss}";

            return tc;
        }

        /// <summary>
        /// 音频时间格式转换
        /// </summary>
        /// <param name="l100Ns">百纳秒</param>
        /// <returns></returns>
        public static string L100Ns2Second(long l100Ns)
        {
            double seconds = Convert.ToDouble(l100Ns) / Math.Pow(10, 7);
            TimeSpan ts = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours + ts.Days * 24, ts.Minutes, ts.Seconds);//精确到秒 
        }

        /// <summary>
        /// 素材百纳秒转换为时码
        /// </summary>
        /// <param name="l100Ns"></param>
        /// <param name="entityType"></param>
        /// <param name="frameRate"></param>
        /// <returns></returns>
        public static string GetTimeCode(long l100Ns, string entityType = "audio", double frameRate = 0)
        {
            if (entityType != "audio" && entityType != "video") return "";
            return entityType == "video" ? GetTimeCode(l100Ns, frameRate, true) : L100Ns2Second(l100Ns);
        }

        public static string GetTimeCode(string l100Ns, string entityType = "audio", double frameRate = 0)
        {
            long d;
            long.TryParse(l100Ns, out d);
            return GetTimeCode(d, entityType, frameRate);
        }
    }
}
