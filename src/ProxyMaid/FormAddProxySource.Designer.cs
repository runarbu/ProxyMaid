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
            this.SuspendLayout();
            // 
            // buttonSaveProxies
            // 
            this.buttonSaveProxies.Location = new System.Drawing.Point(331, 348);
            this.buttonSaveProxies.Name = "buttonSaveProxies";
            this.buttonSaveProxies.Size = new System.Drawing.Size(75, 29);
            this.buttonSaveProxies.TabIndex = 0;
            this.buttonSaveProxies.Text = "Save";
            this.buttonSaveProxies.UseVisualStyleBackColor = true;
            this.buttonSaveProxies.Click += new System.EventHandler(this.buttonSaveProxies_Click);
            // 
            // textBoxAddProxies
            // 
            this.textBoxAddProxies.Location = new System.Drawing.Point(4, 36);
            this.textBoxAddProxies.Multiline = true;
            this.textBoxAddProxies.Name = "textBoxAddProxies";
            this.textBoxAddProxies.Size = new System.Drawing.Size(539, 306);
            this.textBoxAddProxies.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(431, 348);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormAddProxies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 398);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxAddProxies);
            this.Controls.Add(this.buttonSaveProxies);
            this.Name = "FormAddProxies";
            this.Text = "FormAddProxies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveProxies;
        private System.Windows.Forms.TextBox textBoxAddProxies;
        private System.Windows.Forms.Button buttonCancel;
    }
}