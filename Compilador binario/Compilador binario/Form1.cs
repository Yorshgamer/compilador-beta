using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Compilador_binario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 

        private void CrearArchivo_Click(object sender, EventArgs e)
        {
            {
                string nombre = textBox1.Text;
                StreamWriter escribir
                     = new StreamWriter(@"C:\Users\WINDOWS11\Desktop\"+ nombre + ".bin", true);
                try
                {
                    escribir.WriteLine(richTextBox2.Text);
                }
                catch
                {
                    MessageBox.Show("Error");                
                }
                escribir.Close();
            }
        }

        private void Sali_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            StreamReader leer = new StreamReader(@"C:\Users\WINDOWS11\Desktop\" + nombre + ".bin");
            string linea;
            try
            {
                linea = leer.ReadLine();
                while (linea != null)
                {
                    richTextBox1.AppendText(linea+ "\n");
                    linea = leer.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }

        public void Nemonico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = Nemonico.SelectedIndex;
            if (indice == 1) //NOT
            {
                lblHex.Text = "00";
            }else
                if (indice ==2)//NAND
            {
                    lblHex.Text = "1"+textBox2.Text;
                }else
                if (indice==3)//ADD
            {
                    lblHex.Text = "2" + textBox2.Text;
                }else
                if(indice == 4)//LDA
            {
                    lblHex.Text = "3" + textBox2.Text;
                }
                else
                if (indice == 5)//OUTA
            {
                    lblHex.Text = "40";
                }
                else
                if (indice == 6)//OUTB
            {
                    lblHex.Text = "50";
                }
                else
                if (indice == 7)//INA
            {
                    lblHex.Text = "60";
                }
            else
                if (indice == 8)//RD
            {
                lblHex.Text = "70";
            }
            else
                if (indice == 9)//RA
            {
                lblHex.Text = "80";
            }
            else
                if (indice == 10)//LDRA
            {
                lblHex.Text = "90";
            }
            else
                if (indice == 11)//JPI
            {
                lblHex.Text = "C"+textBox2.Text;
            }
            else
                if (indice == 12)//JPC
            {
                lblHex.Text = "D"+textBox2.Text;
            }
            else
                if (indice == 13)//JPZ
            {
                lblHex.Text = "E"+textBox2.Text;
            }
        }

        public class HexadecimalConverter
        {
            public static string ToASCII(string hex)
            {
                string ascii = string.Empty;

                for (int i = 0; i < hex.Length; i += 2)
                {
                    ascii += (char)ToDecimal(hex.Substring(i, 2));
                }

                return ascii;
            }
            public static int ToDecimal(string hex)
            {
                hex = hex.ToUpper();

                int hexLength = hex.Length;
                double dec = 0;

                for (int i = 0; i < hexLength; ++i)
                {
                    byte b = (byte)hex[i];

                    if (b >= 48 && b <= 57)
                        b -= 48;
                    else if (b >= 65 && b <= 70)
                        b -= 55;

                    dec += b * Math.Pow(16, ((hexLength - i) - 1));
                }

                return (int)dec;
            }
        }
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            string hexa = lblHex.Text;
            StringReader obtDats = new StringReader(hexa);
            
            string linea2;
            string Convert;
            try
            {
                linea2 = obtDats.ReadLine();
                Convert = HexadecimalConverter.ToASCII(linea2);
                richTextBox2.AppendText(Convert );
                   
                
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }
    }
}
