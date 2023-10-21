namespace WorldCupWF
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            ddlLanguage = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ddlGender = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // ddlLanguage
            // 
            resources.ApplyResources(ddlLanguage, "ddlLanguage");
            ddlLanguage.FormattingEnabled = true;
            ddlLanguage.Items.AddRange(new object[] { resources.GetString("ddlLanguage.Items"), resources.GetString("ddlLanguage.Items1") });
            ddlLanguage.Name = "ddlLanguage";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // ddlGender
            // 
            resources.ApplyResources(ddlGender, "ddlGender");
            ddlGender.FormattingEnabled = true;
            ddlGender.Items.AddRange(new object[] { resources.GetString("ddlGender.Items"), resources.GetString("ddlGender.Items1") });
            ddlGender.Name = "ddlGender";
            // 
            // btnOk
            // 
            resources.ApplyResources(btnOk, "btnOk");
            btnOk.Name = "btnOk";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            btnOk.KeyPress += btnOk_KeyPress;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            btnCancel.KeyPress += btnCancel_KeyPress;
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label2);
            Controls.Add(ddlGender);
            Controls.Add(label1);
            Controls.Add(ddlLanguage);
            Name = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ddlLanguage;
        private Label label1;
        private Label label2;
        private ComboBox ddlGender;
        private Button btnOk;
        private Button btnCancel;
    }
}