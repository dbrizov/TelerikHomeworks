using System;
using System.Linq;

namespace UsersAndGroups.Client
{
    public class ClientMain
    {
        static void Main(string[] args)
        {
            UsersAndGroupsDAO.AddUser("Pesho", "123456", "Admin");
        }
    }
}
