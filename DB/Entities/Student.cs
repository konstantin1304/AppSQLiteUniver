using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbStudents")]
    public class Student : AbstractDbEntity, IDbEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int LogbookNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Phone> Phones { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Mark> Marks { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Group Group { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} {Group} {LogbookNumber}";
        }
    }
}
