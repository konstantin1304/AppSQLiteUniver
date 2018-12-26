using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbTeachSubj")]
    public class TeachSubj : AbstractDbEntity
    {
        public int TeacherId { get; set; }
        public int SubjId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public virtual List<Mark> Marks { get; set; }
        public virtual List<AudLect> AudLects { get; set; }
    }
}
