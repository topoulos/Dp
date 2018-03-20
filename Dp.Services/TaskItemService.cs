using System.Collections.Generic;
using System.Threading.Tasks;
using Dp.Models.Database;
using Dp.Repository.DAL;

namespace Dp.Services
{
    public interface ITaskItemService
    {
        Task<int> CreateAsync(TaskItem taskItem);
        Task DeleteAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(int id);
        Task UpdateAsync(TaskItem taskItem);
    }

    public class TaskItemService : ITaskItemService
    {
        private readonly IRepository<TaskItem> _repository;

        public TaskItemService(IRepository<TaskItem> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(TaskItem taskItem)
        {
            return await _repository.CreateAsync(taskItem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _repository.GetNotDeletedAsync();
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            await _repository.UpdateAsync(taskItem);
        }
    }
}