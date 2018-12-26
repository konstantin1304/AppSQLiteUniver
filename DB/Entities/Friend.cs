using System;
using System.Diagnostics;
using DB.Abstract;
using SQLite;

namespace DB.Entities
{
    [Table("Friends")]
    public class Friend:AbstractDbEntity,IDbEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}