using System;

namespace dioSeries
{
    public class series : entidadeBase
    {
        //Atributos

        private Genre Genre {get; set;}
        private string Title {get; set;}
        private string Description { get; set;}
        private int Year {get; set;}

        private bool Deleted {get; set;}

        //MÉTODOS
        //Construtor
        public series(int id, Genre genre, string title, string description, int year)
        {
            this.Id=id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }
        
        public override string ToString()
        {
            string feedback = "";
            feedback += "Genero: " + this.Genre + Environment.NewLine;
            feedback += "Titulo: " + this.Title + Environment.NewLine;
            feedback += "Descrição: " + this.Description + Environment.NewLine;
            feedback += "Ano Inicío: " + this.Year;
            feedback += "Exluido: " + this.Deleted;
            return feedback;
        }

        //Encapsulamento

        public string returnTitle()
        {
            return this.Title;
        }
        public int returnId()
        {
            return this.Id;
        }
        public bool returnDeleted()
        {
            return this.Deleted = true; 
        }

        public void Delete() 
        {
            this.Deleted = true;
        }

    }
}