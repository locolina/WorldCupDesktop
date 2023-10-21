namespace WorldCupWF.UC
{
    partial class PlayerUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            imgPlayer = new PictureBox();
            lblName = new Label();
            label1 = new Label();
            label2 = new Label();
            cbFavourite = new CheckBox();
            lblCaptain = new Label();
            lblPosition = new Label();
            lblNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)imgPlayer).BeginInit();
            SuspendLayout();
            // 
            // imgPlayer
            // 
            imgPlayer.InitialImage = null;
            imgPlayer.Location = new Point(3, 3);
            imgPlayer.Name = "imgPlayer";
            imgPlayer.Size = new Size(74, 94);
            imgPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            imgPlayer.TabIndex = 0;
            imgPlayer.TabStop = false;
            imgPlayer.Click += imgPlayer_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.Location = new Point(83, 3);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 19);
            lblName.TabIndex = 1;
            lblName.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 63);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Broj:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 48);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 3;
            label2.Text = "Pozicija:";
            // 
            // cbFavourite
            // 
            cbFavourite.AutoSize = true;
            cbFavourite.CheckAlign = ContentAlignment.MiddleRight;
            cbFavourite.Location = new Point(83, 78);
            cbFavourite.Name = "cbFavourite";
            cbFavourite.Size = new Size(78, 19);
            cbFavourite.TabIndex = 5;
            cbFavourite.Text = "Favourite:";
            cbFavourite.UseVisualStyleBackColor = true;
            cbFavourite.CheckedChanged += cbFavourite_CheckedChanged;
            // 
            // lblCaptain
            // 
            lblCaptain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaptain.AutoSize = true;
            lblCaptain.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaptain.Location = new Point(224, 0);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(24, 25);
            lblCaptain.TabIndex = 8;
            lblCaptain.Text = "C";
            lblCaptain.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(139, 48);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(0, 15);
            lblPosition.TabIndex = 7;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(139, 63);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(0, 15);
            lblNumber.TabIndex = 6;
            // 
            // PlayerUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblCaptain);
            Controls.Add(lblPosition);
            Controls.Add(lblNumber);
            Controls.Add(cbFavourite);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblName);
            Controls.Add(imgPlayer);
            Name = "PlayerUC";
            Size = new Size(248, 100);
            MouseDown += PlayerUC_MouseDown;
            ((System.ComponentModel.ISupportInitialize)imgPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imgPlayer;
        private Label lblName;
        private Label label1;
        private Label label2;
        private CheckBox cbFavourite;
        private Label lblCaptain;
        private Label lblPosition;
        private Label lblNumber;
    }
}
