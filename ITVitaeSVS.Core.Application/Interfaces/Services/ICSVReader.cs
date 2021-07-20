using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface ICSVReader {
        public void ReadTopicCSV(Stream file, char seperator);
        public void ReadDropDownCSV(Stream file, char seperator);
    }
}
