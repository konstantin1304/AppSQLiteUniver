using DB.Abstract;
using DB.Entities;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DB.Common
{
    public class GenericRepository<T> : IDbRepository<T> where T : class, IDbEntity,new()
    {

        SQLiteConnection database;

        public GenericRepository(SQLiteConnection database)
        {
            this.database = database;
            database.CreateTable<T>();
        }

        public IEnumerable<T> AllItems
        {
            get
            {
                //return database.Table<T>()
                return database.GetAllWithChildren<T>(null, false);
            }
        }

        public void AddItem(T item)
        {
            database.Insert(item);
            //database.InsertOrReplace(item);
        }

        public void AddItemWithChildren(T item)
        {
            database.InsertOrReplaceWithChildren(item,true);
        }

        public void AddItemsWithChildren(IEnumerable<T> items)
        {
            database.InsertOrReplaceAllWithChildren(items, false);
        }

        public void AddItemsWithChildrenCascade(IEnumerable<T> items)
        {
            database.InsertOrReplaceAllWithChildren(items, true);
        }

        public void ChangeItem(T item)
        {
            database.InsertOrReplace(item);
        }

        public void ChangeItemWithChildren(T item)
        {
            database.InsertOrReplaceWithChildren(item, false);
        }

        public void DeleteItem(T item)
        {
            database.Delete<T>(item.Id);
        }

        public void DeleteItem(int id)
        {
            database.Delete<T>(id);
        }

        public T GetItem(int id)
        {
            return database.GetWithChildren<T>(id,false);
        }

        public bool SaveChanges()
        {
            try
            {
                return true;
            }
#pragma warning disable CS0168
            catch (Exception e)
#pragma warning restore CS0168
            {
                return false;
            }
        }
    }
}
