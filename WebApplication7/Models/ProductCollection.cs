using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class ProductCollection
{
    public IMongoCollection<Product> Products { get; }

    public ProductCollection()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("GeeksArrayStore");
        Products = database.GetCollection<Product>("Products");

        //CatalogContextSeed.SeedData(Products);

        List<Product> list = Products.Find<Product>
            (p => true).ToList<Product>();

        foreach(Product product in list)
        {
            Console.WriteLine($"ProductID: {product.Id} - Product Name: {product.Name}" );
        }
    }
}