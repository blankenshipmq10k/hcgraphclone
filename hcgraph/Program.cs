using hcgraph.Domain.Models;
using hcgraph.Domain.Repositories;
using hcgraph.Domain.Services;
using hcgraph.ModelExtensions;
using Microsoft.EntityFrameworkCore;
using hcgraph.Queries;
using hcgraph.Mutations;
using HotChocolate.Execution.Options;
using hcgraph.Errors;

IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDbContext>(options =>
{
    options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);


builder.Services
    .AddScoped<IItemRepository, ItemRepository>()
    .AddScoped<IOrderItemRepository, OrderItemRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IOrderService, OrderService>();

builder.Services
    .AddErrorFilter<ErrorFilter>()
    .AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
    .AddQueryType(q => q.Name("Query"))
    .AddType<OrderQuery>()
    .AddType<OrderItemQuery>()
    .AddType<ItemQuery>()
    .AddTypeExtension<OrderExtensions>()
    .AddTypeExtension<OrderItemExtensions>()
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<OrderItemMutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<SampleDbContext>().Database.Migrate();
}

app.UseDeveloperExceptionPage();

app.MapGraphQL();

app.Run();
