using Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces
{
    public interface ICompanyRepository
    {
        Company Add(Company obj);
        bool Delete(int companyId);
        void Dispose();
        List<Company> GetAll();
        Company Get(int id);
        Company Update(Company obj);
        DataSet List(int pageNo, int rowPerPage);

    }
}