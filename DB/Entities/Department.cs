using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbDepartments")]
    public class Department : AbstractDbEntity, IDbEntity
    {
        public string Name { get; set; }

       [OneToMany(CascadeOperations = CascadeOperation.All)] 
        public List<Teacher> Teachers { get; set; }
    }
}
