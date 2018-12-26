using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Abstract
{
    public interface IDbRepository<T>
        where T : class, IDbEntity, new()
    {

        void AddItemWithChildren(T item);

        void AddItem(T item);

        void AddItemsWithChildren(IEnumerable<T> items);
        IEnumerable<T> AllItems { get; }
        void ChangeItem(T item);

        void ChangeItemWithChildren(T item);
        void DeleteItem(T item);
        void DeleteItem(int id);
        T GetItem(int id);
        bool SaveChanges();
    }
}
