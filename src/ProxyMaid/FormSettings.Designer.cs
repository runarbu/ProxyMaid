namespace ProxyMaid
{
    partial class FormSettings
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
            this.textBoxProxyJudge = new System.Windows.Forms.TextBox();
            this.labelProxyJudge = new System.Windows.Forms.Label();
            this.textBoxProxyTimeOut = new System.Windows.Forms.TextBox();
            this.labelProxyTimeOut = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProxyOutTime = new System.Windows.Forms.Label();
            this.textBoxProxyOutTime = new System.Windows.Forms.TextBox();
            this.checkBoxUsePublicProxySources = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxProxyJudge
            // 
            this.textBoxProxyJudge.Location = new System.Drawing.Point(155, 20);
            this.textBoxProxyJudge.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProxyJudge.Name = "textBoxProxyJudge";
            this.textBoxProxyJudge.Size = new System.Drawing.Size(192, 20);
            this.textBoxProxyJudge.TabIndex = 0;
            // 
            // labelProxyJudge
            // 
            this.labelProxyJudge.AutoSize = true;
            this.labelProxyJudge.Location = new System.Drawing.Point(17, 20);
            this.labelProxyJudge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProxyJudge.Name = "labelProxyJudge";
            this.labelProxyJudge.Size = new System.Drawing.Size(62, 13);
            this.labelProxyJudge.TabIndex = 1;
            this.labelProxyJudge.Text = "Proxy judge";
            // 
            // textBoxProxyTimeOut
            // 
            this.textBoxProxyTimeOut.Location = new System.Drawing.Point(271, 55);
            this.textBoxProxyTimeOut.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProxyTimeOut.Name = "textBoxProxyTimeOut";
            this.textBoxProxyTimeOut.Size = new System.Drawing.Size(76, 20);
            this.textBoxProxyTimeOut.TabIndex = 2;
            this.textBoxProxyTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelProxyTimeOut
            // 
            this.labelProxyTimeOut.AutoSize = true;
            this.labelProxyTimeOut.Location = new System.Drawing.Point(17, 55);
            this.labelProxyTimeOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProxyTimeOut.Name = "labelProxyTimeOut";
            this.labelProxyTimeOut.Size = new System.Drawing.Size(122, 13);
            this.labelProxyTimeOut.TabIndex = 3;
            this.labelProxyTimeOut.Text = "Proxy time out (seconds)";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(179, 168);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(56, 19);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(271, 168);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(56, 19);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelProxyOutTime
            // 
            this.labelProxyOutTime.AutoSize = true;
            this.labelProxyOutTime.Location = new System.Drawing.Point(19, 89);
            this.labelProxyOutTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProxyOutTime.Name = "labelProxyOutTime";
            this.labelProxyOutTime.Size = new System.Drawing.Size(118, 13);
            this.labelProxyOutTime.TabIndex = 6;
            this.labelProxyOutTime.Text = "Proxy out time (minutes)";
            // 
            // textBoxProxyOutTime
            // 
            this.textBoxProxyOutTime.Location = new System.Drawing.Point(271, 89);
            this.textBoxProxyOutTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProxyOutTime.Name = "textBoxProxyOutTime";
            this.textBoxProxyOutTime.Size = new System.Drawing.Size(76, 20);
            this.textBoxProxyOutTime.TabIndex = 7;
            this.textBoxProxyOutTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxUsePublicProxySources
            // 
            this.checkBoxUsePublicProxySources.AutoSize = true;
            this.checkBoxUsePublicProxySources.Location = new System.Drawing.Point(206, 125);
            this.checkBoxUsePublicProxySources.Name = "checkBoxUsePublicProxySources";
            this.checkBoxUsePublicProxySources.Size = new System.Drawing.Size(144, 17);
            this.checkBoxUsePublicProxySources.TabIndex = 8;
            this.checkBoxUsePublicProxySources.Text = "Use public proxy sources";
            this.checkBoxUsePublicProxySources.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 214);
            this.Controls.Add(this.checkBoxUsePublicProxySources);
            this.Controls.Add(this.textBoxProxyOutTime);
            this.Controls.Add(this.labelProxyOutTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelProxyTimeOut);
            this.Controls.Add(this.textBoxProxyTimeOut);
            this.Controls.Add(this.labelProxyJudge);
            this.Controls.Add(this.textBoxProxyJudge);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProxyJudge;
        private System.Windows.Forms.Label labelProxyJudge;
        private System.Windows.Forms.TextBox textBoxProxyTimeOut;
        private System.Windows.Forms.Label labelProxyTimeOut;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProxyOutTime;
        private System.Windows.Forms.TextBox textBoxProxyOutTime;
        private System.Windows.Forms.CheckBox checkBoxUsePublicProxySources;
    }
}