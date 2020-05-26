using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Domain;

namespace TodoApi.Data.Mappings
{
    public class TodoMap : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {

            
            builder.Property(t => t.Id)
                .HasColumnName("Id");

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Notes)
                .HasMaxLength(250);

            builder.Property(t => t.Done)
                .HasDefaultValue(false);
                
          
        }
    }
}
