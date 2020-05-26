using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApi.Data.Context;
using TodoApi.Domain;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Data
{
   public class TodoRepository : ITodoRepository
    {
        
        private readonly TodoContext _context = new TodoContext(new Microsoft.EntityFrameworkCore.DbContextOptions<TodoContext>());

        public IEnumerable<ToDoItem> All()
        {
            return _context.TodoItems.ToList();
        }

        public void Delete(Guid id)
        {
            var obj = new ToDoItem { Id = id };
            _context.Remove(obj);
            Save();
        }

        public bool DoesItemExist(Guid id)
        {
            var obj = new ToDoItem { Id = id };

            return _context.TodoItems.Contains(obj);
        }

        public ToDoItem Find(Guid id)
        {
            return _context.TodoItems.Find(id);
        }

        public void Insert(ToDoItem item)
        {
            item.Id = Guid.NewGuid();

            _context.TodoItems.Add(item);
            Save();
        }

        public void Updated(ToDoItem item)
        {
            _context.TodoItems.Update(item);
            Save();
        }

        private void Save() => _context.SaveChanges();

    }
}
