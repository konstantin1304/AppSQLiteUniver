using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbPhones")]
    public class Phone : AbstractDbEntity
    {
        //[StringLength(64)]
        public string StudentsPhone { get; set; }
        public virtual Student Student { get; set; }
    }
}
