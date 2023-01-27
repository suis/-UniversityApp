using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Info.Domain;

namespace University.Info.Interfaces.Application
{
    public interface IUniversityInformationRetriever
    {
        Task<List<UniversityInformation>> GetUniversityInformationByCountry(string countryName);

    }
}
