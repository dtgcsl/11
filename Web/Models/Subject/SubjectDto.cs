namespace Web.Models.Subject
{
    public class SubjectDto 
    {
        /*Id,Name,NumberOfcredits*/
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfCredits { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}
