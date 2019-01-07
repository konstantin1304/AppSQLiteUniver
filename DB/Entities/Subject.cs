using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbSubjects")]
    public class Subject : AbstractDbEntity, IDbEntity
    {
        public string Name { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TeachSubj> TeachSubj { get; set; }
    }
}
