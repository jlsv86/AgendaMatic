using AgendaMatic.WebApi.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaMatic.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected async Task<DefaultResponse<T>> Handle<T>(Func<Task<object>> func)
        {
            try
            {
                var data = await func.Invoke();

                return new DefaultResponse<T>()
                {
                    Data = (T)data,
                    Success = true,
                    Errors = null
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
