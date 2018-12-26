using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbPhones")]
    public class Phone : AbstractDbEntity, IDbEntity
    {
        public string StudentsPhone { get; set; }

        [ForeignKey(typeof(Student))]
        public int StudId { get; set; }

        [ManyToOne]
        public Student Student { get; set; }
    }
}
