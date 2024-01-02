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
        //some other comment to test git

        /// <summary>
        /// ----get all mididata in list----
        /// </summary>
        [HttpGet("getpage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MidifileModel>> GetById_ActionResultOfT(int pagenum, int itemsPerPage)
        {
            var MidifileResults = new List<MidifileModel>();
            var Midifilelist = _context.MidifileModel.ToList();
            MidifileResults = Midifilelist.Skip((pagenum - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            return MidifileResults;// == null ? NotFound() : Midifile;
        }

        /// <summary>
        /// ----get all mididata in list----
        /// </summary>
        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MidifileModel>> GetPage_ActionResultOfT()
        {
            var Midifile = _context.MidifileModel.ToList();
            return Midifile;// == null ? NotFound() : Midifile;
        }

        /// <summary>
        /// ----get mididata table by id----
        /// </summary>
        [HttpGet("findbyid{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MidifileModel> GetById_ActionResultOfT(int id)
        {
            var Midifile = _context.MidifileModel.Find(id);
            return Midifile == null ? NotFound() : Midifile;
        }

        //// upload metadata
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FileNumber,Title,Year,FilePath,Composer")] MidifileModel midiMetaData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(midiMetaData);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(midiMetaData);
        //}

        /// <summary>
        /// ----Deletes mididata table by id----
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
