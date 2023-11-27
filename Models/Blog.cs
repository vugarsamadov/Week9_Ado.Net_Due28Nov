namespace ADO.NET.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }

        public override string ToString()
        {
            return $"{Id} Title: {Title}, Desc: {Description}";
        }
    }
}
