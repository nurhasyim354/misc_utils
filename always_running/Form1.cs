using System.Diagnostics;

namespace always_running
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtProcessName.Text == null || txtProcessName.Text == "")
                return;

            try
            {
                Process[] processes = Process.GetProcesses();
                var exist = processes.FirstOrDefault(p => p.MainWindowTitle != null && p.MainWindowTitle != "" && p.MainModule != null && (p.MainModule.FileName.ToLower() == txtProcessName.Text.ToLower()));

                if (exist == null)
                {
                    string log = $"{DateTime.Now.ToString()} : Starting {txtProcessName.Text}";
                    lbLog.Items.Add(log);
                    Process.Start(txtProcessName.Text);
                }
            }
            catch (Exception ex)
            {
                string log = $"{DateTime.Now.ToString()} : Error {ex.Message}";
                lbLog.Items.Add(log);
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}