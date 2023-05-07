using Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces
{
    public interface IPartyRepository
    {
        Party Add(Party obj);
        bool Delete(int partyId);
        void Dispose();
        List<Party> GetAll();
        Party Get(int id);
        Party Update(Party obj);
        DataSet List(int pageNo, int rowPerPage);

    }
}