using N_Tier.Application.Models;
using N_Tier.Application.Models.TodoList;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface ITodoListService
{
    Task<CreateTodoListResponseModel> CreateAsync(CreateTodoListModel createTodoListModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<TodoListResponseModel>> GetAllAsync();
    Task<PagedResult<TodoList>> GetAllAsync(Options options);
    Task<PagedResult<TodoListResponseModel>> GetAllDTOAsync(Options options);
    Task<UpdateTodoListResponseModel> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel);
}
