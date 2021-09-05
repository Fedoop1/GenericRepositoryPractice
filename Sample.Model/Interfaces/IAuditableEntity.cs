using System;

namespace Sample.Model
{
    public interface IAuditableEntity
    {
        public DateTime CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public string UpdatedBy { get; set; }
    }
}
