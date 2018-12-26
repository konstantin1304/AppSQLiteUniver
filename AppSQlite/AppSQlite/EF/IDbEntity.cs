using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.EF
{
    interface IDbEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        int Id { get; set; }
    }
}
