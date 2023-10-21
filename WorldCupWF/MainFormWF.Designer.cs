namespace WorldCupWF
{
    partial class MainFormWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormWF));
            pnlFavourites = new FlowLayoutPanel();
            pnlAll = new FlowLayoutPanel();
            ddlPickTeam = new ComboBox();
            label1 = new Label();
            btnSettings = new Button();
            btnStatistics = new Button();
            SuspendLayout();
            // 
            // pnlFavourites
            // 
            resources.ApplyResources(pnlFavourites, "pnlFavourites");
            pnlFavourites.AllowDrop = true;
            pnlFavourites.BorderStyle = BorderStyle.FixedSingle;
            pnlFavourites.Name = "pnlFavourites";
            pnlFavourites.DragDrop += Panels_DragDrop;
            pnlFavourites.DragEnter += Panels_DragEnter;
            // 
            // pnlAll
            // 
            resources.ApplyResources(pnlAll, "pnlAll");
            pnlAll.AllowDrop = true;
            pnlAll.BorderStyle = BorderStyle.FixedSingle;
            pnlAll.Name = "pnlAll";
            pnlAll.DragDrop += Panels_DragDrop;
            pnlAll.DragEnter += Panels_DragEnter;
            // 
            // ddlPickTeam
            // 
            resources.ApplyResources(ddlPickTeam, "ddlPickTeam");
            ddlPickTeam.FormattingEnabled = true;
            ddlPickTeam.Name = "ddlPickTeam";
            ddlPickTeam.SelectedIndexChanged += ddlPickTeam_SelectedIndexChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // btnSettings
            // 
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.Name = "btnSettings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnStatistics
            // 
            resources.ApplyResources(btnStatistics, "btnStatistics");
            btnStatistics.Name = "btnStatistics";
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // MainFormWF
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnStatistics);
            Controls.Add(btnSettings);
            Controls.Add(label1);
            Controls.Add(ddlPickTeam);
            Controls.Add(pnlAll);
            Controls.Add(pnlFavourites);
            Name = "MainFormWF";
            FormClosing += MainFormWF_FormClosing;
            Load += MainFormWF_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pnlFavourites;
        private FlowLayoutPanel pnlAll;
        private ComboBox ddlPickTeam;
        private Label label1;
        private Button btnSettings;
        private Button btnStatistics;
    }
}