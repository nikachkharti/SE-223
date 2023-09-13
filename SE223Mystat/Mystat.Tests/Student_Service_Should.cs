using MystatService.Interfaces;

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
        public async void Return_All_Students_From_Database()
        {
            var actual = await _unitOfWork.Student.GetAllStudentsAsync();

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
        public async void Add_New_Student_In_Database()
        {
            Student newStudent = new()
            {
                FirstName = "ანა",
                LastName = "ანანიაშვილი",
                Attends = true,
                AttendsOnline = true,
                Brilliants = 10,
                Comment = string.Empty
            };

            await _unitOfWork.Student.AddNewStudentAsync(newStudent);
        }

        [Fact]
        public async void Get_Single_Student()
        {
            var student = await _unitOfWork.Student.GetStudentByIdAsync(1);
        }

        [Fact]
        public async void Update_Student()
        {
            var studentToUpdate = await _unitOfWork.Student.GetStudentByIdAsync(1);
            studentToUpdate.FirstName = "გიორგი";

            await _unitOfWork.Student.UpdateStudentAsync(studentToUpdate);
        }

        [Fact]
        public async void Delete_Student()
        {
            await _unitOfWork.Student.DeleteStudentAsync(2);
        }


        [Fact]
        public async void Delete_Many_Students()
        {
            await _unitOfWork.Student.DeleteManyStudentsAsync(1, 3);
        }
    }
}
