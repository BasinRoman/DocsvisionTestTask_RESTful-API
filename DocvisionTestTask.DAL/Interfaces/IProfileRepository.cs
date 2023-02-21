using DocvisionTestTask.Domain.Entity;

namespace DocvisionTestTask.DAL.Interfaces
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        // тут нету ни одной подписки, т.к. наше приложение в данный момент этого не требует
        // однако, я считаю верным заложить в фундамент потенциал к расширению функционала api
    }
}
