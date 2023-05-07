using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IPartyFinancialDetailRepository
    {
        PartyFinancialDetail Add(PartyFinancialDetail obj);
        bool Delete(int id);
        void Dispose();
        List<PartyFinancialDetail> GetAll();
        PartyFinancialDetail Get(int id);
        PartyFinancialDetail Update(PartyFinancialDetail obj);
    }
}