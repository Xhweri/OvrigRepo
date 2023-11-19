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

namespace Labb4
{
    
    public partial class Form1 : Form
    {
        
        public Kassa kassaRuta;
        public Databas dataBas;
        

        public Form1()
        {
            InitializeComponent();
            kassaRuta = new Kassa();
            dataBas = new Databas();
        }
        
        private void kassaBtn_Click(object sender, EventArgs e)
        {
            Kassa kassaRuta=new Kassa();
            
            kassaRuta.Show();   
        }

        private void databasBtn_Click(object sender, EventArgs e)
        {
            Databas dataBas = new Databas();
            Csv csv = new Csv();
            string filePathG = "spel.csv";
            string filePathM = "film.csv";
            string filePathB = "bok.csv";
            
            if (File.Exists(filePathG))
            {           
                csv.ReadCsvS(dataBas.SpelDb);
            }
            if (File.Exists(filePathB))
            {
                csv.ReadCsvB(dataBas.BokDb);
            }
            if (File.Exists(filePathM))
            {
                csv.ReadCsvF(dataBas.FilmDb);
            }


            dataBas.Show();
        }
    }
}
