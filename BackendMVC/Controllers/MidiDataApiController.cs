using BackendMVC.Data;
using BackendMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidiDataApiController : Controller
    {
        private readonly BackendMVCContext _context;
        public MidiDataApiController(BackendMVCContext context)
        {
            _context = context;
        }
        //some comment
        /// <summary>
        /// get mididata by id
        /// </summary>
        [HttpGet("findbyid{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MidifileModel> GetById_ActionResultOfT(int id)
        {
            var Midifile = _context.MidifileModel.Find(id);
            return Midifile == null ? NotFound() : Midifile;
        }

        /// <summary>
        /// ----Deletes mididata by id.----
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletebyid{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.MidifileModel.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            _context.MidifileModel.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
