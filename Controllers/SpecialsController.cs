using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizza.Data;

namespace BlazingPizza.Controllers;

//base URL for this controller
/*If app runs at https://localhost:5001, the full URL for this 
 * controller will be https://localhost:5001/specials */
[Route("specials")]

//Dedicate to being an API controller
/* Gives automatic features:
 *  model validation/binding
 *  Returns 400 Bad Request if input is invalid
 *  Helps format responses as JSON or XML
 */
[ApiController]
public class SpecialsController : Controller
{
    private readonly PizzaStoreContext _db;

    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]//Responds to GET requests to /specials
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
    }
}
