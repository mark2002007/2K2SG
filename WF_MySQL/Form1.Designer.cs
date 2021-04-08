
namespace WF_MySQL
{
    partial class AuthorizationForm
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
            this.pwdTB = new System.Windows.Forms.TextBox();
            this.logTB = new System.Windows.Forms.TextBox();
            this.logIcon = new System.Windows.Forms.PictureBox();
            this.pwdIcon = new System.Windows.Forms.PictureBox();
            this.logButton = new System.Windows.Forms.Button();
            this.TopLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwdIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pwdTB
            // 
            this.pwdTB.Location = new System.Drawing.Point(196, 221);
            this.pwdTB.Multiline = true;
            this.pwdTB.Name = "pwdTB";
            this.pwdTB.Size = new System.Drawing.Size(448, 96);
            this.pwdTB.TabIndex = 0;
            // 
            // logTB
            // 
            this.logTB.Location = new System.Drawing.Point(196, 115);
            this.logTB.Multiline = true;
            this.logTB.Name = "logTB";
            this.logTB.Size = new System.Drawing.Size(448, 96);
            this.logTB.TabIndex = 1;
            // 
            // logIcon
            // 
            this.logIcon.BackgroundImage = global::WF_MySQL.Properties.Resources.user;
            this.logIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logIcon.Location = new System.Drawing.Point(92, 115);
            this.logIcon.Name = "logIcon";
            this.logIcon.Size = new System.Drawing.Size(96, 98);
            this.logIcon.TabIndex = 2;
            this.logIcon.TabStop = false;
            // 
            // pwdIcon
            // 
            this.pwdIcon.BackgroundImage = global::WF_MySQL.Properties.Resources.padlock;
            this.pwdIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pwdIcon.Location = new System.Drawing.Point(92, 223);
            this.pwdIcon.Name = "pwdIcon";
            this.pwdIcon.Size = new System.Drawing.Size(96, 98);
            this.pwdIcon.TabIndex = 3;
            this.pwdIcon.TabStop = false;
            // 
            // logButton
            // 
            this.logButton.BackColor = System.Drawing.Color.DimGray;
            this.logButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logButton.FlatAppearance.BorderSize = 0;
            this.logButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logButton.Location = new System.Drawing.Point(92, 323);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(552, 80);
            this.logButton.TabIndex = 4;
            this.logButton.Text = "Login";
            this.logButton.UseVisualStyleBackColor = false;
            // 
            // TopLabel
            // 
            this.TopLabel.BackColor = System.Drawing.Color.DimGray;
            this.TopLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopLabel.Location = new System.Drawing.Point(0, 0);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(770, 96);
            this.TopLabel.TabIndex = 5;
            this.TopLabel.Text = "Authorization";
            this.TopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TopLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopLabel_MouseDown);
            this.TopLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopLabel_MouseMove);
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Firebrick;
            this.ExitButton.Location = new System.Drawing.Point(722, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(52, 49);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(770, 425);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.pwdIcon);
            this.Controls.Add(this.logIcon);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.pwdTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthorizationForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.logIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwdIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pwdTB;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.PictureBox logIcon;
        private System.Windows.Forms.PictureBox pwdIcon;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}

