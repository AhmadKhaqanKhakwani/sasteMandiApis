using Data.Entities;
using System.Collections.Generic;


namespace Data.Interfaces 
{
    public interface IUserRepository
    {
        User Add(User user);
        bool Delete(List<int> userIds);
        User Get(int id);
        User Update(User user);
        void Dispose();


    }
}