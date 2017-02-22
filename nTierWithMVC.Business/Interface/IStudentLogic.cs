using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nTierWithMVC.Model;

namespace nTierWithMVC.Business
{
    public interface IStudentLogic
    {
        List<StudentModel> GetData();

        void SaveData(StudentModel studentModel);

        void Dispose();
    }
}
