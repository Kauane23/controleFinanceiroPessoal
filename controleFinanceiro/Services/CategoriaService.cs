using controleFinanceiro.Data;
using controleFinanceiro.Dtos;
using controleFinanceiro.Dtos.Responses;
using controleFinanceiro.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace controleFinanceiro.Services
{
    public class CategoriaService(AppDbContext context, IMapper mapper)
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<CategoriaResponseDto>> FindAll()
        {
            return await _context.Categorias
                .ProjectTo<CategoriaResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CategoriaResponseDto?> FindById(int id)
        {
            return await _context.Categorias
                .ProjectTo<CategoriaResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CategoriaResponseDto> Create(CategoriaDto data)
        {
            var categoria = _mapper.Map<Categoria>(data);

            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoriaResponseDto>(categoria);
        }

        public async Task<bool> Update(int id, CategoriaDto data)
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categoria is null)
            {
                return false;
            }

            _mapper.Map(data, categoria);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categoria is null)
            {
                return false;
            }

            _context.Categorias.Remove(categoria);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}