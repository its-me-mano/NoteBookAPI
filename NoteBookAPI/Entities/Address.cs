    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    
        [ForeignKey("Type")]
        public Guid Type { get; set; }

        [ForeignKey("Country")]
        public Guid Country { get; set; }



        //public Guid TypeId;

    }
}
