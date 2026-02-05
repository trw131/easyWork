namespace easyWork
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblCurrentDate = new DevExpress.XtraEditors.LabelControl();
            this.memoEditLog = new DevExpress.XtraEditors.MemoEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnHistory = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.lblLastSaved = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(easyWork.MainViewModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.Control.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.layoutControl1.Appearance.Control.Options.UseFont = true;
            this.layoutControl1.Appearance.ControlDisabled.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.layoutControl1.Appearance.ControlDisabled.Options.UseFont = true;
            this.layoutControl1.Appearance.ControlDropDown.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.layoutControl1.Appearance.ControlDropDown.Options.UseFont = true;
            this.layoutControl1.Appearance.ControlFocused.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.layoutControl1.Appearance.ControlFocused.Options.UseFont = true;
            this.layoutControl1.Appearance.ControlReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.layoutControl1.Appearance.ControlReadOnly.Options.UseFont = true;
            this.layoutControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.layoutControl1.Controls.Add(this.lblCurrentDate);
            this.layoutControl1.Controls.Add(this.memoEditLog);
            this.layoutControl1.Controls.Add(this.btnExport);
            this.layoutControl1.Controls.Add(this.btnHistory);
            this.layoutControl1.Controls.Add(this.btnCopy);
            this.layoutControl1.Controls.Add(this.lblLastSaved);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(700, 500);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentDate.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCurrentDate.Appearance.Options.UseFont = true;
            this.lblCurrentDate.Appearance.Options.UseForeColor = true;
            this.lblCurrentDate.Location = new System.Drawing.Point(12, 12);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(216, 22);
            this.lblCurrentDate.StyleController = this.layoutControl1;
            this.lblCurrentDate.TabIndex = 4;
            this.lblCurrentDate.Text = "2026年02月05日 星期四";
            // 
            // memoEditLog
            // 
            this.memoEditLog.Location = new System.Drawing.Point(12, 42);
            this.memoEditLog.Name = "memoEditLog";
            this.memoEditLog.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.memoEditLog.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.memoEditLog.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.memoEditLog.Properties.Appearance.Options.UseBackColor = true;
            this.memoEditLog.Properties.Appearance.Options.UseFont = true;
            this.memoEditLog.Properties.Appearance.Options.UseForeColor = true;
            this.memoEditLog.Properties.AcceptsReturn = true;
            this.memoEditLog.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEditLog.Properties.Padding = new System.Windows.Forms.Padding(6);
            this.memoEditLog.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoEditLog.Properties.WordWrap = true;
            this.memoEditLog.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.memoEditLog.Size = new System.Drawing.Size(676, 398);
            this.memoEditLog.StyleController = this.layoutControl1;
            this.memoEditLog.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExport.Appearance.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Location = new System.Drawing.Point(12, 450);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 36);
            this.btnExport.StyleController = this.layoutControl1;
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "导出月度报表";
            // 
            // btnHistory
            // 
            this.btnHistory.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHistory.Appearance.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.btnHistory.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Appearance.Options.UseBackColor = true;
            this.btnHistory.Appearance.Options.UseFont = true;
            this.btnHistory.Appearance.Options.UseForeColor = true;
            this.btnHistory.Location = new System.Drawing.Point(115, 450);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(95, 36);
            this.btnHistory.StyleController = this.layoutControl1;
            this.btnHistory.TabIndex = 7;
            this.btnHistory.Text = "查看历史";
            // 
            // btnCopy
            // 
            this.btnCopy.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCopy.Appearance.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.btnCopy.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Appearance.Options.UseBackColor = true;
            this.btnCopy.Appearance.Options.UseFont = true;
            this.btnCopy.Appearance.Options.UseForeColor = true;
            this.btnCopy.Location = new System.Drawing.Point(218, 450);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(95, 36);
            this.btnCopy.StyleController = this.layoutControl1;
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "复制今日日志";
            // 
            // lblLastSaved
            // 
            this.lblLastSaved.Appearance.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lblLastSaved.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblLastSaved.Appearance.Options.UseFont = true;
            this.lblLastSaved.Appearance.Options.UseForeColor = true;
            this.lblLastSaved.Appearance.Options.UseTextOptions = true;
            this.lblLastSaved.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblLastSaved.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLastSaved.Location = new System.Drawing.Point(558, 450);
            this.lblLastSaved.Name = "lblLastSaved";
            this.lblLastSaved.Size = new System.Drawing.Size(130, 36);
            this.lblLastSaved.StyleController = this.layoutControl1;
            this.lblLastSaved.TabIndex = 9;
            this.lblLastSaved.Text = "最后保存: 14:30:25";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(700, 500);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblCurrentDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(680, 28);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 4);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.memoEditLog;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(680, 408);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnExport;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 436);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(103, 44);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 6, 2, 2);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnHistory;
            this.layoutControlItem4.Location = new System.Drawing.Point(103, 436);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(103, 44);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 6, 2, 2);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCopy;
            this.layoutControlItem6.Location = new System.Drawing.Point(206, 436);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(103, 44);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 6, 2, 2);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lblLastSaved;
            this.layoutControlItem5.Location = new System.Drawing.Point(546, 436);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(134, 44);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(309, 436);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(237, 44);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyWork - 工作日志记录";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lblCurrentDate;
        private DevExpress.XtraEditors.MemoEdit memoEditLog;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnHistory;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.LabelControl lblLastSaved;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}

