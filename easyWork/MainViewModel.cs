using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using easyWork.Models;
using easyWork.Services;
using easyWork.Views;

namespace easyWork
{
    [POCOViewModel()]
    public class MainViewModel
    {
        private readonly WorkLogService _logService;
        private System.Windows.Forms.Timer _autoSaveTimer;
        private HistoryDialog _historyDialog;

        protected MainViewModel()
        {
            _logService = new WorkLogService();
            
            // 加载今日日志
            CurrentLog = _logService.LoadLog(DateTime.Today);
            
            // 设置自动保存定时器(每30秒自动保存一次)
            _autoSaveTimer = new System.Windows.Forms.Timer();
            _autoSaveTimer.Interval = 30000;
            _autoSaveTimer.Tick += OnAutoSave;
            _autoSaveTimer.Start();
        }

        /// <summary>
        /// 当前日志
        /// </summary>
        public virtual WorkLog CurrentLog { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public virtual string LogContent
        {
            get { return CurrentLog?.Content; }
            set
            {
                if (CurrentLog != null && CurrentLog.Content != value)
                {
                    CurrentLog.Content = value;
                    // 内容变化时立即保存
                    SaveCurrentLog();
                }
            }
        }

        /// <summary>
        /// 当前日期显示
        /// </summary>
        public virtual string CurrentDateText
        {
            get { return CurrentLog?.Date.ToString("yyyy年MM月dd日 dddd"); }
        }

        /// <summary>
        /// 上次保存时间
        /// </summary>
        public virtual string LastSavedText
        {
            get
            {
                if (CurrentLog?.LastModified == null || CurrentLog.LastModified == DateTime.MinValue)
                    return "尚未保存";
                return $"最后保存: {CurrentLog.LastModified:HH:mm:ss}";
            }
        }

        /// <summary>
        /// 保存当前日志
        /// </summary>
        private void SaveCurrentLog()
        {
            if (CurrentLog != null)
            {
                _logService.SaveLog(CurrentLog);
                this.RaisePropertyChanged(x => x.LastSavedText);
            }
        }

        /// <summary>
        /// 刷新今日日志(从外部调用)
        /// </summary>
        public void RefreshTodayLog()
        {
            CurrentLog = _logService.LoadLog(DateTime.Today);
            this.RaisePropertyChanged(x => x.CurrentLog);
            this.RaisePropertyChanged(x => x.LogContent);
            this.RaisePropertyChanged(x => x.LastSavedText);
        }

        /// <summary>
        /// 自动保存事件
        /// </summary>
        private void OnAutoSave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LogContent))
            {
                SaveCurrentLog();
            }
        }

        /// <summary>
        /// 复制今日日志
        /// </summary>
        public void CopyTodayLog()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LogContent))
                {
                    return;
                }

                // 构建带日期的完整内容
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(LogContent);

                // 复制到剪贴板
                Clipboard.SetText(sb.ToString());
            }
            catch
            {
                // 静默处理错误
            }
        }

        /// <summary>
        /// 导出月度报表
        /// </summary>
        public void ExportMonthlyReport()
        {
            ExportDialog dialog = new ExportDialog();
            dialog.ShowDialog();
        }

        /// <summary>
        /// 复制上周日志(Markdown)
        /// </summary>
        public void CopyLastWeekLogAsMarkdown()
        {
            try
            {
                DateTime lastWeekStart = GetLastWeekStart(DateTime.Today);
                DateTime lastWeekEnd = lastWeekStart.AddDays(6);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"# 上周工作日志（{lastWeekStart:yyyy-MM-dd} ~ {lastWeekEnd:yyyy-MM-dd}）");
                sb.AppendLine();

                for (DateTime date = lastWeekStart; date <= lastWeekEnd; date = date.AddDays(1))
                {
                    WorkLog log = _logService.LoadLog(date);

                    sb.AppendLine($"## {date:yyyy-MM-dd} {GetChineseWeekText(date)}");
                    sb.AppendLine();

                    if (string.IsNullOrWhiteSpace(log.Content))
                    {
                        sb.AppendLine("- 暂无日志");
                    }
                    else
                    {
                        sb.AppendLine(log.Content.Trim());
                    }

                    sb.AppendLine();
                }

                Clipboard.SetText(sb.ToString().TrimEnd());
            }
            catch
            {
                // 静默处理错误
            }
        }

        /// <summary>
        /// 查看历史日志
        /// </summary>
        public void ViewHistory()
        {
            if (_historyDialog == null || _historyDialog.IsDisposed)
            {
                _historyDialog = new HistoryDialog();
                _historyDialog.FormClosed += OnHistoryDialogClosed;
                _historyDialog.Show();
                return;
            }

            if (_historyDialog.WindowState == FormWindowState.Minimized)
            {
                _historyDialog.WindowState = FormWindowState.Normal;
            }

            _historyDialog.Activate();
        }

        private void OnHistoryDialogClosed(object sender, FormClosedEventArgs e)
        {
            if (_historyDialog != null)
            {
                _historyDialog.FormClosed -= OnHistoryDialogClosed;
                _historyDialog = null;
            }

            RefreshTodayLog();
        }

        private DateTime GetLastWeekStart(DateTime referenceDate)
        {
            int daysSinceMonday = ((int)referenceDate.DayOfWeek + 6) % 7;
            DateTime currentWeekStart = referenceDate.Date.AddDays(-daysSinceMonday);
            return currentWeekStart.AddDays(-7);
        }

        private string GetChineseWeekText(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Saturday:
                    return "星期六";
                default:
                    return "星期日";
            }
        }

        /// <summary>
        /// 清理资源
        /// </summary>
        public void Cleanup()
        {
            if (_autoSaveTimer != null)
            {
                _autoSaveTimer.Stop();
                _autoSaveTimer.Dispose();
            }

            if (_historyDialog != null && !_historyDialog.IsDisposed)
            {
                _historyDialog.FormClosed -= OnHistoryDialogClosed;
                _historyDialog.Close();
                _historyDialog.Dispose();
                _historyDialog = null;
            }
            
            // 最后保存一次
            SaveCurrentLog();
        }
    }
}
