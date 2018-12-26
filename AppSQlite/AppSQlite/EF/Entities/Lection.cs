using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbLections")]
    public class Lection : AbstractDbEntity
    {
        //[Column(TypeName = "datetime")]
        public DateTime Start { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime Finish { get; set; }
        public DayOfWeek Day { get; set; }
        public List<AudLect> AudLects { get; set; }
    }
}
