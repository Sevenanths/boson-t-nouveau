using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NewBosonT
{
    class audio
    {
        public string stagemusica = Application.StartupPath + "/cachee/stagea.ogg";
        public string stagemusicb = Application.StartupPath + "/cachee/stageb.ogg";
        public void changeMusic(AxWMPLib.AxWindowsMediaPlayer ax, string stage, Button btn)
        {
            OpenFileDialog musicBrowser = new OpenFileDialog();
            musicBrowser.Filter = "*Ogg Vorbis|*.ogg";
            if (musicBrowser.ShowDialog() == DialogResult.OK)
            {
                switch (stage)
                {
                    case "a":
                        File.Copy(musicBrowser.FileName, stagemusica, true);
                        ax.URL = stagemusica;
                        break;
                    case "b":
                        File.Copy(musicBrowser.FileName, stagemusicb, true);
                        ax.URL = stagemusicb;
                        break;
                }
            }
            btn.Enabled = true;
        }
        public void removeMusic(AxWMPLib.AxWindowsMediaPlayer ax, string stage, Button btn)
        {
            switch (stage)
            {
                case "a":
                    File.Delete(stagemusica);
                    ax.URL = "";
                    break;
                case "b":
                    File.Delete(stagemusicb);
                    ax.URL = "";
                    break;
            }
            btn.Enabled = false;
        }
        public void loadMusic(AxWMPLib.AxWindowsMediaPlayer ax, Button btnRemove, string stage)
        {
            string filename = "";
            switch (stage)
            {
                case "a":
                    filename = stagemusica;
                    break;
                case "b":
                    filename = stagemusicb;
                    break;
            }

            if (File.Exists(filename))
            {
                btnRemove.Enabled = true;
                ax.URL = filename;
            }
        }
    }
}
