﻿using BlazorCommerce.CoreBusiness.Models;
using BlazorCommerce.UseCases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorCommerce.Data
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products = new List<Product>() { 
            new Product(){ Id = 1, Brand = "Google", Name="Google clock", Price=200, ImageLink="data:image/jpeg;base64,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", Description="Clock from google with love"},
            new Product(){ Id = 2, Brand = "Google", Name="Google flower", Price=300, ImageLink="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTnsBViYl0G_vg0r3asMquQhQt49vDR42PMWg&usqp=CAU", Description="Clock from google with love"},
            new Product(){ Id = 3, Brand = "Google", Name="Google docker", Price=400, ImageLink="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcS7QFa9c0zA8wYTRF6dindcYqBXvwbjYkdpXQ&usqp=CAU", Description="Clock from google with love"},
            new Product(){ Id = 4, Brand = "Microsoft", Name="MS table", Price=2300, ImageLink="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRaoMIbetOcc393LyrLkq95fmqYbNPH1FG00Q&usqp=CAU", Description="Clock from google with love"},
            new Product(){ Id = 5, Brand = "Microsoft", Name="Ms clock", Price=300, ImageLink="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTnvRkjhz6o9cozy_l1y7nfotYXey_qS684WA&usqp=CAU", Description="Clock from google with love"},
            new Product(){ Id = 6, Brand = "Microsoft", Name="MS PC", Price=1200, ImageLink="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRhsz1qtpoTR5KkH1fhMfo1xYX1qefKcPIdPQ&usqp=CAU", Description="Clock from google with love"},
        };

        public List<Order> orders;

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter)) return products;

            return products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        public Order AddProduct(int Id,int Quantity)
        { 
            var product = products.FirstOrDefault(x => x.Id == Id);
            
            return new Order()
            {
                IdProduct = product.Id,
                Quantity = Quantity,
                Total = Quantity * product.Price,
                Product = product
            };            
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders;
        }
    }
}
