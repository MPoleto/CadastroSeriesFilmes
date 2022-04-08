using System;

namespace Cadastro_Series.src
{
    public class Movie : EntityBase
    {
        public Movie(Genres genre, string title, string description, int year, bool excluded) 
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

        public Movie(int id, Genres genre, string title, string description, int year)
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
            string movieInformations = "";
            movieInformations += "Gênero: " + this.Genre + Environment.NewLine;
            movieInformations += "Título: " + this.Title + Environment.NewLine;
            movieInformations += "Descrição: " + this.Description + Environment.NewLine;
            movieInformations += "Ano de início: " + this.Year + Environment.NewLine;
            movieInformations += "Excluído: " + this.Excluded;
            return movieInformations;
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
        public void DeletedMovie()
        {
            this.Excluded = true;
        }
    }
}