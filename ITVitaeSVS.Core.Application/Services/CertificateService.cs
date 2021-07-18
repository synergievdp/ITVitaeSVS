using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class CertificateService : GenericService<Certificate>, ICertificateService {
        public CertificateService(IGenericRepository<Certificate> repo) : base(repo) {}

        public IEnumerable<Certificate> GetAllByName(string name) {
            return repo.GetAll(certificate => certificate.Name.Contains(name));
        }

        public Certificate GetByName(string name) {
            return repo.Get(certificate => certificate.Name.Contains(name));
        }

        public override void Update(Certificate obj) {
            if(GetByName(obj.Name) == null
                && GetByExamId(obj.ExamId) == null)
                base.Update(obj);
        }

        public override Certificate Add(Certificate obj) {
            if (GetByName(obj.Name) == null
                && GetByExamId(obj.ExamId) == null)
                return base.Add(obj);
            else
                return null;
        }

        public Certificate GetByExamId(string examId) {
            return repo.Get(certificate => certificate.ExamId.Contains(examId));
        }
    }
}
