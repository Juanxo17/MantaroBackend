using Microsoft.AspNetCore.Mvc;
using MantaroBot.Services;
using MantaroBot.Models;
using MantaroBot.Data;

namespace MantaroBot.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotController : ControllerBase
{
    private readonly SesionService _sesionService;

    public ChatbotController(SesionService sesionService)
    {
        _sesionService = sesionService;
    }

    [HttpPost]
    public IActionResult ProcesarMensaje([FromBody] ChatRequest request)
    {
        if (string.IsNullOrEmpty(request.SessionId) || string.IsNullOrEmpty(request.Mensaje))
        {
            return BadRequest("SessionId y Mensaje son obligatorios.");
        }

        var sesion = _sesionService.ObtenerOcrearSesion(request.SessionId);
        
        string mensajeUsuario = request.Mensaje.Trim().ToLower();
        string respuestaBot = "";
        string urlAccion = "";
        string textoAccion = "";
        string urlSecundaria = "";
        string textoSecundario = "";

        switch (sesion.EstadoActual)
        {
            case "INICIO":
                respuestaBot = "¡Hola! Bienvenido a Mantaro. ☕\n\n¿Qué te gustaría hacer?\n1. Ver Menú\n2. Hablar con un asesor";
                sesion.EstadoActual = "ESPERANDO_OPCION_INICIO";
                break;

            case "ESPERANDO_OPCION_INICIO":
                if (mensajeUsuario == "1" || mensajeUsuario.Contains("menu") || mensajeUsuario.Contains("menú"))
                {
                    respuestaBot = "¡Genial! Aquí tienes nuestras categorías:\n";
                    int numCat = 1;
                    foreach(var cat in MenuData.Categorias.Keys)
                    {
                        respuestaBot += $"{numCat}. {cat}\n";
                        numCat++;
                    }
                    respuestaBot += "\nResponde con el número de la categoría que quieres ver.";
                    sesion.EstadoActual = "VIENDO_CATEGORIAS";
                }
                else if (mensajeUsuario == "2")
                {
                    respuestaBot = "¡Claro que sí! Toca el botón de abajo para que uno de nuestros asesores te atienda por WhatsApp en este momento.\n\n*(Escribe '1' o 'hola' si deseas volver a ver el menú)*";
                    urlAccion = "https://wa.me/573166677871?text=Hola,%20quisiera%20hablar%20con%20un%20asesor";
                    textoAccion = "💬 Hablar con un asesor por WhatsApp";
                    sesion.EstadoActual = "INICIO";
                }
                else
                {
                    respuestaBot = "No te entendí. Por favor, escribe 1 para ver el menú o 2 para hablar con un asesor.";
                }
                break;

            case "VIENDO_CATEGORIAS":
                if (mensajeUsuario == "0" || mensajeUsuario == "volver")
                {
                    respuestaBot = "¡Hola! Bienvenido a Mantaro. ☕\n\n¿Qué te gustaría hacer?\n1. Ver Menú\n2. Hablar con un asesor";
                    sesion.EstadoActual = "ESPERANDO_OPCION_INICIO";
                }
                else if (int.TryParse(mensajeUsuario, out int indexCat))
                {
                    int contadorCats = 1;
                    string catEncontrada = null;

                    foreach (var cat in MenuData.Categorias.Keys)
                    {
                        if (contadorCats == indexCat)
                        {
                            catEncontrada = cat;
                            break;
                        }
                        contadorCats++;
                    }

                    if (catEncontrada != null)
                    {
                        sesion.CategoriaSeleccionada = catEncontrada;
                        var itemsCat = MenuData.Categorias[catEncontrada];
                        respuestaBot = $"📋 MENÚ DE {catEncontrada.ToUpper()}:\n\n";
                        for (int i = 0; i < itemsCat.Count; i++)
                        {
                            respuestaBot += $"{i + 1}. {itemsCat[i].Nombre} - ${itemsCat[i].Precio}\n";
                        }
                        respuestaBot += $"\nEscribe el NÚMERO del producto que deseas agregar, o '0' para volver a las categorías.";
                        sesion.EstadoActual = "SELECCIONANDO_PRODUCTO";
                    }
                    else
                    {
                        respuestaBot = "Ese número de categoría no existe. Escribe un número válido o '0' para volver.";
                    }
                }
                else if (mensajeUsuario == "0" || mensajeUsuario == "volver")
                {
                    respuestaBot = "¡Hola! Bienvenido a Mantaro. ☕\n\n¿Qué te gustaría hacer?\n1. Ver Menú\n2. Hablar con un asesor";
                    sesion.EstadoActual = "ESPERANDO_OPCION_INICIO";
                }
                else
                {
                    respuestaBot = "Por favor, escribe '1' para Pizzas, '2' para Bebidas Calientes, o '0' para volver.";
                }
                break;

            case "SELECCIONANDO_PRODUCTO":
                if (mensajeUsuario == "0" || mensajeUsuario == "volver")
                {
                    respuestaBot = "¡Genial! Aquí tienes nuestras categorías:\n";
                    int numCat = 1;
                    foreach(var cat in MenuData.Categorias.Keys)
                    {
                        respuestaBot += $"{numCat}. {cat}\n";
                        numCat++;
                    }
                    respuestaBot += "\nResponde con el número de la categoría que quieres ver.";
                    sesion.EstadoActual = "VIENDO_CATEGORIAS";
                }
                else if (int.TryParse(mensajeUsuario, out int indexProducto))
                {
                    if (MenuData.Categorias.ContainsKey(sesion.CategoriaSeleccionada))
                    {
                        var items = MenuData.Categorias[sesion.CategoriaSeleccionada];
                        if (indexProducto > 0 && indexProducto <= items.Count)
                        {
                            var productoElegido = items[indexProducto - 1];
                            sesion.PedidoActual.Items.Add(productoElegido);
                            
                            respuestaBot = $"✅ ¡Se agregó '{productoElegido.Nombre}' a tu carrito!\n\n¿Qué quieres hacer ahora?\n1. Agregar más {sesion.CategoriaSeleccionada}\n2. Ver otras categorías\n3. 🛒 Finalizar pedido";
                            sesion.EstadoActual = "CONFIRMANDO_AGREGADO";
                        }
                        else
                        {
                            respuestaBot = "El número que ingresaste no está en la lista. Por favor envía el número correcto, o '0' para regresar.";
                        }
                    }
                    else
                    {
                        respuestaBot = "Error al identificar la categoría. Volvamos al inicio.";
                        sesion.EstadoActual = "INICIO";
                    }
                }
                else
                {
                    respuestaBot = "Por favor escribe un número válido de la lista.";
                }
                break;

            case "CONFIRMANDO_AGREGADO":
                if (mensajeUsuario == "1")
                {
                    var listado = MenuData.Categorias[sesion.CategoriaSeleccionada];
                    respuestaBot = $"Menú de {sesion.CategoriaSeleccionada}:\n\n";
                    for (int i = 0; i < listado.Count; i++)
                    {
                        respuestaBot += $"{i + 1}. {listado[i].Nombre} - ${listado[i].Precio}\n";
                    }
                    respuestaBot += "\nEscribe el NÚMERO de lo que deseas agregar, o '0' para volver.";
                    sesion.EstadoActual = "SELECCIONANDO_PRODUCTO";
                }
                else if (mensajeUsuario == "2")
                {
                    respuestaBot = "Aquí tienes nuestras categorías:\n";
                    int numCat = 1;
                    foreach(var cat in MenuData.Categorias.Keys)
                    {
                        respuestaBot += $"{numCat}. {cat}\n";
                        numCat++;
                    }
                    respuestaBot += "\nResponde con el número de la categoría que quieres ver.";
                    sesion.EstadoActual = "VIENDO_CATEGORIAS";
                }
                else if (mensajeUsuario == "3")
                {
                    if (sesion.PedidoActual.Items.Count == 0)
                    {
                        respuestaBot = "Tu carrito está vacío. Escribe '1' para regresar al menú principal.";
                        sesion.EstadoActual = "INICIO";
                    }
                    else
                    {
                        respuestaBot = "¡Perfecto! ¿Tu pedido es para consumir en Mantaro o para Domicilio?\n\n1. 🍽️ Consumir en la mesa\n2. 🛵 Domicilio";
                        sesion.EstadoActual = "TIPO_ENTREGA";
                    }
                }
                else
                {
                    respuestaBot = "Por favor responde: 1 (Agregar más), 2 (Otras categorías) o 3 (Finalizar pedido).";
                }
                break;

            case "TIPO_ENTREGA":
                if (mensajeUsuario == "1")
                {
                    sesion.PedidoActual.EsDomicilio = false;
                    respuestaBot = "¿En qué mesa o lugar te encuentras? (Ej: Mesa 2, La Barra, Afuera)";
                    sesion.EstadoActual = "ESPERANDO_UBICACION";
                }
                else if (mensajeUsuario == "2")
                {
                    sesion.PedidoActual.EsDomicilio = true;
                    respuestaBot = "Por favor, escribe la dirección exacta de entrega en Ginebra para el domicilio:";
                    sesion.EstadoActual = "ESPERANDO_UBICACION";
                }
                else
                {
                    respuestaBot = "Por favor, elige una opción:\n1. 🍽️ Consumir en la mesa\n2. 🛵 Domicilio";
                }
                break;

            case "ESPERANDO_UBICACION":
                sesion.PedidoActual.NumeroMesa = request.Mensaje.Trim(); // Tomamos el mensaje original con todo y mayúsculas
                
                respuestaBot = "¡Anotado! 📝 Por último, ¿Tienes alguna especificación sobre los sabores o tamaños de tus productos?\n\n(Ej: Torta de zanahoria, el americano de 14oz, la soda de lulo...)\n\nSi no tienes ninguna, escribe 'No' o 'Ninguno'.";
                sesion.EstadoActual = "ESPERANDO_NOTAS";
                break;

            case "ESPERANDO_NOTAS":
                string notas = request.Mensaje.Trim();
                if (notas.ToLower() != "no" && notas.ToLower() != "ninguno" && notas.ToLower() != "ninguna")
                {
                    sesion.PedidoActual.Observaciones = notas;
                }

                decimal total = 0;
                string textoWa = "¡Hola Mantaro! Quiero confirmar este pedido desde el Bot:\n\n";
                
                foreach (var item in sesion.PedidoActual.Items)
                {
                    textoWa += $"- 1x {item.Nombre} (${item.Precio})\n";
                    total += item.Precio;
                }
                
                textoWa += $"\n*TOTAL: ${total}*\n";
                
                if (!string.IsNullOrEmpty(sesion.PedidoActual.Observaciones))
                {
                    textoWa += $"\n*Aclaraciones del pedido:* {sesion.PedidoActual.Observaciones}\n";
                }

                textoWa += sesion.PedidoActual.EsDomicilio 
                    ? $"\n📍 Domicilio a: {sesion.PedidoActual.NumeroMesa}" 
                    : $"\n🍽️ Para consumir en: {sesion.PedidoActual.NumeroMesa}";
                
                // Formateamos para que funcione como enlace
                string linkWa = $"https://wa.me/573166677871?text={Uri.EscapeDataString(textoWa)}";
                
                respuestaBot = $"🛒 *RESUMEN FINAL*\nTotal: ${total}\nEntrega en: {sesion.PedidoActual.NumeroMesa}\n\n¡Casi listo! Revisa tu pedido y toca el botón abajo para enviarlo a la cocina.\n\nTambién te invitamos a que califiques tu experiencia en Mantaro en Google Maps. ¡Cada reseña nos ayuda a crecer!\n\n*(Escribe 'hola' si deseas hacer un nuevo pedido)*";
                urlAccion = linkWa;
                textoAccion = "📲 Pedir por WhatsApp";
                urlSecundaria = "https://www.google.com/search?client=opera-gx&hs=MGp&sca_esv=2f8518efab07fb93&sxsrf=ANbL-n6SXtPRg7cgboe5k_UisN6HzFrquQ:1776118626721&q=caf%C3%A9+mantaro+ginebra&si=AL3DRZEsmMGCryMMFSHJ3StBhOdZ2-6yYkXd_doETEE1OR-qOYN3wpy3qjdvT64QxSoAdeCNqLZTB9tNPlJIElSpc_7gkdPm7GL9heEH5USLiImEE0yIpxXXsMKgJGsaGDw07BVtFeK9-QTB7GH8TclXLUYks6j6aw%3D%3D&sa=X&ved=2ahUKEwivisy-7euTAxW0QzABHaESHD4QrrQLegQIGhAA&biw=1324&bih=611&dpr=1#";
                textoSecundario = "⭐ Calificanos en Google Maps";
                
                // Limpiamos la memoria para que quede libre
                sesion.PedidoActual.Items.Clear();
                sesion.PedidoActual.NumeroMesa = "";
                sesion.PedidoActual.Observaciones = "";
                sesion.EstadoActual = "INICIO";
                break;

            default:
                respuestaBot = "Me perdí un poco. Escribe 'hola' para volver al menú principal.";
                sesion.EstadoActual = "INICIO";
                break;
        }

        _sesionService.ActualizarSesion(request.SessionId, sesion);

        return Ok(new ChatResponse { 
            Respuesta = respuestaBot, 
            UrlAccion = urlAccion, 
            TextoAccion = textoAccion,
            UrlSecundaria = urlSecundaria,
            TextoSecundario = textoSecundario
        });
    }
}

public class ChatRequest
{
    public string SessionId { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
}

public class ChatResponse
{
    public string Respuesta { get; set; } = string.Empty;
    public string UrlAccion { get; set; } = string.Empty;
    public string TextoAccion { get; set; } = string.Empty;
    public string UrlSecundaria { get; set; } = string.Empty;
    public string TextoSecundario { get; set; } = string.Empty;
}