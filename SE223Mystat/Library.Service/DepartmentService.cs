using Library.Entities;
using Library.Repository;
using Library.Service.Interfaces;

namespace Library.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task Add(Department model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            await _departmentRepository.Add(model);
        }

        public async Task DeleteDepartment(Department model)
        {
            var result = await _departmentRepository.Get(author => author.Id == model.Id);

            if (result is not null)
            {
                _departmentRepository.Remove(result);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var result = await _departmentRepository.GetAll();

            if (result.Count() > 0)
            {
                return result.ToList();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            var result = await _departmentRepository.Get(author => author.Id == id);

            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Department model)
        {
            if (model is not null)
            {
                _departmentRepository.Update(model);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
