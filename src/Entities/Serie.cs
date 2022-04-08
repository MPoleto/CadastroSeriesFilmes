using System;

namespace Cadastro_Series.src
{
    public class Serie : EntityBase
    {
        public Serie(Genres genre, string title, string description, int year, bool excluded) 
        {
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = excluded;
               
        }
        private Genres Genre {get; set;}
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}
        private bool Excluded {get; set;}

        public Serie(int id, Genres genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string serieInformations = "";
            serieInformations += "Gênero: " + this.Genre + Environment.NewLine;
            serieInformations += "Título: " + this.Title + Environment.NewLine;
            serieInformations += "Descrição: " + this.Description + Environment.NewLine;
            serieInformations += "Ano de início: " + this.Year + Environment.NewLine;
            serieInformations += "Excluído: " + this.Excluded;
            return serieInformations;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        internal int returnId()
        {
            return this.Id;
        }

        public bool returnExcluded()
        {
            return this.Excluded;
        }
        public void DeletedSerie()
        {
            this.Excluded = true;
        }       
    
    }
}