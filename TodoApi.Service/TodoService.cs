using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Domain;
using TodoApi.Domain.Interfaces;
using TodoApi.Service.Interfaces;

namespace TodoApi.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IEnumerable<ToDoItem> All()
        {
            return _todoRepository.All();
        }

        public void Delete(Guid id)
        {
            _todoRepository.Delete(id);
        }

        public bool DoesItemExist(Guid id)
        {
            return _todoRepository.DoesItemExist(id);
        }

        public ToDoItem Find(Guid id)
        {
            return _todoRepository.Find(id);
        }

        public void Insert(ToDoItem item)
        {
            _todoRepository.Insert(item);
        }

        public void Updated(ToDoItem item)
        {
            _todoRepository.Updated(item);
        }
    }
}
