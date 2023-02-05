using System.ComponentModel.DataAnnotations;

namespace ReTask.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime Time { get; set; }

    }
}
