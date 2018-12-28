using DB.Abstract;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    [Table("tbGroups")]
    public class Group : AbstractDbEntity, IDbEntity
    {

        public string Name { get; set; }

        [ForeignKey(typeof(Speciality))]
        public int SpecialityID { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Speciality Speciality { get; set; }

       [OneToMany(CascadeOperations = CascadeOperation.All)] 
        public List<Student> Students { get; set; }
       [OneToMany(CascadeOperations = CascadeOperation.All)] 
        public List<AudLect> AudLects { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
