using System;

namespace Utility.Enumerations
{
    public static class Enums
    {
        public static string GetFolderNameByModule(int docType)
        {
            if (docType == Convert.ToInt32(Module.Users))
                return "Users";
            else
                return "";
        }
    }

    public enum FileType
    {
        ProfilePicture = 1,
        Document = 2,
        Logo = 3
    }

    public enum Module
    {
        Users = 1
    }


    public enum UserStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }

    public enum OrderStatusEnum
    {
        Active = 1,
        Delivered = 2,
        Rejected = 3,
        Canceled = 4,
        Completed = 5
    }

}
