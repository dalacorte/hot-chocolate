using CommanderGQL.Data;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Drink> GetDrink([Service] AppDbContext context)
        {
            return context.Drinks.Include(i => i.Ingredients);
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Ingredient> GetIngredient([Service] AppDbContext context)
        {
            return context.Ingredients.Include(i => i.Drink);
        }
    }
}
