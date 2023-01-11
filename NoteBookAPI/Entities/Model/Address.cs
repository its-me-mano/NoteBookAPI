using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace NoteBookAPI.Entities
{
    public class Address : BaseModelDto
    {
  

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        ///<summary>
        /// street name of the user  
        ///</summary>
        public string Line1 { get; set; }
        
        ///<summary>
        /// 2nd street  of the user 
        ///</summary>
        public string Line2 { get; set; }
        
        ///<summary>
        /// city  of the user 
        ///</summary>
        public string City { get; set; }

        ///<summary>
        /// state name of the user 
        ///</summary>
        public string StateName { get; set; }
        
        ///<summary>
        /// zipcode of the user 
        ///</summary>
        public string Zipcode { get; set; }
    
        [ForeignKey("Type")]
        public Guid Type { get; set; }

        ///<summary>
        /// country  of the user 
        ///</summary>
        [ForeignKey("Country")]
        public Guid Country { get; set; }



    }
}
