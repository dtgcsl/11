namespace Web.Models.Subject
{
    public class UpdateSubjectDto
    {
        /*Id,Name,NumberOfcredits*/
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfCredits { get; set; }

    }
}
