// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfInterceptorSample;

public sealed class SaveProductInterceptor : SaveChangesInterceptor
{
  public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
  {
    Console.WriteLine("Product saved");
    return result;
  }
}
