using System.Dynamic;

namespace MantaroBot.Models;

public class Pedido
{
    public List<ItemPedido> Items { get; set; } = new();
    public string? NumeroMesa { get; set; }
    public bool EsDomicilio {get; set;}    public string Observaciones { get; set; } = string.Empty;}