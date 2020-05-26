using System;

namespace TodoApi.Domain
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
