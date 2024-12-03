﻿namespace BookHub.Server.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using Seed;

    public class ReadingListConfiguration : IEntityTypeConfiguration<ReadingList>
    {
        public void Configure(EntityTypeBuilder<ReadingList> builder)
            => builder.HasData(ReadingListSeeder.Seed());
    }
}