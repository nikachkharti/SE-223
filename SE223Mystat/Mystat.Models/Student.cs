namespace Mystat.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Attends { get; set; }
        public bool AttendsOnline { get; set; }
        public int Brilliants { get; set; }
        public string Comment { get; set; }
    }
}
