using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzeepel
{
    public partial class YahtzeeInvoer : Form
    {
        //
        //Vars
        //
        Random rnd = new Random(); // hier maken we een random om te gebruiken voor de dobbelstenen
        byte rolCount = 0;
        int result1;
        int result2;
        int result3;
        int result4;
        int result5;

        public YahtzeeInvoer()
        {
            InitializeComponent();
        }

        //
        //Methodes
        //
        private void DisEnableCheckboxes(bool enable)
        {
            if (enable)
            {
                chbB1.Enabled = true;
                chbB2.Enabled = true;
                chbB3.Enabled = true;
                chbB4.Enabled = true;
                chbB5.Enabled = true;
            }
            else if(enable == false)
            {
                chbB1.Enabled = false;
                chbB2.Enabled = false;
                chbB3.Enabled = false;
                chbB4.Enabled = false;
                chbB5.Enabled = false;
            }
        }
        private void DiceRol()
        {
            result1 = rnd.Next(1, 7);
            result2 = rnd.Next(1, 7);
            result3 = rnd.Next(1, 7);
            result4 = rnd.Next(1, 7);
            result5 = rnd.Next(1, 7);
                if (chbB1.Checked != true)
                {
                    lblD1.Text = result1.ToString();
                }
                if (chbB2.Checked != true)
                {
                    lblD2.Text = result2.ToString();
                }
                if (chbB3.Checked != true)
                {
                    lblD3.Text = result3.ToString();
                }
                if (chbB4.Checked != true)
                {
                    lblD4.Text = result4.ToString();
                }
                if (chbB5.Checked != true)
                {
                    lblD5.Text = result5.ToString();
                }
            if (rolCount == 3)
            {
                btnRol.Enabled = false;
                btnKlaar.Enabled = false;
                pnlScore.Visible = true;
                pnlScore.Enabled = true;
                DisEnableCheckboxes(false);
            }

        }
        private void Bereken()
        {
            bool inputFout = false;
            int Out = 0;
            int dice1 = int.Parse(lblD1.Text);
            int dice2 = int.Parse(lblD2.Text);
            int dice3 = int.Parse(lblD3.Text);
            int dice4 = int.Parse(lblD4.Text);
            int dice5 = int.Parse(lblD5.Text);
            int[] Dices = { dice1, dice2, dice3, dice4, dice5 };
            // check voor de nummers
            if (rdbEnen.Checked)
            {
                foreach (int dice in Dices)
                {
                    if(dice == 1) Out++;
                    
                }
                lblEnenOut.Text = Out.ToString();
                rdbEnen.Checked = false;
                rdbEnen.Enabled = false;
            }
            if (rdbTweeen.Checked)
            {
                foreach(int dice in Dices)
                {
                    if (dice == 2) Out = Out + 2;
                }
                lblTweeenOut.Text = Out.ToString();
                rdbTweeen.Checked = false;
                rdbTweeen.Enabled = false;
            }
            if (rdbDrieen.Checked)
            {
                foreach(int dice in Dices)
                {
                    if (dice == 3) Out = Out + 3;
                }
                lblDrienOut.Text = Out.ToString();
                rdbDrieen.Checked = false;
                rdbDrieen.Enabled = false;
            }
            if (rdbVieren.Checked)
            {
                foreach(int dice in Dices)
                {
                    if (dice == 4) Out = Out + 4;
                }
                lblVierenOut.Text = Out.ToString();
                rdbVieren.Checked = false;
                rdbVieren.Enabled = false;
            }
            if (rdbVijven.Checked)
            {
                foreach(int dice in Dices)
                {
                    if (dice == 5) Out = Out + 5;
                }
                lblVijfenOut.Text = Out.ToString();
                rdbVijven.Checked = false;
                rdbVijven.Enabled = false;
            }
            if (rdbZessen.Checked)
            {
                foreach(int dice in Dices)
                {
                    if (dice == 6) Out = Out + 6;
                }
                lblZessenOut.Text = Out.ToString();
                rdbZessen.Checked = false;
                rdbZessen.Enabled = false;
            }
            //check voor de specials
            if (rdbTOAK.Checked)
            {
                if (checkDuplicates(3))
                {
                    foreach (int dice in Dices)
                    {
                        Out = Out + dice;
                    }
                    lblTOAKOut.Text = Out.ToString();
                    rdbTOAK.Checked = false;
                    rdbTOAK.Enabled = false;
                }
                else inputFout = true;
            }
            if (rdbCare.Checked)
            {
                if (checkDuplicates(4))
                {
                    foreach (int dice in Dices)
                    {
                        Out = Out + dice;
                    }
                    lblCareOut.Text = Out.ToString();
                    rdbCare.Checked = false;
                    rdbCare.Enabled = false;
                }
                else inputFout = true;
            }
            if (rdbFullhouse.Checked)
            {
                if (checkDuplicates(2) && checkDuplicates(3))
                {
                    Out = 25;
                    lblFullhouseOut.Text = Out.ToString();
                    rdbFullhouse.Enabled = false;
                    rdbFullhouse.Checked = false;
                }
                else inputFout = true;
            }
            if (rdbKleineStraat.Checked)
            {
                int een = 0;
                int twee = 0;
                int drie = 0;
                int vier = 0;
                int vijf = 0;
                int zes = 0;
                foreach(int dice in Dices)
                {
                    if (dice == 1) een = een + 1;
                    if (dice == 2) twee = twee + 1;
                    if (dice == 3) drie = drie + 1;
                    if (dice == 4) vier = vier +1;
                    if (dice == 5) vijf = vijf +1;
                    if (dice == 6) zes = zes +1;
                }
                if (een > 0 && twee > 0 && drie > 0 && vier > 0 || twee > 0 && drie > 0 && vier > 0 && vijf > 0 || drie > 0 && vier > 0 && vijf > 0 && zes > 0)
                {
                    Out = 30;
                    lblKleineStraatOut.Text = Out.ToString();
                    rdbKleineStraat.Checked = false;
                    rdbKleineStraat.Enabled = false;
                }
                else inputFout = true;
            }
            if (rdbGroteStraat.Checked)
            {
                int een = 0;
                int twee = 0;
                int drie = 0;
                int vier = 0;
                int vijf = 0;
                int zes = 0;
                foreach (int dice in Dices)
                {
                    if (dice == 1) een = een + 1;
                    if (dice == 2) twee = twee + 1;
                    if (dice == 3) drie = drie + 1;
                    if (dice == 4) vier = vier + 1;
                    if (dice == 5) vijf = vijf + 1;
                    if (dice == 6) zes = zes + 1;
                }
                if (een > 0 && twee > 0 && drie > 0 && vier > 0 && vijf > 0 || twee > 0 && drie > 0 && vier > 0 && vijf > 0 && zes > 0)
                {
                    Out = 40;
                    lblGroteStraatOut.Text = Out.ToString();
                    rdbGroteStraat.Checked = false;
                    rdbGroteStraat.Enabled = false;
                }
                else inputFout = true;
            }
            if (rdbYathzee.Checked)
            {
                if (checkDuplicates(5))
                {
                    Out = 50;
                    lblYahtzeeOut.Text = Out.ToString();
                    rdbYathzee.Checked = false;
                    rdbYathzee.Enabled = false;
                }
                else inputFout = true;
            }
            if (rdbChance.Checked)
            {
                foreach(int dice in Dices)
                {
                    Out = Out + dice;
                    lblChanceOut.Text = Out.ToString();
                    rdbChance.Enabled = false;
                    rdbChance.Checked = false;
                }
            }
            //Reset Vars/Labels/Buttons
            if (inputFout == false)
            {
                rolCount = 0;
                lblD1.Text = "1";
                lblD2.Text = "1";
                lblD3.Text = "1";
                lblD4.Text = "1";
                lblD5.Text = "1";
                btnKlaar.Enabled = true;
                btnRol.Enabled = true;
                pnlScore.Visible = false;
                pnlScore.Enabled = false;
                chbB1.Checked = false;
                chbB2.Checked = false;
                chbB3.Checked = false;
                chbB4.Checked = false;
                chbB5.Checked = false;
                DisEnableCheckboxes(false);
            }
            else if (inputFout)
            {
                MessageBox.Show("Verkeerde invoer!");
            }


        }
        private bool checkDuplicates(int nummer_of_multiples)
        { 
            int check = nummer_of_multiples;
            int Tel = 0;
            int een = 0;
            int twee = 0;
            int drie = 0;
            int vier = 0;
            int vijf = 0;
            int zes = 0;
            int dice1 = int.Parse(lblD1.Text);
            int dice2 = int.Parse(lblD2.Text);
            int dice3 = int.Parse(lblD3.Text);
            int dice4 = int.Parse(lblD4.Text);
            int dice5 = int.Parse(lblD5.Text);
            int[] Dices = { dice1, dice2, dice3, dice4, dice5 };
            foreach(int dice in Dices)
            {
   
                if (dice == 1) een++;
                if (dice == 2) twee++;
                if (dice == 3) drie++;
                if (dice == 4) vier++;
                if (dice == 5) vijf++;
                if (dice == 6) zes++;
                Tel++;
            }
            if (een == check || twee == check || drie == check || vier == check || vijf == check || zes == check) return true;
            else return false;
        }

        //
        //Events
        //
        private void btnRol_Click(object sender, EventArgs e)
        {
            rolCount++;
            DiceRol();
            DisEnableCheckboxes(true);
        }

        private void btnKlaar_Click(object sender, EventArgs e)
        {
            if (rolCount == 0) MessageBox.Show("Er moet tenminste één keer gerold worden!");
            else { rolCount = 3; DiceRol(); }
        }

        private void btnBereken_Click(object sender, EventArgs e)
        {
            Bereken();
        }
    }
}
