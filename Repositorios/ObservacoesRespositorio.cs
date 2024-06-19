using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio : IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbCotext)
        {
            _dbContext = dbCotext;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.Id_Observacoes == id);
        }

        public async Task<ObservacoesModel> InsertObservacoes(ObservacoesModel observacoes)
        {
            await _dbContext.Observacoes.AddAsync(observacoes);
            await _dbContext.SaveChangesAsync();
            return observacoes;

        }

        public async Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel observacao, int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacoes.ObservacoesDescricao = observacao.ObservacoesDescricao;
                observacoes.ObservacoesLocal = observacao.ObservacoesLocal;
                observacoes.ObservacoesData = observacao.ObservacoesData;
                observacoes.PessoaId = observacao.PessoaId;
                observacoes.UsuarioId = observacao.UsuarioId;
                _dbContext.Observacoes.Update(observacoes);
                await _dbContext.SaveChangesAsync();
            }
            return observacoes;
        }

        public async Task<bool> DeleteObservacoes(int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(observacoes);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
