﻿using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbCotext)
        {
            _dbContext = dbCotext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Id_Usuario == id);
        }

        public async Task<UsuarioModel> InsertUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;

        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarios.UsuarioNome = usuario.UsuarioNome;
                usuarios.UsuarioTelefone = usuario.UsuarioTelefone;
                usuarios.UsuarioEmail = usuario.UsuarioEmail;
                usuarios.UsuarioSenha = usuario.UsuarioSenha;
                _dbContext.Usuario.Update(usuarios);
                await _dbContext.SaveChangesAsync();
            }
            return usuario;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuario = await GetById(id);
            if (usuario == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
