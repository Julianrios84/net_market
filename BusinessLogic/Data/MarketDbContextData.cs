﻿using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarketDbContextData
    {
        public static async Task LoadSeedersAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Mark.Any())
                {
                    var markSeeder = File.ReadAllText("../BusinessLogic/Data/Seeders/Mark.json");
                    var marks = JsonSerializer.Deserialize<List<Mark>>(markSeeder);

                    foreach (var mark in marks)
                    {
                        context.Mark.Add(mark);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Category.Any())
                {
                    var categorySeeder = File.ReadAllText("../BusinessLogic/Data/Seeders/Category.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categorySeeder);

                    foreach (var category in categories)
                    {
                        context.Category.Add(category);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Product.Any())
                {
                    var productSeeder = File.ReadAllText("../BusinessLogic/Data/Seeders/Product.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productSeeder);

                    foreach (var product in products)
                    {
                        context.Product.Add(product);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(e.Message);
            }
        }
    }
}
