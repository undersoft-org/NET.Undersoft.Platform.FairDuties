using System.Collections.Generic;
using Undersoft.IDP.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace Undersoft.IDP.Admin.EntityFramework.Configuration.Configuration
{
	public class IdentityData
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}
