using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class ApplicationServices
    {
        public static string GetError(this Exception ex)
        {
            return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
        }
    }
}
