using BookStore.Services;

namespace BookStore.Configs
{
    public static class ServiceConfiguration
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<AuthorService>();
            services.AddScoped<BookService>();
            services.AddScoped<ReportService>();

        }
    }
}
