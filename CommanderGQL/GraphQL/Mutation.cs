using CommanderGQL.Data;
using CommanderGQL.GraphQL.Drinks;
using CommanderGQL.Models;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddDrinkPayload> AddDrink(AddDrinkInput input, AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var drink = new Drink
            {
                Name = input.Name,
                Description = input.Description,
            };

            context.Drinks.Add(drink);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnDrinkAdded), drink, cancellationToken);

            return new AddDrinkPayload(drink);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddIngredientPayload> AddIngredient(AddIngredientInput input, AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient
            {
                Name = input.Name,
                DrinkId = input.DrinkId,
            };

            context.Ingredients.Add(ingredient);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnIngredientAdded), ingredient, cancellationToken);

            return new AddIngredientPayload(ingredient);
        }
    }
}
