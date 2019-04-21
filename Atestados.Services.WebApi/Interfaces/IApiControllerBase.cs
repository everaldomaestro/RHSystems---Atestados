using System.Net.Http;

namespace Atestados.Services.WebApi.Interfaces
{
    public interface IApiControllerBase<Entity> where Entity : class
    {
        HttpResponseMessage Get();

        HttpResponseMessage Get(int id);

        HttpResponseMessage Post(Entity entity);

        HttpResponseMessage Put(Entity entity);

        HttpResponseMessage Delete(Entity entity);
    }
}
