using NoteBookAPI.Contracts;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public RefSet TypeFinder(string type)
        {
            return _context.RefSets.FirstOrDefault(b => b.Key == type);
        }
        ///<summary>
        /// Guid list of RefSet
        ///</summary>
        ///<param name="id"></param>
        public bool metaExist(string type)
        {
            return _context.RefSets.Any(a => a.Key == type);
        }
        ///<summary>
        /// Return the List of RefSet
        ///</summary>
        ///<param name="items"></param>
        public IEnumerable<Guid> getRefSetGroup(Guid id)
        {
            List<Guid> Group = new List<Guid>();
            foreach (SetRefTerm item in _context.SetRefTerms)
            {
                if (item.ReftermId.Equals(id))
                {

                    Group.Add(item.RefSetid);
                }
            }
            return Group;
        }
        ///<summary>
        /// Get the RefTerm based on Refterm Name  
        ///</summary>
        ///<param name="name"></param>
        public IEnumerable<RefSet> getRefSet(IEnumerable<Guid> items)
        {

            return _context.RefSets.Where(a => items.Contains(a.Id));
        }
        ///<summary>
        /// check the metadata exist or not 
        ///</summary>
        ///<param name="type"></param>
        public RefTerm getRefTerm(string name)
        {
            return (_context.RetTerms.FirstOrDefault(a => a.Key == name));
        }
    }
}
