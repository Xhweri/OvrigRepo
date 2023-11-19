using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Labb4
{

    public partial class Databas : Form
    {
        
        public BindingList<Games> SpelDb = new BindingList<Games>();
        public BindingList<Movies> FilmDb = new BindingList<Movies>();
        public BindingList<Books> BokDb = new BindingList<Books>();
        public Csv csv;

        public Databas()
        {
            InitializeComponent();
            
            dataGridView1.DataSource = SpelDb;
            dataGridView2.DataSource = FilmDb;
            dataGridView3.DataSource = BokDb;
            

            csv = new Csv();
        }
        
         public int stat = 0;
        public int nummer;
        public void AddNewGame(string title, string publisher, string price, string productCode, string category)
        {
            try
            {
                if (SpelDb.Any(item => item.ProductCode == productCode))
                {

                    MessageBox.Show($"Produkt koden {productCode} du angivit är upptaget") ;
                    
                    return;
                }

                if (!int.TryParse(PrisTxt.Text, out nummer))
                {
                    MessageBox.Show("Priset är inget Nummer");
                    return;
                }
                if (int.Parse(PrisTxt.Text) <= 0)
                {
                    MessageBox.Show("priset måste vara ett positivt tal");
                    return;
                }

                if (!int.TryParse(varunrTxt.Text, out nummer))
                {
                    MessageBox.Show("VarNr måste vara en siffra");
                    return;
                }
                if (int.Parse(varunrTxt.Text) <= 0)
                {
                    MessageBox.Show("VaruNr måste vara ett positivt tal");
                    return;
                }


                var existingGame = SpelDb.FirstOrDefault(item => item.Title == title);

                if (existingGame != null)
                {
                    DialogResult adderaLager = MessageBox.Show("Denna vara finns redan i lager vill du Addera den till lagret?", "Lager", MessageBoxButtons.YesNo);
                    if (adderaLager == DialogResult.Yes)
                    {
                        stat = existingGame.Status++;
                        csv.SparaCsvG(SpelDb);

                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                var newGame = new Games
                {
                    Title = title,
                    Publisher = publisher,
                    Price = price,
                    ProductCode = productCode,
                    Category = category,
                    Status = 1

                };
                SpelDb.Add(newGame);
                csv.SparaCsvG(SpelDb);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel på AddnewGame funktionen");
            }
        }



        public void AddNewMovie(string title, string director, string price, string productCode, string category,string speltid)
        {
            try
            {
                if (FilmDb.Any(movie => movie.ProductCode == productCode))
                {
                    MessageBox.Show($"Produkt koden {productCode} du angivit är upptaget");
                    return;
                }
                if (!int.TryParse(FilmPri.Text, out nummer))
                {
                    MessageBox.Show("Priset är inget Nummer");
                    return;
                }
                if (int.Parse(FilmPri.Text) <= 0)
                {
                    MessageBox.Show("priset måste vara ett positivt tal");
                    return;
                }

                if (!int.TryParse(FilmVaruNrtxt.Text, out nummer))
                {
                    MessageBox.Show("VarNr måste vara en siffra");
                    return;
                }
                if (int.Parse(FilmVaruNrtxt.Text) <= 0)
                {
                    MessageBox.Show("VaruNr måste vara ett positivt tal");
                    return;
                }
                var existingGame = FilmDb.FirstOrDefault(item => item.Title == title);

                if (existingGame != null)
                {
                    DialogResult adderaLager = MessageBox.Show("Denna vara finns redan i lager vill du Addera den till lagret?", "Lager", MessageBoxButtons.YesNo);
                    if (adderaLager == DialogResult.Yes)
                    {
                        existingGame.Status++; 
                        csv.SparaCsvM(FilmDb);
                        return;
                    }
                }

                var newMovie = new Movies
                {
                    Title = title,
                    Director = director,
                    Price = price,
                    ProductCode = productCode,
                    Category = category,
                    Speltid = speltid,
                    Status = 1
                };

                FilmDb.Add(newMovie);
                csv.SparaCsvM(FilmDb);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel på AddnewGame funktionen");
            }
        }



        public void AddNewBook(string title, string author, string price, string productCode, string category)
        {
            if (BokDb.Any(book => book.ProductCode == productCode))
            {
                MessageBox.Show($"Produkt koden {productCode} du angivit är upptaget");
                return;
            }
            if (!int.TryParse(BokPriTxt.Text, out nummer))
            {
                MessageBox.Show("Priset är inget Nummer");
                return;
            }
            if (int.Parse(BokPriTxt.Text) <= 0)
            {
                MessageBox.Show("priset måste vara ett positivt tal");
                return;
            }

            if (!int.TryParse(BokVaruNrTxt.Text, out nummer))
            {
                MessageBox.Show("VarNr måste vara en siffra");
                return;
            }
            if (int.Parse(BokVaruNrTxt.Text) <= 0)
            {
                MessageBox.Show("VaruNr måste vara ett positivt tal");
                return;
            }
            var ExistingProd=BokDb.FirstOrDefault(item => item.Title == title);
            
            if (ExistingProd != null)
            {
                DialogResult adderaLager = MessageBox.Show("Denna vara finns redan i lager vill du Addera den till lagret?", "Lager", MessageBoxButtons.YesNo);
                if (adderaLager == DialogResult.Yes)
                {
                    ExistingProd.Status++;
                    csv.SparaCsvB(BokDb);
                    return;
                }
            }

            var newBook = new Books
            {
                Title = title,
                Author = author,
                Price = price,
                ProductCode = productCode,
                Category = category,
                Status = 1
            };

            BokDb.Add(newBook);
            csv.SparaCsvB(BokDb);
        }




        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SpelTxt.Text) && !string.IsNullOrEmpty(PrisTxt.Text))
            {
                AddNewGame(SpelTxt.Text, PubTxt.Text, PrisTxt.Text, varunrTxt.Text, ScategoryTxt.Text);
            }
            else
            {
                MessageBox.Show("Fyll i titeln på Spelet och priset");
            }
        }

        private void AddBtnFilm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FilmTxt.Text) && !string.IsNullOrEmpty(FilmPri.Text))
            {
                AddNewMovie(FilmTxt.Text, FilmDirTxt.Text, FilmPri.Text, FilmVaruNrtxt.Text, FCategoryTxt.Text,speltidTxt.Text);

            }
            else
            {
                MessageBox.Show("Fyll i Titels på filmen och priset");
            }
        }
        private void BtnAddbok_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(BokTxt.Text) && !string.IsNullOrEmpty(BokPriTxt.Text))
                {
                    AddNewBook(BokTxt.Text, BokAuth.Text, BokPriTxt.Text, BokVaruNrTxt.Text, BCategoryTxt.Text);
                }
                else
                {
                    MessageBox.Show("Fyll i Titel på boken och priset");
                }
        }



        private void BtnRemove_Click(object sender, EventArgs e)
        {
         
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                Games SelectedCell = SpelDb[rowIndex];
                SelectedCell.Status--;
                if (SelectedCell.Status == 0)
                {
                    var resultat = MessageBox.Show("Är du säker på att du vill radera varan ur lagret?", "Delete", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == resultat)
                    {
                        SpelDb.RemoveAt(rowIndex);
                        csv.DeleteRowS(rowIndex);
                    }
                }
            }
        }

        private void BtnRemove2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                
                int rowIndex = dataGridView2.SelectedRows[0].Index;
                Movies selectedCell = FilmDb[rowIndex];
                selectedCell.Status--;
                if(selectedCell.Status == 0)
                {
                    var resultat = MessageBox.Show("Är du säker på att du vill radera varan ur lagret?", "Delete", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == resultat)
                    {
                        FilmDb.RemoveAt(rowIndex);
                        csv.DeleteRowM(rowIndex);
                    }
                }
                
            }
        }

        private void BtnRemove3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView3.SelectedRows[0].Index;
                Books selectedCell = BokDb[rowIndex];
                selectedCell.Status--;
                if (selectedCell.Status == 0)
                {
                    var resultat = MessageBox.Show("Är du säker på att du vill radera varan ur lagret?", "Delete", MessageBoxButtons.YesNo);
                    if(DialogResult.Yes == resultat)
                    {
                        BokDb.RemoveAt(rowIndex);
                        csv.DeleteRowB(rowIndex);
                    }
                }
               
            }
        }
       
        public void XmlUpgrade()
        {
            try
            {
                WebClient api = new WebClient();
                var data = api.DownloadString("https://hex.cse.kau.se/~jonavest/csharp-api/");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);   
                foreach (XmlElement rad in doc.FirstChild.ChildNodes)
                {
                    if (rad.Name == "error")
                    {
                        throw new Exception(rad.InnerXml);
                    }
                    else if (rad.Name == "products")
                    {
                        foreach (XmlElement childN in rad.ChildNodes)
                        {
                            
                            if (childN.Name == "game")
                            {
                                string gameTitle = childN.ChildNodes[1].InnerText;
                                string gamePrice = childN.ChildNodes[2].InnerText;
                                int gamestock = int.Parse(childN.ChildNodes[3].InnerXml);
                                string gamesPc = childN.ChildNodes[0].InnerText;

                                Games existingGame = SpelDb.FirstOrDefault(g => g.Title == gameTitle);
                                //Extra funktion för att kolla om titeln redan finns i databasen och om den inte gör det så ska den skapa en ny produkt.
                                if (existingGame != null)
                                {
                                    existingGame.Price = gamePrice;
                                    existingGame.Status = gamestock;
                                    existingGame.ProductCode = gamesPc;
                                }
                                else
                                {
                                    Games newGame = new Games()
                                    {
                                        Title = gameTitle,
                                        Price = gamePrice,
                                        Status = gamestock,
                                        ProductCode = gamesPc

                                    };
                                    SpelDb.Add(newGame);
                                }
                                csv.SparaCsvG(SpelDb);
                            }

                            if (childN.Name == "book")
                            {
                                string bokTitle = childN.ChildNodes[1].InnerText;
                                string bokPrice = childN.ChildNodes[2].InnerText;
                                int bokstock = int.Parse(childN.ChildNodes[3].InnerXml);
                                string bokPc = childN.ChildNodes[0].InnerText;

                                Books existingGame = BokDb.FirstOrDefault(g => g.Title == bokTitle);
                                //Extra funktion för att kolla om titeln redan finns i databasen och om den inte gör det så ska den skapa en ny produkt.
                                if (existingGame != null)
                                {
                                    existingGame.Price = bokPrice;
                                    existingGame.Status = bokstock;
                                    existingGame.ProductCode =bokPc;
                                }
                                else
                                {
                                    Books newBook = new Books()
                                    {
                                        Title = bokTitle,
                                        Price = bokPrice,
                                        Status = bokstock,
                                        ProductCode = bokPc

                                    };
                                    BokDb.Add(newBook);
                                }
                                csv.SparaCsvB(BokDb);
                            }

                            if (childN.Name == "movie")
                            {
                                string movieTitle = childN.ChildNodes[1].InnerText;
                                string moviePrice = childN.ChildNodes[2].InnerText;
                                int movietock = int.Parse(childN.ChildNodes[3].InnerXml);
                                string moviePc = childN.ChildNodes[0].InnerText;

                                Movies existingGame = FilmDb.FirstOrDefault(g => g.Title == movieTitle);
                                //Extra funktion för att kolla om titeln redan finns i databasen och om den inte gör det så ska den skapa en ny produkt.
                                if (existingGame != null)
                                {
                                    existingGame.Price = moviePrice;
                                    existingGame.Status = movietock;
                                    existingGame.ProductCode = moviePc;
                                }
                                else
                                {
                                    Movies newMovie = new Movies()
                                    {
                                        Title = movieTitle,
                                        Price = moviePrice,
                                        Status = movietock,
                                        ProductCode = moviePc

                                    };
                                     FilmDb.Add(newMovie);
                                }
                                csv.SparaCsvM(FilmDb);
                            }

                        }
                    }
                    if (rad.Name == "metadata")
                    {
                        string tid = rad.LastChild.InnerText;
                        label18.Text = rad.LastChild.InnerText;
                        label19.Text = rad.LastChild.InnerText;
                        label20.Text = rad.LastChild.InnerText;

                    }
                }
                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void updateS_Click(object sender, EventArgs e)
        {
            XmlUpgrade();
            
        }
    }
}