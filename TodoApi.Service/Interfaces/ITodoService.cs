using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Domain;

namespace TodoApi.Service.Interfaces
{
    public interface ITodoService
    {
        bool DoesItemExist(Guid id);
        IEnumerable<ToDoItem> All();
        ToDoItem Find(Guid id);
        void Insert(ToDoItem item);
        void Updated(ToDoItem item);
        void Delete(Guid id);
    }
}
