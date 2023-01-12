using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;


namespace NoteBookAPI.Entities
{
    [DataContract]
    public class Address : BaseModel
    {
        [DataMember(Name="user_id")]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        ///<summary>
        /// street name of the user  
        ///</summary>
        [DataMember(Name = "line1")]
        public string Line1 { get; set; }
        ///<summary>
        /// 2nd street  of the user 
        ///</summary>
        [DataMember(Name = "line2")]
        public string Line2 { get; set; }
        ///<summary>
        /// city  of the user 
        ///</summary>
        [DataMember(Name="city")]
        public string City { get; set; }
        ///<summary>
        /// state name of the user 
        ///</summary>
        [DataMember(Name = "state_name")]
        public string StateName { get; set; }
        ///<summary>
        /// zipcode of the user 
        ///</summary>
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }  
        [ForeignKey("Type")]
        [DataMember(Name = "type")]
        public Guid Type { get; set; }
        [ForeignKey("Country")]
        ///<summary>
        ///Country
        ///</summary>
        [DataMember(Name="country")]
        public Guid Country { get; set; }



    }
}
