using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages
{
    public class PizzaModel : PageModel
    {
        public List<PizzasModel> facePizzasDb = new List<PizzasModel>() { 
            new PizzasModel(){ ImageTitle="Margerita", PizzaName="Magerita", BasePrice=2, TomatoSauce=true, Cheese= true, FinalPrice=4},
            new PizzasModel(){ ImageTitle="Bolognese", PizzaName="Bolognese", BasePrice=2, TomatoSauce=true, Cheese= true, FinalPrice=4},
            new PizzasModel(){ ImageTitle="Hawaiian", PizzaName="Hawaiian", BasePrice=2, TomatoSauce=true, Cheese= true, Pineapple=true, FinalPrice=14},
            new PizzasModel(){ ImageTitle="Carbonara", PizzaName="Carbonara", BasePrice=2, TomatoSauce=true, Cheese= true, FinalPrice=4},
            new PizzasModel(){ ImageTitle="MeatFeast", PizzaName="MeatFeast", BasePrice=2, TomatoSauce=true, Cheese= true, Beef=true, Ham=true, FinalPrice=6},
            new PizzasModel(){ ImageTitle="Mushroom", PizzaName="Mushroom", BasePrice=2, TomatoSauce=true, Cheese= true, FinalPrice=4},
            new PizzasModel(){ ImageTitle="Pepperoni", PizzaName="Pepperoni", BasePrice=2, TomatoSauce=true, Cheese= true, FinalPrice=4},
            new PizzasModel(){ ImageTitle="Seafood", PizzaName="Seafood", BasePrice=2, TomatoSauce=true, Cheese= true, Tuna=true, FinalPrice=4},
            new PizzasModel(){ ImageTitle="Vegetarian", PizzaName="Vegetarian", BasePrice=2, TomatoSauce=true, Cheese= true, FinalPrice=4}
        };
        public void OnGet()
        {
        }
    }
}
