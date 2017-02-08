using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishedoAPI.Models
{
    public class UserContext : DbContext
    {
		public DbSet<User> Users {get;set;}
		public UserContext (DbContextOptions<UsersContext> options)
			:base (options)
		{ }
    }
}
