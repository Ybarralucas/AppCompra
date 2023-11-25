using AppCompra.Models;
using AppCompra.Models.VModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



namespace AppCompra.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppcompradbContext _dbContext;

        public HomeController(AppcompradbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            
                List<Producto> listProductos = (from b in _dbContext.Productos select b).ToList();
                return View(listProductos);
           
            
        }

        [HttpPost]
        public IActionResult Index([FromBody] CompraVM oCompraVM)
        {
            Compra oCompra = oCompraVM.oCompra;
            oCompra.DetalleCompras = oCompraVM.oDetalleCompra;
            _dbContext.Compras.Add(oCompra);
            _dbContext.SaveChanges();
            return Json(new { respuesta = true });
        }

        [HttpPost]
        public IActionResult GetProduct([FromBody] Producto product)
        {
            
            Producto getproducto = (from p in _dbContext.Productos where p.IdProducto == product.IdProducto select p).First();
            return Json(new { id= getproducto.IdProducto,
                              nombre= getproducto.NombreProducto,
                              img=getproducto.Img,
                              precio=getproducto.PrecioProducto,
                              status=0
                             });
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
    }
}