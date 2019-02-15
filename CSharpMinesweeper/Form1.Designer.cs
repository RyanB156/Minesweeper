namespace CSharpMinesweeper
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
            this.optionMenu = new System.Windows.Forms.Panel();
            this.bombChanceLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.bombChanceBox = new System.Windows.Forms.TextBox();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.reloadButton = new System.Windows.Forms.Button();
            this.optionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionMenu
            // 
            this.optionMenu.Controls.Add(this.bombChanceLabel);
            this.optionMenu.Controls.Add(this.widthLabel);
            this.optionMenu.Controls.Add(this.heightLabel);
            this.optionMenu.Controls.Add(this.bombChanceBox);
            this.optionMenu.Controls.Add(this.widthBox);
            this.optionMenu.Controls.Add(this.heightBox);
            this.optionMenu.Controls.Add(this.reloadButton);
            this.optionMenu.Location = new System.Drawing.Point(12, 12);
            this.optionMenu.Name = "optionMenu";
            this.optionMenu.Size = new System.Drawing.Size(258, 138);
            this.optionMenu.TabIndex = 0;
            // 
            // bombChanceLabel
            // 
            this.bombChanceLabel.AutoSize = true;
            this.bombChanceLabel.Location = new System.Drawing.Point(109, 62);
            this.bombChanceLabel.Name = "bombChanceLabel";
            this.bombChanceLabel.Size = new System.Drawing.Size(96, 17);
            this.bombChanceLabel.TabIndex = 6;
            this.bombChanceLabel.Text = "Bomb Chance";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(109, 34);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(44, 17);
            this.widthLabel.TabIndex = 5;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(109, 6);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(49, 17);
            this.heightLabel.TabIndex = 4;
            this.heightLabel.Text = "Height";
            // 
            // bombChanceBox
            // 
            this.bombChanceBox.Location = new System.Drawing.Point(3, 59);
            this.bombChanceBox.Name = "bombChanceBox";
            this.bombChanceBox.Size = new System.Drawing.Size(100, 22);
            this.bombChanceBox.TabIndex = 3;
            this.bombChanceBox.TextChanged += new System.EventHandler(this.bombChanceBox_TextChanged);
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(3, 31);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(100, 22);
            this.widthBox.TabIndex = 2;
            this.widthBox.TextChanged += new System.EventHandler(this.widthBox_TextChanged);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(3, 3);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(100, 22);
            this.heightBox.TabIndex = 1;
            this.heightBox.TextChanged += new System.EventHandler(this.heightBox_TextChanged);
            // 
            // reloadButton
            // 
            this.reloadButton.Location = new System.Drawing.Point(180, 112);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(75, 23);
            this.reloadButton.TabIndex = 0;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.optionMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.optionMenu.ResumeLayout(false);
            this.optionMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel optionMenu;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Label bombChanceLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox bombChanceBox;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TextBox heightBox;
    }
}

