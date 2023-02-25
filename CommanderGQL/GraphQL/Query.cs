﻿using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Drink> GetDrink(AppDbContext context)
        {
            return context.Drinks;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Ingredient> GetIngredient(AppDbContext context)
        {
            return context.Ingredients;
        }
    }
}
