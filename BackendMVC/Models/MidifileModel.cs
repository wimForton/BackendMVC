namespace BackendMVC.Models
{
    public class MidifileModel
    {
        public int Id { get; set; }
        public int FileNumber { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public string? FilePath { get; set; }
        public int Filesize { get; set; }
        public int Duration { get; set; }
        public string? Composer { get; set; }

    }
}
