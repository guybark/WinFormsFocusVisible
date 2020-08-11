namespace WinFormsFocusVisible
{
    partial class FormFocusVisible
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
            this.buttonStandard = new System.Windows.Forms.Button();
            this.buttonCustom = new WinFormsFocusVisible.MyButton();
            this.myUserControl = new WinFormsFocusVisible.MyUserControl();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonShowMoreControls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStandard
            // 
            this.buttonStandard.Location = new System.Drawing.Point(37, 80);
            this.buttonStandard.Name = "buttonStandard";
            this.buttonStandard.Size = new System.Drawing.Size(149, 77);
            this.buttonStandard.Text = "&Standard";
            this.buttonStandard.UseVisualStyleBackColor = true;
            // 
            // buttonCustom
            // 
            this.buttonCustom.Location = new System.Drawing.Point(226, 80);
            this.buttonCustom.Name = "buttonCustom";
            this.buttonCustom.Size = new System.Drawing.Size(149, 77);
            this.buttonCustom.Text = "&Custom";
            this.buttonCustom.UseVisualStyleBackColor = true;
            // 
            // myUserControl
            // 
            this.myUserControl.Location = new System.Drawing.Point(415, 80);
            this.myUserControl.Name = "myUserControl";
            this.myUserControl.Size = new System.Drawing.Size(149, 77);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(633, 367);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(155, 71);
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonShowMoreControls
            // 
            this.buttonShowMoreControls.Location = new System.Drawing.Point(37, 353);
            this.buttonShowMoreControls.Name = "buttonShowMoreControls";
            this.buttonShowMoreControls.Size = new System.Drawing.Size(298, 85);
            this.buttonShowMoreControls.Text = "Show &More Controls";
            this.buttonShowMoreControls.UseVisualStyleBackColor = true;
            this.buttonShowMoreControls.Click += new System.EventHandler(this.buttonShowMoreControls_Click);
            // 
            // FormFocusVisible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStandard);
            this.Controls.Add(this.buttonCustom);
            this.Controls.Add(this.myUserControl);
            this.Controls.Add(this.buttonShowMoreControls);
            this.Controls.Add(this.buttonClose);
            this.MaximizeBox = false;
            this.Name = "FormFocusVisible";
            this.Text = "Keyboard focus visuals demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStandard;
        private MyButton buttonCustom;
        private MyUserControl myUserControl;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonShowMoreControls;
    }
}

