using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using easyWork.Services;

namespace easyWork.Views
{
    public partial class ExportDialog : XtraForm
    {
        private readonly WorkLogService _logService;
        private readonly ExportService _exportService;

        public ExportDialog()
        {
            InitializeComponent();
            
            // 设置窗体启动位置为父窗体中央
            this.StartPosition = FormStartPosition.CenterParent;
            
            _logService = new WorkLogService();
            _exportService = new ExportService();
            
            // 初始化年月选择器
            dateEditMonth.Properties.DisplayFormat.FormatString = "yyyy年MM月";
            dateEditMonth.Properties.EditFormat.FormatString = "yyyy年MM月";
            dateEditMonth.EditValue = DateTime.Today;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = (DateTime)dateEditMonth.EditValue;
                var logs = _logService.GetMonthLogs(selectedDate.Year, selectedDate.Month);

                if (logs.Count == 0)
                {
                    XtraMessageBox.Show("该月份没有工作日志记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "HTML文件 (*.html)|*.html|文本文件 (*.txt)|*.txt";
                saveDialog.FileName = $"工作日志_{selectedDate:yyyy年MM月}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveDialog.FilterIndex == 1)
                    {
                        _exportService.ExportToHtml(logs, saveDialog.FileName);
                    }
                    else
                    {
                        _exportService.ExportToText(logs, saveDialog.FileName);
                    }

                    XtraMessageBox.Show($"导出成功!\n共导出 {logs.Count} 天的工作日志。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"导出失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}