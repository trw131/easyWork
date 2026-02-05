using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyWork.Models;

namespace easyWork.Services
{
    /// <summary>
    /// 导出服务
    /// </summary>
    public class ExportService
    {
        /// <summary>
        /// HTML编码
        /// </summary>
        private string HtmlEncode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;")
                .Replace("\n", "<br/>");
        }

        /// <summary>
        /// 转义JavaScript字符串
        /// </summary>
        private string JsEncode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t");
        }

        /// <summary>
        /// 导出月度报表为文本文件
        /// </summary>
        public void ExportToText(List<WorkLog> logs, string fileName)
        {
            if (logs == null || logs.Count == 0)
            {
                throw new Exception("没有可导出的日志数据");
            }

            StringBuilder sb = new StringBuilder();
            
            // 添加标题
            var firstLog = logs.First();
            sb.AppendLine($"========================================");
            sb.AppendLine($"        工作日志月度报表");
            sb.AppendLine($"        {firstLog.Date:yyyy年MM月}");
            sb.AppendLine($"========================================");
            sb.AppendLine();

            // 添加日志内容
            foreach (var log in logs)
            {
                sb.AppendLine($"日期: {log.Date:yyyy-MM-dd dddd}");
                sb.AppendLine($"----------------------------------------");
                sb.AppendLine(log.Content);
                sb.AppendLine();
                sb.AppendLine();
            }

            // 添加统计信息
            sb.AppendLine($"========================================");
            sb.AppendLine($"本月共记录 {logs.Count} 天工作日志");
            sb.AppendLine($"导出时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"========================================");

            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// 生成纯文本内容(用于HTML中的下载)
        /// </summary>
        private string GenerateTextContent(List<WorkLog> logs)
        {
            StringBuilder sb = new StringBuilder();
            
            // 添加标题
            var firstLog = logs.First();
            sb.AppendLine($"========================================");
            sb.AppendLine($"        工作日志月度报表");
            sb.AppendLine($"        {firstLog.Date:yyyy年MM月}");
            sb.AppendLine($"========================================");
            sb.AppendLine();

            // 添加日志内容
            foreach (var log in logs)
            {
                sb.AppendLine($"日期: {log.Date:yyyy-MM-dd dddd}");
                sb.AppendLine(log.Content);
                sb.AppendLine();
                sb.AppendLine();
            }

            // 添加统计信息
            sb.AppendLine($"========================================");
            sb.AppendLine($"本月共记录 {logs.Count} 天工作日志");
            sb.AppendLine($"导出时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"========================================");

            return sb.ToString();
        }

        /// <summary>
        /// 导出月度报表为HTML文件
        /// </summary>
        public void ExportToHtml(List<WorkLog> logs, string fileName)
        {
            if (logs == null || logs.Count == 0)
            {
                throw new Exception("没有可导出的日志数据");
            }

            StringBuilder sb = new StringBuilder();
            var firstLog = logs.First();

            // 生成纯文本内容用于下载
            string textContent = GenerateTextContent(logs);
            string jsEncodedText = JsEncode(textContent);

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("    <meta charset='utf-8'>");
            sb.AppendLine($"    <title>工作日志 - {firstLog.Date:yyyy年MM月}</title>");
            sb.AppendLine("    <style>");
            sb.AppendLine("        body { font-family: '微软雅黑', Arial, sans-serif; margin: 20px; background-color: #f5f5f5; }");
            sb.AppendLine("        .header { text-align: center; background-color: #4CAF50; color: white; padding: 20px; border-radius: 5px; position: relative; }");
            sb.AppendLine("        .export-btn { position: absolute; right: 20px; top: 50%; transform: translateY(-50%); background-color: white; color: #4CAF50; border: none; padding: 10px 20px; border-radius: 5px; cursor: pointer; font-size: 14px; font-weight: bold; }");
            sb.AppendLine("        .export-btn:hover { background-color: #f0f0f0; }");
            sb.AppendLine("        .log-item { background-color: white; margin: 20px 0; padding: 20px; border-radius: 5px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); }");
            sb.AppendLine("        .log-date { color: #4CAF50; font-size: 18px; font-weight: bold; border-bottom: 2px solid #4CAF50; padding-bottom: 10px; margin-bottom: 15px; }");
            sb.AppendLine("        .log-content { line-height: 1.8; white-space: pre-wrap; }");
            sb.AppendLine("        .footer { text-align: center; margin-top: 30px; color: #666; }");
            sb.AppendLine("    </style>");
            sb.AppendLine("    <script>");
            sb.AppendLine("        function exportToTxt() {");
            sb.AppendLine($"            var textContent = \"{jsEncodedText}\";");
            sb.AppendLine("            var blob = new Blob([textContent], { type: 'text/plain;charset=utf-8' });");
            sb.AppendLine("            var link = document.createElement('a');");
            sb.AppendLine($"            link.href = URL.createObjectURL(blob);");
            sb.AppendLine($"            link.download = '工作日志_{firstLog.Date:yyyy年MM月}.txt';");
            sb.AppendLine("            document.body.appendChild(link);");
            sb.AppendLine("            link.click();");
            sb.AppendLine("            document.body.removeChild(link);");
            sb.AppendLine("        }");
            sb.AppendLine("    </script>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine($"    <div class='header'>");
            sb.AppendLine($"        <button class='export-btn' onclick='exportToTxt()'>导出为TXT</button>");
            sb.AppendLine($"        <h1>工作日志月度报表</h1>");
            sb.AppendLine($"        <h2>{firstLog.Date:yyyy年MM月}</h2>");
            sb.AppendLine($"    </div>");

            foreach (var log in logs)
            {
                sb.AppendLine($"    <div class='log-item'>");
                sb.AppendLine($"        <div class='log-date'>{log.Date:yyyy-MM-dd dddd}</div>");
                sb.AppendLine($"        <div class='log-content'>{HtmlEncode(log.Content)}</div>");
                sb.AppendLine($"    </div>");
            }

            sb.AppendLine($"    <div class='footer'>");
            sb.AppendLine($"        <p>本月共记录 {logs.Count} 天工作日志</p>");
            sb.AppendLine($"        <p>导出时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
            sb.AppendLine($"    </div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
        }
    }
}