namespace NanoleafLightController.User_Controlls
{
    partial class SetupUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelSetup = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tableLayoutPanelSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelSetup
            // 
            this.tableLayoutPanelSetup.ColumnCount = 3;
            this.tableLayoutPanelSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanelSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanelSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanelSetup.Controls.Add(this.btnNext, 2, 4);
            this.tableLayoutPanelSetup.Controls.Add(this.metroLabel1, 1, 4);
            this.tableLayoutPanelSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSetup.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSetup.Name = "tableLayoutPanelSetup";
            this.tableLayoutPanelSetup.RowCount = 5;
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.59575F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.46809F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.08511F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.6383F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSetup.Size = new System.Drawing.Size(391, 455);
            this.tableLayoutPanelSetup.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Location = new System.Drawing.Point(290, 407);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(98, 45);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseSelectable = true;
            this.btnNext.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel1.Location = new System.Drawing.Point(105, 404);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(179, 51);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Step 1";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetupUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelSetup);
            this.MaximumSize = new System.Drawing.Size(391, 455);
            this.MinimumSize = new System.Drawing.Size(391, 455);
            this.Name = "SetupUserControl";
            this.Size = new System.Drawing.Size(391, 455);
            this.Load += new System.EventHandler(this.SetupUserControl_Load);
            this.tableLayoutPanelSetup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSetup;
        private MetroFramework.Controls.MetroButton btnNext;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
