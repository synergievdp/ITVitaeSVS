using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface ICertificateService : IGenericService<Certificate> {
        public Certificate GetByName(string name);
        public Certificate GetByExamId(string examId);
        public IEnumerable<Certificate> GetAllByName(string name);
    }
}
