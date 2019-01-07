using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbTeachSubj")]
    public class TeachSubj : AbstractDbEntity, IDbEntity
    {
        [ForeignKey(typeof(Teacher))]
        public int TeacherId { get; set; }

        [ForeignKey(typeof(Subject))]
        public int SubjId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Teacher Teacher { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Subject Subject { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Mark> Marks { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AudLect> AudLects { get; set; }
    }
}
