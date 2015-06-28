using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NewBosonT
{
    public partial class main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        ui ui = new ui();
        stagesparser sparser;
        patternsparser pparser = new patternsparser();
        public string gamespath = "";
        public main()
        {
            InitializeComponent();
        }

        private void pnlButtons_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            gamespath = ui.loadSettings();
            stagesparser.main = this;
            sparser = new stagesparser();
        }

        private void btnSelectGameDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseGameDir = new FolderBrowserDialog();
            browseGameDir.Description = "Select your Boson-X game folder.";
            if (browseGameDir.ShowDialog() == DialogResult.OK)
            {
                ui.writeSettings(browseGameDir.SelectedPath);
            }
        }

        private void cbxStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamespath != null && gamespath != "")
            {
                sparser.loadVariables(gamespath + "/data/" + cbxStages.Text + ".lua", nudInitSpeed, nudMaxSpeed, nudEnergyInterval, nudEnergySpeedup, nudLevelDepth, txtParticleName, txtParticleAbbv);
                pparser.clearDataStructures(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
                pparser.parsePatternsNouveau(gamespath + "/data/" + "patterns_" + cbxStages.Text + ".lua", lvwSections);
            }
            else
            {
                MessageBox.Show("Please select your Boson-X game folder.", "Couldn't load stage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvwSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            pparser.visualiseSection(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
        }

        private void dgvpparser_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            pparser.saveChanges(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItemAir_Click(object sender, EventArgs e)
        {
         //   pparser.changeCellValue("", dgvPlatformEdit);
        }

        private void normalPToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    pparser.changeCellValue("P", dgvPlatformEdit);
        }

        private void fastFToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   pparser.changeCellValue("F", dgvPlatformEdit);
        }

        private void collapsingCToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   pparser.changeCellValue("C", dgvPlatformEdit);
        }

        private void energyEToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("E", dgvPlatformEdit);
        }

        private void barrierBToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("B", dgvPlatformEdit);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("1", dgvPlatformEdit);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("2", dgvPlatformEdit);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
//pparser.changeCellValue("3", dgvPlatformEdit);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("4", dgvPlatformEdit);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("5", dgvPlatformEdit);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("6", dgvPlatformEdit);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("7", dgvPlatformEdit);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("8", dgvPlatformEdit);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
          //  pparser.changeCellValue("9", dgvPlatformEdit);
        }

        private void dgvPlatformEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pparser.saveChanges(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            dgvPlatformEdit.Rows.Add();
        }
    }
}
