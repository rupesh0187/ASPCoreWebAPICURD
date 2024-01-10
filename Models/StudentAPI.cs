using System.ComponentModel.DataAnnotations;

namespace ASPCoreWebAPICURD.Models
{
    public class StudentAPI
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Course { get; set; }
        public int Age { get; set; }
        public long Phoneno {  get; set; }

    }
}
