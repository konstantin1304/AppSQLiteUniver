using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbLections")]
    public class Lection : AbstractDbEntity, IDbEntity
    {
        //[Column(TypeName = "datetime")]
        public DateTime Start { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime Finish { get; set; }
        public DayOfWeek Day { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AudLect> AudLects { get; set; }
    }
}
