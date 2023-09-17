using MystatService.Interfaces;

namespace Mystat.Tests
{
    public class Teacher_Service_Should
    {
        private readonly IUnitOfWork _unitOfWork;
        public Teacher_Service_Should()
        {
            _unitOfWork = new UnitOfWork();
        }


        [Fact]
        public async void Return_All_Teachers()
        {
            var actual = await _unitOfWork.Teacher.GetAllTeachersAsync();
        }

        [Fact]
        public async void Return_Single_Teacher()
        {
            var actual = await _unitOfWork.Teacher.GetTeacherByIdAsync(12);
        }


    }
}
