using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using easyWork.Models;
using easyWork.Services;

namespace easyWork.Views
{
    public partial class HistoryDialog : XtraForm
    {
        private readonly WorkLogService _logService;
        private List<WorkLog> _logs;
        private bool _isEditing = false;
        private WorkLog _currentEditingLog = null;

        // 保存原始内容用于取消编辑
        private string _originalContent = null;

        public HistoryDialog()
        {
            InitializeComponent();
            
            // 设置窗体启动位置为父窗体中央
            this.StartPosition = FormStartPosition.CenterParent;
            
            // 设置窗体最小尺寸
            this.MinimumSize = new Size(900, 650);
            
            _logService = new WorkLogService();
            
            // 初始化年月选择器
            dateEditMonth.Properties.DisplayFormat.FormatString = "yyyy年MM月";
            dateEditMonth.Properties.EditFormat.FormatString = "yyyy年MM月";
            dateEditMonth.EditValue = DateTime.Today;
            
            // 配置MemoEdit支持换行显示 - 关键配置
            memoEdit1.Properties.WordWrap = true;                      // 自动换行
            memoEdit1.Properties.ScrollBars = ScrollBars.Vertical;     // 垂直滚动条
            memoEdit1.Properties.AcceptsReturn = true;                 // 接受回车键
            memoEdit1.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap; // DevExpress特有的换行设置
            
            LoadMonthLogs();
        }

        private void dateEditMonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadMonthLogs();
        }

        private void LoadMonthLogs()
        {
            DateTime selectedDate = (DateTime)dateEditMonth.EditValue;
            
            // 获取该月所有日期(包括没有日志的)
            _logs = new List<WorkLog>();
            
            int year = selectedDate.Year;
            int month = selectedDate.Month;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            
            // 加载已有的日志
            var existingLogs = _logService.GetMonthLogs(year, month);
            
            // 生成完整的月份日期列表
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(year, month, day);
                
                // 查找是否已有日志
                var existingLog = existingLogs.Find(l => l.Date.Date == date.Date);
                
                if (existingLog != null)
                {
                    _logs.Add(existingLog);
                }
                else
                {
                    // 创建空日志占位
                    _logs.Add(new WorkLog { Date = date, Content = "" });
                }
            }
            
            // 更新列表显示
            listBoxControl1.Items.Clear();
            foreach (var log in _logs)
            {
                string dateText = $"{log.Date:yyyy-MM-dd dddd}";
                if (!string.IsNullOrWhiteSpace(log.Content))
                {
                    dateText += " ✓"; // 有内容的日期加标记
                }
                listBoxControl1.Items.Add(dateText);
            }

