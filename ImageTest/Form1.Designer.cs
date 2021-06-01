namespace ImageTest
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutputImage = new System.Windows.Forms.PictureBox();
            this.OpenImageButton = new System.Windows.Forms.Button();
            this.MotionBlurButton = new System.Windows.Forms.Button();
            this.GaussBlurButton = new System.Windows.Forms.Button();
            this.SepiaButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.PosterImageButton = new System.Windows.Forms.Button();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputImage
            // 
            this.OutputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputImage.Location = new System.Drawing.Point(25, 24);
            this.OutputImage.Name = "OutputImage";
            this.OutputImage.Size = new System.Drawing.Size(748, 432);
            this.OutputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OutputImage.TabIndex = 0;
            this.OutputImage.TabStop = false;
            this.OutputImage.Paint += new System.Windows.Forms.PaintEventHandler(this.OutputImage_Paint);
            // 
            // OpenImageButton
            // 
            this.OpenImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpenImageButton.Location = new System.Drawing.Point(25, 486);
            this.OpenImageButton.Name = "OpenImageButton";
            this.OpenImageButton.Size = new System.Drawing.Size(83, 23);
            this.OpenImageButton.TabIndex = 1;
            this.OpenImageButton.Text = "Open image";
            this.OpenImageButton.UseVisualStyleBackColor = true;
            this.OpenImageButton.Click += new System.EventHandler(this.OpenImageButton_Click);
            // 
            // MotionBlurButton
            // 
            this.MotionBlurButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MotionBlurButton.Location = new System.Drawing.Point(153, 486);
            this.MotionBlurButton.Name = "MotionBlurButton";
            this.MotionBlurButton.Size = new System.Drawing.Size(75, 23);
            this.MotionBlurButton.TabIndex = 2;
            this.MotionBlurButton.Text = "Motion blur";
            this.MotionBlurButton.UseVisualStyleBackColor = true;
            this.MotionBlurButton.Click += new System.EventHandler(this.MotionBlurButton_Click);
            // 
            // GaussBlurButton
            // 
            this.GaussBlurButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GaussBlurButton.Location = new System.Drawing.Point(271, 486);
            this.GaussBlurButton.Name = "GaussBlurButton";
            this.GaussBlurButton.Size = new System.Drawing.Size(75, 23);
            this.GaussBlurButton.TabIndex = 3;
            this.GaussBlurButton.Text = "Gauss blur";
            this.GaussBlurButton.UseVisualStyleBackColor = true;
            this.GaussBlurButton.Click += new System.EventHandler(this.GaussBlurButton_Click);
            // 
            // SepiaButton
            // 
            this.SepiaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SepiaButton.Location = new System.Drawing.Point(396, 486);
            this.SepiaButton.Name = "SepiaButton";
            this.SepiaButton.Size = new System.Drawing.Size(75, 23);
            this.SepiaButton.TabIndex = 4;
            this.SepiaButton.Text = "Sepia";
            this.SepiaButton.UseVisualStyleBackColor = true;
            this.SepiaButton.Click += new System.EventHandler(this.SepiaButton_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(518, 479);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 37);
            this.button5.TabIndex = 5;
            this.button5.Text = "Black &   \r\nWhite";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.GrayScale_Click);
            // 
            // PosterImageButton
            // 
            this.PosterImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PosterImageButton.Location = new System.Drawing.Point(622, 486);
            this.PosterImageButton.Name = "PosterImageButton";
            this.PosterImageButton.Size = new System.Drawing.Size(75, 23);
            this.PosterImageButton.TabIndex = 6;
            this.PosterImageButton.Text = "PosterImage";
            this.PosterImageButton.UseVisualStyleBackColor = true;
            this.PosterImageButton.Click += new System.EventHandler(this.PosterImageButton_Click);
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.FileName = "OpenImage";
            this.OpenImageDialog.Filter = "Bmp files(*.bmp)|*.bmp|All files(*.*)|*.*";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(713, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 74);
            this.button1.TabIndex = 7;
            this.button1.Text = "REFRESH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PosterImageButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.SepiaButton);
            this.Controls.Add(this.GaussBlurButton);
            this.Controls.Add(this.MotionBlurButton);
            this.Controls.Add(this.OpenImageButton);
            this.Controls.Add(this.OutputImage);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox OutputImage;
        private System.Windows.Forms.Button OpenImageButton;
        private System.Windows.Forms.Button MotionBlurButton;
        private System.Windows.Forms.Button GaussBlurButton;
        private System.Windows.Forms.Button SepiaButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button PosterImageButton;
        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
        private System.Windows.Forms.Button button1;
    }
}

