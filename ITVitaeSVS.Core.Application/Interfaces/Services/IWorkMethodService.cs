﻿using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface IWorkMethodService : IGenericService<WorkMethod> {
        public WorkMethod GetByName(string name);
        public IEnumerable<WorkMethod> GetAllByName(string name);
    }
}
