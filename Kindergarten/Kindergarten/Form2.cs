using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Form2 : Form
    {
        Parents parents1 = new Parents();
        Form1 form1 = new Form1();
        public Form2(Parents parents, Form1 f)
        {
            InitializeComponent();
            form1 = f;
            parents1 = parents;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalArea personal = new PersonalArea(parents1);
            personal.Show();
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
            
        }
    }
    
}
