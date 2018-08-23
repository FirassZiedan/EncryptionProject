using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Encryption
{

    public partial class Form1 : Form
    {
         string extion;
         string[] Vernam = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
         //List<string> key_char = new List<string>() ;
         List <int> key_num = new List<int>() ;
         char [] key;
         List<string> mess_t  = new List<string>() ;
         List<int>  mess_n =new List<int>();
         List<int> key_full = new List<int>();
         List<int> enc_n = new List<int>();
         List<string> enc_t = new List<string>();
        
        
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult DR = openFileDialog1.ShowDialog();
                if (DR == DialogResult.OK)
                {
                    extion = openFileDialog1.FileName.ToString();
                }//end if

                string cont = "";
                foreach (string line in File.ReadAllLines(extion))
                {
                    string[] parts = line.Split();

                    foreach (string part in parts)
                    {
                        cont += " " + part;
                    }

                }
                textBox1.Text = cont;
            }
            catch
            {
                MessageBox.Show("Select File");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            key_num.Clear();
            mess_t.Clear();
            mess_n.Clear();
            key_full.Clear();
            enc_n.Clear();
            // enc_t.Clear();
            textBox2.Text = " ";
            char[] fg = textBox1.Text.ToCharArray();
            for (int q = 0; q < fg.Length; q++)
            {
                if (fg[q] != ' ')
                {
                    string s = fg[q].ToString();
                    mess_t.Add(s);
                }
            }


            if (radioButton2.Checked)
            {


                string row1 = "";
                string row2 = "";
                string row3 = "";
                string r1 = "";
                string r2 = "";
                string r3 = "";
                string r = "";
                int row = mess_t.Count;
                int row_1 = (row / 2) / 2 + 1;
                int row_2 = row / 2;
                int row_3 = (row / 2) / 2;
                int c = 1;
                int a = 0;
                for (int i = 0; i < mess_t.Count; i++)
                {
                    if (c == 1)
                    {
                        row1 += mess_t[i] + " ";
                        row2 += "." + " ";
                        row3 += "." + " ";
                        r1 += mess_t[i];
                        c = 2;
                    }

                    else if (c == 2)
                    {
                        row1 += "." + " ";
                        row2 += mess_t[i] + " ";
                        row3 += "." + " ";
                        r2 += mess_t[i];
                        if (a == 1)
                        {
                            c = 1;
                            a = 0;
                        }
                        else if (a == 0)
                            c = 3;
                    }
                    else if (c == 3)
                    {
                        row1 += "." + " ";
                        row2 += "." + " ";
                        row3 += mess_t[i] + " ";
                        r3 += mess_t[i];


                        c = 2;
                        a = 1;
                    }




                }//end for 
                string enc_t = " ";
                textBox2.Text = row1 + "\r\n";
                textBox2.Text += row2 + "\r\n";
                textBox2.Text += row3;
                r = r1 + r2 + r3;
                r.ToCharArray();
                for (int i = 0; i < r.Length; i++)
                {
                    if (i % 5 == 0)
                        enc_t += " " + r[i].ToString();
                    else
                        enc_t += r[i].ToString();
                }
                textBox2.Text += "\r\n\r\n";
                textBox2.Text += enc_t;
            }//end RB2
            //------------------------------------------------------------------------------------------------------------------
            if (radioButton3.Checked)
            {
                string en = "";
                if (textBox3.Text != "")
                {
                    char[] k = textBox3.Text.ToCharArray();
                    string kb = Convert.ToString(k[0], 2);
                    List<string> bin = new List<string>();

                    for (int i = 0; i < fg.Length; i++)
                    {
                        string bin1 = Convert.ToString(fg[i], 2);
                        bin.Add(bin1);
                        listBox1.Items.Add(bin1);
                    }

                    for (int i = 0; i < bin.Count; i++)
                    {

                        char[] s1 = bin[i].ToCharArray();
                        char[] ks = kb.ToCharArray();
                        /*  for (int o = 0; o < ks.Length; o++)
                              MessageBox.Show(ks[o].ToString());*/
                        for (int q = 0; q < s1.Length; q++)
                        {
                            if ((s1[q] == '1' && ks[q] == '1') || (s1[q] == '0' && ks[q] == '0'))
                            {
                                en += "0";
                            }
                            else if ((s1[q] == '1' && ks[q] == '0') || (s1[q] == '0' && ks[q] == '1'))
                            {
                                en += "1";
                            }
                        }
                        en += " ";

                    }//end for 

                    textBox2.Text = en;
                }
                else
                 MessageBox.Show("Enter The key!!!!");
            }


            //------------------------------------------------------------------------------------------------------------------




                if (radioButton5.Checked)
                {
                    // key_char.Clear();
                    key_num.Clear();

                    if (textBox3.Text != "")
                    {
                        key = textBox3.Text.ToCharArray();

                        char[] fgg = textBox1.Text.ToCharArray();
                        for (int q = 0; q < fgg.Length; q++)
                        {
                            if (fg[q] != ' ')
                            {
                                string s = fgg[q].ToString();
                                //-----------
                                for (int z = 0; z < Vernam.Length; z++)
                                {
                                    if (s == Vernam[z].ToString())
                                    {
                                        mess_n.Add(z);
                                        //  listBox2.Items.Add(s + "   " + z);

                                    }//end if
                                }
                                //-----------
                            }
                        }


                        for (int a = 0; a < key.Length; a++)
                        {
                            for (int y = 0; y < Vernam.Length; y++)
                            {
                                if (key[a].ToString() == Vernam[y])
                                {
                                    key_num.Add(y);
                                }
                            }
                        }
                        int y1 = 0;
                        for (int i = 0; i < mess_n.Count; i++)
                        {


                            if (y1 == key.Length)
                                y1 = 0;

                            key_full.Add(key_num[y1]);
                            y1++;
                        }//end for 
                        string text = "";
                        for (int i = 0; i < mess_n.Count; i++)
                        {
                            int wq = (mess_n[i] + key_full[i]) % 26;
                            enc_n.Add(wq);
                        }//end for 
                        for (int i = 0; i < enc_n.Count; i++)
                        {
                            string ss = Vernam[enc_n[i]];

                            enc_t.Add(ss);
                            text += ss;

                        }


                        textBox2.Text = text;
                    }//end if 
                    else
                    {
                        MessageBox.Show("Enter The Key ");
                    }


                

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            MessageBox.Show("Enter The Key ");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Enter The Key One Character ");
            groupBox1.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  string c = "hello";
           /* byte[] arr = System.Text.Encoding.ASCII.GetBytes(c);
            
            for (int i = 0; i < arr.Length; i++)
            {
                listBox1.Items.Add(arr[i]);
            }*/


           // string  cc = new System.Text.UTF8Encoding().GetBytes("hello"); 
           // char  str = 'h';
           /* string val = SByte.MinValue.ToString("x");
            byte res = Convert.ToByte(val,16 );*/
            string bin = Convert.ToString('A', 2);
 
               MessageBox.Show(bin);
        }//end B3

       
    }
}
