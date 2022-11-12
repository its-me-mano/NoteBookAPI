using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class ImageStore
    {
        [Key]
        public Guid FileId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength]
        public string File { get; set; }

    }
}
