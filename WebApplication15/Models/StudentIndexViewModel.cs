namespace WebApplication15.Models
{
    public class StudentIndexViewModel
    {
        public IEnumerable<Student> students { get; set; } =new List<Student>();

        public string texttosearch { get; set; }

        public int? No { get; set; }

        

    }
}
