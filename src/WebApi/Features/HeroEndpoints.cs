﻿using MediatR;
using SSW.CleanArchitecture.Application.Features.Heroes.Commands.CreateHero;
using SSW.CleanArchitecture.Application.Features.Heroes.Queries.GetAllHeroes;
using SSW.CleanArchitecture.WebApi.Extensions;

namespace SSW.CleanArchitecture.WebApi.Features;

public static class HeroEndpoints
{
    public static void MapHeroEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("heroes")
            .WithTags("Heroes")
            .WithOpenApi();

        // TODO: Investigate examples for swagger docs. i.e. better docs than:
        // myWeirdField: "string" vs myWeirdField: "this-silly-string"
        // (https://github.com/SSWConsulting/SSW.CleanArchitecture/issues/79)

        group
            .MapPost("/", async (ISender sender, CreateHeroCommand command, CancellationToken ct) =>
            {
                await sender.Send(command, ct);
                return Results.Created();
            })
            .WithName("CreateHero")
            .ProducesPost();
    }
}