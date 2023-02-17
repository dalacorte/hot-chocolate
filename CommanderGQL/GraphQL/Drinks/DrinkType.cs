using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Drinks
{
    public class DrinkType : ObjectType<Drink>
    {
        protected override void Configure(IObjectTypeDescriptor<Drink> descriptor)
        {
            descriptor.Description("Represents a delicious drink.");

            // Ignore a field
            //descriptor.Field(d => d.Description).Ignore();

            descriptor.Field(d => d.Ingredients)
                .ResolveWith<Resolvers>(d => d.GetIngredients(default!, default!))
                .UseDbContext<AppDbContext>()
                .UseProjection();
        }

        private class Resolvers
        {
            public IQueryable<Ingredient> GetIngredients([Parent] Drink drink, AppDbContext context)
            {
                return context.Ingredients;
            }
        }
    }
}
