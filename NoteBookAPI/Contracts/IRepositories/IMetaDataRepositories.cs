﻿    using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Contracts
{
    public interface IMetaDataRepositories
    {
        ///<summary>
        /// get the refset
        ///</summary>
        ///<param name="type"></param>
        RefTerm TypeFinder(string type);
        ///<summary>
        /// Guid list of RefSet
        ///</summary>
        ///<param name="id"></param>
        IEnumerable<Guid> GetRefTermGroup(Guid id);
        ///<summary>
        /// Return the List of RefSet
        ///</summary>
        ///<param name="items"></param>
        IEnumerable<RefTerm> GetRefTerm(IEnumerable<Guid> items);
        ///<summary>
        /// Get the RefTerm based on Refterm Name  
        ///</summary>
        ///<param name="name"></param>
        RefSet GetRefSet(string name);
        ///<summary>
        /// check the metadata     exist or not 
        ///</summary>
        ///<param name="type"></param>
        bool MetaExist(string type);
    }
}
