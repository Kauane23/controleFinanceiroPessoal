using controleFinanceiro.Data;
using controleFinanceiro.Dtos;
using controleFinanceiro.Dtos.Responses;
using controleFinanceiro.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace controleFinanceiro.Services
{
    public class ContaService(AppDbContext context, IMapper mapper)
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<ContaResponseDto>> FindAll()
        {
            return await _context.Contas
                .ProjectTo<ContaResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ContaResponseDto?> FindById(int id)
        {
            return await _context.Contas
                .ProjectTo<ContaResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContaResponseDto> Create(ContaDto data)
        {
            if (data.SaldoAtual is null)
            {
                throw new ArgumentException("O saldo é obrigatório.");
            }

            var usuarioExiste = await _context.Usuarios
                .AnyAsync(x => x.Id == data.UsuarioId);

            if (!usuarioExiste)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            var conta = _mapper.Map<Conta>(data);

            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();

            return _mapper.Map<ContaResponseDto>(conta);
        }

        public async Task<bool> Update(int id, ContaDto data)
        {
            var conta = await _context.Contas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (conta is null)
            {
                return false;
            }

            if (data.SaldoAtual is null)
            {
                throw new ArgumentException("O saldo é obrigatório.");
            }

            var usuarioExiste = await _context.Usuarios
                .AnyAsync(x => x.Id == data.UsuarioId);

            if (!usuarioExiste)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            _mapper.Map(data, conta);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var conta = await _context.Contas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (conta is null)
            {
                return false;
            }

            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}