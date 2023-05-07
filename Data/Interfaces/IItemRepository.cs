using Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces
{
    public interface IItemRepository
    {
        Item Add(Item obj);
        bool Delete(int id);
        void Dispose();
        Item Get(int id);
        List<Item> GetAll();
        List<Item> GetAllByParty(int id);
        Item Update(Item obj);
        DataSet List(int pageNo, int rowPerPage);

    }
}