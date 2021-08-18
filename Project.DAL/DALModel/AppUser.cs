using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.DALModel
{
   
    public class AppUser : IdentityUser, IEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
