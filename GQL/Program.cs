using GQL.Data;
using GQL.GraphQL;
using GQL.GraphQL.Drinks;
using GQL.GraphQL.Ingredients;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotChocolate")));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<DrinkType>()
    .AddType<IngredientType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled);


var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.MapGet("/", () => "Hot Chocolate");

app.Run();
