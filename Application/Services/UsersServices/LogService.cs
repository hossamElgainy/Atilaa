using Core.Dtos.Logs;
using Core.Interfaces.IServices.UsersIServices;
using Core.Interfaces.Specifications;
using Domain.DomaimModels;
using Infrastructure.Data.Specifications;

namespace Application.Services.UsersServices
{
    public class LogService(IUnitOfWork unitOfWork) : ILogService
    {
        public async Task<LogDetailDto> GetByIdAsync(int id)
        {
            var log = await unitOfWork.Repository<LogModel>().GetByIdAsync(id);
            if (log == null)
                throw new KeyNotFoundException("Log not found");

            return new LogDetailDto
            {
                Id = log.Id,
                Message = log.Message,
                exception = log.Exception,
                Level = log.Level,
                Timestamp = log.TimeStamp,
                Solved = log.Solved
            };
        }

        public async Task<PagedResult<LogDto>> GetAllAsync(LogFilterDto filter, int pageNumber = 1, int pageSize = 10)
        {
            var spec = new GetAllLogsSpec(filter, pageNumber, pageSize);
            var items = await unitOfWork.Repository<LogModel>().GetAllWithSpecAsync(spec);
            var count = await unitOfWork.Repository<LogModel>().CountAsync(new GetAllLogsSpec(filter, 0, 0));

            return new PagedResult<LogDto>(
                items.Select(l => new LogDto
                {
                    Id = l.Id,
                    Message = l.Message,
                    Exception = l.Exception,
                    Level = l.Level,
                    Timestamp = l.TimeStamp,
                    Solved = l.Solved
                }).ToList(),
                count,
                pageNumber,
                pageSize);
        }

        public async Task<bool> MarkAsSolvedAsync(int id)
        {
            var log = await unitOfWork.Repository<LogModel>().GetByIdAsync(id);
            if (log == null)
                return false;
            log.Solved = true;
            await unitOfWork.Complete();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var log = await unitOfWork.Repository<LogModel>().GetByIdAsync(id);
            if (log == null)
                return false;
            unitOfWork.Repository<LogModel>().Delete(log);
            await unitOfWork.Complete();
            return true;
        }

        public async Task<int> CleanOldLogsAsync(int daysToKeep)
        {
            var cutoff = DateTime.UtcNow.AddDays(-daysToKeep);
            var old = await unitOfWork.Repository<LogModel>().GetAllByProAsync(l => l.TimeStamp < cutoff);
            unitOfWork.Repository<LogModel>().DeleteRange(old);
            await unitOfWork.Complete();
            return old.Count;
        }

        public async Task<int> CountAsync(LogFilterDto? filter = null)
        {
            filter ??= new LogFilterDto();
            return await unitOfWork.Repository<LogModel>().CountAsync(new GetAllLogsSpec(filter, 0, 0));
        }
    }
}
