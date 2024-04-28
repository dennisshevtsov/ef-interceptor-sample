// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text;

namespace EfInterceptorSample.Test;

[TestClass]
public sealed class EfInterceptorSampleDbContextTest
{
#pragma warning disable CS8618
  private StringBuilder _logger;
  private EfInterceptorSampleDbContext _context;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _logger  = new StringBuilder();
    _context = new EfInterceptorSampleDbContext(_logger);
    _context.Database.EnsureCreated();
  }

  [TestCleanup]
  public void Cleanup()
  {
    _context?.Database.EnsureDeleted();
    _context?.Dispose();
  }

  [TestMethod]
  public async Task SaveChangesAsync_ProductAdded_SavingLogged()
  {
    // Arrange
    _context.Add(new ProductEntity
    {
      ProductId   = Guid.NewGuid(),
      Name        = "Test Name 1",
      Description = "Test Description 1",
      Price       = 1000UL,
    });
    _context.Add(new ProductEntity
    {
      ProductId   = Guid.NewGuid(),
      Name        = "Test Name 2",
      Description = "Test Description 2",
      Price       = 2000UL,
    });

    // Act
    await _context.SaveChangesAsync();

    // Assert
    Assert.AreEqual("Product saved", _logger.ToString().Trim());
  }
}
