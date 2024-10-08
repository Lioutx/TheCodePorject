﻿using Domain.Entities;

namespace Domain.Aggregates
{
    public class Recipe
    {
        public string Title { get; set; }
        public List<Product> Products { get; set; }
        public string UrlToRecipe { get; set; }
        public bool IsSnack { get; set; }
    }
}
