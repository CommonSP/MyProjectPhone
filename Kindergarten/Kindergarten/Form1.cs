using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (KindergartenContext db = new KindergartenContext())
            {
                if (textBox1.Text == "") 
                {
                    label5.Text = "Введите логин!";
                    label5.ForeColor=Color.Red;
                }
                else label5.Text = "";
                if (textBox2.Text=="")
                {
                    label6.Text = "Введите  пароль!";
                    label6.ForeColor = Color.Red;
                }
                else label6.Text = "";
                if(textBox1.Text!="" && textBox2.Text!="")
                {
                    Parents parent = db.Parents.Where(item => item.Login == textBox1.Text).FirstOrDefault();
                    if (parent == null) {
                        label7.Text = "Неправильно указан логин и/или пароль";
                    }
                    else
                    {
                        if (parent.Password == textBox2.Text)
                        {
                            Form2 newForm = new Form2(parent, this);
                            newForm.Show();
                            this.Hide();
                            label7.Text = "";
                        }
                        else
                        {
                            parent = null;  
                            label7.Text = "Неправильно указан логин и/или пароль";
                        }
                    }
                   
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }
    }
}
