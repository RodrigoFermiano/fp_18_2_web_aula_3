using fp_stack_api.Contexts;
using fp_stack_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace fp_stack_api.Controllers
{

    [Route("api/[controller]")]
    public class PerguntasController : Controller
    {

        private Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }
               

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Pergunta>))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var perguntas = _context.Perguntas.ToList();
            if (perguntas.Count == 0)
                return NotFound();

            return Ok(perguntas);
        }

        [HttpGet]
        //public ActionResult<List<Pergunta>> Get()
        //{
        //    var times = _context.Perguntas.ToList();
        //    if (times.Count == 0)
        //        return NotFound();

        //    return _context.Perguntas.ToList();
        //}

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Pergunta> Get(int id)
        {
            var pergunta = _context.Perguntas.FirstOrDefault(t => t.Id.Equals(id));
            if (pergunta == null)
                return NotFound();

            return Ok(pergunta);
        }


        [HttpPost]
        public ActionResult<Pergunta> Post(Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Perguntas.Add(pergunta);
                _context.SaveChanges();
                return Created($"/api/perguntas/{pergunta.Id}", pergunta);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Pergunta> Put(int id, Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(pergunta);
                _context.SaveChanges();
                return Ok(pergunta);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var pergunta = _context.Perguntas.FirstOrDefault(t => t.Id.Equals(id));
            if (pergunta == null)
                return NotFound();

            _context.Perguntas.Remove(pergunta);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
