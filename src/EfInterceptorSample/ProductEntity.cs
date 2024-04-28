// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace EfInterceptorSample;

public sealed class ProductEntity
{
  public required Guid ProductId { get; set; }

  public required string Name { get; set; }

  public string? Description { get; set; }

  public required ulong Price { get; set; }
}
