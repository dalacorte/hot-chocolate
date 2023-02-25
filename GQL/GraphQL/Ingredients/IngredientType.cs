using GQL.Data;
using GQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GQL.GraphQL.Ingredients
{
    public class IngredientType : ObjectType<Ingredient>
    {
        protected override void Configure(IObjectTypeDescriptor<Ingredient> descriptor)
        {
            descriptor.Description("Represents the ingredients of a delicious drink.");

            // Ignore a field
            //descriptor.Field(i => i.Name).Ignore();

            descriptor.Field(i => i.Drink)
                .ResolveWith<Resolvers>(i => i.GetDrink(default!, default!))
                .UseDbContext<AppDbContext>()
                .UseProjection();
        }

        protected class Resolvers
        {
            public IQueryable<Drink> GetDrink([Parent] Ingredient ingredient, AppDbContext context)
            {
                return context.Drinks.Where(d => d.Id == ingredient.DrinkId).Include(d => d.Ingredients);
            }
        }
    }
}
