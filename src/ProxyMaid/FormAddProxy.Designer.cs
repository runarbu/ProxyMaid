namespace ProxyMaid
{
    partial class FormAddProxy
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
            this.textBoxAddProxy = new System.Windows.Forms.TextBox();
            this.buttonSaveAddProxy = new System.Windows.Forms.Button();
            this.buttonCancelAddProxy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxAddProxy
            // 
            this.textBoxAddProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddProxy.Location = new System.Drawing.Point(2, 27);
            this.textBoxAddProxy.Multiline = true;
            this.textBoxAddProxy.Name = "textBoxAddProxy";
            this.textBoxAddProxy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAddProxy.Size = new System.Drawing.Size(280, 184);
            this.textBoxAddProxy.TabIndex = 0;
            // 
            // buttonSaveAddProxy
            // 
            this.buttonSaveAddProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveAddProxy.Location = new System.Drawing.Point(104, 227);
            this.buttonSaveAddProxy.Name = "buttonSaveAddProxy";
            this.buttonSaveAddProxy.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAddProxy.TabIndex = 3;
            this.buttonSaveAddProxy.Text = "Save";
            this.buttonSaveAddProxy.UseVisualStyleBackColor = true;
            this.buttonSaveAddProxy.Click += new System.EventHandler(this.buttonSaveAddProxy_Click);
            // 
            // buttonCancelAddProxy
            // 
            this.buttonCancelAddProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelAddProxy.Location = new System.Drawing.Point(197, 227);
            this.buttonCancelAddProxy.Name = "buttonCancelAddProxy";
            this.buttonCancelAddProxy.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelAddProxy.TabIndex = 4;
            this.buttonCancelAddProxy.Text = "Cancel";
            this.buttonCancelAddProxy.UseVisualStyleBackColor = true;
            this.buttonCancelAddProxy.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proxies to check. Format is ip:port";
            // 
            // FormAddProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelAddProxy);
            this.Controls.Add(this.buttonSaveAddProxy);
            this.Controls.Add(this.textBoxAddProxy);
            this.Name = "FormAddProxy";
            this.Text = "FormAddProxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddProxy;
        private System.Windows.Forms.Button buttonSaveAddProxy;
        private System.Windows.Forms.Button buttonCancelAddProxy;
        private System.Windows.Forms.Label label1;
    }
}