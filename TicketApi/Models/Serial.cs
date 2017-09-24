namespace TicketApi.Models
{
    public class Serial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int PackagesCount { get; set; }
        public int TicketsCount { get; set; }

        public bool NoteIsNotEmpty => !string.IsNullOrEmpty(Note);
    }
}
