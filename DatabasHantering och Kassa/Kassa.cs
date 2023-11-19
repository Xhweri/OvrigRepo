using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper.Configuration;
using CsvHelper;

namespace Labb4
{

    public partial class Kassa : Form
    {

        public BindingList<Games> gamesDbS;
        public BindingList<Movies> filmsDbF;
        public BindingList<Books> booksDbB;
        public BindingList<Games> comboBoxS;
        public BindingList<Movies> comboBoxF;
        public BindingList<Books> comboBoxB;
        public Databas dataBas;
        public Games gm;
        public Csv csv;

        public string Title { get; set; }
        public bool bekraftad = false;
        public string ProductCode { get; set; }
        private readonly string SfileName = "spel.csv";
        private readonly string FfileName = "film.csv";
        private readonly string BfileName = "bok.csv";

        public Kassa()
        {

            InitializeComponent();
            comboBoxS = new BindingList<Games>();
            comboBoxF = new BindingList<Movies>();
            comboBoxB = new BindingList<Books>();
            dataBas = new Databas();
            gm = new Games();
            csv = new Csv();

        }

        bool f = false; bool s = false; bool b = false;
        public void ComoLaggS()
        {
            gamesDbS = new BindingList<Games>();


            using (var reader = new StreamReader("spel.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
            {
                while (csv.Read())
                {
                    comboBoxS.Add(new Games
                    {
                        Title = csv.GetField<string>(0),
                        Publisher = csv.GetField<string>(1),
                        Price = csv.GetField<string>(2),
                        ProductCode = csv.GetField<string>(3),
                        Category = csv.GetField<string>(4),
                        Status = csv.GetField<int>(5),
                    });
                }
            }

        }
        public void ComoLaggF()
        {
            filmsDbF = new BindingList<Movies>();


            using (var reader = new StreamReader("film.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
            {
                while (csv.Read())
                {
                    comboBoxF.Add(new Movies
                    {
                        Title = csv.GetField<string>(0),
                        Director = csv.GetField<string>(1),
                        Price = csv.GetField<string>(2),
                        ProductCode = csv.GetField<string>(3),
                        Category = csv.GetField<string>(4),
                        Speltid = csv.GetField<string>(5),
                        Status = csv.GetField<int>(6),
                    });
                }
            }

        }
        public void ComoLaggB()
        {
            booksDbB = new BindingList<Books>();


            using (var reader = new StreamReader("bok.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
            {
                while (csv.Read())
                {
                    comboBoxB.Add(new Books
                    {
                        Title = csv.GetField<string>(0),
                        Author = csv.GetField<string>(1),
                        Price = csv.GetField<string>(2),
                        ProductCode = csv.GetField<string>(3),
                        Category = csv.GetField<string>(4),
                        Status = csv.GetField<int>(5),
                    });
                }
            }

        }

        private void sokBtn_Click(object sender, EventArgs e)
        {

            if (SokTxt.Text.Contains("spel") || SokTxt.Text.Contains("film") || SokTxt.Text.Contains("bok"))
            {
                if (SokTxt.Text.Contains("spel"))
                {
                    dataGridView1.DataSource = comboBoxS;
                    if (File.Exists(SfileName))
                    {
                        if (s == false)
                        {

                            ComoLaggS();
                            s = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("filen finns inte");
                    }

                }
                else if (SokTxt.Text.Contains("film"))
                {
                    dataGridView1.DataSource = comboBoxF;
                    if (File.Exists(FfileName))
                    {
                        if (f == false)
                        {
                            ComoLaggF();
                            f = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("filen finns inte");
                    }

                }
                else if (SokTxt.Text.Contains("bok"))
                {
                    dataGridView1.DataSource = comboBoxB;
                    if (File.Exists(BfileName))
                    {
                        if (b == false)
                        {
                            ComoLaggB();
                            b = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("filen finns inte");
                    }
                }
            }
            else
            {

                MessageBox.Show("Välj mellan spel/film eller bok");
            }
        }

        private void AddVara_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                if (rowIndex >= 0 && rowIndex < comboBoxS.Count)
                {
                    if (SokTxt.Text.Contains("spel"))
                    {
                        Games selectedCellS = comboBoxS[rowIndex];
                        kundkorg.Text += "," + selectedCellS.Title;
                        bekraftad = true;
                    }
                }
                if (rowIndex >= 0 && rowIndex < comboBoxF.Count)
                {
                    if (SokTxt.Text.Contains("film"))
                    {
                        Movies selectedCellF = comboBoxF[rowIndex];
                        kundkorg.Text += "," + selectedCellF.Title;
                        bekraftad=true;
                    }
                }
                if (rowIndex >= 0 && rowIndex < comboBoxB.Count)
                {
                    if (SokTxt.Text.Contains("bok"))
                    {
                        Books selectedCellB = comboBoxB[rowIndex];
                        kundkorg.Text += "," + selectedCellB.Title;
                        bekraftad=true;
                    }
                }
            }
        }

        private void bekraftakop_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int rowIndex = dataGridView1.SelectedRows[0].Index;

            //    if (rowIndex >= 0 && rowIndex < comboBoxS.Count)
            //    {
            //        if (SokTxt.Text.Contains("spel") && bekraftad == true)
            //        {
            //            Games selectedCellS = comboBoxS[rowIndex];
            //            selectedCellS.Status--;
            //            csv.SparaCsvG(comboBoxS);
            //            if (selectedCellS.Status <= 0)
            //            {
            //                comboBoxS.RemoveAt(rowIndex);
            //                csv.DeleteRowS(rowIndex);
            //                MessageBox.Show("Varan är nu slut");
            //            }
            //        }

            //    }
            //    if (rowIndex >= 0 && rowIndex < comboBoxF.Count)
            //    {
            //        if (SokTxt.Text.Contains("film") && bekraftad == true)
            //        {
            //            Movies selectedCellF = comboBoxF[rowIndex];
            //            selectedCellF.Status--;
            //            csv.SparaCsvM(comboBoxF);
            //            if (selectedCellF.Status <= 0)
            //            {
            //                comboBoxF.RemoveAt(rowIndex);
            //                csv.DeleteRowM(rowIndex);
            //                MessageBox.Show("Varan är nu slut");
            //            }        
            //        }
            //    }
            //    if (rowIndex >= 0 && rowIndex < comboBoxB.Count)
            //    {


            //        if (SokTxt.Text.Contains("bok") && bekraftad == true)
            //        {
            //            Books selectedCellB = comboBoxB[rowIndex];
            //            selectedCellB.Status--;
            //            csv.SparaCsvB(comboBoxB);
            //            if (selectedCellB.Status <= 0)
            //            {
            //                comboBoxB.RemoveAt(rowIndex);
            //                csv.DeleteRowB(rowIndex);
            //                MessageBox.Show("Varan är nu slut");
            //            }
            //        }
            //    }
            //}
            //kundkorg.Text = ""; 
            //Bekrefta köp innan version 2

            if (!string.IsNullOrEmpty(kundkorg.Text) && bekraftad == true)//Bättre att kolla om kundkorgen är tom
            {
                string[] items = kundkorg.Text.Split(','); // splitar på alla items så vi kan lägga dom separat i arryn

                foreach (string item in items)// itterera över alla platser i arrayn, som representerar den valda raden.
                {
                    if (SokTxt.Text.Contains("spel"))//kollar vilken bindinglist det är genom att kolla vad som står i sökfältet
                    {
                        Games selectedGame = comboBoxS.FirstOrDefault(g => g.Title == item);//satsen kollar titel och om det matchar med array indexen, g representerar indexen för bindinglisten comboboxs
                        if (selectedGame != null)
                        {
                            selectedGame.Status--;
                            csv.SparaCsvG(comboBoxS);
                            if (selectedGame.Status <= 0)
                            {
                                comboBoxS.Remove(selectedGame);
                                csv.DeleteRowS(comboBoxS.IndexOf(selectedGame));
                                MessageBox.Show("Varan är nu slut");
                            }
                        }
                    }
                    else if (SokTxt.Text.Contains("film"))
                    {
                        Movies selectedMovie = comboBoxF.FirstOrDefault(m => m.Title == item);
                        if (selectedMovie != null)
                        {
                            selectedMovie.Status--;
                            csv.SparaCsvM(comboBoxF);
                            if (selectedMovie.Status <= 0)
                            {
                                comboBoxF.Remove(selectedMovie);
                                csv.DeleteRowM(comboBoxF.IndexOf(selectedMovie));
                                MessageBox.Show("Varan är nu slut");
                            }
                        }
                    }
                    else if (SokTxt.Text.Contains("bok"))
                    {
                        Books selectedBook = comboBoxB.FirstOrDefault(b => b.Title == item);
                        if (selectedBook != null)
                        {
                            selectedBook.Status--;
                            csv.SparaCsvB(comboBoxB);
                            if (selectedBook.Status <= 0)
                            {
                                comboBoxB.Remove(selectedBook);
                                csv.DeleteRowB(comboBoxB.IndexOf(selectedBook));
                                MessageBox.Show("Varan är nu slut");
                            }
                        }
                    }
                }
            }

            kundkorg.Text = "";
        }

        private void RaderaVara_Click(object sender, EventArgs e)
        {
            kundkorg.Text = "";
            bekraftad=false;
        }
    }
}



