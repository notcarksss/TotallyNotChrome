using System;
using System.Windows.Forms;
/*
 *TotallyNotChrome copyrighted by Notcarksss 2016
 */
namespace Browser_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebBrowser wb = new WebBrowser();
        int i = 0;

        public void Form1_Load(object sender, EventArgs e)
        {
            wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            wb.Dock = DockStyle.Fill;
            wb.Visible = true;
            wb.DocumentCompleted += wb_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(wb);
            i += 1;
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
             ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            wb.Dock = DockStyle.Fill;
            wb.Visible = true;
            wb.DocumentCompleted += wb_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(wb);
            i += 1;
        }

        private void removePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
                {
                    toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
                }
            }
        }

        private void refreshPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void stopPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
