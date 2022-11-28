using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Generator
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        byte lop;
        bool numberexist = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            
            listBox1.Visible = false;
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                lop = 1;
                label2.Text = "IMEI NUMBER VERIZON";
            }
            if (radioButton2.Checked)
            {
                lop = 10;
                label3.Text = "Verizon";
            }
            if (radioButton3.Checked)
            {
                lop = 25;
                label3.Text = "Verizon";
            }
            string number="";
            for (int i = 0; i < lop; i++)
            {


                int sumtry = 0;
                while (numberexist)
                {
                    number = imei_Creator();
                    numberexist = checknumber(number);
                    sumtry = sumtry + 1;
                    if (sumtry == 100)
                    {
                        MessageBox.Show( "I have tried 100 different combination but could not find a new number. Please change the Starting Numbers and try again", "Warning--Change Starting Numbers");
                        return;
                    }
                }
                numberexist = true;
                if (lop > 1)
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(number);
                }
                else
                {
                    textBox1.Text = number;
                }
                
                TextWriter wt = new StreamWriter("numbers.txt", true);
                wt.WriteLine(number+" Verizon");
                wt.Close();
            }
        }
        private string imei_Creator()
        {
            string a="", b="";
            
            int x=0,z=0,sum=0;

            x = textBox2.Text.Length;
          int  y = 14 - x;
            string[] c= new string[y];
            
            for (int i = 0; i < y; i++)
            {
                if (x > 14)
                {
                    break;
                }
                c[i] = (rnd.Next(0, 9)).ToString();

            }
            a = textBox2.Text;
            for (int j = 0; j < c.Length; j++)
            {

                a = a + c[j];
            }

            for (int k = 0; k < a.Length; k++)
            {
                b = a.Substring(k, 1);
                z = Convert.ToInt32(b);
                if ((k+1) / 2m == (k+1) / 2)
                {
                    z = z * 2;

                    foreach(char d in z.ToString())
                    {
                        sum = sum + Convert.ToInt32(z);
                    }
                }
                else
                {
                    sum = sum + z;
                }
              
            }

            int kk = 10 - (sum- ((sum / 10)*10));
            if (kk == 10)
            {
                kk = 0;
            }
            a = a + kk.ToString();




            //button1.Text = a.Length.ToString();
            rnd.Next();
            return a;
            //357772175770817
        }
        private bool checknumber(string a)
        {
            string number;
            numberexist = false;
            var fexist = File.Exists("numbers.txt");
            if (fexist)
            {
                StreamReader rw = new StreamReader("numbers.txt");
                while ((number = rw.ReadLine()) != null)
                {
                    if (number.IndexOf(a)>-1)
                    {
                        numberexist = true;
                    }
                }
                rw.Close();
            }
            return numberexist;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Visible = false;

            contextMenuStrip1.MouseClick += new MouseEventHandler(clicked);
            listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);

        }
        private void List_RightClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                int index = this.listBox1.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                   listBox1.SelectedIndex =index;
                }
            }

        }
        private void clicked(object sender, MouseEventArgs e)
        {
           
            string a = listBox1.SelectedItem.ToString();
            Clipboard.SetText (a);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label3.Text = "";
            listBox1.Visible = false;
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                lop = 1;
                label2.Text = "IMEI NUMBER AT&T";
            }
            if (radioButton2.Checked)
            {
                lop = 10;
                label3.Text = "AT&T";
            }
            if (radioButton3.Checked)
            {
                lop = 25;
                label3.Text = "AT&T";
            }
            string number = "";
            for (int i = 0; i < lop; i++)
            {


                int sumtry = 0;
                while (numberexist)
                {
                    number = imei_Creator();
                    numberexist = checknumber(number);
                    sumtry = sumtry + 1;
                    if (sumtry == 100)
                    {
                        MessageBox.Show("Warning--Change Starting Numbers", "I have tried 100 different combination but could not find a new number. Please change the Starting Numbers and try again");
                        return;
                    }
                }
                numberexist = true;
                if (lop > 1)
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add(number);
                }
                else
                {
                    textBox1.Text = number;
                }

                TextWriter wt = new StreamWriter("numbers.txt", true);
                wt.WriteLine(number + " AT&T");
                wt.Close();
            }
        }

        
    }
}
