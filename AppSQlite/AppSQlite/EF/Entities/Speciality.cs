using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbSpeciality")]
    public class Speciality : AbstractDbEntity
    {
        //[StringLength(64)]
        public string Name { get; set; }
        public virtual List<Group> Groups { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
