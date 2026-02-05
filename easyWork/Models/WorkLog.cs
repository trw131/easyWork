using System;

namespace easyWork.Models
{
    /// <summary>
    /// 工作日志实体
    /// </summary>
    public class WorkLog
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public DateTime LastModified { get; set; }

        public WorkLog()
        {
            Date = DateTime.Today;
            Content = string.Empty;
            LastModified = DateTime.Now;
        }
    }
}