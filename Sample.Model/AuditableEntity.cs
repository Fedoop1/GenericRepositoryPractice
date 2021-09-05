using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedTime { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
    }
}
