using Microsoft.AspNetCore.Mvc;
using PortafolioWeb.Models;
using System.Diagnostics;

namespace PortafolioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {     
              var proyectos = ObtenerProyectos().Take(3).ToList();
              var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
              return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>
            {
                new Proyecto
                {
                    Titulo = "App para certifiaciones Microsoft",
                    Descripcion = "Portal de entrenamiento Tecnologias Microsoft",
                    Link = "https://learn.microsoft.com/es-es/credentials/",
                    ImagenURL = "imagenes/Microsoft.jpg"
                },

                new Proyecto
                {
                    Titulo = "Grupo Bancolombia",
                    Descripcion = "Desarrollo App clientes",
                    Link = "https://learn.microsoft.com/es-es/credentials/",
                    ImagenURL = "/imagenes/bancolombia.jpg"
                },

                new Proyecto
                {
                    Titulo = "Desarrollo App vitual Exito",
                    Descripcion = "Desarrollo App compras Online Angular",
                    Link = "https://learn.microsoft.com/es-es/credentials/",
                    ImagenURL = "imagenes/exito.jpg"
                },

                new Proyecto
                {
                    Titulo = "Desarrollo App Simulador de prestamos",
                    Descripcion = "Desarrollo app prestamos",
                    Link = "https://learn.microsoft.com/es-es/credentials/",
                    ImagenURL = "/imagenes/Microsoft.jpg"
                },
            };
        }
    }
}
