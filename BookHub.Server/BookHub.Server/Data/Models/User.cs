﻿namespace BookHub.Server.Data.Models
{
    using BookHub.Server.Data.Models.Base;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public bool IsDeleted { get; set;  }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }

        public IEnumerable<Book> Books { get; } = new List<Book>();
    }
}
