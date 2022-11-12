using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class AssetDto
    {
        [Key]
        public Guid AssetId { get; set; }
        [ForeignKey("fieldId")]
        public Guid fieldId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
    }
}
