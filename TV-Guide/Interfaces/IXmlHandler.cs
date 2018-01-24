using System.Collections.Generic;
using TV_Guide.Models;

namespace TV_Guide.Interfaces
{
    public interface IXmlHandler
    {
        void FindFile();
        void CreateFile(string path);
        List<Program> GetPrograms();
    }
}
