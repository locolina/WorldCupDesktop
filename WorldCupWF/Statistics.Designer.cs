namespace WorldCupWF
{
    partial class Statistics
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            btnPrint = new Button();
            label1 = new Label();
            label2 = new Label();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument = new System.Drawing.Printing.PrintDocument();
            playerStat = new DataGridView();
            matchStat = new DataGridView();
            matchBindingSource = new BindingSource(components);
            playerBindingSource = new BindingSource(components);
            panel1 = new Panel();
            radioYellowCards = new RadioButton();
            radioGoals = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)playerStat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matchStat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matchBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Name = "btnPrint";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
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
            // printPreviewDialog1
            // 
            resources.ApplyResources(printPreviewDialog1, "printPreviewDialog1");
            printPreviewDialog1.Document = printDocument;
            printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // printDocument
            // 
            printDocument.PrintPage += printDocument_PrintPage;
            // 
            // playerStat
            // 
            resources.ApplyResources(playerStat, "playerStat");
            playerStat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playerStat.Name = "playerStat";
            playerStat.RowTemplate.Height = 25;
            // 
            // matchStat
            // 
            resources.ApplyResources(matchStat, "matchStat");
            matchStat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matchStat.Name = "matchStat";
            matchStat.RowTemplate.Height = 25;
            // 
            // matchBindingSource
            // 
            matchBindingSource.DataSource = typeof(WorldCupDL.Models.Match);
            // 
            // playerBindingSource
            // 
            playerBindingSource.DataSource = typeof(WorldCupDL.Models.Player);
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(radioYellowCards);
            panel1.Controls.Add(radioGoals);
            panel1.Name = "panel1";
            // 
            // radioYellowCards
            // 
            resources.ApplyResources(radioYellowCards, "radioYellowCards");
            radioYellowCards.Name = "radioYellowCards";
            radioYellowCards.TabStop = true;
            radioYellowCards.UseVisualStyleBackColor = true;
            radioYellowCards.CheckedChanged += radio_CheckedChanged;
            // 
            // radioGoals
            // 
            resources.ApplyResources(radioGoals, "radioGoals");
            radioGoals.Name = "radioGoals";
            radioGoals.TabStop = true;
            radioGoals.UseVisualStyleBackColor = true;
            radioGoals.CheckedChanged += radio_CheckedChanged;
            // 
            // Statistics
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(matchStat);
            Controls.Add(playerStat);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPrint);
            Name = "Statistics";
            Load += Statistics_Load;
            ((System.ComponentModel.ISupportInitialize)playerStat).EndInit();
            ((System.ComponentModel.ISupportInitialize)matchStat).EndInit();
            ((System.ComponentModel.ISupportInitialize)matchBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private Label label1;
        private Label label2;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private DataGridView playerStat;
        private DataGridView matchStat;
        private BindingSource matchBindingSource;
        private BindingSource playerBindingSource;
        private Panel panel1;
        private RadioButton radioYellowCards;
        private RadioButton radioGoals;
    }
}