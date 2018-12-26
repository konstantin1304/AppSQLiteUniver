using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbMarks")]
    public class Mark : AbstractDbEntity, IDbEntity
    {
        public int StudentsMark { get; set; }

        [ForeignKey(typeof(Student))]
        public int StudId { get; set; }

        [ForeignKey(typeof(TeachSubj))]
        public int TeachSubjId { get; set; }

        [ManyToOne]
        public Student Student { get; set; }

        [ManyToOne]
        public TeachSubj TeachSubj { get; set; }

    }
}
