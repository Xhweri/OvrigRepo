using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using System.ComponentModel;
using CsvHelper.Configuration;
using System.Net;
using System.Xml;

namespace Labb4
{

    public class Csv
    {
        private readonly string SfileName = "spel.csv";
        private readonly string FfileName = "film.csv";
        private readonly string BfileName = "bok.csv";
        public void SparaCsvM(BindingList<Movies> filmDb)
        {

            try
            {
                StreamWriter sw = new StreamWriter("film.csv", false);
                for (int i = 0; i < filmDb.Count; i++)
                {
                    sw.WriteLine($"{filmDb[i].Title},{filmDb[i].Director},{filmDb[i].Price},{filmDb[i].ProductCode},{filmDb[i].Category},{filmDb[i].Speltid},{filmDb[i].Status}");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the CSV file: {ex.Message}");
            }
        }
        public void SparaCsvG(BindingList<Games> spelDb)
        {

            try
            {
                StreamWriter sw = new StreamWriter("spel.csv", false);


                for (int i = 0; i < spelDb.Count; i++)
                {
                    sw.WriteLine($"{spelDb[i].Title},{spelDb[i].Publisher},{spelDb[i].Price},{spelDb[i].ProductCode},{spelDb[i].Category},{spelDb[i].Status}");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the CSV file: {ex.Message}");
            }
        }
        public void SparaCsvB(BindingList<Books> BokDb)
        {

            try
            {
                StreamWriter sw = new StreamWriter("bok.csv", false);


                for (int i = 0; i < BokDb.Count; i++)
                {
                    sw.WriteLine($"{BokDb[i].Title},{BokDb[i].Author},{BokDb[i].Price},{BokDb[i].ProductCode},{BokDb[i].Category},{BokDb[i].Status}");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the CSV file: {ex.Message}");
            }
        }
        public void ReadCsvS(BindingList<Games> spelDb)
        {
            using (var reader = new StreamReader("spel.csv"))


            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
            {

                while (csv.Read())
                {
                    spelDb.Add(new Games
                    {

                        Title = csv.GetField<string>(0),
                        Publisher = csv.GetField<string>(1),
                        Price = csv.GetField<string>(2),
                        ProductCode = csv.GetField<string>(3),
                        Category = csv.GetField<string>(4),
                        Status = csv.GetField<int>(5)
                    });


                }
            }

        }
        public void ReadCsvF(BindingList<Movies> FilmDb)
        {
            using (var reader = new StreamReader("film.csv"))


            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
            {

                while (csv.Read())
                {
                    FilmDb.Add(new Movies
                    {

                        Title = csv.GetField<string>(0),
                        Director = csv.GetField<string>(1),
                        Price = csv.GetField<string>(2),
                        ProductCode = csv.GetField<string>(3),
                        Category = csv.GetField<string>(4),
                        Speltid = csv.GetField<string>(5),
                        Status = csv.GetField<int>(6)
                    });


                }
            }

        }
        public void ReadCsvB(BindingList<Books> BokDb)
        {
            using (var reader = new StreamReader("bok.csv"))


            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
            {

                while (csv.Read())
                {
                    BokDb.Add(new Books
                    {

                        Title = csv.GetField<string>(0),
                        Author = csv.GetField<string>(1),
                        Price = csv.GetField<string>(2),
                        ProductCode = csv.GetField<string>(3),
                        Category = csv.GetField<string>(4),
                        Status = csv.GetField<int>(5)
                    });


                }
            }

        }

        public void DeleteRowS(int rowIndex)
        {
            if (File.Exists(SfileName))
            {
                var lines = File.ReadAllLines(SfileName);
                if (lines.Length > rowIndex)
                {
                    var remainingLines = lines.Where((line, index) => index != rowIndex);
                    File.WriteAllLines(SfileName, remainingLines);
                }
            }        
        }
        public void DeleteRowM(int rowIndex)
        {
            if (File.Exists(FfileName))
            {
                var lines = File.ReadAllLines(FfileName);
                if (lines.Length > rowIndex)
                {
                    var remainingLines = lines.Where((line, index) => index != rowIndex);
                    File.WriteAllLines(FfileName, remainingLines);
                }
            }
        }
        public void DeleteRowB(int rowIndex)
        {
            if (File.Exists(BfileName))
            {
                var lines = File.ReadAllLines(BfileName);
                if (lines.Length > rowIndex)
                {
                    var remainingLines = lines.Where((line, index) => index != rowIndex);
                    File.WriteAllLines(BfileName, remainingLines);
                }
            }
        }

       
    }

}

