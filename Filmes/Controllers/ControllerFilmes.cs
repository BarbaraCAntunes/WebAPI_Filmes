using Microsoft.AspNetCore.Mvc;
using Filmes.Models;


namespace Filmes.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recupera todos os filmes.
        /// </summary>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<Filme>> GetFilmes()
        {
            var filmes = _context.Filmes.ToList();
            if (_context.Filmes == null)
            {
                return Ok("Nenhum filme cadstrado!");
            }
            else
            {
                return Ok(filmes);
            }
        }

        /// <summary>
        /// Recupera um filme específico pelo id.
        /// </summary>
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult<Filme> GetFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
            {
                return NotFound("Filme não encontrado!");
            }

            return Ok(filme);
        }

        /// <summary>
        /// Atualiza um filme específico.
        /// </summary>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult PutFilme(int id, Filme filme)
        {
            if (id != filme.Id)
            {
                return BadRequest("Os Ids não são iguais!");
            }

            var filmeExistente = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filmeExistente == null)
            {
                return NotFound("Filme não encontrado!");
            }

            filmeExistente.Nome = filme.Nome;
            filmeExistente.Duracao = filme.Duracao;
            filmeExistente.Diretor = filme.Diretor;
            filmeExistente.Genero = filme.Genero;

            _context.SaveChanges();

            return Ok("Filme atualizado com sucesso!");
        }


        /// <summary>
        /// Cria um novo filme.
        /// </summary>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<Filme> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFilme), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Deleta um filme específico pelo id.
        /// </summary>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult DeleteFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
            {
                return NotFound("Filme não encontrado!");
            }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return Ok("O filme foi removido com sucesso!");
        }
    }
}
