using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoServer.Web.Context;
using TodoServer.Web.Services;
using TodoServer.Web.UseCases;
using TodoServer.Web.Utils;

namespace Web
{
  public class Startup
  {
    public IConfiguration configuration { get; }

    public Startup(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) 
    {
      // Controllers
      services.AddControllers();
      // DbContext
      services
        .AddEntityFrameworkNpgsql()
        .AddDbContext<AppDbContext>(options => 
          options.UseNpgsql(this.configuration["ConnectionString:PostgreSQL:TodosServer"]));
      services.AddTransient<AppDbContext>();
      // CORS
      services.AddCors(options => 
        options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000")));
      // UseCases
      services.AddTransient<CreateUserUseCase>();
      services.AddTransient<FindAllUsersUseCase>();
      services.AddTransient<LoginUserUseCase>();
      // Services
      services.AddTransient<FindUserByEmailService>();
      services.AddTransient<HashPasswordService>();
      services.AddTransient<CreateUserService>();
      services.AddTransient<FindAllUsersService>();
      services.AddTransient<IsPasswordMatchService>();
      services.AddTransient<GetSignInTokenService>();
      // Utils
      services.AddTransient<TextFormatter>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseCors();
      app.UseRouting();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
