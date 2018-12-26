﻿using AppSQlite.EF;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite
{
    public class AbstractDbEntity : IDbEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}
