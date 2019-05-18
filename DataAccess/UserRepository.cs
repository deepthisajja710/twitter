using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
     public class UserRepository
    {
        public void AddUser(Client objUser)
        {
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    objContext.Clients.Add(objUser);
                    objContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerifyUser(string username, string password)
        {
            try
            {
                using (TweetContext objContext = new TweetContext())
                {
                    var NoOfUsers = (from obj in objContext.Clients
                                     where obj.user_id == username && obj.password == password
                                     select obj).Count();
                    if (NoOfUsers > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
