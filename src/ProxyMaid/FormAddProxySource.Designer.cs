namespace ProxyMaid
{
    partial class FormAddProxySource
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
            this.buttonSaveProxies = new System.Windows.Forms.Button();
            this.textBoxAddProxies = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSaveProxies
            // 
            this.buttonSaveProxies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveProxies.Location = new System.Drawing.Point(248, 283);
            this.buttonSaveProxies.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSaveProxies.Name = "buttonSaveProxies";
            this.buttonSaveProxies.Size = new System.Drawing.Size(56, 24);
            this.buttonSaveProxies.TabIndex = 0;
            this.buttonSaveProxies.Text = "Save";
            this.buttonSaveProxies.UseVisualStyleBackColor = true;
            this.buttonSaveProxies.Click += new System.EventHandler(this.buttonSaveProxies_Click);
            // 
            // textBoxAddProxies
            // 
            this.textBoxAddProxies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddProxies.Location = new System.Drawing.Point(3, 29);
            this.textBoxAddProxies.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAddProxies.Multiline = true;
            this.textBoxAddProxies.Name = "textBoxAddProxies";
            this.textBoxAddProxies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAddProxies.Size = new System.Drawing.Size(405, 249);
            this.textBoxAddProxies.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(323, 283);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(56, 24);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Urls to scrape";
            // 
            // FormAddProxySource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxAddProxies);
            this.Controls.Add(this.buttonSaveProxies);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAddProxySource";
            this.Text = "FormAddProxies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveProxies;
        private System.Windows.Forms.TextBox textBoxAddProxies;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
    }
}