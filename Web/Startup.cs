using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoServer.Web.Services;
using TodoServer.Web.UseCases;
using TodoServer.Web.Utils;
using TodoServer.Web.Middlewares;
using TodoServer.Web.Context;
using Microsoft.EntityFrameworkCore;

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
      services.AddControllers();
      AddUseCases(services);
      AddServices(services);
      // DbContext
      services
        .AddEntityFrameworkNpgsql()
        .AddDbContext<AppDbContext>(options => 
          options.UseNpgsql(this.configuration["ConnectionString:PostgreSQL:TodosServer"]));
      // CORS
      services.AddCors();
      // Utils
      services.AddTransient<TextFormatter>();
      // Middlewares
      services.AddTransient<FactoryActivatedMiddleware>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      // CORS
      app.UseCors(builder => 
          builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
      app.UseAuthenticationTokenVerifierMiddleware();
      // Using IMiddleware (MiddlewareFactory) so that not singleton services can be used
      app.UseFactoryAcitivatedMiddleware();
      app.UseRouting();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    private void AddUseCases(IServiceCollection services)
    {
      // Users
      services.AddTransient<CreateUserUseCase>();
      services.AddTransient<FindAllUsersUseCase>();
      services.AddTransient<LoginUserUseCase>();
      services.AddTransient<AuthenticateUserUseCase>();
      // Auth
      services.AddTransient<AuthenticationTokenVerifierUseCase>();
      // Tasks
      services.AddTransient<CreateTaskUseCase>();
      services.AddTransient<DeleteTaskUseCase>();
      services.AddTransient<FindTaskByIdUseCase>();
      services.AddTransient<FindTasksByUserIdUseCase>();
      services.AddTransient<UpdateTaskUseCase>();
      // Todos
      services.AddTransient<CreateTodoUseCase>();
      services.AddTransient<FindTodosByTaskIdUseCase>();
      services.AddTransient<FindTodoByIdUseCase>();
      services.AddTransient<UpdateTodoUseCase>();
      services.AddTransient<DeleteTodoUseCase>();
      services.AddTransient<SetTodoAsCompleteUseCase>();
      services.AddTransient<SetTodoAsNotCompleteUseCase>();
      services.AddTransient<ClearCompleteTodosByTaskIdUseCase>();
    }

    private void AddServices(IServiceCollection services)
    {
      // Users
      services.AddTransient<FindUserByEmailService>();
      services.AddTransient<HashPasswordService>();
      services.AddTransient<CreateUserService>();
      services.AddTransient<FindAllUsersService>();
      services.AddTransient<IsPasswordMatchService>();
      services.AddTransient<GetSignInTokenService>();
      services.AddTransient<DecodeTokenService>();
      services.AddTransient<FindUserByIdService>();
      // Tasks
      services.AddTransient<CreateTaskService>();
      services.AddTransient<FindTasksByUserIdService>();
      services.AddTransient<FindTaskByIdService>();
      services.AddTransient<DeleteTaskByIdService>();
      services.AddTransient<UpdateTaskService>();
      // Todos
      services.AddTransient<CreateTodoService>();
      services.AddTransient<FindTodosByTaskIdService>();
      services.AddTransient<FindTodoByIdService>();
      services.AddTransient<UpdateTodoService>();
      services.AddTransient<DeleteTodoService>();
      services.AddTransient<SetTodoAsCompleteService>();
      services.AddTransient<SetTodoAsNotCompleteService>();
      services.AddTransient<ClearCompleteTodosByTaskIdService>();
    }
  }
}
