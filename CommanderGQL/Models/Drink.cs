﻿using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public Drink(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}