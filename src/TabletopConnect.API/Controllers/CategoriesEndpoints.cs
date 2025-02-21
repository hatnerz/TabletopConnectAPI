using Microsoft.AspNetCore.Mvc;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.API.Controllers;

public static class CategoriesEndpoints
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/categories");

        group.MapGet("/", GetAllCategories)
             .WithName(nameof(GetAllCategories))
             .Produces<List<Category>>(StatusCodes.Status200OK);

        /*group.MapGet("/{id:int}", GetCategoryById)
             .WithName("GetCategoryById")
             .Produces<Category>(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);*/

        /*group.MapPost("/", CreateCategory)
             .WithName("CreateCategory")
             .Accepts<CategoryCreateDto>("application/json")
             .Produces<Category>(StatusCodes.Status201Created)
             .Produces<ValidationResult>(StatusCodes.Status400BadRequest);*/

    }

    private static async Task<IResult> GetAllCategories(
        [FromServices]ICategoriesService categoryService)
    {
        var categories = await categoryService.GetAllAsync();
        return Results.Ok(categories);
    }

    /*private static async Task<IResult> GetCategoryById(int id, ICategoryService categoryService)
    {
        var category = await categoryService.GetByIdAsync(id);
        return category is not null ? Results.Ok(category) : Results.NotFound();
    }

    private static async Task<IResult> CreateCategory(CategoryCreateDto dto, ICategoryService categoryService, HttpContext httpContext)
    {
        var result = await categoryService.CreateAsync(dto.Name);
        return result.IsValid
            ? Results.CreatedAtRoute("GetCategoryById", new { id = categoryService.LastCreatedId }, categoryService.GetByIdAsync(categoryService.LastCreatedId).Result)
            : Results.BadRequest(result.Errors);
    }*/
}