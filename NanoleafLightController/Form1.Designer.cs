namespace NanoleafLightController
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroMainPanel = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResizeForm = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroMainPanel
            // 
            this.metroMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroMainPanel.HorizontalScrollbarBarColor = true;
            this.metroMainPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.metroMainPanel.HorizontalScrollbarSize = 10;
            this.metroMainPanel.Location = new System.Drawing.Point(20, 60);
            this.metroMainPanel.Name = "metroMainPanel";
            this.metroMainPanel.Size = new System.Drawing.Size(391, 102);
            this.metroMainPanel.TabIndex = 0;
            this.metroMainPanel.VerticalScrollbarBarColor = true;
            this.metroMainPanel.VerticalScrollbarHighlightOnWheel = false;
            this.metroMainPanel.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblResizeForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 18);
            this.panel1.TabIndex = 1;
            // 
            // lblResizeForm
            // 
            this.lblResizeForm.AutoSize = true;
            this.lblResizeForm.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblResizeForm.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblResizeForm.Location = new System.Drawing.Point(195, 0);
            this.lblResizeForm.Name = "lblResizeForm";
            this.lblResizeForm.Size = new System.Drawing.Size(0, 0);
            this.lblResizeForm.TabIndex = 0;
            this.lblResizeForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblResizeForm.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(431, 182);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroMainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(431, 550);
            this.MinimumSize = new System.Drawing.Size(431, 160);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Nanoleaf lights controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroMainPanel;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel lblResizeForm;
    }
}

