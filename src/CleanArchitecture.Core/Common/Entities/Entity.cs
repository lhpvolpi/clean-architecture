using System;

namespace CleanArchitecture.Core.Common.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Active { get; set; } = true;

        public DateTime? UpdatedAt { get; set; } = null;

        public abstract void Activate();

        public abstract void Inactivate();
    }
}

