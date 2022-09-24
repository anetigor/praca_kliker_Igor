using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ihateniggers
{
    public partial class Form1 : Form
    {
        public int klikniecia = 0;
        public int klikanieNaliczajacePunkty = 1;
        public int punktyDoZbierania = 0;
        public int NajwiecejPunktowPodczasJednejPruby = 0;
        public int CzasPodejscia = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clickerBtn_Click(object sender, EventArgs e)
        {
            if (klikniecia == 0) StartCzasuIProby();
            klikniecia += klikanieNaliczajacePunkty;
            clicksLbl.Text = "" + klikniecia;
        }
        
        public async void StartCzasuIProby()
        {
            CzasPodejscia = 5;
            for (int i = 0; i < 5; i++)
            {

                timerLbl.Text = "" + CzasPodejscia;
                await Task.Delay(1000);
                CzasPodejscia--;
            }
            timerLbl.Text = "" + CzasPodejscia;
            if (klikniecia > NajwiecejPunktowPodczasJednejPruby) NajwiecejPunktowPodczasJednejPruby = klikniecia;
            najLbl.Text = "" + NajwiecejPunktowPodczasJednejPruby;
            punktyDoZbierania += klikniecia;
            pktLbl.Text = "" + punktyDoZbierania;
            klikniecia = 0;
            if (punktyDoZbierania <= 1000) progressBar.Value = punktyDoZbierania;
            else
            {
                progressBar.Value = 1000;
                MessageBox.Show("WYGRANA ! ! !");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (punktyDoZbierania >= 50)
            {
                klikanieNaliczajacePunkty += 1;
                punktyDoZbierania = punktyDoZbierania - 50;
                pktLbl.Text = "" + punktyDoZbierania;
            }
        }
    }
}
