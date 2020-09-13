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
            this.components = new System.ComponentModel.Container();
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.rightPictureBox = new System.Windows.Forms.PictureBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.left_picture_label = new System.Windows.Forms.Label();
            this.right_picture_label = new System.Windows.Forms.Label();
            this.leftPictureSize = new System.Windows.Forms.Label();
            this.rightPictureSize = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPictureBox
            // 
            this.leftPictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.leftPictureBox.Location = new System.Drawing.Point(4, 24);
            this.leftPictureBox.Name = "leftPictureBox";
            this.leftPictureBox.Size = new System.Drawing.Size(360, 360);
            this.leftPictureBox.TabIndex = 0;
            this.leftPictureBox.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.PictureRightClickSave_Click);
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 22);
            this.save.Text = "保存";
            // 
            // rightPictureBox
            // 
            this.rightPictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.rightPictureBox.Location = new System.Drawing.Point(370, 24);
            this.rightPictureBox.Name = "rightPictureBox";
            this.rightPictureBox.Size = new System.Drawing.Size(360, 360);
            this.rightPictureBox.TabIndex = 1;
            this.rightPictureBox.TabStop = false;
            // 
            // leftButton
            // 
            this.leftButton.Enabled = false;
            this.leftButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftButton.Location = new System.Drawing.Point(162, 390);
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
            this.rightButton.Location = new System.Drawing.Point(528, 390);
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
            this.left_picture_label.Location = new System.Drawing.Point(161, 4);
            this.left_picture_label.Name = "left_picture_label";
            this.left_picture_label.Size = new System.Drawing.Size(47, 17);
            this.left_picture_label.TabIndex = 5;
            this.left_picture_label.Text = "第 0 列";
            // 
            // right_picture_label
            // 
            this.right_picture_label.AutoSize = true;
            this.right_picture_label.Location = new System.Drawing.Point(527, 4);
            this.right_picture_label.Name = "right_picture_label";
            this.right_picture_label.Size = new System.Drawing.Size(47, 17);
            this.right_picture_label.TabIndex = 5;
            this.right_picture_label.Text = "第 0 列";
            // 
            // leftPictureSize
            // 
            this.leftPictureSize.AutoSize = true;
            this.leftPictureSize.Location = new System.Drawing.Point(4, 390);
            this.leftPictureSize.Name = "leftPictureSize";
            this.leftPictureSize.Size = new System.Drawing.Size(39, 17);
            this.leftPictureSize.TabIndex = 8;
            this.leftPictureSize.Text = "H: W:";
            // 
            // rightPictureSize
            // 
            this.rightPictureSize.AutoSize = true;
            this.rightPictureSize.Location = new System.Drawing.Point(370, 387);
            this.rightPictureSize.Name = "rightPictureSize";
            this.rightPictureSize.Size = new System.Drawing.Size(39, 17);
            this.rightPictureSize.TabIndex = 8;
            this.rightPictureSize.Text = "H: W:";
            // 
            // ImagesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 438);
            this.Controls.Add(this.rightPictureSize);
            this.Controls.Add(this.leftPictureSize);
            this.Controls.Add(this.right_picture_label);
            this.Controls.Add(this.left_picture_label);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightPictureBox);
            this.Controls.Add(this.leftPictureBox);
            this.KeyPreview = true;
            this.Name = "ImagesListForm";
            this.Text = "图片序列";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImagesListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.Label rightPictureSize;
        private System.Windows.Forms.Label leftPictureSize;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}