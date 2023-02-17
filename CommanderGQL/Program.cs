using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotChocolate")));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "Hot Chocolate");

app.Run();
