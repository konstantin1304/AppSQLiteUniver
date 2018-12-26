using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbAudLect")]
    public class AudLect : AbstractDbEntity
    {
        public int AudId { get; set; }
        public int LectId { get; set; }
        public int GroupId { get; set; }
        public Audience Audience { get; set; }
        public Lection Lection { get; set; }
        public Group Group { get; set; }
        public virtual TeachSubj TeachSubj { get; set; }
    }
}
