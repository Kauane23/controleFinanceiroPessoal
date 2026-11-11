using controleFinanceiro.Data;
using controleFinanceiro.Dtos;
using controleFinanceiro.Dtos.Responses;
using controleFinanceiro.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace controleFinanceiro.Services
{
    public class UsuarioService(AppDbContext context, IMapper mapper)
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<UsuarioResponseDto>> FindAll()
        {
            return await _context.Usuarios
                .ProjectTo<UsuarioResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UsuarioResponseDto?> FindById(int id)
        {
            return await _context.Usuarios
                .ProjectTo<UsuarioResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioResponseDto> Create(UsuarioDto data)
        {
            var usuario = _mapper.Map<Usuario>(data);

            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, data.Senha);

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioResponseDto>(usuario);
        }

        public async Task<bool> Update(int id, UsuarioDto data)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario is null)
            {
                return false;
            }

            _mapper.Map(data, usuario);

            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, data.Senha);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario is null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}