using Project.ENTITIES.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ENTITIES.CoreInterfaces
{
    //IEntity BaseEntity'me miras vericek. 
    public interface IEntity
    {
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }


    }
}
