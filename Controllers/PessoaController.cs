using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet("GetAllPessoa")]
        public async Task<ActionResult<List<PessoaModel>>> GetAllPessoa()
        {
            List<PessoaModel> pessoa = await _pessoaRepositorio.GetAll();
            return Ok(pessoa);
        }

        [HttpGet("GetPessoaId/{id}")]
        public async Task<ActionResult<PessoaModel>> GetPessoaId(int id)
        {
            PessoaModel usuario = await _pessoaRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreatePessoa")]
        public async Task<ActionResult<PessoaModel>> InsertPessoa([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel pessoa = await _pessoaRepositorio.InsertPessoa(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPut("UpdatePessoa/{id:int}")]
        public async Task<ActionResult<PessoaModel>> UpdatePessoa(int id, [FromBody] PessoaModel pessoaModel)
        {
            pessoaModel.Id_Pessoa = id;
            PessoaModel pessoa = await _pessoaRepositorio.UpdatePessoa(pessoaModel, id);
            return Ok(pessoa);
        }

        [HttpDelete("DeletePessoa/{id:int}")]
        public async Task<ActionResult<PessoaModel>> DeletePessoa(int id)
        {
            bool deleted = await _pessoaRepositorio.DeletePessoa(id);
            return Ok(deleted);
        }
    }
}
