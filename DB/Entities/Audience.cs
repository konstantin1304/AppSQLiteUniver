using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbAudiences")]
    public class Audience : AbstractDbEntity, IDbEntity
    {
        public string Name { get; set; }

        [OneToMany(CascadeOperations=CascadeOperation.All)]
        public List<AudLect> AudLects { get; set; }
    }
}
