namespace ReTask.Models.ViewModel
{
    public class NewsDTO
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

    }
}
