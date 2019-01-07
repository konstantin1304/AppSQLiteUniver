using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbSpeciality")]
    public class Speciality : AbstractDbEntity, IDbEntity
    {
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Group> Groups { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
