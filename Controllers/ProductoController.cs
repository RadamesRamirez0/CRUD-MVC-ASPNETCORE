using Microsoft.AspNetCore.Mvc;
using crudapi.Models;

namespace crudapi.Controllers
{


    [Route("/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        
         private readonly DataContext _context;
            
        public ProductoController(DataContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetAsync()
        {
            return Ok(await _context.Productos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Producto>>> GetAsync(int id)
        {

            var producto = await _context.Productos.FindAsync(id);
            if(producto == null)
                return BadRequest("Producto no encontrado");
            return Ok(producto);

        }

        [HttpPost]
        public async Task<ActionResult<List<Producto>>> AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(await _context.Productos.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Producto>>> ModificarProducto(Producto producto)
        {
            
            var dbProducto = await _context.Productos.FindAsync(producto.ID);
            if(dbProducto == null)
                return BadRequest("Producto no encontrado");
            dbProducto.ID = producto.ID;
            dbProducto.Nombre = producto.Nombre;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Productos.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Producto>>> BorrarProducto(int id)
        {
            var dbProducto = await _context.Productos.FindAsync(id);
            if(dbProducto == null)
                return BadRequest("Producto no encontrado");

            _context.Productos.Remove(dbProducto);
            await _context.SaveChangesAsync();
            return Ok(await _context.Productos.ToListAsync());

        }
        
         
        


    }
}