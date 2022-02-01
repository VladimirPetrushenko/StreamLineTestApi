namespace StreamLineTestApi.Middlewares
{
    public class HTTPpipeline : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Cookies[".AspNetCore.Application.Id"];
            if (!string.IsNullOrEmpty(token))
                context.Request.Headers.Add("Authorization", "Bearer " + token);

            await next(context);
        }
    }
}
