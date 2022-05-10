using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasteBook.WebApi.Data;
using PasteBook.WebApi.Models;
using System.Threading.Tasks;

namespace PasteBook.WebApi.Controllers
{
    [Route("comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public CommentController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await UnitOfWork.CommentRepository.FindAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var post = await UnitOfWork.CommentRepository.FindByPrimaryKey(id);
            if (post is object)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            if (ModelState.IsValid)
            {
                var newComment = await UnitOfWork.CommentRepository.Insert(comment);
                await UnitOfWork.CommitAsync();

                return StatusCode(StatusCodes.Status201Created, newComment);
            }

            return BadRequest();
        }
    }
}
