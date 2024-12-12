using Microsoft.EntityFrameworkCore;
using MS_API.Data;
using MS_API.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace MS_API.Controllers;

public static class MsCervezaEndpoints
{
    public static void MapMsCervezaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/MsCerveza").WithTags(nameof(MsCerveza));

        group.MapGet("/", async (MateoSantosExam1PdbContext db) =>
        {
            return await db.MsCervezas.ToListAsync();
        })
        .WithName("GetAllMsCervezas")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<MsCerveza>, NotFound>> (int mscervezaid, MateoSantosExam1PdbContext db) =>
        {
            return await db.MsCervezas.AsNoTracking()
                .FirstOrDefaultAsync(model => model.MsCervezaId == mscervezaid)
                is MsCerveza model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMsCervezaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int mscervezaid, MsCerveza msCerveza, MateoSantosExam1PdbContext db) =>
        {
            var affected = await db.MsCervezas
                .Where(model => model.MsCervezaId == mscervezaid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.MsCervezaId, msCerveza.MsCervezaId)
                    .SetProperty(m => m.MsCervezaName, msCerveza.MsCervezaName)
                    .SetProperty(m => m.MsCervezaDescription, msCerveza.MsCervezaDescription)
                    .SetProperty(m => m.MsEscarchada, msCerveza.MsEscarchada)
                    .SetProperty(m => m.MsPrice, msCerveza.MsPrice)
                    .SetProperty(m => m.MsDate, msCerveza.MsDate)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMsCerveza")
        .WithOpenApi();

        group.MapPost("/", async (MsCerveza msCerveza, MateoSantosExam1PdbContext db) =>
        {
            db.MsCervezas.Add(msCerveza);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/MsCerveza/{msCerveza.MsCervezaId}",msCerveza);
        })
        .WithName("CreateMsCerveza")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int mscervezaid, MateoSantosExam1PdbContext db) =>
        {
            var affected = await db.MsCervezas
                .Where(model => model.MsCervezaId == mscervezaid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMsCerveza")
        .WithOpenApi();
    }
}
