using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Abstract
{
    public interface IDbEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        int Id { get; set; }
    }
}
