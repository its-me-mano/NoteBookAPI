using NoteBookAPI.Contracts;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Entities;
using System;
using System.Linq;
namespace NoteBookAPI.Repositories
{
    public class FileRepositories : IFileRepositories
    {
        private readonly UserDetailsContext _context;
        public FileRepositories(UserDetailsContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        ///<summary>
        /// get the image
        ///</summary>
        ///<param name="id"></param>
        public Asset GetImage(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Asset img = _context.Assets.FirstOrDefault(b => b.Id == id);
            if (img == null)
            {
                throw new ArgumentNullException(nameof(img));
            }
            return img;
        }
        ///<summary>
        /// save the file  
        ///</summary>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        ///<summary>
        /// upload the image  
        ///</summary>
        ///<param name="img"></param>
        public void uploadImage(Asset img)
        {
            if (img == null)
            {
                throw new ArgumentNullException(nameof(img));
            }
            _context.Assets.Add(img);
        }

    }
}
