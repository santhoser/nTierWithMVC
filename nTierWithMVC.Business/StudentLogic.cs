using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nTierWithMVC.Model;
using nTierWithMVC.Repository;
using nTierWithMVC.DAL;

namespace nTierWithMVC.Business
{
    public class StudentLogic : IStudentLogic
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Student> studentRepository;

        public StudentLogic(IUnitOfWork unitOfWork, IGenericRepository<Student> studentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.studentRepository = studentRepository;
        }

        public List<StudentModel> GetData()
        {
            List<StudentModel> students = studentRepository.GetAll().Select(s => new StudentModel
            {
                StudentId = s.StudentId,
                Name = s.Name
            }).ToList();
            return students;
        }

        public void SaveData(StudentModel studentModel)
        {
            Student student = new Student() { StudentId = studentModel.StudentId, Name = studentModel.Name };
            studentRepository.Insert(student);
            this.unitOfWork.Save();
        }
        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }
    }
}
