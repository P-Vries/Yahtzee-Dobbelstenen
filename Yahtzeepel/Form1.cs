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
    public partial class Form1 : Form
    {
        //
        //Vars
        //
        Random rnd = new Random(); // hier maken we een random om te gebruiken voor de dobbelstenen

        public Form1()
        {
            InitializeComponent();
        }

        private void DiceRol()
        {
            int result1 = rnd.Next(1, 7);
            int result2 = rnd.Next(1, 7);
            int result3 = rnd.Next(1, 7);
            int result4 = rnd.Next(1, 7);
            int result5 = rnd.Next(1, 7);

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
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            DiceRol();
        }
    }
}
