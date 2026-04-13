namespace MantaroBot.Data;

using MantaroBot.Models;

public static class MenuData
{
    public static readonly Dictionary<string, List<ItemPedido>> Categorias = new()
    {
        {
            "Pizzas", new List<ItemPedido>
            {
                new ItemPedido { Nombre = "Maiale", Precio = 22000 },
                new ItemPedido { Nombre = "Frango", Precio = 22000 },
                new ItemPedido { Nombre = "Vegetales", Precio = 21000 },
                new ItemPedido { Nombre = "Campesina", Precio = 20000 },
                new ItemPedido { Nombre = "Mexicana", Precio = 20000 },
                new ItemPedido { Nombre = "Peperoni", Precio = 20500 },
                new ItemPedido { Nombre = "Olé", Precio = 24000 },
                new ItemPedido { Nombre = "Carnes", Precio = 20500 },
                new ItemPedido { Nombre = "Pollo con champiñones", Precio = 22000 },
                new ItemPedido { Nombre = "Hawaiana", Precio = 19000 }
            }
        },
        {
            "Bebidas Calientes", new List<ItemPedido>
            {
                new ItemPedido { Nombre = "Café Americano 7oz", Precio = 5000 },
                new ItemPedido { Nombre = "Café Americano 14oz", Precio = 7800 },
                new ItemPedido { Nombre = "Milo 7oz", Precio = 8000 },
                new ItemPedido { Nombre = "Milo 14oz", Precio = 9500 },
                new ItemPedido { Nombre = "Mocaccino 7oz", Precio = 7500 },
                new ItemPedido { Nombre = "Mocaccino 14oz", Precio = 9500 },
                new ItemPedido { Nombre = "Latte 7oz", Precio = 7000 },
                new ItemPedido { Nombre = "Latte 14oz", Precio = 9000 },
                new ItemPedido { Nombre = "Expresso", Precio = 4500 },
                new ItemPedido { Nombre = "Doble Expresso", Precio = 8000 },
                new ItemPedido { Nombre = "Chocolate 7oz", Precio = 8500 },
                new ItemPedido { Nombre = "Chocolate 14oz", Precio = 9500 },
                new ItemPedido { Nombre = "Macchiato", Precio = 7500 },
                new ItemPedido { Nombre = "Té Chai 7oz", Precio = 10500 },
                new ItemPedido { Nombre = "Té Chai 14oz", Precio = 12500 },
                new ItemPedido { Nombre = "Cappuccino Tradicional 7oz", Precio = 7000 },
                new ItemPedido { Nombre = "Cappuccino Tradicional 14oz", Precio = 11800 },
                new ItemPedido { Nombre = "Café Montañero", Precio = 6500 },
                new ItemPedido { Nombre = "Café Mantarillo", Precio = 12000 },
                new ItemPedido { Nombre = "Tinto", Precio = 2600 },
                new ItemPedido { Nombre = "Cappuccino Vienés", Precio = 9000 },
                new ItemPedido { Nombre = "Cappuccino con Licor", Precio = 13500 },
                new ItemPedido { Nombre = "Café Irlandés", Precio = 14000 },
                new ItemPedido { Nombre = "Café Bombón", Precio = 11500 },
                new ItemPedido { Nombre = "Aromática frutos rojos", Precio = 9000 },
                new ItemPedido { Nombre = "Aromática frutos amarillos", Precio = 9000 },
                new ItemPedido { Nombre = "Cappuccino vainilla-arequipe", Precio = 10000 }
            }
        },
        {
            "Bebidas Frías", new List<ItemPedido>
            {
                new ItemPedido { Nombre = "Sorbete de frutos rojos", Precio = 9500 },
                new ItemPedido { Nombre = "Sorbete de frutos amarillos", Precio = 9500 },
                new ItemPedido { Nombre = "Sorbete de uva", Precio = 9500 },
                new ItemPedido { Nombre = "Ice Coffee", Precio = 7600 },
                new ItemPedido { Nombre = "Granizado de Café", Precio = 10500 },
                new ItemPedido { Nombre = "Granizado de Milo", Precio = 11000 },
                new ItemPedido { Nombre = "Granizado de Galleta", Precio = 11000 },
                new ItemPedido { Nombre = "Milo Frío", Precio = 8500 },
                new ItemPedido { Nombre = "Lulada", Precio = 10000 },
                new ItemPedido { Nombre = "Limonata", Precio = 6200 },
                new ItemPedido { Nombre = "Limonada de Cereza", Precio = 11000 },
                new ItemPedido { Nombre = "Limonada de Coco", Precio = 11500 },
                new ItemPedido { Nombre = "Coca Cola", Precio = 4500 },
                new ItemPedido { Nombre = "Botella de Agua", Precio = 2500 },
                new ItemPedido { Nombre = "Soda", Precio = 4000 },
                new ItemPedido { Nombre = "Soda Michelada", Precio = 6500 },
                new ItemPedido { Nombre = "Té Chai Frío", Precio = 13000 },
                new ItemPedido { Nombre = "Soda Artesanal Mango", Precio = 15000 },
                new ItemPedido { Nombre = "Soda Artesanal Lychee", Precio = 15000 },
                new ItemPedido { Nombre = "Soda Artesanal Lulo", Precio = 15000 },
                new ItemPedido { Nombre = "Soda Artesanal Maracuyá", Precio = 15000 },
                new ItemPedido { Nombre = "Soda Artesanal Frutos Rojos", Precio = 15000 },
                new ItemPedido { Nombre = "Malteada Baileys", Precio = 16500 },
                new ItemPedido { Nombre = "Malteada de Café", Precio = 14500 },
                new ItemPedido { Nombre = "Malteada de Chocolate", Precio = 14500 },
                new ItemPedido { Nombre = "Malteada de Galleta", Precio = 14500 },
                new ItemPedido { Nombre = "Malteada de Vainilla", Precio = 14500 },
                new ItemPedido { Nombre = "Malteada de Milo", Precio = 14500 },
                new ItemPedido { Nombre = "Cappuccino Frío", Precio = 11000 }
            }
        },
        {
            "Brunch", new List<ItemPedido>
            {
                new ItemPedido { Nombre = "Tortilla Española", Precio = 14000 },
                new ItemPedido { Nombre = "Tortilla Ranchera", Precio = 15000 },
                new ItemPedido { Nombre = "Sandwich Club", Precio = 22000 },
                new ItemPedido { Nombre = "Sandwich Club Pollo", Precio = 23000 },
                new ItemPedido { Nombre = "Sandwich Club Vegetariano", Precio = 20000 },
                new ItemPedido { Nombre = "Sandwich Club de Carne", Precio = 25500 },
                new ItemPedido { Nombre = "Sandwich Club Mix", Precio = 26500 },
                new ItemPedido { Nombre = "Sandwich Superwaffle", Precio = 18500 },
                new ItemPedido { Nombre = "Waffle Sencillo", Precio = 5200 },
                new ItemPedido { Nombre = "Wafflebono", Precio = 9000 },
                new ItemPedido { Nombre = "Choripan", Precio = 14000 },
                new ItemPedido { Nombre = "Chorimex", Precio = 15000 },
                new ItemPedido { Nombre = "Croissant Americano", Precio = 14000 },
                new ItemPedido { Nombre = "Croissant Clásico", Precio = 12000 },
                new ItemPedido { Nombre = "Croissant Sencillo", Precio = 3500 },
                new ItemPedido { Nombre = "Arma tu Desayuno", Precio = 14000 }
            }
        },
        {
            "Endúlzate", new List<ItemPedido>
            {
                new ItemPedido { Nombre = "Torta de Zanahoria", Precio = 8000 },
                new ItemPedido { Nombre = "Torta de Naranja", Precio = 8000 },
                new ItemPedido { Nombre = "Torta de Chocolate", Precio = 8000 },
                new ItemPedido { Nombre = "Red Velvet", Precio = 11000 },
                new ItemPedido { Nombre = "Galleta Vainilla Chips", Precio = 2500 },
                new ItemPedido { Nombre = "Waffle con Helado", Precio = 10500 },
                new ItemPedido { Nombre = "Afogato", Precio = 11500 },
                new ItemPedido { Nombre = "Cheesecake", Precio = 11000 },
                new ItemPedido { Nombre = "Copa de Helado", Precio = 5500 }
            }
        },
        {
            "Licores", new List<ItemPedido>
            {
                new ItemPedido { Nombre = "Copa de Vino", Precio = 9000 },
                new ItemPedido { Nombre = "Decantador de Vino", Precio = 36000 },
                new ItemPedido { Nombre = "Sangría Copa", Precio = 13500 },
                new ItemPedido { Nombre = "Tinto de Verano", Precio = 9500 },
                new ItemPedido { Nombre = "Rebujito", Precio = 8500 },
                new ItemPedido { Nombre = "Mojito", Precio = 12000 },
                new ItemPedido { Nombre = "Corona", Precio = 7500 },
                new ItemPedido { Nombre = "Stella Artois", Precio = 8500 },
                new ItemPedido { Nombre = "Club Dorada", Precio = 6500 },
                new ItemPedido { Nombre = "Cerveza BBC", Precio = 6000 },
                new ItemPedido { Nombre = "Shot Aguardiente Amarillo", Precio = 7500 },
                new ItemPedido { Nombre = "Shot Jhonnie Walker", Precio = 9500 },
                new ItemPedido { Nombre = "Shot Baileys", Precio = 9500 },
                new ItemPedido { Nombre = "Shot Ron Blanco", Precio = 7000 },
                new ItemPedido { Nombre = "Michelada Clásica", Precio = 0 },
                new ItemPedido { Nombre = "Michelada Mango Biche", Precio = 0 },
                new ItemPedido { Nombre = "Michelada Maracuyá", Precio = 0 },
                new ItemPedido { Nombre = "Michelada Escarchada", Precio = 0 }
            }
        }
    };
}