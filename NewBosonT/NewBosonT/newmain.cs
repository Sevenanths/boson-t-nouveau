using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace NewBosonT
{
    public partial class newmain : Form
    {
        patternsparser pparser = new patternsparser();
        stagesparser sparser = new stagesparser();
        ui ui = new ui();
        audio audio = new audio();

        public string patternspath = Application.StartupPath + "/cachee/patterns_.lua";
        public string testpatternspath = Application.StartupPath + "/boson/data/patterns_stage1.lua";

        public string stagespath = Application.StartupPath + "/cachee/stages.lua";
        public string teststagespath = Application.StartupPath + "/boson/data/stages.lua";

        public string stagemusica = Application.StartupPath + "/cachee/stagea.ogg";
        public string stagemusicb = Application.StartupPath + "/cachee/stageb.ogg";
        public string testmusicapath = Application.StartupPath + "/boson/data/stage1a.ogg";
        public string testmusicbpath = Application.StartupPath + "/boson/data/stage1b.ogg";

        public newmain()
        {
            InitializeComponent();
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            pparser.addSection(txtAddSection, lvwSections);
        }

        private void lvwSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwSections.SelectedItems.Count > 0)
            {
                dgvPlatformEdit.Enabled = true;
                pparser.visualiseSection(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
                File.WriteAllText(Application.StartupPath + "/debug.txt", lvwSections.SelectedItems[0].Tag.ToString());
            }
            else
            {
                dgvPlatformEdit.Enabled = false;
            }
        }

        private void newmain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember(
             "DoubleBuffered",
              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
              null,
              dgvPlatformEdit,
              new object[] { true });
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ui.openBPK();
            pparser.parsePatternsNouveau(patternspath, lvwSections);
            sparser.loadVariablesNouveau(nudInitSpeed, nudMaxSpeed, nudEnergyInterval, nudEnergySpeedup, nudLevelDepth, txtParticleName, txtParticleAbbv);
            audio.loadMusic(axBGMusic, btnRemoveBGMusic, "a");
            audio.loadMusic(axDiffuseMusic, btnRemoveDiffuseMusic, "b");
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            pparser.addRow(1, dgvPlatformEdit);
        }

        private void btnAddLine5_Click(object sender, EventArgs e)
        {
            pparser.addRow(5, dgvPlatformEdit);
        }

        private void btnAddLine10_Click(object sender, EventArgs e)
        {
            pparser.addRow(10, dgvPlatformEdit);
        }

        private void btnAddSection25_Click(object sender, EventArgs e)
        {
            pparser.addRow(25, dgvPlatformEdit);
        }

        private void toolStripMenuItemAir_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void normalPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("P", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void fastFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("F", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void collapsingCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("C", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void energyEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("E", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void barrierBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("B", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("1", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("2", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("3", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("4", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("5", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("6", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("7", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("8", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("9", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }
        private void lightningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.changeCellValue("*", dgvPlatformEdit, lvwSections, cbxNoEnergy, txtStages);
        }
        private void dgvPlatformEdit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlatformEdit.NotifyCurrentCellDirty(true);
            dgvPlatformEdit.EndEdit();
            dgvPlatformEdit.NotifyCurrentCellDirty(false);
        }
        private void dgvPlatformEdit_MouseMove(object sender, MouseEventArgs e)
        {
            pparser.countCells(lblStatus, dgvPlatformEdit);
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            pparser.removeRow(dgvPlatformEdit);
        }

        private void dgvPlatformEdit_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            pparser.saveChanges(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
        }

        private void cbxNoEnergy_SelectedIndexChanged(object sender, EventArgs e)
        {
            pparser.saveChanges(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
        }

        private void txtStages_TextChanged(object sender, EventArgs e)
        {
            pparser.saveChanges(lvwSections, dgvPlatformEdit, cbxNoEnergy, txtStages);
        }

        private void testStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pparser.buildLuaNouveau(patternspath, lvwSections);
            sparser.buildStages(nudInitSpeed, nudMaxSpeed, nudEnergyInterval, nudEnergySpeedup, nudLevelDepth, txtParticleName, txtParticleAbbv);

            File.Copy(patternspath, testpatternspath, true);
            File.Copy(stagespath, teststagespath, true);
            File.Copy(stagemusica, testmusicapath, true);
            File.Copy(stagemusicb, testmusicbpath, true);

            tmrBosonTestStart.Start();
        }

        private void btnChangeBGMusic_Click(object sender, EventArgs e)
        {
            audio.changeMusic(axBGMusic, "a", btnChangeBGMusic);
        }

        private void btnChangeDiffuseMusic_Click(object sender, EventArgs e)
        {
            audio.changeMusic(axDiffuseMusic, "b", btnChangeDiffuseMusic);
        }

        private void btnRemoveBGMusic_Click(object sender, EventArgs e)
        {
            audio.removeMusic(axBGMusic, "a", btnRemoveBGMusic);
        }

        private void btnRemoveDiffuseMusic_Click(object sender, EventArgs e)
        {
            audio.removeMusic(axDiffuseMusic, "b", btnRemoveDiffuseMusic);
        }

        private void tmrBosonTestStart_Tick(object sender, EventArgs e)
        {
            //Process bosonTester = new Process();
            //bosonTester.StartInfo.FileName = Application.StartupPath + "/boson/bosonx.exe";
            //bosonTester.StartInfo.UseShellExecute = true;
            //bosonTester.Start();

            //tmrBosonTestStart.Stop();

            Process test = new Process();
            test.StartInfo.FileName = "C:/Windows/system32/cmd.exe";
            test.StartInfo.Arguments = Application.StartupPath + "/boson/bosonx.exe";
            test.Start();

            tmrBosonTestStart.Stop();
        }
    }
}
