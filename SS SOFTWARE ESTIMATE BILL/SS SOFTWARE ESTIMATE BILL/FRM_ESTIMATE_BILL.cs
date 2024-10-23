using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace SS_SOFTWARE_ESTIMATE_BILL
{
    public partial class FRM_ESTIMATE_BILL : Form
    {
        public FRM_ESTIMATE_BILL()
        {
            InitializeComponent();
        }

        int i = 0;

        private void calcTotal()
        {
            double grossAmount = 0, totalPcs = 0, totalGrossWt = 0, totalNetWt = 0, totalVat = 0;
            for (int i = 0; i < dgwDetails.Rows.Count; i++)
            {
                if (dgwDetails.Rows[i].Cells[3].Value != null)
                { totalPcs += double.Parse(dgwDetails.Rows[i].Cells[3].Value.ToString()); }
                if (dgwDetails.Rows[i].Cells[4].Value != null)
                { totalGrossWt += double.Parse(dgwDetails.Rows[i].Cells[4].Value.ToString()); }
                if (dgwDetails.Rows[i].Cells[5].Value != null)
                { totalNetWt += double.Parse(dgwDetails.Rows[i].Cells[5].Value.ToString()); }
                if (dgwDetails.Rows[i].Cells[6].Value != null)
                { totalVat += double.Parse(dgwDetails.Rows[i].Cells[6].Value.ToString()); }
                if (dgwDetails.Rows[i].Cells[7].Value != null)
                { grossAmount += double.Parse(dgwDetails.Rows[i].Cells[7].Value.ToString()); }

                lblPcs.Text = Math.Round(totalPcs, 2).ToString("00");
                lblGrossWt.Text = Math.Round(totalGrossWt, 2).ToString("N3");
                lblNetWt.Text = Math.Round(totalNetWt, 2).ToString("N3");
                lblVat.Text = Math.Round(totalVat, 2).ToString("N3");
                txtGrossAmount.Text = Math.Round(grossAmount, 2).ToString("N2");
            }
        }

        private void clearCustomerDetails()
        {
            txtDate.ResetText();
            txtName.ResetText();
            txtArea.ResetText();
            txtMobileNo.ResetText();
        }

        private void clearTotal()
        {
            txtGrossAmount.ResetText();
            txtOldAmount.ResetText();
            txtTotalAmount.ResetText();
            lblPcs.ResetText();
            lblVat.ResetText();
            lblGrossWt.ResetText();
            lblNetWt.ResetText();
            txtGrossAmount.Text = "0.00";
            txtOldAmount.Text = "0.00";
            txtTotalAmount.Text = "0.00";
            lblPcs.Text = "00";
            lblVat.Text = "0.000";
            lblGrossWt.Text = "0.000";
            lblNetWt.Text = "0.000";
        }

        private void clearDetails()
        {
            txtParticulars.ResetText();
            txtHsnCode.ResetText();
            txtPcs.ResetText();
            txtVat.ResetText();
            txtGrossWt.ResetText();
            txtNetWt.ResetText();
            txtAmount.ResetText();
            txtPcs.Text = "01";
            txtVat.Text = "0.000";
            txtGrossWt.Text = "0.000";
            txtNetWt.Text = "0.000";
            txtAmount.Text = "0.00";
        }

        private void FRM_ESTIMATE_BILL_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Wanna Exit Application?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Wanna Delete Bill?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clearTotal();
                clearCustomerDetails();
                clearDetails();
                dgwDetails.Rows.Clear();
                txtName.Focus();
                btnAdd.Enabled = true;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtParticulars.Text != "" && txtHsnCode.Text != "")
            {
                if (MessageBox.Show("Do You Wanna Add One More Details?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    double sno = 01;
                    dgwDetails.Rows.Add(sno, txtParticulars.Text, txtHsnCode.Text, txtPcs.Text, txtGrossWt.Text, txtNetWt.Text, txtVat.Text, txtAmount.Text);
                    clearDetails();
                    txtParticulars.Focus();
                    calcTotal();
                }
                else
                {
                    double sno = 01;
                    dgwDetails.Rows.Add(sno, txtParticulars.Text, txtHsnCode.Text, txtPcs.Text, txtGrossWt.Text, txtNetWt.Text, txtVat.Text, txtAmount.Text);
                    clearDetails();
                    txtOldAmount.Focus();
                    calcTotal();
                }
            }
            else
            {
                MessageBox.Show("Fill All The Boxes?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearDetails();
                txtParticulars.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgwDetails.Rows.Count != 0)
            {
                dgwDetails.SelectedRows[i].Cells[1].Value = txtParticulars.Text;
                dgwDetails.SelectedRows[i].Cells[2].Value = txtHsnCode.Text;
                dgwDetails.SelectedRows[i].Cells[3].Value = txtPcs.Text;
                dgwDetails.SelectedRows[i].Cells[4].Value = txtGrossWt.Text;
                dgwDetails.SelectedRows[i].Cells[5].Value = txtNetWt.Text;
                dgwDetails.SelectedRows[i].Cells[6].Value = txtVat.Text;
                dgwDetails.SelectedRows[i].Cells[7].Value = txtAmount.Text;
                clearDetails();
                btnAdd.Enabled = true;
                txtOldAmount.Focus();
                calcTotal();
            }
            else
            {
                MessageBox.Show("Data Not Found? You Can't Edit", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearTotal();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearDetails();
            txtParticulars.Focus();
            calcTotal();
            btnAdd.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (dgwDetails.Rows.Count != 0)
            {
                if (MessageBox.Show("Do You Wanna Delete?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dgwDetails.SelectedRows[i].Cells[0].RowIndex;
                    dgwDetails.Rows.RemoveAt(rowIndex);
                    clearDetails();
                    calcTotal();
                }
                else
                {
                    clearDetails();
                    txtParticulars.Focus();
                    calcTotal();
                }
            }
            else
            {
                MessageBox.Show("Data Not Found? You Can't Delete", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearTotal();
            }
        }

        private void dgwDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgwDetails.Columns[1].DefaultCellStyle.Format = "{0:00}";
        }

        private void dgwDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgwDetails.Rows[e.RowIndex].Cells["Column1"].Value = string.Format("{0:00}", e.RowIndex + 1).ToString();
        }

        private void txtGrossWt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtGrossWt.Text, "[^0-9.,]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtNetWt.Text = txtGrossWt.Text;
        }

        private void txtNetWt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNetWt.Text, "[^0-9.,]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNetWt.Text = "0.000";
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "[^0-9.,]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Text = "0.00";
            }
        }

        private void txtGrossAmount_TextChanged(object sender, EventArgs e)
        {
            txtTotalAmount.Text = txtGrossAmount.Text;
        }

        private void txtOldAmount_TextChanged(object sender, EventArgs e)
        {
            double first;
            double second;
            double third;
            double.TryParse(txtGrossAmount.Text, out first);
            double.TryParse(txtOldAmount.Text, out second);
            third = first - second;
            txtTotalAmount.Text = third.ToString("N2");
        }

        private void txtPcs_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPcs.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPcs.Text = "01";
            }
        }

        private void txtHsnCode_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtHsnCode.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHsnCode.ResetText();
            }
        }

        private void txtPcs_Leave(object sender, EventArgs e)
        {
            if (txtPcs.Text == "")
            {
                txtPcs.Text = "01";
            }
            else
            {
                float a;
                float.TryParse(txtPcs.Text, out a);
                txtPcs.Text = string.Format("{0:00}", a);
            }
        }

        private void txtVat_Leave(object sender, EventArgs e)
        {
            if (txtVat.Text == "")
            {
                txtVat.Text = "0.000";
            }
            else
            {
                float a;
                float.TryParse(txtVat.Text, out a);
                txtVat.Text = string.Format("{0:N3}", a);
            }
            double first;
            double second;
            double third;
            double.TryParse(txtGrossWt.Text, out first);
            double.TryParse(txtVat.Text, out second);
            third = first + second;
            txtGrossWt.Text = third.ToString("N3");
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtVat.Text, "[^0-9.,]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVat.Text = "0.000";
            }
        }

        private void txtGrossWt_Leave(object sender, EventArgs e)
        {
            if (txtGrossWt.Text == "")
            {
                txtGrossWt.Text = "0.000";
            }
            else
            {
                float a;
                float.TryParse(txtGrossWt.Text, out a);
                txtGrossWt.Text = string.Format("{0:N3}", a);
            }
        }

        private void txtNetWt_Leave(object sender, EventArgs e)
        {
            if (txtNetWt.Text == "")
            {
                txtNetWt.Text = "0.000";
            }
            else
            {
                float a;
                float.TryParse(txtNetWt.Text, out a);
                txtNetWt.Text = string.Format("{0:N3}", a);
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                txtAmount.Text = "0.00";
            }
            else
            {
                float a;
                float.TryParse(txtAmount.Text, out a);
                txtAmount.Text = string.Format("{0:N2}", a);
            }
        }

        private void dgwDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Do You Wanna Edit?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtParticulars.Text = dgwDetails.SelectedRows[i].Cells[1].Value.ToString();
                txtHsnCode.Text = dgwDetails.SelectedRows[i].Cells[2].Value.ToString();
                txtPcs.Text = dgwDetails.SelectedRows[i].Cells[3].Value.ToString();
                txtGrossWt.Text = dgwDetails.SelectedRows[i].Cells[4].Value.ToString();
                txtNetWt.Text = dgwDetails.SelectedRows[i].Cells[5].Value.ToString();
                txtVat.Text = dgwDetails.SelectedRows[i].Cells[6].Value.ToString();
                txtAmount.Text = dgwDetails.SelectedRows[i].Cells[7].Value.ToString();
                double first;
                double second;
                double third;
                double.TryParse(txtGrossWt.Text, out first);
                double.TryParse(txtVat.Text, out second);
                third = first - second;
                txtGrossWt.Text = third.ToString("N3");
                btnAdd.Enabled = false;
                txtParticulars.Focus();
            }
            else
            {
                btnAdd.Enabled = true;
                clearDetails();
            }
        }

        private void txtOldAmount_Leave(object sender, EventArgs e)
        {
            if (txtOldAmount.Text == "")
            {
                txtOldAmount.Text = "0.00";
            }
            else
            {
                float a;
                float.TryParse(txtOldAmount.Text, out a);
                txtOldAmount.Text = string.Format("{0:N2}", a);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgwDetails.Rows.Count != 0 && txtName.Text != "" && txtMobileNo.Text != "")
            {
                if (MessageBox.Show("Do You Wanna Print Bill?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CRY_ESTIMATE_BILL Estimate_Bill = new CRY_ESTIMATE_BILL();
                    FRM_CRY_ESTIMATE_BILL View_Estimate_Bill = new FRM_CRY_ESTIMATE_BILL();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    TextObject Date = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section1"].ReportObjects["txtDate"];
                    Date.Text = txtDate.Text;
                    TextObject Customer_Name = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section1"].ReportObjects["txtName"];
                    Customer_Name.Text = txtName.Text;
                    TextObject Area = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section1"].ReportObjects["txtArea"];
                    Area.Text = txtArea.Text;
                    TextObject Mobileno = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section1"].ReportObjects["txtMobileNo"];
                    Mobileno.Text = txtMobileNo.Text;
                    TextObject GrossAmount = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section4"].ReportObjects["txtNetAmount"];
                    GrossAmount.Text = txtGrossAmount.Text;
                    TextObject OldAmount = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section4"].ReportObjects["txtOldAmount"];
                    OldAmount.Text = txtOldAmount.Text;
                    TextObject TotalAmount = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section4"].ReportObjects["txtTotalAmount"];
                    TotalAmount.Text = txtTotalAmount.Text;
                    TextObject TotalPcs = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section4"].ReportObjects["lblPcs"];
                    TotalPcs.Text = lblPcs.Text;
                    TextObject TotalNetWt = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section4"].ReportObjects["lblNetWt"];
                    TotalNetWt.Text = lblNetWt.Text;
                    TextObject TotalVat = (TextObject)Estimate_Bill.ReportDefinition.Sections["Section4"].ReportObjects["lblVat"];
                    TotalVat.Text = lblVat.Text;

                    dt.Columns.Add("S.No");
                    dt.Columns.Add("Particulars");
                    dt.Columns.Add("HSN CODE");
                    dt.Columns.Add("PCS");
                    dt.Columns.Add("Gross Wt");
                    dt.Columns.Add("Net Wt");
                    dt.Columns.Add("VAT");
                    dt.Columns.Add("Amount");
                    foreach (DataGridViewRow dgw_estimate_bill in dgwDetails.Rows)
                    {
                        dt.Rows.Add(dgw_estimate_bill.Cells[0].Value, dgw_estimate_bill.Cells[1].Value, dgw_estimate_bill.Cells[2].Value, dgw_estimate_bill.Cells[3].Value, dgw_estimate_bill.Cells[4].Value, dgw_estimate_bill.Cells[5].Value, dgw_estimate_bill.Cells[6].Value, dgw_estimate_bill.Cells[7].Value);
                    }
                    ds.Tables.Add(dt);
                    ds.WriteXmlSchema("Estimate_Bill.xml");
                    dgwDetails.DataSource = null;
                    Estimate_Bill.SetDataSource(ds);
                    View_Estimate_Bill.cryEstimateBill.ReportSource = Estimate_Bill;
                    Estimate_Bill.PrintOptions.PrinterName = "SNBC TVSE LP 46 NEO BPLE";
                    Estimate_Bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    Estimate_Bill.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    Estimate_Bill.PrintToPrinter(1, false, 0, 0);
                    if (MessageBox.Show("Do You Wanna Clear Bill?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clearTotal();
                        clearCustomerDetails();
                        clearDetails();
                        dgwDetails.Rows.Clear();
                        txtName.Focus();
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        txtName.Focus();
                    }
                }
                else
                {
                    txtName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Fill All The Boxes?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
        }

        private void FRM_ESTIMATE_BILL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Do You Wanna Exit Application?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnPrint.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                btnDelete.PerformClick();
            }
        }
    }
}
