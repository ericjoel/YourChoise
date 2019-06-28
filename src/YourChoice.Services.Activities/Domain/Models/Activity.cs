using System;
using YourChoice.Common.Exceptions;

namespace YourChoice.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; set; }

        protected Activity()
        {
        }

        public Activity(Guid id, Category category, Guid userId, string name, string description, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new YourChoiceException("empty_activity_name"
                    , $"Activity name can not be empty.");
            Id = id;
            Name = name.ToLowerInvariant();
            UserId = userId;
            Category = category.Name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}