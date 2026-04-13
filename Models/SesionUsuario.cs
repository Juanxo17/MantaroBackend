using System;

namespace MantaroBot.Models
{
    public class SesionUsuario
    {
        public string EstadoActual { get; set; } = "INICIO";
        public string CategoriaSeleccionada { get; set; } = "";
        public Pedido PedidoActual { get; set; } = new Pedido();
        public DateTime UltimaInteraccion { get; set; } = DateTime.Now;
    }
}