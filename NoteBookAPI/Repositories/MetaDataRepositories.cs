using NoteBookAPI.Contracts;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteBookAPI.Repositories
{
    public class MetaDataRepositories : IMetaDataRepositories
    {
        private readonly UserDetailsContext _context;
        public MetaDataRepositories(UserDetailsContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        ///<summary>
        /// get the refset
        ///</summary>
        ///<param name="type"></param>
        public RefTerm TypeFinder(string type)
        {
            return _context.RefTerms.FirstOrDefault(b => b.Key == type);
        }
        ///<summary>
        /// Guid list of RefSet
        ///</summary>
        ///<param name="id"></param>
        public bool metaExist(string type)
        {
            return _context.RefTerms.Any(a => a.Key == type);
        }
        ///<summary>
        /// Return the List of RefSet
        ///</summary>
        ///<param name="items"></param>
        public IEnumerable<Guid> getRefTermGroup(Guid id)
        {
            List<Guid> Group = new List<Guid>();
            foreach (SetRefTerm item in _context.SetRefTerms)
            {
                if (item.RefSetid.Equals(id))
                {
                    Group.Add(item.ReftermId);
                }
            }
            return Group;
        }
        ///<summary>
        /// Get the RefTerm based on Refterm Name  
        ///</summary>
        ///<param name="name"></param>
        public IEnumerable<RefTerm> getRefTerm(IEnumerable<Guid> items)
        {
            return _context.RefTerms.Where(a => items.Contains(a.Id));
        }
        ///<summary>
        /// check the metadata exist or not 
        ///</summary>
        ///<param name="type"></param>
        public RefSet getRefSet(string name)
        {
            return (_context.RefSets.FirstOrDefault(a => a.Key == name));
        }
    }
}
