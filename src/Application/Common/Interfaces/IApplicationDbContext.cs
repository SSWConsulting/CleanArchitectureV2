﻿using Microsoft.EntityFrameworkCore;
using SSW.CleanArchitecture.Domain.Entities;

namespace SSW.CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}