using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbAudLect")]
    public class AudLect : AbstractDbEntity, IDbEntity
    {
        [ForeignKey(typeof(Audience))]
        public int AudId { get; set; }

        [ForeignKey(typeof(Lection))]
        public int LectId { get; set; }

        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }

        [ForeignKey(typeof(TeachSubj))]
        public int TeachSubjId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Audience Audience { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Lection Lection { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Group Group { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public TeachSubj TeachSubj { get; set; }
    }
}
