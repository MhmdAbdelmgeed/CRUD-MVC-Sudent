namespace WebApplication15.Models
{
    public class StudentMoc
    {
      static  List<Student> Students = new List<Student>()
        {
            new Student(){  Id= 1, Name ="ali",Age=50},
            new Student(){  Id= 2, Name ="ahmed",Age=40},
            new Student(){  Id= 3, Name ="mohamed",Age=30},
            new Student(){  Id= 4, Name ="mai",Age=20},
            new Student(){  Id= 5, Name ="amir",Age=50},
             new Student(){  Id= 6, Name ="alaa",Age=30},
            new Student(){  Id= 7, Name ="osama",Age=45},
            new Student(){  Id= 8, Name ="yasser",Age=33},
            new Student(){  Id= 9, Name ="morad",Age=20},
            new Student(){  Id= 10, Name ="eslam",Age=10},

        };
        public List<Student>GetAllStudents()
        {
            return Students;
        }
        public Student GetStudentById(int id)
        {
            return Students.FirstOrDefault(a => a.Id == id);
        }
        public void AddStudent(Student std)
        {
            Students.Add(std);
        }
        public void UpdateStudent(Student std)
        {
            Student oldst=Students.FirstOrDefault(a => a.Id == std.Id);
            if(oldst!=null)
            {
                oldst.Age = std.Age;
                oldst.Name = std.Name;
            }
        }
        public void DeleteStudent(int id)
        {
            Students.Remove(GetStudentById(id));
        }
    }
}
