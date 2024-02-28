namespace CNDP.Basic
{
    #region Imports

    using System;
    using System.Linq;

    #endregion

    /// <summary>
    ///   桌面视频制式标准枚举定义
    /// </summary>
    internal enum MpcVideoStandard
    {
        MpcVideostandardUnknow = 0x00000000, //Invalid

        MpcVideostandardPal = 0x00000001, //PAL size:720*576 f/s : 25
        MpcVideostandardNtsc2997 = 0x00000002, //NTSC size:720*486  f/s : 29.97
        MpcVideostandardNtsc30 = 0x00000004, //NTSC size:720*486 f/s : 30 
        MpcVideostandardSecam = 0x00000008, //SECAM

        MpcVideostandard1920108050I = 0x00000010, //HDTV size:1920*1080 f/s : 25  interlaced
        MpcVideostandard192010805994I = 0x00000020, //HDTV size:1920*1080 f/s : 29.97 interlaced
        MpcVideostandard1920108060I = 0x00000040, //HDTV size:1920*1080 f/s : 30 interlaced

        MpcVideostandard192010802398P = 0x00000080, //HDTV size:1920*1080 f/s : 23.98 progressive
        MpcVideostandard1920108024P = 0x00000100, //HDTV size:1920*1080 f/s : 24 progressive
        MpcVideostandard1920108025P = 0x00000200, //HDTV size:1920*1080 f/s : 25 progressive
        MpcVideostandard192010802997P = 0x00000400, //HDTV size:1920*1080 f/s : 29.97 progressive
        MpcVideostandard1920108030P = 0x00000800, //HDTV size:1920*1080 f/s : 30 progressive

        MpcVideostandard12807202398P = 0x00001000, //HDTV size:1280*720 f/s : 23.98 progressive
        MpcVideostandard128072024P = 0x00002000, //HDTV size:1280*720 f/s : 24 progressive
        MpcVideostandard128072050P = 0x00004000, //HDTV size:1280*720 f/s : 50 progressive
        MpcVideostandard12807205994P = 0x00008000, //HDTV size:1280*720 f/s : 59.94 progressive

        MpcVideostandard1440108050I = 0x00010000, //HD  size:1440*1080 f/s : 25 interlaced
        MpcVideostandard144010805994I = 0x00020000, //HD  size:1440*1080 f/s : 29.97 interlaced
        MpcVideostandard1440108060I = 0x00040000, //HD  size:1440*1080 f/s : 30 interlaced
    };

    /// <summary>
    ///   时码转换帮助类
    /// </summary>
    public class TimeCodeConvertHelper
    {
        #region 私有变量

        #region 25

        /// <summary>
        ///   PAL field frequency
        /// </summary>
        private static long m_mpcStRate25 = 50; // PAL field frequency

        /// <summary>
        ///   PAL frame  frequency
        /// </summary>
        private const long MpcStFrameRate25 = 25; // PAL frame  frequency

        /// <summary>
        ///   PAL scale
        /// </summary>
        private const long MpcStScale25 = 1; // PAL scale 

        #endregion

        #region 2997

        /// <summary>
        ///   NTSC field frequency
        /// </summary>
        private static long m_mpcStRate2997 = 60000; // NTSC field frequency

        /// <summary>
        ///   NTSC frame  frequency
        /// </summary>
        private const long MpcStFrameRate2997 = 30000; // NTSC frame  frequency

        /// <summary>
        ///   NTSC scale
        /// </summary>
        private const long MpcStScale2997 = 1001; // NTSC scale 

        #endregion

        #region 30

        /// <summary>
        ///   30-F field frequency
        /// </summary>
        private static long m_mpcStRate30 = 60; // 30-F field frequency

        /// <summary>
        ///   30-F frame frequency
        /// </summary>
        private const long MpcStFrameRate30 = 30; // 30-F frame frequency

        /// <summary>
        ///   30-F scale
        /// </summary>
        private const long MpcStScale30 = 1; // 30-F scale 

        #endregion

        #region 24

        /// <summary>
        ///   24-F field frequency
        /// </summary>
        private static long m_mpcStRate24 = 48; // 24-F field frequency

        /// <summary>
        ///   24-F field frequency
        /// </summary>
        private const long MpcStFrameRate24 = 24; // 24-F field frequency

        /// <summary>
        ///   24-F scale
        /// </summary>
        private const long MpcStScale24 = 1; // 24-F scale 

        #endregion

        #region 23.98

        /// <summary>
        ///   2398-F field frequency
        /// </summary>
        private static long m_mpcStRate2398 = 48000; // 2398-F field frequency

        /// <summary>
        ///   2398-F frame frequency
        /// </summary>
        private const long MpcStFrameRate2398 = 24000; // 2398-F frame frequency

        /// <summary>
        ///   2398-F scale
        /// </summary>
        private const long MpcStScale2398 = 1001; // 2398-F scale 

        #endregion

        #region 50

        /// <summary>
        ///   PAL field frequency
        /// </summary>
        private static long m_mpcStRate50 = 50; // PAL field frequency

        /// <summary>
        ///   PAL frame  frequency
        /// </summary>
        private const long MpcStFrameRate50 = 50; // PAL frame  frequency

        /// <summary>
        ///   PAL scale
        /// </summary>
        private const long MpcStScale50 = 1; // PAL scale 

        #endregion

        #region 5994

        /// <summary>
        ///   NTSC field frequency
        /// </summary>
        private static long m_mpcStRate5994 = 60000; // NTSC field frequency

        /// <summary>
        ///   NTSC frame  frequency
        /// </summary>
        private const long MpcStFrameRate5994 = 60000; // NTSC frame  frequency

        /// <summary>
        ///   NTSC scale
        /// </summary>
        private const long MpcStScale5994 = 1001; // NTSC scale 

        #endregion

        #region 60

        /// <summary>
        ///   60-F field frequency
        /// </summary>
        private static long m_mpcStRate60 = 60; // 60-F field frequency

        /// <summary>
        ///   60-F frame frequency
        /// </summary>
        private const long MpcStFrameRate60 = 60; // 60-F frame frequency

        /// <summary>
        ///   60-F scale
        /// </summary>
        private const long MpcStScale60 = 1; // 60-F scale 

        #endregion

        #region 25 Frame

        /// <summary>
        ///   25 Frame: frames per second
        /// </summary>
        private const long MpcFramesSecond25 = 25L; // 25 Frame: frames per second

        /// <summary>
        ///   25 Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute25 = 1500L; // 25 Frame: frames per minute

        /// <summary>
        ///   25 Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour25 = 90000L; // 25 Frame: frames per hour 

        #endregion

        #region 24 DROP Frame

        /// <summary>
        ///   30 DROP Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute24Drop = 1438L; // 24 DROP Frame: frames per minute

        /// <summary>
        ///   30 DROP Frame: frames per 10 minutes
        /// </summary>
        private const long MpcFrames10Minutes24Drop = 14382L; // 24 DROP Frame: frames per 10 minutes

        /// <summary>
        ///   30 DROP Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour24Drop = 86292L; // 24 DROP Frame: frames per hour 

        #endregion

        #region 24 Frame

        /// <summary>
        ///   24 Frame: frames per second
        /// </summary>
        private const long MpcFramesSecond24 = 24L; // 24 Frame: frames per second    

        /// <summary>
        ///   24 Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute24 = 1440L; // 24 Frame: frames per minute

        /// <summary>
        ///   24 Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour24 = 86400L; // 24 Frame: frames per hour 

        #endregion

        #region 30 NO_DROP Frame

        /// <summary>
        ///   30 NO_DROP Frame: frames per second
        /// </summary>
        private const long MpcFramesSecondNodrop30 = 30L; // 30 NO_DROP Frame: frames per second 

        /// <summary>
        ///   30 NO_DROP Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinuteNodrop30 = 1800L; // 30 NO_DROP Frame: frames per minute

        /// <summary>
        ///   30 NO_DROP Frame: frames per hour
        /// </summary>
        private const long MpcFramesHourNodrop30 = 108000L; // 30 NO_DROP Frame: frames per hour 

        #endregion

        #region 30 DROP Frame

        /// <summary>
        ///   30 DROP Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute30Drop = 1798L; // 30 DROP Frame: frames per minute

        /// <summary>
        ///   30 DROP Frame: frames per 10 minutes
        /// </summary>
        private const long MpcFrames10Minutes30Drop = 17982L; // 30 DROP Frame: frames per 10 minutes

        /// <summary>
        ///   30 DROP Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour30Drop = 107892L; // 30 DROP Frame: frames per hour 

        #endregion

        #region 50 Frame

        /// <summary>
        ///   50 Frame: frames per second
        /// </summary>
        private const long MpcFramesSecond50 = 50L; // 25 Frame: frames per second

        /// <summary>
        ///   50 Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute50 = 3000L; // 25 Frame: frames per minute

        /// <summary>
        ///   50 Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour50 = 180000L; // 25 Frame: frames per hour 

        #endregion

        #region 60 DROP Frame

        /// <summary>
        ///   60 DROP Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute60Drop = 3596L; // 60 DROP Frame: frames per minute

        /// <summary>
        ///   60 DROP Frame: frames per 10 minutes
        /// </summary>
        private const long MpcFrames10Minutes60Drop = 35964L; // 60 DROP Frame: frames per 10 minutes

        /// <summary>
        ///   60 DROP Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour60Drop = 215784L; // 60 DROP Frame: frames per hour 

        #endregion

        #region 60 Frame

        /// <summary>
        ///   60 Frame: frames per second
        /// </summary>
        private const long MpcFramesSecond60 = 60L; // 60 Frame: frames per second

        /// <summary>
        ///   60 Frame: frames per minute
        /// </summary>
        private const long MpcFramesMinute60 = 3600L; // 60 Frame: frames per minute

        /// <summary>
        ///   60 Frame: frames per hour
        /// </summary>
        private const long MpcFramesHour60 = 216000L; // 60 Frame: frames per hour 

        #endregion

        #endregion

        #region 公共方法

        #region 帧转百纳秒

        /// <summary>
        ///   帧转百纳秒
        /// </summary>
        /// <param name = "lFrame">帧</param>
        /// <param name = "dRate">帧率</param>
        /// <param name = "dScale"></param>
        /// <returns>百纳秒</returns>
        public static long Frame2L100Ns(long lFrame, double dRate, double dScale)
        {
            double dFrameRate = MpcStFrameRate25;
            double dFrameScale = MpcStScale25;

            Rate2ScaleFrameRateAndFrameScale(dRate, dScale, ref dFrameRate, ref dFrameScale);

            return Convert.ToInt64(Math.Floor(lFrame * Math.Pow(10, 7) * dFrameRate / dFrameScale));
        }

        /// <summary>
        ///   帧转百纳秒
        /// </summary>
        /// <param name = "dFrame">帧</param>
        /// <param name = "dFrameRate">帧率</param>
        /// <returns>百纳秒</returns>
        public static long Frame2L100Ns(long dFrame, double dFrameRate)
        {
            double dRate = MpcStFrameRate25;
            double dScale = MpcStScale25;
            FrameRate2RateAndScale(dFrameRate, ref dRate, ref dScale);

            return Convert.ToInt64(Math.Floor(dFrame * dScale * Math.Pow(10, 7) / dRate));
        }

        #endregion

        #region 帧转秒

        /// <summary>
        ///   帧转秒
        /// </summary>
        /// <param name = "lFrame">帧</param>
        /// <param name = "dRate">帧率</param>
        /// <param name = "dScale"></param>
        /// <returns>秒</returns>
        public static double Frame2Second(long lFrame, double dRate, double dScale)
        {
            double dFrameRate = MpcStFrameRate25;
            double dFrameScale = MpcStScale25;
            Rate2ScaleFrameRateAndFrameScale(dRate, dScale, ref dFrameRate, ref dFrameScale);

            return (lFrame * dFrameScale / dFrameRate);
        }

        /// <summary>
        ///   帧转秒
        /// </summary>
        /// <param name = "dFrame">帧</param>
        /// <param name = "dFrameRate">帧率</param>
        /// <returns>秒</returns>
        public static double Frame2Second(long dFrame, double dFrameRate)
        {
            double dRate = MpcStFrameRate25;
            double dScale = MpcStScale25;
            FrameRate2RateAndScale(dFrameRate, ref dRate, ref dScale);

            return (dFrame * dScale / dRate);
        }

        #endregion

        #region 帧转时码

        /// <summary>
        ///   帧转时码
        /// </summary>
        /// <param name = "dFrame">帧</param>
        /// <param name = "dRate">帧率</param>
        /// <param name = "dScale"></param>
        /// <returns>时码字符串</returns>
        public static string Frame2Tc(double dFrame, double dRate, double dScale, bool dropFrame)
        {
            string strTc = string.Empty;
            if ((dRate == MpcStFrameRate25 && dScale == MpcStScale25) || (dRate * MpcStScale25 == dScale * MpcStFrameRate25))
            {
                long dHour = (long)(Math.Floor(dFrame / MpcFramesHour25));
                long dResidue = (long)(Math.Floor(dFrame % MpcFramesHour25));
                long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinute25));
                dResidue = dResidue % MpcFramesMinute25;
                long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond25));
                long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond25));
                strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
            }
            else if ((dRate == MpcStFrameRate2997 && dScale == MpcStScale2997) || (dRate * MpcStScale2997 == dScale * MpcStFrameRate2997))
            {
                if (dropFrame)
                {
                    long dHour = (long)(Math.Floor(dFrame / MpcFramesHour30Drop));
                    long dResidue = (long)(Math.Floor(dFrame % MpcFramesHour30Drop));
                    long dMin = (long)(Math.Floor((double)10 * (dResidue / MpcFrames10Minutes30Drop)));
                    dResidue = dResidue % MpcFrames10Minutes30Drop;
                    if (dResidue >= MpcFramesMinuteNodrop30)
                    {
                        dResidue -= MpcFramesMinuteNodrop30;
                        dMin += 1 + dResidue / MpcFramesMinute30Drop;
                        dResidue %= MpcFramesMinute30Drop;
                        dResidue += 2;
                    }
                    long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecondNodrop30));
                    long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecondNodrop30));
                    strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, true);
                }
                else
                {
                    long dHour = (long)(Math.Floor((double)dFrame / MpcFramesHourNodrop30));
                    long dResidue = (long)(Math.Floor((double)dFrame % MpcFramesHourNodrop30));
                    long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinuteNodrop30));
                    dResidue = dResidue % MpcFramesMinuteNodrop30;
                    long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecondNodrop30));
                    long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecondNodrop30));
                    strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
                }
            }
            else if ((dRate == MpcStFrameRate30 && dScale == MpcStScale30) || (dRate * MpcStScale30 == dScale * MpcStFrameRate30))
            {
                long dHour = (long)(Math.Floor((double)dFrame / MpcFramesHourNodrop30));
                long dResidue = (long)(Math.Floor((double)dFrame % MpcFramesHourNodrop30));
                long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinuteNodrop30));
                dResidue = dResidue % MpcFramesMinuteNodrop30;
                long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecondNodrop30));
                long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecondNodrop30));
                strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
            }
            else if ((dRate == MpcStFrameRate24 && dScale == MpcStScale24) || (dRate * MpcStScale24 == dScale * MpcStFrameRate24))
            {
                long dHour = (long)(Math.Floor((double)dFrame / MpcFramesHour24));
                long dResidue = (long)(Math.Floor((double)dFrame % MpcFramesHour24));
                long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinute24));
                dResidue = dResidue % MpcFramesMinute24;
                long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond24));
                long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond24));
                strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
            }
            else if ((dRate == MpcStFrameRate2398 && dScale == MpcStScale2398) || (dRate * MpcStScale2398 == dScale * MpcStFrameRate2398))
            {
                if (dropFrame)
                {
                    long dHour = (long)(Math.Floor(dFrame / MpcFramesHour24Drop));
                    long dResidue = (long)(Math.Floor(dFrame % MpcFramesHour24Drop));
                    long dMin = (long)(Math.Floor((double)10 * (dResidue / MpcFrames10Minutes24Drop)));
                    dResidue = dResidue % MpcFrames10Minutes24Drop;
                    if (dResidue >= MpcFramesMinute24)
                    {
                        dResidue -= MpcFramesMinute24;
                        dMin += 1 + dResidue / MpcFramesMinute24Drop;
                        dResidue %= MpcFramesMinute24Drop;
                        dResidue += 2;
                    }
                    long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond24));
                    long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond24));
                    strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, true);
                }
                else
                {
                    long dHour = (long)(Math.Floor((double)dFrame / MpcFramesHour24));
                    long dResidue = (long)(Math.Floor((double)dFrame % MpcFramesHour24));
                    long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinute24));
                    dResidue = dResidue % MpcFramesMinute24;
                    long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond24));
                    long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond24));
                    strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
                }
            }
            else if ((dRate == MpcStFrameRate50 && dScale == MpcStScale50) || (dRate * MpcStScale50 == dScale * MpcStFrameRate50))
            {
                long dHour = (long)(Math.Floor(dFrame / MpcFramesHour50));
                long dResidue = (long)(Math.Floor(dFrame % MpcFramesHour50));
                long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinute50));
                dResidue = dResidue % MpcFramesMinute50;
                long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond50));
                long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond50));
                strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
            }
            else if ((dRate == MpcStFrameRate5994 && dScale == MpcStScale5994) || (dRate * MpcStScale5994 == dScale * MpcStFrameRate5994))
            {
                if (dropFrame)
                {
                    long dHour = (long)(Math.Floor(dFrame / MpcFramesHour60Drop));
                    long dResidue = (long)(Math.Floor(dFrame % MpcFramesHour60Drop));
                    long dMin = (long)(Math.Floor((double)10 * (dResidue / MpcFrames10Minutes60Drop)));
                    dResidue = dResidue % MpcFrames10Minutes60Drop;
                    if (dResidue >= MpcFramesMinute60)
                    {
                        dResidue -= MpcFramesMinute60;
                        dMin += 1 + dResidue / MpcFramesMinute60Drop;
                        dResidue %= MpcFramesMinute60Drop;
                        dResidue += 4;
                    }
                    long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond60));
                    long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond60));
                    strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, true);
                }
                else
                {
                    long dHour = (long)(Math.Floor((double)dFrame / MpcFramesHour60));
                    long dResidue = (long)(Math.Floor((double)dFrame % MpcFramesHour60));
                    long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinute60));
                    dResidue = dResidue % MpcFramesMinute60;
                    long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond60));
                    long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond60));
                    strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
                }
            }
            else if ((dRate == MpcStFrameRate60 && dScale == MpcStScale60) || (dRate * MpcStScale60 == dScale * MpcStFrameRate60))
            {
                long dHour = (long)(Math.Floor((double)dFrame / MpcFramesHour60));
                long dResidue = (long)(Math.Floor((double)dFrame % MpcFramesHour60));
                long dMin = (long)(Math.Floor((double)dResidue / MpcFramesMinute60));
                dResidue = dResidue % MpcFramesMinute60;
                long dSec = (long)(Math.Floor((double)dResidue / MpcFramesSecond60));
                long dFra = (long)(Math.Floor((double)dResidue % MpcFramesSecond60));
                strTc = FormatTimeCodeString(dHour, dMin, dSec, dFra, false);
            }
            return strTc;
        }

        /// <summary>
        ///   帧转时码
        /// </summary>
        /// <param name = "dFrame">帧</param>
        /// <param name = "dFrameRate">帧率</param>
        /// <param name="dropFrame">是否丢帧</param>
        /// <returns>时码字符串</returns>
        public static string Frame2Tc(long dFrame, double dFrameRate, bool dropFrame)
        {
            double dRate = MpcStFrameRate25;
            double dScale = MpcStScale25;
            FrameRate2RateAndScale(dFrameRate, ref dRate, ref dScale);

            string strTc = Frame2Tc(dFrame, dRate, dScale, dropFrame);
            return strTc;
        }

        #endregion

        #region 时码字符串转帧

        /// <summary>
        ///   时码字符串转帧
        /// </summary>
        /// <param name = "sTimeCode">时码</param>
        /// <param name="frameRate">帧率</param>
        /// <param name = "dRate"></param>
        /// <param name = "dScale"></param>
        /// <param name="dropframe">是否是丢帧</param>
        /// <returns>帧</returns>
        public static long TimeCode2Frame(string sTimeCode, double frameRate, double dRate, double dScale, bool dropframe)
        {
            long ftcFrames = 0;
            if ((dRate == MpcStFrameRate25 && dScale == MpcStScale25) || (dRate * MpcStScale25 == dScale * MpcStFrameRate25))
            {
                ftcFrames = TimeCode2NdfFrame(sTimeCode, frameRate);
            }
            else if ((dRate == MpcStFrameRate2997 && dScale == MpcStScale2997) || (dRate * MpcStScale2997 == dScale * MpcStFrameRate2997))
            {
                long lHour = 0;
                long lMinute = 0;
                long lSecond = 0;
                long lFrame = 0;

                TimeCode2Format(sTimeCode, out lHour, out lMinute, out lSecond, out lFrame, frameRate);

                if (dropframe)
                {
                    ftcFrames += lHour * MpcFramesHour30Drop;

                    long lwReste = lMinute / 10;
                    ftcFrames += lwReste * MpcFrames10Minutes30Drop;
                    lwReste = lMinute % 10;

                    if (lwReste > 0)
                    {
                        ftcFrames += MpcFramesMinuteNodrop30;
                        ftcFrames += (lwReste - 1) * MpcFramesMinute30Drop;
                        ftcFrames -= 2;
                    }

                    ftcFrames += lSecond * MpcFramesSecondNodrop30;
                    ftcFrames += lFrame;
                }
                else
                {
                    ftcFrames = TimeCode2NdfFrame(sTimeCode, 30);
                }
            }
            else if ((dRate == MpcStFrameRate30 && dScale == MpcStScale30) || (dRate * MpcStScale30 == dScale * MpcStFrameRate30))
            {
                ftcFrames = TimeCode2NdfFrame(sTimeCode, frameRate);
            }
            else if ((dRate == MpcStFrameRate24 && dScale == MpcStScale24) || (dRate * MpcStScale24 == dScale * MpcStFrameRate24))
            {
                ftcFrames = TimeCode2NdfFrame(sTimeCode, frameRate);
            }
            else if ((dRate == MpcStFrameRate2398 && dScale == MpcStScale2398) || (dRate * MpcStScale2398 == dScale * MpcStFrameRate2398))
            {
                long lHour = 0;
                long lMinute = 0;
                long lSecond = 0;
                long lFrame = 0;

                TimeCode2Format(sTimeCode, out lHour, out lMinute, out lSecond, out lFrame, frameRate);

                if (dropframe)
                {
                    ftcFrames += lHour * MpcFramesHour24;

                    long lwReste = lMinute / 10;
                    ftcFrames += lwReste * MpcFrames10Minutes24Drop;
                    lwReste = lMinute % 10;
                    if (lwReste > 0)
                    {
                        ftcFrames += MpcFramesMinute60;
                        ftcFrames += (lwReste - 1) * MpcFramesMinute24;
                        ftcFrames -= 2;
                    }

                    ftcFrames += lSecond * MpcFramesSecond24;
                    ftcFrames += lFrame;
                }
                else
                {
                    ftcFrames = TimeCode2NdfFrame(sTimeCode, 24);
                }
            }
            else if ((dRate == MpcStFrameRate50 && dScale == MpcStScale50) || (dRate * MpcStScale50 == dScale * MpcStFrameRate50))
            {
                ftcFrames = TimeCode2NdfFrame(sTimeCode, frameRate);
            }
            else if ((dRate == MpcStFrameRate5994 && dScale == MpcStScale5994) || (dRate * MpcStScale5994 == dScale * MpcStFrameRate5994))
            {
                long lHour = 0;
                long lMinute = 0;
                long lSecond = 0;
                long lFrame = 0;

                TimeCode2Format(sTimeCode, out lHour, out lMinute, out lSecond, out lFrame, frameRate);
                if (dropframe)
                {
                    ftcFrames += lHour * MpcFramesHour60Drop;

                    long lwReste = lMinute / 10;
                    ftcFrames += lwReste * MpcFrames10Minutes60Drop;
                    lwReste = lMinute % 10;
                    if (lwReste > 0)
                    {
                        ftcFrames += MpcFramesMinute60;
                        ftcFrames += (lwReste - 1) * MpcFramesMinute60Drop;
                        ftcFrames -= 4;
                    }

                    ftcFrames += lSecond * MpcFramesSecond60;
                    ftcFrames += lFrame;
                }
                else
                {
                    ftcFrames = TimeCode2NdfFrame(sTimeCode, 60);
                }
            }
            else if ((dRate == MpcStFrameRate60 && dScale == MpcStScale60) || (dRate * MpcStScale60 == dScale * MpcStFrameRate60))
            {
                ftcFrames = TimeCode2NdfFrame(sTimeCode, frameRate);
            }
            return ftcFrames;
        }

        /// <summary>
        ///   时间字符串转帧
        /// </summary>
        /// <param name="sTimeCode">时码</param>
        /// <param name="dFrameRate">帧率</param>
        /// <param name="dropFrame">是否是丢帧</param>
        /// <returns>帧</returns>
        public static long TimeCode2Frame(string sTimeCode, double dFrameRate, bool dropFrame)
        {
            #region 格式化TC中的丢帧与非丢帧

            //sTimeCode = FormatTimeCodeString(sTimeCode, dFrameRate, GetRateDropFrame(dFrameRate));
            sTimeCode = FormatTimeCodeString(sTimeCode, dFrameRate, dropFrame);

            #endregion

            double dRate = MpcStFrameRate25;
            double dScale = MpcStScale25;
            FrameRate2RateAndScale(dFrameRate, ref dRate, ref dScale);

            long ftcFrames = TimeCode2Frame(sTimeCode, dFrameRate, dRate, dScale, dropFrame);

            string newTc = Frame2Tc(ftcFrames, dFrameRate, dropFrame);

            #region 防止因为 . 和 : 导致不一样

            newTc = newTc.Replace(".", ":");
            sTimeCode = sTimeCode.Replace(".", ":");

            #endregion

            if (newTc != sTimeCode)
            {
                ftcFrames = GetFrameByTimeCode(sTimeCode, ftcFrames, true, 1, dFrameRate, dropFrame);
            }

            return ftcFrames;
        }

        #endregion

        #region 获取帧率和修正值

        /// <summary>
        ///   获取帧率和修正值
        /// </summary>
        /// <param name = "dFrameRate">输入帧率</param>
        /// <param name = "dRate">修正帧率</param>
        /// <param name = "dScale">修正值</param>
        public static void FrameRate2RateAndScale(double dFrameRate, ref double dRate, ref double dScale)
        {
            if (Math.Abs(dFrameRate - MpcStFrameRate25 / (double)MpcStScale25) < 0.01)
            {
                dRate = MpcStFrameRate25;
                dScale = MpcStScale25;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate2997 / (double)MpcStScale2997) < 0.01)
            {
                dRate = MpcStFrameRate2997;
                dScale = MpcStScale2997;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate30 / (double)MpcStScale30) < 0.01)
            {
                dRate = MpcStFrameRate30;
                dScale = MpcStScale30;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate24 / (double)MpcStScale24) < 0.01)
            {
                dRate = MpcStFrameRate24;
                dScale = MpcStScale24;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate2398 / (double)MpcStScale2398) < 0.01)
            {
                dRate = MpcStFrameRate2398;
                dScale = MpcStScale2398;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate50 / (double)MpcStScale50) < 0.01)
            {
                dRate = MpcStFrameRate50;
                dScale = MpcStScale50;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate5994 / (double)MpcStScale5994) < 0.01)
            {
                dRate = MpcStFrameRate5994;
                dScale = MpcStScale5994;
            }
            else if (Math.Abs(dFrameRate - MpcStFrameRate60 / (double)MpcStScale60) < 0.01)
            {
                dRate = MpcStFrameRate60;
                dScale = MpcStScale60;
            }
        }

        #endregion

        #region 百纳秒转帧

        /// <summary>
        ///   百纳秒转帧
        /// </summary>
        /// <param name = "l100Ns">百纳秒</param>
        /// <param name = "dRate">帧率</param>
        /// <param name = "dScale">修正值</param>
        /// <returns>帧</returns>
        public static long L100Ns2Frame(long l100Ns, double dRate, double dScale)
        {
            double dFrameRate = MpcStFrameRate25;
            double dFrameScale = MpcStScale25;
            Rate2ScaleFrameRateAndFrameScale(dRate, dScale, ref dFrameRate, ref dFrameScale);

            return Convert.ToInt64(Math.Floor(l100Ns / Math.Pow(10, 7) * dFrameRate / dFrameScale + 0.5));
        }

        /// <summary>
        ///   百纳秒转帧
        /// </summary>
        /// <param name = "l100Ns">百纳秒</param>
        /// <param name = "dFrameRate">帧率</param>
        /// <returns>帧</returns>
        public static long L100Ns2Frame(long l100Ns, double dFrameRate)
        {
            double dRate = MpcStFrameRate25;
            double dScale = MpcStScale25;
            FrameRate2RateAndScale(dFrameRate, ref dRate, ref dScale);

            return Convert.ToInt64(Math.Floor(l100Ns * dRate / dScale / Math.Pow(10, 7) + 0.5));
        }

        #endregion

        #region 百纳秒转时码

        /// <summary>
        ///   百纳秒转时码
        /// </summary>
        /// <param name = "l100Ns">百纳秒</param>
        /// <param name = "dropFrame">是否是丢帧</param>
        /// <returns>时码字符串</returns>
        public static string L100Ns2Tc(long l100Ns, bool dropFrame)
        {
            long dHour = (long)Math.Floor(l100Ns / (60 * 60 * Math.Pow(10, 7)));
            long llResidue = (long)(l100Ns % (60 * 60 * Math.Pow(10, 7)));
            long dMin = (long)Math.Floor(llResidue / (60 * Math.Pow(10, 7)));
            llResidue = llResidue % Convert.ToInt64(Math.Floor(60 * Math.Pow(10, 7)));
            long dSec = (long)Math.Floor(llResidue / (Math.Pow(10, 7)));
            llResidue = llResidue % Convert.ToInt64(Math.Pow(10, 7));
            long dFraction = (long)Math.Floor((double)llResidue / (10 * 1000 * 10));
            return FormatTimeCodeString(dHour, dMin, dSec, dFraction, dropFrame);
        }

        /// <summary>
        ///   百纳秒转时码
        /// </summary>
        /// <param name = "l100Ns">百纳秒</param>
        /// <param name = "dFrameRate">帧率</param>
        /// <returns>时码字符串</returns>
        public static string L100Ns2Tc(long l100Ns, double dFrameRate, bool dropFrame)
        {
            return Frame2Tc(L100Ns2Frame(l100Ns, dFrameRate), dFrameRate, dropFrame);
        }

        #endregion

        #region 帧率修正

        /// <summary>
        ///   帧率修正
        /// </summary>
        /// <param name = "dRate">帧率</param>
        /// <param name = "dScale">修正值</param>
        /// <param name = "dFrameRate">输出帧率</param>
        /// <param name = "dFrameScale">输出修正值</param>
        public static void Rate2ScaleFrameRateAndFrameScale(double dRate, double dScale, ref double dFrameRate, ref double dFrameScale)
        {
            if ((dRate == MpcStFrameRate25 && dScale == MpcStScale25) || (dRate * MpcStScale25 == dScale * MpcStFrameRate25))
            {
                dFrameRate = MpcStFrameRate25;
                dFrameScale = MpcStScale25;
            }
            else if ((dRate == MpcStFrameRate2997 && dScale == MpcStScale2997) || (dRate * MpcStScale2997 == dScale * MpcStFrameRate2997))
            {
                dFrameRate = MpcStFrameRate2997;
                dFrameScale = MpcStScale2997;
            }
            else if ((dRate == MpcStFrameRate30 && dScale == MpcStScale30) || (dRate * MpcStScale30 == dScale * MpcStFrameRate30))
            {
                dFrameRate = MpcStFrameRate30;
                dFrameScale = MpcStScale30;
            }
            else if ((dRate == MpcStFrameRate24 && dScale == MpcStScale24) || (dRate * MpcStScale24 == dScale * MpcStFrameRate24))
            {
                dFrameRate = MpcStFrameRate24;
                dFrameScale = MpcStScale24;
            }
            else if ((dRate == MpcStFrameRate2398 && dScale == MpcStScale2398) || (dRate * MpcStScale2398 == dScale * MpcStFrameRate2398))
            {
                dFrameRate = MpcStFrameRate2398;
                dFrameScale = MpcStScale2398;
            }
            else if ((dRate == MpcStFrameRate50 && dScale == MpcStScale50) || (dRate * MpcStScale50 == dScale * MpcStFrameRate50))
            {
                dFrameRate = MpcStFrameRate50;
                dFrameScale = MpcStScale50;
            }
            else if ((dRate == MpcStFrameRate5994 && dScale == MpcStScale5994) || (dRate * MpcStScale5994 == dScale * MpcStFrameRate5994))
            {
                dFrameRate = MpcStFrameRate5994;
                dFrameScale = MpcStScale5994;
            }
            else if ((dRate == MpcStFrameRate60 && dScale == MpcStScale60) || (dRate * MpcStScale60 == dScale * MpcStFrameRate60))
            {
                dFrameRate = MpcStFrameRate60;
                dFrameScale = MpcStScale60;
            }
        }

        #endregion

        #region 秒转帧

        /// <summary>
        ///   秒转帧
        /// </summary>
        /// <param name = "dbSec">秒数</param>
        /// <param name = "dRate">帧率</param>
        /// <param name = "dScale">修正值</param>
        /// <returns>帧数</returns>
        public static long Second2Frame(double dbSec, double dRate, double dScale)
        {
            dbSec = Math.Ceiling(dbSec * Math.Pow(10, 7));
            double dFrameRate = MpcStFrameRate25;
            double dFrameScale = MpcStScale25;
            Rate2ScaleFrameRateAndFrameScale(dRate, dScale, ref dFrameRate, ref dFrameScale);

            //return Convert.ToInt64( dbSec * dRate / dScale );
            return Convert.ToInt64(Math.Floor(dbSec * dFrameRate / dFrameScale / Math.Pow(10, 7)));
        }

        /// <summary>
        ///   秒转帧
        /// </summary>
        /// <param name = "dbSec">秒数</param>
        /// <param name = "dFrameRate">帧率</param>
        /// <returns>帧数</returns>
        public static long Second2Frame(double dbSec, double dFrameRate)
        {
            //超过24的归零
            if (dbSec >= 24 * 60 * 60)
            {
                dbSec = dbSec - 24 * 60 * 60;

                return Second2Frame(dbSec, dFrameRate);
            }

            dbSec = Math.Ceiling(dbSec * Math.Pow(10, 7));
            double dRate = MpcStFrameRate25;
            double dScale = MpcStScale25;
            FrameRate2RateAndScale(dFrameRate, ref dRate, ref dScale);

            //return Convert.ToInt64( dbSec * dRate / dScale );
            return Convert.ToInt64(Math.Floor(dbSec * dRate / dScale / Math.Pow(10, 7)));
        }

        #endregion

        #region 格式化时码字符串

        /// <summary>
        ///   格式化时码字符串
        /// </summary>
        /// <param name = "hours">小时数</param>
        /// <param name = "minutes">分指数</param>
        /// <param name = "seconds">秒数</param>
        /// <param name = "frames">帧数</param>
        /// <param name = "dropFrame">是否是丢帧</param>
        /// <returns>格式化后的时码字符串</returns>
        public static string FormatTimeCodeString(long hours, long minutes, long seconds, long frames, bool dropFrame)
        {
            hours = hours >= 24 ? hours - 24 : hours;
            minutes = minutes >= 60 ? minutes - 60 : minutes;
            seconds = seconds >= 60 ? seconds - 60 : seconds;

            string framesSeparator = ".";
            if (!dropFrame)
            {
                framesSeparator = ":";
            }

            hours = (long)(Math.Floor(hours % 24.0));

            return string.Format("{0:D2}:{1:D2}{4}{2:D2}:{3:D2}", hours, minutes, seconds, frames, framesSeparator);
        }


        public static string FormatTimeCodeString(string timeCode, double dFrameRate, bool dropFrame)
        {
            if (!string.IsNullOrEmpty(timeCode))
            {
                #region 兼容以前.在帧前面的情况

                if (timeCode.Length == 11)
                {
                    char[] c = timeCode.ToCharArray();
                    if (c[8] == '.')
                    {
                        c[8] = ':';
                        c[5] = '.';
                    }
                    timeCode = new string(c);
                }

                #endregion

                long hours = 0;
                long minutes = 0;
                long seconds = 0;
                long frames = 0;
                string[] ftcs = timeCode.Split(':');
                hours = long.Parse(ftcs[0]);
                if (ftcs.Length >= 4)
                {
                    minutes = long.Parse(ftcs[1]);
                    seconds = long.Parse(ftcs[2]);

                    if (int.Parse(ftcs[3]) >= dFrameRate)
                    {
                        #region 修正最后一位 29.97最大显示29 25最大显示24

                        double showframeRate = Math.Ceiling(dFrameRate) - 1;

                        #endregion

                        ftcs[3] = showframeRate.ToString();
                    }
                    else
                    {
                        #region 验证是否是丢帧时码

                        //验证是否是丢帧时码 
                        if (dropFrame)
                        {
                            //如果是丢帧帧率 分钟 除开 00 10 20 30 40 50 外所有的 00 01帧不存在 强制设置为02帧 5994强制设置为04帧
                            string[] dropM =
                            {
                                "00", "10", "20", "30", "40", "50"
                            };
                            string[] drop5994F =
                            {
                                "00", "01", "02", "03"
                            };
                            string[] dropF =
                            {
                                "00", "01"
                            };

                            if (ftcs[2] == "00" && !dropM.Contains(ftcs[1]) && drop5994F.Contains(ftcs[3]))
                            {
                                if (Math.Abs(60.0 - dFrameRate) < 0.1)
                                {
                                    ftcs[3] = "04";
                                }
                                else if (Math.Abs(30.0 - dFrameRate) < 0.1 || Math.Abs(24.0 - dFrameRate) < 0.1)
                                {
                                    if (dropF.Contains(ftcs[3]))
                                    {
                                        ftcs[3] = "02";
                                    }
                                }
                            }
                        }

                        #endregion
                    }
                    frames = long.Parse(ftcs[3]);
                }
                else
                {
                    string[] ftcssf = ftcs[1].Split('.');
                    minutes = long.Parse(ftcssf[0]);
                    seconds = long.Parse(ftcssf[1]);

                    if (int.Parse(ftcs[2]) >= dFrameRate)
                    {
                        #region 修正最后一位 29.97最大显示29 25最大显示24

                        double showframeRate = Math.Ceiling(dFrameRate) - 1;

                        #endregion

                        ftcs[2] = showframeRate.ToString();
                    }
                    else
                    {
                        #region 验证是否是丢帧时码

                        //验证是否是丢帧时码 
                        if (dropFrame)
                        {
                            //如果是丢帧帧率 分钟 除开 00 10 20 30 40 50 外所有的 00 01帧不存在 强制设置为02帧
                            string[] dropM =
                            {
                                "00", "10", "20", "30", "40", "50"
                            };
                            string[] drop5994F =
                            {
                                "00", "01", "02", "03"
                            };
                            string[] dropF =
                            {
                                "00", "01"
                            };

                            if (ftcssf[1] == "00" && !dropM.Contains(ftcssf[0]) && drop5994F.Contains(ftcs[2]))
                            {
                                if (Math.Abs(60.0 - dFrameRate) < 0.1)
                                {
                                    ftcs[2] = "04";
                                }
                                else if (Math.Abs(30.0 - dFrameRate) < 0.1 || Math.Abs(24.0 - dFrameRate) < 0.1)
                                {
                                    if (dropF.Contains(ftcs[2]))
                                    {
                                        ftcs[2] = "02";
                                    }
                                }
                            }
                        }

                        #endregion
                    }
                    frames = long.Parse(ftcs[2]);
                }

                return FormatTimeCodeString(hours, minutes, seconds, frames, dropFrame);
            }
            return "--:--:--:--";
        }

        #endregion

        #region 时间字符串转秒

        /// <summary>
        /// 递归解决时码丢帧的问题
        /// </summary>
        /// <param name="sTimeCode"></param>
        /// <param name="ftcFrames"></param>
        /// <param name="isAdded">是否加修正值 为false的时候 为减了修正值</param>
        /// <param name="corrValue"> 修正值</param>
        /// <param name="dFrameRate"></param>
        /// <returns></returns>
        private static long GetFrameByTimeCode(string sTimeCode, long ftcFrames, bool isAdded, long corrValue, double dFrameRate, bool dropFrame)
        {
            long ftcNewFrames = 0;
            if (isAdded)
            {
                ftcNewFrames = ftcFrames + corrValue;
            }
            else
            {
                ftcNewFrames = ftcFrames - corrValue;
                corrValue++;
            }
            string newTc = Frame2Tc(ftcNewFrames, dFrameRate, dropFrame);

            #region 防止因为 . 和 : 导致不一样

            newTc = newTc.Replace(".", ":");
            sTimeCode = sTimeCode.Replace(".", ":");

            #endregion

            if (newTc != sTimeCode)
            {
                return GetFrameByTimeCode(sTimeCode, ftcFrames, !isAdded, corrValue, dFrameRate, dropFrame);
            }

            return ftcNewFrames;
        }

        /// <summary>
        /// 获取此帧率是否丢帧
        /// </summary>
        /// <param name="rate">帧率</param>
        /// <returns></returns>
        public static bool GetRateDropFrame(double rate)
        {
            if (rate == 23.98 || (rate < 24 && rate > 23))
            {
                return true;
            }
            else if (rate == 24.0)
            {
                return false;
            }
            else if (rate == 25.0)
            {
                return false;
            }
            else if (rate == 29.97 || (rate < 30 && rate > 29))
            {
                return true;
            }
            else if (rate == 30.0)
            {
                return false;
            }
            else if (rate == 50.0)
            {
                return false;
            }
            else if (rate == 59.94 || (rate < 60 && rate > 59))
            {
                return true;
            }
            else if (rate == 60.0)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        ///   时间字符串转秒(未考虑丢帧的情况)
        /// </summary>
        /// <returns>帧数</returns>
        private static long TimeCode2NdfFrame(string sTimeCode, double dFrameRate)
        {
            long ftcSeconds = 0;
            long ftcFrames = 0;

            long lHour = 0;
            long lMinute = 0;
            long lSecond = 0;
            long lFrame = 0;

            TimeCode2Format(sTimeCode, out lHour, out lMinute, out lSecond, out lFrame, dFrameRate);

            ftcSeconds += lHour * 60 * 60;
            ftcSeconds += lMinute * 60;
            ftcSeconds += lSecond;
            ftcFrames += lFrame;
            ftcFrames += Second2Frame(ftcSeconds, dFrameRate);

            return ftcFrames;
        }



        /// <summary>
        ///   时间字符串格式化
        /// </summary>
        /// <returns>帧数</returns>
        private static void TimeCode2Format(string sTimeCode, out long lHour, out long lMinute, out long lSecond, out long lFrame, double dFrameRate)
        {
            string[] ftcCodes = sTimeCode.Split(':');

            if (ftcCodes.Length >= 4)
            {
                lHour = long.Parse(ftcCodes[0]);
                lMinute = long.Parse(ftcCodes[1]);
                lSecond = long.Parse(ftcCodes[2]);
                lFrame = long.Parse(ftcCodes[3]);
            }
            else
            {
                string[] ftcssf = ftcCodes[1].Split('.');
                lHour = long.Parse(ftcCodes[0]);
                lMinute = long.Parse(ftcssf[0]);
                lSecond = long.Parse(ftcssf[1]);
                lFrame = long.Parse(ftcCodes[2]);
            }

            lHour = lHour >= 24 ? lHour - 24 : lHour;
            lMinute = lMinute >= 60 ? lMinute - 60 : lMinute;
            lSecond = lSecond >= 60 ? lSecond - 60 : lSecond;
            lFrame = lFrame >= Math.Ceiling(dFrameRate) ? lFrame - (long)Math.Ceiling(dFrameRate) : lFrame;
        }

        #endregion

        #endregion Methods
    }
}