using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Core.EntityBase
{
    public abstract class EntityBase :IEntityBase
    {
        public EntityBase()
        {
            CreatedBy = "Undifined";
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; set; }= Guid.NewGuid();
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
