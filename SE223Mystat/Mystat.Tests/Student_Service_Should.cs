using MystatService.Interfaces;

//NIKA CHKARTIHSVILI

namespace MystatService
{
    public class Student_Service_Should
    {
        private readonly IUnitOfWork _unitOfWork;
        public Student_Service_Should()
        {
            _unitOfWork = new UnitOfWork();
        }

        [Fact]
        public void Return_All_Students_From_Database()
        {
            //var actual = _unitOfWork.Student.GetAllStudents();

            //var expected = new List<Student>()
            //{
            //    new Student()
            //    {
            //        Id = 1,
            //        FirstName = "ნიკოლოზ",
            //        LastName = "ლაშხია",
            //        RegisterDate = new DateTime(2023,09,10,20,43,13,827),
            //        FullName = "ნიკოლოზლაშხია",
            //        Attends = true,
            //        AttendsOnline = true,
            //        Brilliants = 10,
            //        Comment = null
            //    }
            //};


            //Assert.Equal(expected, actual, new StudentEquilityComparer());
        }

        [Fact]
        public void Add_New_Student_In_Database()
        {
            //Student newStudent = new()
            //{
            //    FirstName = "რატი",
            //    LastName = "მამულაშვილი",
            //    Attends = true,
            //    AttendsOnline = true,
            //    Brilliants = 10,
            //    Comment = string.Empty
            //};

            //_unitOfWork.Student.AddNewStudent(newStudent);
        }

    }
}
