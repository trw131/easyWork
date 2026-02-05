using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using easyWork.Models;

namespace easyWork.Services
{
    /// <summary>
    /// 工作日志数据服务
    /// </summary>
    public class WorkLogService
    {
        private static readonly string DataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "EasyWork",
            "Logs"
        );

        public WorkLogService()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }

        /// <summary>
        /// 获取指定日期的日志文件路径
        /// </summary>
        private string GetLogFilePath(DateTime date)
        {
            return Path.Combine(DataFolder, $"{date:yyyy-MM-dd}.xml");
        }

        /// <summary>
        /// 加载指定日期的日志
        /// </summary>
        public WorkLog LoadLog(DateTime date)
        {
            string filePath = GetLogFilePath(date);
            
            if (!File.Exists(filePath))
            {
                return new WorkLog { Date = date };
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WorkLog));
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    WorkLog log = (WorkLog)serializer.Deserialize(fs);
                    
                    // 确保换行符格式正确 - 统一转换为 \r\n (Windows标准)
                    if (!string.IsNullOrEmpty(log.Content))
                    {
                        log.Content = NormalizeLineEndings(log.Content);
                    }
                    
                    return log;
                }
            }
            catch
            {
                return new WorkLog { Date = date };
            }
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        public void SaveLog(WorkLog log)
        {
            log.LastModified = DateTime.Now;
            
            // 保存前确保换行符格式正确
            if (!string.IsNullOrEmpty(log.Content))
            {
                log.Content = NormalizeLineEndings(log.Content);
            }
            
            string filePath = GetLogFilePath(log.Date);

            try
            {
                // 使用 UTF-8 编码并保留换行符
                XmlSerializer serializer = new XmlSerializer(typeof(WorkLog));
                using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(false)))
                {
                    serializer.Serialize(writer, log);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"保存日志失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 标准化换行符 - 统一转换为 Windows 标准的 \r\n
        /// </summary>
        private string NormalizeLineEndings(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // 先将所有换行符统一为 \n
            text = text.Replace("\r\n", "\n");
            text = text.Replace("\r", "\n");
            
            // 再统一转换为 \r\n (Windows标准)
            text = text.Replace("\n", "\r\n");
            
            return text;
        }

        /// <summary>
        /// 获取指定月份的所有日志
        /// </summary>
        public List<WorkLog> GetMonthLogs(int year, int month)
        {
            List<WorkLog> logs = new List<WorkLog>();
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                string filePath = GetLogFilePath(date);
                if (File.Exists(filePath))
                {
                    WorkLog log = LoadLog(date);
                    if (!string.IsNullOrWhiteSpace(log.Content))
                    {
                        logs.Add(log);
                    }
                }
            }

            return logs.OrderBy(l => l.Date).ToList();
        }
    }
}