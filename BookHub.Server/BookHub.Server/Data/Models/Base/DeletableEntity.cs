﻿namespace BookHub.Server.Data.Models.Base
{
    public abstract class DeletableEntity : Entity, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }
    }
}