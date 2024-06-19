using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
        public class PessoaRepositorio : IPessoaRepositorio
        {
            private readonly Contexto _dbContext;

            public PessoaRepositorio(Contexto dbCotext)
            {
                _dbContext = dbCotext;
            }

            public async Task<List<PessoaModel>> GetAll()
            {
                return await _dbContext.Pessoa.ToListAsync();
            }

            public async Task<PessoaModel> GetById(int id)
            {
                return await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.Id_Pessoa == id);
            }

            public async Task<PessoaModel> InsertPessoa(PessoaModel pessoa)
            {
                await _dbContext.Pessoa.AddAsync(pessoa);
                await _dbContext.SaveChangesAsync();
                return pessoa;

            }

            public async Task<PessoaModel> UpdatePessoa(PessoaModel pessoa, int id)
            {
                PessoaModel pessoas = await GetById(id);
                if (pessoas == null)
                {
                    throw new Exception("Não encontrado.");
                }
                else
                {
                    pessoas.PessoaNome = pessoa.PessoaNome;
                    pessoas.PessoaRoupa = pessoa.PessoaRoupa;
                    pessoas.PessoaCor = pessoa.PessoaCor;
                    pessoas.PessoaSexo = pessoa. PessoaSexo;
                    pessoas.PessoaObservacao = pessoa.PessoaObservacao;
                    pessoas.PessoaFoto = pessoa.PessoaFoto;
                    pessoas.PessoaLocoalDesaparecimento = pessoa.PessoaLocoalDesaparecimento;
                    pessoas.PessoaDtDesaparecimento = pessoa.PessoaDtDesaparecimento;
                    pessoas.PessoaDtEncontro = pessoa.PessoaDtEncontro;
                    pessoas.PessoaStatus = pessoa.PessoaStatus;
                    pessoas.UsuarioId = pessoa.UsuarioId;
                    _dbContext.Pessoa.Update(pessoas);
                    await _dbContext.SaveChangesAsync();
                }
                return pessoa;
            }

            public async Task<bool> DeletePessoa(int id)
            {
                PessoaModel pessoa = await GetById(id);
                if (pessoa == null)
                {
                    throw new Exception("Não encontrado.");
                }

                _dbContext.Pessoa.Remove(pessoa);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
}
