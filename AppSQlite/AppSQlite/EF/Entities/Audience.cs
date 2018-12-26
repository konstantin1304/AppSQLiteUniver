using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbAudiences")]
    public class Audience : AbstractDbEntity
    {
        //[StringLength(32)]
        public string Name { get; set; }
        public List<AudLect> AudLects { get; set; }
    }
}
