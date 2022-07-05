using System;
namespace CleanArchitecture.Core.Entities
{
    public class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
            this.Active = true;
            this.UpdatedAt = null;
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public void Activate()
        {
            this.Active = true;
        }

        public void Inactivate()
        {
            this.Active = false;
        }
    }
}

