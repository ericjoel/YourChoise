using System;

namespace YourChoice.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; set; }

        protected Activity()
        {
        }

        public Activity(string name, Category category, string description, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
            Category = category.Name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}