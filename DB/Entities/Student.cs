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
        //[StringLength(64)]
        public string FirstName { get; set; }
        //[StringLength(64)]
        public string MiddleName { get; set; }
        //[StringLength(64)]
        public string LastName { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime Birthday { get; set; }
        public int LogbookNumber { get; set; }
        //[StringLength(64)]
        public string Email { get; set; }
        //[StringLength(128)]
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
