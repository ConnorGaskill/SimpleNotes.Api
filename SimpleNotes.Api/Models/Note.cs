namespace SimpleNotes.Api.Models
{
    public class Note
    {
        public int Id { get; private set; }
        public string Content { get; set; } = string.Empty;
    }
}
