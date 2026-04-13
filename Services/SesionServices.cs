using System;
using System.Collections.Concurrent;
using MantaroBot.Models;

namespace MantaroBot.Services
{
    public class SesionService
    {
        private readonly ConcurrentDictionary<string, SesionUsuario> _sesiones = new();

        public SesionUsuario ObtenerOcrearSesion(string sessionId)
        {
            return _sesiones.GetOrAdd(sessionId, _ => new SesionUsuario());
        }

        public void ActualizarSesion(string sessionId, SesionUsuario sesion)
        {
            sesion.UltimaInteraccion = DateTime.Now;
            _sesiones[sessionId] = sesion;
        }

        public void LimpiarSesion(string sessionId)
        {
            _sesiones.TryRemove(sessionId, out _);
        }
    }
}