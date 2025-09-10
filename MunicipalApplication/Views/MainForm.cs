using System;
using System.Windows.Forms;
using MunicipalApplication.Controllers;

namespace MunicipalApplication.Views
{
    public class MainForm : Form
    {
        private Button btnReport;
        private Button btnEvents;
        private Button btnStatus;
        private Label lblTitle;
        private IssueController _controller;

        public MainForm(IssueController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Municipal Services - Main Menu";
            this.Width = 480;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label() { Text = "Municipal Services", AutoSize = false, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            lblTitle.Top = 20; lblTitle.Left = 20; lblTitle.Width = 420; lblTitle.Height = 40;

            btnReport = new Button() { Text = "1. Report Issues", Top = 80, Left = 140, Width = 200, Height = 40 };
            btnEvents = new Button() { Text = "2. Local Events and Announcements (disabled)", Top = 130, Left = 40, Width = 400, Height = 40, Enabled = false };
            btnStatus = new Button() { Text = "3. Service Request Status (disabled)", Top = 180, Left = 40, Width = 400, Height = 40, Enabled = false };

            btnReport.Click += BtnReport_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnReport);
            this.Controls.Add(btnEvents);
            this.Controls.Add(btnStatus);

            // Small footer showing current saved issues
            var lblFooter = new Label() { Top = 230, Left = 20, Width = 420, Height = 24 };
            lblFooter.Text = $"Saved reports: {_controller.GetIssueCount()}";
            this.Controls.Add(lblFooter);

            // update footer when form receives focus (so after returning from report form)
            this.Activated += (s, e) => { lblFooter.Text = $"Saved reports: {_controller.GetIssueCount()}"; };
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportIssueForm(_controller);
            reportForm.ShowDialog();
        }
    }
}
