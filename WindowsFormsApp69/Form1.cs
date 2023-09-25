using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp69
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader cteni = new StreamReader("cisla.txt");
            try
            {
                long n = long.Parse(textBox1.Text);
                int pocitac = 0; int pate = 0; bool jecislo = true;
                while (!cteni.EndOfStream)
                {
                    string line = cteni.ReadLine();
                    if (pocitac == 4)
                    {
                        if (int.TryParse(line, out pate))
                        {
                            MessageBox.Show("pate cislo je: " + pate);
                            break;
                        }
                        else
                        {
                            jecislo = false;
                            break;
                        }
                    }
                    pocitac++;
                }
                if (jecislo == true)
                {
                    cteni.Close();
                    int umocnene = 1;
                    bool okay = true;
                    for (int x = 0; x < n; x++)
                    {
                        try
                        {
                            checked { umocnene = umocnene * pate; }
                        }
                        catch (OverflowException)
                        {
                            MessageBox.Show("preteceni nastalo pri nasobeni");
                            okay = false;
                            break;
                        }
                    }
                    if(okay == true)
                    {
                        if (n == 0)
                        {
                            MessageBox.Show("n je 0, nemůžete dělit nulou");
                        }
                        else
                        {
                            double real_podil = (double)umocnene / (double)n;
                            long celo_podil = umocnene / n;
                            StreamReader cteni2 = new StreamReader("cisla.txt");
                            int soucet_cisel_je = 0;
                            while (!cteni2.EndOfStream)
                            {
                                try
                                {
                                    checked { soucet_cisel_je += int.Parse(cteni2.ReadLine()); }
                                }
                                catch (OverflowException)
                                {
                                    MessageBox.Show("preteceni nastalo pri scitani");
                                }
                            }
                            MessageBox.Show("pate cislo na n je: " + umocnene + "\n realny podil cisla n a umocneneho je: " + real_podil + "\n celociselny podil cisla na a umoceneneho je: " + celo_podil + "\n soucet vsech cisel je: " + soucet_cisel_je);
                            cteni2.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("pate cislo v souboru neni zadáno");
                }

            }
            catch (OverflowException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (FileNotFoundException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (FormatException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                cteni.Close();
            }
        }
    }
}
