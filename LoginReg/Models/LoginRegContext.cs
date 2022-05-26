using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace LoginReg.Models
{
    
    public class LoginRegContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LoginRegContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}

        //Get User by UserId or email address
        public User GetUser(int? UserId)
        {
            if(UserId == null){
                return null;
            }
            return Users.FirstOrDefault(u => u.UserId == UserId);
        }

        public User GetUser(string email)
        {
            return Users.FirstOrDefault(u => u.email.Equals(email));
        }
    }
}