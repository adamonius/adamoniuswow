using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using ExternalSiteUtils;

namespace Professions
{
    public partial class frmProfs : Form
    {
        private SortedList<String, List<NameLevel>> profsByChar;
        private static String serverName;
        private static String globalCharName;
        private Armory armorySite;

        public frmProfs()
        {
            InitializeComponent();
            profsByChar = new SortedList<String, List<NameLevel>>();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtBoxResult.Text = String.Empty;
            armorySite = new Armory(Armory.Region.US, txtBoxServer.Text);


            String guildName = radGuild.Checked ? txtBoxName.Text : String.Empty;
            List<String> charList = armorySite.GetGuildList(guildName);
            prgBarProcess.Maximum = charList.Count;
            prgBarProcess.Value = 0;
            serverName = txtBoxServer.Text;

            bgrndWork.RunWorkerAsync(charList);
        }

        private void bgrndWork_DoWork(object sender, DoWorkEventArgs e)
        {
            List<String> charList = e.Argument as List<String>;
            BackgroundWorker worker = sender as BackgroundWorker; 
            
            foreach (String charName in charList)
            {
                String profOneName, profTwoName;
                Int32 profOneLevel, profTwoLevel;
                try
                {
                    armorySite.GetProfessions(charName, out profOneName, out profOneLevel, out profTwoName, out profTwoLevel);
                    AddCharProfs(charName, worker, profOneName, profOneLevel, profTwoName, profTwoLevel);
                } catch (ArmoryException)
                {
                    System.Threading.Thread.Sleep(2500);
                    try
                    {
                        armorySite.GetProfessions(charName, out profOneName, out profOneLevel, out profTwoName, out profTwoLevel);

                    } catch (Exception)
                    {
                        AddCharProfs(charName, worker, "Unknown", -1, "Unknown", -1);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Error", ex);
                } 
            }
        }

        private void AddCharProfs(String charName, BackgroundWorker worker, String profOneName, Int32 profOneLevel, String profTwoName, Int32 profTwoLevel)
        {
            globalCharName = charName;
            if (!profsByChar.ContainsKey(profOneName))
                profsByChar.Add(profOneName, new List<NameLevel>());
            profsByChar[profOneName].Add(new NameLevel(charName, profOneLevel));
            worker.ReportProgress(0, String.Format(" - {0:15} : {1}", profOneName, profOneLevel));

            if (!profsByChar.ContainsKey(profTwoName))
                profsByChar.Add(profTwoName, new List<NameLevel>());
            profsByChar[profTwoName].Add(new NameLevel(charName, profTwoLevel));
            worker.ReportProgress(1, String.Format(" - {0:15} : {1}", profTwoName, profTwoLevel));
        }

        private void bgrndWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                txtBoxResult.Text += globalCharName + Environment.NewLine;
            txtBoxResult.Text += e.UserState + Environment.NewLine;
            prgBarProcess.PerformStep();
            if (e.ProgressPercentage == 1)
                txtBoxResult.Text += Environment.NewLine;
        }

        private void bgrndWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtBoxResult.Text += Environment.NewLine;
            txtBoxResult.Text += "---------------" + Environment.NewLine;
            txtBoxResult.Text += "----Results----" + Environment.NewLine;
            txtBoxResult.Text += "---------------" + Environment.NewLine;
            txtBoxResult.Text += Environment.NewLine;

            foreach (KeyValuePair<String, List<NameLevel>> kvp in profsByChar)
            {
                txtBoxResult.Text += kvp.Key + Environment.NewLine;
                kvp.Value.Sort();
                foreach (NameLevel nameRankPair in kvp.Value)
                {
                    txtBoxResult.Text += " - " + nameRankPair.name + " : " + nameRankPair.level + Environment.NewLine;
                }
                txtBoxResult.Text += Environment.NewLine;
            }

        }
    }

    class NameLevel : IComparable
    {
        public String name;
        public Int32 level;

        public NameLevel(String name, String level)
        {
            this.name = name;
            this.level = Int32.Parse(level);
        }

        public NameLevel(String name, Int32 level)
        {
            this.name = name;
            this.level = level;
        }

        #region IComparable Members
        //Sort by descending level; if equal, by ascending name
        public int CompareTo(object obj)
        {
            if ((obj as NameLevel) == null)
                return 0;

            NameLevel compObj = obj as NameLevel;

            if (this.level == compObj.level)
            {
                if (this.name == compObj.name)
                    return -1;
                else
                    return String.Compare(this.name, compObj.name);
            } else
                return compObj.level.CompareTo(this.level);
        }

        #endregion
    }
}