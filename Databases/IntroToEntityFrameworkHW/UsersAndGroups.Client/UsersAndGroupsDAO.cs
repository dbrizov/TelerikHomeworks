using System;
using System.Linq;
using System.Transactions;
using UsersAndGroups.Data;

namespace UsersAndGroups.Client
{
    // Task 11
    // Create a database holding users and groups.
    // Create a transactional EF based method that creates an user and puts it in a group "Admins".
    // In case the group "Admins" do not exist, create the group in the same transaction.
    // If some of the operations fail (e.g. the username already exist), cancel the entire transaction.

    public static class UsersAndGroupsDAO
    {
        public static void AddUser(string username, string password, string groupName)
        {
            UsersAndGroupsEntities usersAndGroupsDb = new UsersAndGroupsEntities();
            using (usersAndGroupsDb)
            {
                TransactionScope transaction = new TransactionScope();
                using (transaction)
                {
                    Group group;
                    group = usersAndGroupsDb.Groups.FirstOrDefault(g => g.Name == groupName);
                    if (group == null)
                    {
                        group = AddGroup(groupName);
                    }

                    User newUser = new User()
                    {
                        Username = username,
                        Password = password,
                        GroupID = group.GroupID
                    };

                    usersAndGroupsDb.Users.Add(newUser);
                    usersAndGroupsDb.Groups.Add(group);
                    group.Users.Add(newUser);

                    usersAndGroupsDb.SaveChanges();

                    transaction.Complete();
                }
            }
        }

        public static Group AddGroup(string name)
        {
            Group newGroup = new Group();
            newGroup.Name = name;

            UsersAndGroupsEntities usersAndGrousDb = new UsersAndGroupsEntities();
            using (usersAndGrousDb)
            {
                usersAndGrousDb.Groups.Add(newGroup);
                usersAndGrousDb.SaveChanges();
            }

            return newGroup;
        }
    }
}
