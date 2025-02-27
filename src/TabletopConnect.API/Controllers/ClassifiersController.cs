using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TabletopConnect.API.Controllers.Dtos.Classifiers;
using TabletopConnect.API.Controllers.Dtos.Common;
using TabletopConnect.Application.Services.Interfaces;

namespace TabletopConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassifiersController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;
    private readonly IDesignersService _designersService;
    private readonly IFamiliesService _familiesService;
    private readonly IMechanicsService _mechanicsService;
    private readonly IPublishersService _publishersService;
    private readonly ISubcategoriesService _subcategoriesService;
    private readonly IThemesService _themesService;
    private readonly IMapper _mapper;

    public ClassifiersController(
        ICategoriesService categoriesService,
        IDesignersService designersService,
        IFamiliesService familiesService,
        IMechanicsService mechanicsService,
        IPublishersService publishersService,
        ISubcategoriesService subcategoriesService,
        IThemesService themesService,
        IMapper mapper)
    {
        _categoriesService = categoriesService;
        _designersService = designersService;
        _familiesService = familiesService;
        _mechanicsService = mechanicsService;
        _publishersService = publishersService;
        _subcategoriesService = subcategoriesService;
        _themesService = themesService;
        _mapper = mapper;
    }


    // Categories
    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories(CancellationToken cancellation)
    {
        var entities = await _categoriesService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("categories")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _categoriesService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("categories/{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody]UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _categoriesService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("categories/{id}")]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellation)
    {
        var result = await _categoriesService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }


    // Designers
    [HttpGet("designers")]
    public async Task<IActionResult> GetDesigners(CancellationToken cancellation)
    {
        var entities = await _designersService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("designers")]
    public async Task<IActionResult> CreateDesigner([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _designersService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("designers/{id}")]
    public async Task<IActionResult> UpdateDesigner(int id, [FromBody] UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _designersService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("designers/{id}")]
    public async Task<IActionResult> DeleteDesigner(int id, CancellationToken cancellation)
    {
        var result = await _designersService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }


    // Families
    [HttpGet("families")]
    public async Task<IActionResult> GetFamilies(CancellationToken cancellation)
    {
        var entities = await _familiesService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("families")]
    public async Task<IActionResult> CreateFamily([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _familiesService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("families/{id}")]
    public async Task<IActionResult> UpdateFamily(int id, [FromBody] UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _familiesService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("families/{id}")]
    public async Task<IActionResult> DeleteFamily(int id, CancellationToken cancellation)
    {
        var result = await _familiesService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }


    // Mechanics
    [HttpGet("mechanics")]
    public async Task<IActionResult> GetMechanics(CancellationToken cancellation)
    {
        var entities = await _mechanicsService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("mechanics")]
    public async Task<IActionResult> CreateMechanics([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _mechanicsService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("mechanics/{id}")]
    public async Task<IActionResult> UpdateMechanics(int id, [FromBody] UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _mechanicsService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("mechanics/{id}")]
    public async Task<IActionResult> DeleteMechanics(int id, CancellationToken cancellation)
    {
        var result = await _mechanicsService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }


    // Publishers
    [HttpGet("publishers")]
    public async Task<IActionResult> GetPublishers(CancellationToken cancellation)
    {
        var entities = await _publishersService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("publishers")]
    public async Task<IActionResult> CreatePublisher([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _publishersService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("publishers/{id}")]
    public async Task<IActionResult> UpdatePublisher(int id, [FromBody] UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _publishersService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("publishers/{id}")]
    public async Task<IActionResult> DeletePublisher(int id, CancellationToken cancellation)
    {
        var result = await _publishersService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }


    // Subcategories
    [HttpGet("subcategories")]
    public async Task<IActionResult> GetSubcategories(CancellationToken cancellation)
    {
        var entities = await _subcategoriesService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("subcategories")]
    public async Task<IActionResult> CreateSubcategory([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _subcategoriesService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("subcategories/{id}")]
    public async Task<IActionResult> UpdateSubcategory(int id, [FromBody] UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _subcategoriesService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("subcategories/{id}")]
    public async Task<IActionResult> DeleteSubcategory(int id, CancellationToken cancellation)
    {
        var result = await _subcategoriesService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }


    // Themes
    [HttpGet("themes")]
    public async Task<IActionResult> GetThemes(CancellationToken cancellation)
    {
        var entities = await _themesService.GetAllAsync(cancellation);
        return Ok(_mapper.Map<List<ClassifierItemResponse>>(entities));
    }

    [HttpPost("themes")]
    public async Task<IActionResult> CreateTheme([FromBody] CreateClassifierRequest request, CancellationToken cancellation)
    {
        var (result, id) = await _themesService.CreateAsync(request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok(new CreatedResponse(id));
    }

    [HttpPut("themes/{id}")]
    public async Task<IActionResult> UpdateTheme(int id, [FromBody] UpdateClassifierRequest request, CancellationToken cancellation)
    {
        if (request.Id != id)
            return BadRequest();

        var result = await _themesService.UpdateAsync(request.Id, request.Name, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }

    [HttpDelete("themes/{id}")]
    public async Task<IActionResult> DeleteTheme(int id, CancellationToken cancellation)
    {
        var result = await _themesService.DeleteAsync(id, cancellation);
        if (!result.Success)
            return BadRequest(new ValidationErrorResponse(result.Errors));

        return Ok();
    }
}
