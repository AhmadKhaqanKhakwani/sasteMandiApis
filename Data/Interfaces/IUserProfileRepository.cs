
using Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IUserProfileRepository
    {
        UserProfile Add(UserProfile userProfile);
        UserProfile Get(int id);
        List<UserProfile> GetAll();
        void Dispose();

    }
}