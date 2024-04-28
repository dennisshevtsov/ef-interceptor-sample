// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text;

namespace EfInterceptorSample;

public sealed class SaveProductInterceptor(StringBuilder logger) : SaveChangesInterceptor
{
  private readonly StringBuilder _logger = logger ?? throw new ArgumentNullException(nameof(logger));

  public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
  {
    _logger.AppendLine("Product saved");
    return base.SavingChangesAsync(eventData, result, cancellationToken);
  }
}
