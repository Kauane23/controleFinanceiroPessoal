using AutoMapper;
using AutoMapper.QueryableExtensions;
using controleFinanceiro.Data;
using controleFinanceiro.Dtos;
using controleFinanceiro.Dtos.Responses;
using controleFinanceiro.Entities;
using Microsoft.EntityFrameworkCore;

namespace controleFinanceiro.Services
{
    public class MovimentacaoService(AppDbContext context, IMapper mapper)
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<MovimentacaoResponseDto>> FindAll()
        {
            return await _context.Movimentacoes
                .ProjectTo<MovimentacaoResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MovimentacaoResponseDto?> FindById(int id)
        {
            return await _context.Movimentacoes
                .ProjectTo<MovimentacaoResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MovimentacaoResponseDto> Create(MovimentacaoDto data)
        {
            var movimentacao = _mapper.Map<Movimentacao>(data);

            await _context.Movimentacoes.AddAsync(movimentacao);
            await _context.SaveChangesAsync();

            return (await FindById(movimentacao.Id))!;
        }

        public async Task<bool> Update(int id, MovimentacaoDto data)
        {
            var movimentacao = await _context.Movimentacoes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movimentacao is null)
            {
                return false;
            }

            _mapper.Map(data, movimentacao);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var movimentacao = await _context.Movimentacoes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movimentacao is null)
            {
                return false;
            }

            _context.Movimentacoes.Remove(movimentacao);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}