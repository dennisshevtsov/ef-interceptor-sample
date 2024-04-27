// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfInterceptorSample;

public sealed class EfInterceptorSampleDbContext : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ef-interceptor-db;Username=dev;Password=dev");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    EntityTypeBuilder<ProductEntity> entityTypeBuilder = modelBuilder.Entity<ProductEntity>();
    entityTypeBuilder.HasKey(entity => entity.ProductId);
    entityTypeBuilder.ToTable("product");

    entityTypeBuilder.Property(entity => entity.ProductId  ).IsRequired(true ).HasColumnName("product_id" );
    entityTypeBuilder.Property(entity => entity.Name       ).IsRequired(true ).HasColumnName("name"       );
    entityTypeBuilder.Property(entity => entity.Description).IsRequired(false).HasColumnName("description");
    entityTypeBuilder.Property(entity => entity.Price      ).IsRequired(true ).HasColumnName("price"      );
  }
}
