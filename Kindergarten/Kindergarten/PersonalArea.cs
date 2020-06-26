using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class PersonalArea : Form
    {
        
        public PersonalArea(Parents p)
        {
            InitializeComponent();
            label1.Text = p.Fio.Split(' ')[0];
            label2.Text = p.Fio.Split(' ')[1];
            label3.Text = p.Fio.Split(' ')[2];
            label4.Text = p.Pasport;
            label5.Text = p.Phone;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
           
        }
    }
}
