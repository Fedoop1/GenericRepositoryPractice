using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Model
{
    [Table("Country")]
    public class Country : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("Country Name")]
        public string Name { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
