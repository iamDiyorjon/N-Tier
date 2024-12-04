using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Services;
using N_Tier.Core.Entities;

namespace N_Tier.API.Controllers;

[Authorize]
public class TodoListsController : ApiController
{
    private readonly ITodoItemService _todoItemService;
    private readonly ITodoListService _todoListService;

    public TodoListsController(ITodoListService todoListService, ITodoItemService todoItemService)
    {
        _todoListService = todoListService;
        _todoItemService = todoItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<TodoListResponseModel>>.Success(await _todoListService.GetAllAsync()));
    }

    //[HttpPost("all")]
    //public async Task<IActionResult> GetAll(Options options)
    //{
    //    var result = await _todoListService.GetAllAsync(options);

    //    return Ok(ApiResult<PagedResult<TodoList>>.Success(result));
    //}

    [HttpPost("all")]
    [Authorize]
    public async Task<IActionResult> GetAll(Options options)
    {
        var result = await _todoListService.GetAllDTOAsync(options);

        return Ok(ApiResult<PagedResult<TodoListResponseModel>>.Success(result));
    }

    [HttpPost("all/quer")]
    public async Task<IActionResult> GetAllQuery(Options options)
    {
        var result = await _todoListService.GetAllWithIQueryableAsync();

        return Ok(ApiResult<List<TodoList>>.Success(result));
    }

    [HttpPost("all/enum")]
    public ActionResult GetAllEnum(Options options)
    {
        var result = _todoListService.GetAllWithIEnumerable();

        return Ok(ApiResult<List<TodoList>>.Success(result));
    }

    [HttpGet("{id:guid}/todoItems")]
    public async Task<IActionResult> GetAllTodoItemsAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<TodoItemResponseModel>>.Success(
            await _todoItemService.GetAllByListIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTodoListModel createTodoListModel)
    {
        return Ok(ApiResult<CreateTodoListResponseModel>.Success(
            await _todoListService.CreateAsync(createTodoListModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel)
    {
        return Ok(ApiResult<UpdateTodoListResponseModel>.Success(
            await _todoListService.UpdateAsync(id, updateTodoListModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _todoListService.DeleteAsync(id)));
    }
}
