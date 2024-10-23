
namespace SS_SOFTWARE_ESTIMATE_BILL
{
    partial class FRM_CRY_ESTIMATE_BILL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CRY_ESTIMATE_BILL));
            this.cryEstimateBill = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CRY_ESTIMATE_BILL1 = new SS_SOFTWARE_ESTIMATE_BILL.CRY_ESTIMATE_BILL();
            this.SuspendLayout();
            // 
            // cryEstimateBill
            // 
            this.cryEstimateBill.ActiveViewIndex = 0;
            this.cryEstimateBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryEstimateBill.Cursor = System.Windows.Forms.Cursors.Default;
            this.cryEstimateBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryEstimateBill.Location = new System.Drawing.Point(0, 0);
            this.cryEstimateBill.Name = "cryEstimateBill";
            this.cryEstimateBill.ReportSource = this.CRY_ESTIMATE_BILL1;
            this.cryEstimateBill.Size = new System.Drawing.Size(800, 450);
            this.cryEstimateBill.TabIndex = 0;
            // 
            // FRM_CRY_ESTIMATE_BILL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cryEstimateBill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_CRY_ESTIMATE_BILL";
            this.Text = "FRM_CRY_ESTIMATE_BILL";
            this.ResumeLayout(false);

        }

        #endregion
        private CRY_ESTIMATE_BILL CRY_ESTIMATE_BILL1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer cryEstimateBill;
    }
}