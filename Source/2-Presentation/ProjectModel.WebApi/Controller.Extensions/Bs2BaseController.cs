using Microsoft.AspNetCore.Mvc;

namespace ProjectModel.WebApi.Controllers
{
    public static class Bs2BaseController
    {
        private const string tagName = "x-bs2-correlation-id";

        public static string Cid(this ControllerBase controller)
        {
            // if (!controller.Request.Headers.ContainsKey(tagName))
            //     return null;

            // return controller.Request.Headers[tagName];
            return "123456";
        }
    }
}