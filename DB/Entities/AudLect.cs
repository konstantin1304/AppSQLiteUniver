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

        [ManyToOne]
        public Audience Audience { get; set; }

        [ManyToOne]
        public Lection Lection { get; set; }

        [ManyToOne]
        public Group Group { get; set; }

        [ManyToOne]
        public TeachSubj TeachSubj { get; set; }
    }
}
