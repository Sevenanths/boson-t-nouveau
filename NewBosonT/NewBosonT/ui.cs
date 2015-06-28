using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace NewBosonT
{
    class ui
    {
        public string apppath = Application.StartupPath;
        public string settingsfile = Application.StartupPath + "/settings.config";
        public string loadSettings()
        {
            if (File.Exists(settingsfile))
            {
                string[] settings = File.ReadAllLines(settingsfile);
                foreach (string setting in settings)
                {
                    if (setting.StartsWith("path"))
                    {
                        return setting.Split('=')[1];
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            else
            {
                File.Create(settingsfile).Dispose();
                return null;
            }
        }

        public void writeSettings(string gamespath)
        {
            File.WriteAllText(settingsfile, "path=" + gamespath);
        }

        public void openBPK()
        {
            OpenFileDialog browseBPK = new OpenFileDialog();
            browseBPK.Filter = "Boson Package Files|*.bpk";
            browseBPK.Title = "Select a BPK";

            if (browseBPK.ShowDialog() == DialogResult.OK)
            {
                string zipfile = browseBPK.FileName;
                Zippy zip = Zippy.Open(zipfile, FileAccess.Read);
                List<Zippy.ZipFileEntry> dir = zip.ReadCentralDir();

                foreach (Zippy.ZipFileEntry entry in dir)
                {
                    string path = Application.StartupPath + "/cachee/" + Path.GetFileName(entry.FilenameInZip);
                    zip.ExtractFile(entry, path);
                }
            }
        }
    }
}