            if (_logs.Count > 0)
            {
                // 默认选中今天或最后一天
                DateTime today = DateTime.Today;
                int todayIndex = _logs.FindIndex(l => l.Date.Date == today);
                
                if (todayIndex >= 0)
                {
                    listBoxControl1.SelectedIndex = todayIndex;
                }
                else
                {
                    listBoxControl1.SelectedIndex = _logs.Count - 1;
                }
            }
            else
            {
                memoEdit1.Text = "该月份没有日期";
            }
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedIndex >= 0 && listBoxControl1.SelectedIndex < _logs.Count)
            {
                var selectedLog = _logs[listBoxControl1.SelectedIndex];
                
                if (string.IsNullOrWhiteSpace(selectedLog.Content))
                {
                    memoEdit1.Text = "[暂无日志内容,点击'编辑/追加'可以添加内容]";
                }
                else
                {
                    // 直接设置内容,MemoEdit会自动处理换行符
                    memoEdit1.Text = selectedLog.Content;
                }
                
                // 如果正在编辑模式,切换日期时不自动退出,而是提示
                if (_isEditing)
                {
                    // 这里不调用CancelEdit,因为日期列表已被禁用
                    // 编辑模式下无法切换日期
                }
            }
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            // 如果正在编辑模式,不响应双击复制
            if (_isEditing)
            {
                return;
            }
            
            CopySelectedLog();
        }

        private void CopySelectedLog()
        {
            if (listBoxControl1.SelectedIndex >= 0 && listBoxControl1.SelectedIndex < _logs.Count)
            {
                var selectedLog = _logs[listBoxControl1.SelectedIndex];
                
                if (string.IsNullOrWhiteSpace(selectedLog.Content))
                {
                    return;
                }

                try
                {
                    // 构建带日期的完整内容(保留原始换行)
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"日期: {selectedLog.Date:yyyy-MM-dd dddd}");
                    sb.Append(selectedLog.Content); // 不使用AppendLine,保留原始格式

                    // 复制到剪贴板
                    Clipboard.SetText(sb.ToString());
                    
                    // 显示简短的提示
                    this.Text = $"历史日志查看 - 已复制 {selectedLog.Date:MM-dd}";
                    
                    // 2秒后恢复标题
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 2000;
                    timer.Tick += (s, args) =>
                    {
                        if (!_isEditing)
                        {
                            this.Text = "历史日志查看";
                        }
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                }
                catch
                {
                    // 静默处理错误
                }
            }
        }

        /// <summary>
        /// 编辑/取消按钮点击
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                // 当前是编辑模式,点击=取消编辑
                CancelEdit();
            }
            else
            {
                // 当前不是编辑模式,点击=进入编辑
                if (listBoxControl1.SelectedIndex < 0 || listBoxControl1.SelectedIndex >= _logs.Count)
                {
                    XtraMessageBox.Show("请先选择要编辑的日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                EnterEditMode();
            }
        }

        /// <summary>
        /// 进入编辑模式
        /// </summary>
        private void EnterEditMode()
        {
            _isEditing = true;
            _currentEditingLog = _logs[listBoxControl1.SelectedIndex];
            
            // 保存原始内容用于取消编辑
            _originalContent = _currentEditingLog.Content;
            
            // 如果是空日志,清空提示文本
            if (string.IsNullOrWhiteSpace(_currentEditingLog.Content))
            {
                memoEdit1.Text = "";
            }
            else
            {
                memoEdit1.Text = _currentEditingLog.Content;
            }
            
            // 设置编辑框为可编辑
            memoEdit1.Properties.ReadOnly = false;
            memoEdit1.BackColor = System.Drawing.Color.White;
            
            // 调整按钮状态
            btnEdit.Text = "取消编辑";
            btnEdit.Enabled = true;
            btnSave.Visible = true;
            btnSave.Enabled = true;
            btnClose.Enabled = false; // 灰化关闭按钮
            
            // 禁用日期选择和列表,防止切换
            dateEditMonth.Enabled = false;
            listBoxControl1.Enabled = false;
            
            // 修改窗口标题
            this.Text = $"编辑模式 - {_currentEditingLog.Date:yyyy-MM-dd}";
            
            // 聚焦到编辑框末尾
            memoEdit1.Focus();
            memoEdit1.SelectionStart = memoEdit1.Text.Length;
        }

        /// <summary>
        /// 保存按钮点击
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentEditingLog == null)
            {
                return;
            }

            try
            {
                _currentEditingLog.Content = memoEdit1.Text;
                _currentEditingLog.LastModified = DateTime.Now;
                
                // 保存到文件
                _logService.SaveLog(_currentEditingLog);
                
                // 保存当前选中的索引
                int selectedIndex = listBoxControl1.SelectedIndex;
                
                // 退出编辑模式
                ExitEditMode();
                
                // 重新加载列表(更新✓标记)
                LoadMonthLogs();
                
                // 恢复选中
                if (selectedIndex >= 0 && selectedIndex < listBoxControl1.Items.Count)
                {
                    listBoxControl1.SelectedIndex = selectedIndex;
                }
                
                // 显示保存成功提示
                this.Text = "历史日志查看 - 保存成功";
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) =>
                {
                    this.Text = "历史日志查看";
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"保存失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 退出编辑模式
        /// </summary>
        private void ExitEditMode()
        {
            _isEditing = false;
            _currentEditingLog = null;
            _originalContent = null;
            
            // 恢复只读状态
            memoEdit1.Properties.ReadOnly = true;
            memoEdit1.BackColor = System.Drawing.SystemColors.Control;
            
            // 恢复按钮状态
            btnEdit.Text = "编辑/追加";
            btnEdit.Enabled = true;
            btnSave.Visible = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true; // 恢复关闭按钮
            
            // 恢复日期选择和列表
            dateEditMonth.Enabled = true;
            listBoxControl1.Enabled = true;
            
            // 恢复窗口标题
            this.Text = "历史日志查看";
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        private void CancelEdit()
        {
            if (!_isEditing)
            {
                return;
            }

            // 询问是否放弃修改
            var result = XtraMessageBox.Show(
                "是否放弃当前的修改?",
                "确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            // 恢复原始内容到编辑框
            if (string.IsNullOrWhiteSpace(_originalContent))
            {
                memoEdit1.Text = "[暂无日志内容,点击'编辑/追加'可以添加内容]";
            }
            else
            {
                memoEdit1.Text = _originalContent;
            }
            
            // 退出编辑模式
            ExitEditMode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体关闭前检查
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 只在点击X关闭时检查,避免重复提示
            if (_isEditing && e.CloseReason == CloseReason.UserClosing)
            {
                var result = XtraMessageBox.Show(
                    "当前正在编辑,是否保存修改?",
                    "提示",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else // DialogResult.No
                {
                    // 放弃修改,直接退出
                    _isEditing = false;
                }
            }

            base.OnFormClosing(e);
        }
    }
}