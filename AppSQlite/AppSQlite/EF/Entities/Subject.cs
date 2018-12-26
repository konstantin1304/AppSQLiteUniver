using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbSubjects")]
    public class Subject : AbstractDbEntity
    {
        //[StringLength(64)]
        public string Name { get; set; }
        public IList<TeachSubj> TeachSubj { get; set; }
    }
}
