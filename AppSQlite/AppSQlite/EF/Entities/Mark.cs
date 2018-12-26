using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF.Entities
{
    [Table("tbMarks")]
    public class Mark : AbstractDbEntity
    {
        //[Range(0, 100)]
        public int StudentsMark { get; set; }
        public virtual Student Student { get; set; }
        public virtual TeachSubj TeachSubj { get; set; }

    }
}
