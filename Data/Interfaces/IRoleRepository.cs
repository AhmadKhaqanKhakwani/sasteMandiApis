using Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces 
{
    public interface IRoleRepository
    {
        Role Add(Role role);
        bool AddRolePermissions(List<RolePermission> rolePerms);
        UserInRole AddUserRole(UserInRole userInRole);
        bool Delete(int roleId);
        bool DeleteRolePermissions(int roleId);
        bool DeleteUserRoles(int roleId);
        void Dispose();
        Role Get(int roleId);
        List<Role> GetAll();
        List<UserInRole> GetUserRoles(int userId);
        Role Update(Role role);
        UserInRole UpdateUserRole(UserInRole userInRole);
        DataSet List(int pageNo, int rowPerPage);

    }
}