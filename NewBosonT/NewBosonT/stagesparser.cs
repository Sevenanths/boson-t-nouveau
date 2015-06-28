using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NewBosonT
{
    class stagesparser
    {
        public static main main;
        public string stagespath = Application.StartupPath + "/cachee/stages.lua";
        public void loadVariables(string path, NumericUpDown nudInitSpeed, NumericUpDown nudMaxSpeed, NumericUpDown nudEnergyInterval, NumericUpDown nudEnergySpeedup, NumericUpDown nudLevelDepth, TextBox txtParticleName, TextBox txtParticleAbbv)
        {
            string stageno = Path.GetFileNameWithoutExtension(path).Replace("stage", "");
            string[] stageslines = File.ReadAllLines(main.gamespath + "/data/stages.lua");

            int linecount = 0;
            foreach (string line in stageslines)
            {
                if (line.Contains("-- STAGE " + stageno))
                {
                    int extra = 0;
                    if (stageslines[linecount + 1].Contains("{"))
                    {
                        extra = 1;
                    }

                    nudInitSpeed.Value = Convert.ToDecimal(stageslines[linecount + extra + 1].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudMaxSpeed.Value = Convert.ToDecimal(stageslines[linecount + extra + 2].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudEnergyInterval.Value = Convert.ToDecimal(stageslines[linecount + extra + 3].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudEnergySpeedup.Value = Convert.ToDecimal(stageslines[linecount + extra + 4].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudLevelDepth.Value = Convert.ToDecimal(stageslines[linecount + extra + 5].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    txtParticleName.Text = stageslines[linecount + extra + 6].Split('=')[1].Trim().Replace("\"", "").Replace(",", "");
                    txtParticleAbbv.Text = stageslines[linecount + extra + 7].Split('=')[1].Trim().Replace("\"", "").Replace(",", "");
                }

                linecount++;
            }
        }
        public void loadVariablesNouveau(NumericUpDown nudInitSpeed, NumericUpDown nudMaxSpeed, NumericUpDown nudEnergyInterval, NumericUpDown nudEnergySpeedup, NumericUpDown nudLevelDepth, TextBox txtParticleName, TextBox txtParticleAbbv)
        {
            string[] stageslines = File.ReadAllLines(stagespath);

            int linecount = 0;
            foreach (string line in stageslines)
            {
                if (line.Contains("-- STAGE 1"))
                {
                    int extra = 0;
                    if (stageslines[linecount + 1].Contains("{"))
                    {
                        extra = 1;
                    }

                    nudInitSpeed.Value = Convert.ToDecimal(stageslines[linecount + extra + 1].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudMaxSpeed.Value = Convert.ToDecimal(stageslines[linecount + extra + 2].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudEnergyInterval.Value = Convert.ToDecimal(stageslines[linecount + extra + 3].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudEnergySpeedup.Value = Convert.ToDecimal(stageslines[linecount + extra + 4].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    nudLevelDepth.Value = Convert.ToDecimal(stageslines[linecount + extra + 5].Split('=')[1].Trim().Replace(",", "").Replace('.', ','));
                    txtParticleName.Text = stageslines[linecount + extra + 6].Split('=')[1].Trim().Replace("\"", "").Replace(",", "");
                    txtParticleAbbv.Text = stageslines[linecount + extra + 7].Split('=')[1].Trim().Replace("\"", "").Replace(",", "");
                }

                linecount++;
            }
        }
        public void buildStages(NumericUpDown nudInitSpeed, NumericUpDown nudMaxSpeed, NumericUpDown nudEnergyInterval, NumericUpDown nudEnergySpeedup, NumericUpDown nudLevelDepth, TextBox txtParticleName, TextBox txtParticleAbbv)
        {
            string content = "";
            content += "stages = {\r\n    -- STAGE 1\r\n";
            content += "{\r\n";
            content += "        initial_speed = " + nudInitSpeed.Value.ToString().Replace(',','.') + ",\r\n";
            content += "        max_speed = " + nudMaxSpeed.Value.ToString().Replace(',', '.') + ",\r\n";
            content += "        energy_interval = " + nudEnergyInterval.Value.ToString().Replace(',', '.') + ",\r\n";
            content += "        energy_speedup = " + nudEnergySpeedup.Value.ToString().Replace(',', '.') + ",\r\n";
            content += "        level_depth = " + nudLevelDepth.Value.ToString().Replace(',', '.') + ",\r\n";
            content += "        particle_name = \"" + txtParticleName.Text + "\",\r\n";
            content += "        particle_abbv = \"" + txtParticleAbbv.Text + "\",\r\n";
            content += "},\r\n}\r\n";

            content += "num_stages = 1\r\nfor i = 1, num_stages do\r\nstages[i].id = i\r\nend\r\nfunction get_stage(stage_id)\r\nreturn stages[math.min(num_stages, stage_id)]\r\nend\r\nfunction is_unlocked(s)\r\nreturn s == 1\r\nor s == 2 and lt.state.stage_finished[1]\r\nor s == 3 and lt.state.stage_finished[2]\r\nor s == 4 and lt.state.stage_finished[1]\r\nor s == 5 and lt.state.stage_finished[4]\r\nor s == 6 and lt.state.stage_finished[5] and lt.state.stage_finished[3]\r\nend\r\nfunction compute_progress()\r\nlocal stage = 0\r\nfor s = 1, num_stages do\r\nif lt.state.stage_finished[s] then\r\nstage = stage + 1\r\nend\r\nend\r\nreturn stage\r\nend";

            File.WriteAllText(stagespath, content);
        }
    }
}
