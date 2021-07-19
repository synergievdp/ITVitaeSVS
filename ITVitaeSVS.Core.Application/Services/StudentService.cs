using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class StudentService : GenericService<Student>, IStudentService {
        public StudentService(IGenericRepository<Student> repo) : base(repo) {

        }
        public Student GetByName(string name) {
            return repo.Get(student => student.Name.Contains(name));
        }

        public IEnumerable<Student> GetAllByName(string name) {
            return repo.GetAll(student => student.Name.Contains(name));
        }
    }
}
