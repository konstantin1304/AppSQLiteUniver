using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbDepartments")]
    public class Department : AbstractDbEntity
    {
        //[StringLength(64)]
        public string Name { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
    }
}
