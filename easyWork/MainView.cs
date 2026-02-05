using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easyWork
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        public MainView()
        {
            InitializeComponent();
            
            // 设置窗体启动位置为屏幕中央
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // 设置窗体最小尺寸
            this.MinimumSize = new Size(800, 500);
            
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
            
            // 绑定当前日期
            fluent.SetBinding(lblCurrentDate, l => l.Text, x => x.CurrentDateText);
            
            // 绑定日志内容(实时保存)
            fluent.SetBinding(memoEditLog, m => m.EditValue, x => x.LogContent);
            
            // 绑定最后保存时间
            fluent.SetBinding(lblLastSaved, l => l.Text, x => x.LastSavedText);
            
            // 绑定按钮命令
            fluent.BindCommand(btnExport, x => x.ExportMonthlyReport());
            fluent.BindCommand(btnHistory, x => x.ViewHistory());
            fluent.BindCommand(btnCopy, x => x.CopyTodayLog());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 窗体关闭时清理资源
            var viewModel = mvvmContext1.GetViewModel<MainViewModel>();
            if (viewModel != null)
            {
                viewModel.Cleanup();
            }
            base.OnFormClosing(e);
        }
    }
}
