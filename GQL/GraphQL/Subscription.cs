using GQL.Models;

namespace GQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Drink OnDrinkAdded([EventMessage] Drink drink)
        {
            return drink;
        }

        [Subscribe]
        [Topic]
        public Ingredient OnIngredientAdded([EventMessage] Ingredient ingredient)
        {
            return ingredient;
        }
    }
}
