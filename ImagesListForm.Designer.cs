namespace opencv
{
    partial class ImagesListForm
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
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.rightPictureBox = new System.Windows.Forms.PictureBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.left_picture_label = new System.Windows.Forms.Label();
            this.right_picture_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPictureBox
            // 
            this.leftPictureBox.Location = new System.Drawing.Point(12, 43);
            this.leftPictureBox.Name = "leftPictureBox";
            this.leftPictureBox.Size = new System.Drawing.Size(360, 360);
            this.leftPictureBox.TabIndex = 0;
            this.leftPictureBox.TabStop = false;
            // 
            // rightPictureBox
            // 
            this.rightPictureBox.Location = new System.Drawing.Point(378, 43);
            this.rightPictureBox.Name = "rightPictureBox";
            this.rightPictureBox.Size = new System.Drawing.Size(360, 360);
            this.rightPictureBox.TabIndex = 1;
            this.rightPictureBox.TabStop = false;
            // 
            // leftButton
            // 
            this.leftButton.Enabled = false;
            this.leftButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftButton.Location = new System.Drawing.Point(170, 409);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(45, 45);
            this.leftButton.TabIndex = 7;
            this.leftButton.Text = "←";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Enabled = false;
            this.rightButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rightButton.Location = new System.Drawing.Point(536, 409);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(45, 45);
            this.rightButton.TabIndex = 7;
            this.rightButton.Text = "→";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // left_picture_label
            // 
            this.left_picture_label.AutoSize = true;
            this.left_picture_label.Location = new System.Drawing.Point(169, 23);
            this.left_picture_label.Name = "left_picture_label";
            this.left_picture_label.Size = new System.Drawing.Size(47, 17);
            this.left_picture_label.TabIndex = 5;
            this.left_picture_label.Text = "第 0 列";
            // 
            // right_picture_label
            // 
            this.right_picture_label.AutoSize = true;
            this.right_picture_label.Location = new System.Drawing.Point(535, 23);
            this.right_picture_label.Name = "right_picture_label";
            this.right_picture_label.Size = new System.Drawing.Size(47, 17);
            this.right_picture_label.TabIndex = 5;
            this.right_picture_label.Text = "第 0 列";
            // 
            // ImagesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 461);
            this.Controls.Add(this.right_picture_label);
            this.Controls.Add(this.left_picture_label);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightPictureBox);
            this.Controls.Add(this.leftPictureBox);
            this.Name = "ImagesListForm";
            this.Text = "ImagesListForm";
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox leftPictureBox;
        private System.Windows.Forms.PictureBox rightPictureBox;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Label left_picture_label;
        private System.Windows.Forms.Label right_picture_label;
    }
}