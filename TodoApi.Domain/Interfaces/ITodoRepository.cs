using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Domain.Interfaces
{
   public interface ITodoRepository
    {
        bool DoesItemExist(Guid id);
        IEnumerable<ToDoItem> All();
        ToDoItem Find(Guid id);
        void Insert(ToDoItem item);
        void Updated(ToDoItem item);
        void Delete(Guid id);

    }
}
