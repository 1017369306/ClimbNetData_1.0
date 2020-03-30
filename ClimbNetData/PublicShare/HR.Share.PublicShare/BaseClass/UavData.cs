using System.ComponentModel;

namespace HR.Share.PublicShare.BaseClass
{
    public class UavData
    {
        private string _guid;
        private string _findTime;
        private string _uavType;
        private double _freq;
        private double _bw;
        private double _distance;

        [DescriptionAttribute("Guid")]
        public string Guid { get => _guid; set => _guid = value; }
        [DescriptionAttribute("发现时间")]
        public string FindTime { get => _findTime; set => _findTime = value; }
        [DescriptionAttribute("无人机类型")]
        public string UavType { get => _uavType; set => _uavType = value; }
        [DescriptionAttribute("频率")]
        public double Freq { get => _freq; set => _freq = value; }
        [DescriptionAttribute("步进")]
        public double Bw { get => _bw; set => _bw = value; }
        [DescriptionAttribute("距离")]
        public double Distance { get => _distance; set => _distance = value; }
    }

    public struct SortResultData
    {
        private string _uavType;
        private string _uavId;
        private int _sortCount;

        public string UavType { get => _uavType; set => _uavType = value; }
        public string UavId { get => _uavId; set => _uavId = value; }
        public int SortCount { get => _sortCount; set => _sortCount = value; }
    }

    /// <summary>
    /// 返回日志信息结构体
    /// </summary>
    public struct LogData
    {
        /// <summary>
        /// 成功捕获次数
        /// </summary>
        private int CatchCount;
        /// <summary>
        /// 起跟踪采样点
        /// </summary>
        private int SamplingPoint;
        /// <summary>
        /// 工作频点
        /// </summary>
        private double FrequencyPoint;
        /// <summary>
        /// 峰值
        /// </summary>
        private double PeakValue;
    }
}
