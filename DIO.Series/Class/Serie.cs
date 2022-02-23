namespace DIO.Series
{

    public class Serie : EntityBase
    {
        //Proprieties
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Exclude { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year) {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = Year;
            this.Exclude = false;
        }

        public override string ToString()
        {
            string answer = String.Empty;
            answer += "Gênero : " + this.Genre + Environment.NewLine;
            answer += "Título : " + this.Title + Environment.NewLine;
            answer += "Descrção : " + this.Description + Environment.NewLine;
            answer += "Ano de Inicio : " + this.Year + Environment.NewLine;
            answer += "Excluido : " + this.Exclude;
            return answer;
        }

        public string GetTitle() 
        {
            return this.Title;
        }

        public int GetId() 
        {
            return this.Id;
        }

        public bool GetExclude()
        {
            return this.Exclude;
        }

        public void Delete()
        {
            this.Exclude = true;
        }
    }
}