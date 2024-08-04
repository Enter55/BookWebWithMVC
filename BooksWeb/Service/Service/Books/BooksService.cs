using AutoMapper;
using Contract.Dto.Books;
using Persistence;
using Service.Interface.Books;

namespace Service.Service.Books
{
    public class BooksService : IBooksService
    {
        public readonly IMapper _mapper;
        public readonly DatabaseContext _DatabaseContext;

        public BooksService(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _DatabaseContext = databaseContext;
        }
        public async Task<IEnumerable<BooksDto>> All()
        {
            var model = _DatabaseContext.Books.ToList();
            var saveChangedAsync = await _DatabaseContext.SaveChangesAsync();
            return model.Select(x => _mapper.Map<BooksDto>(x)).ToList();
        }

        public async Task<BooksDto> GetId(int id)
        {
            var model = _DatabaseContext.Books.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                throw new KeyNotFoundException("Id wurde nicht gefunden");
            }
            await _DatabaseContext.SaveChangesAsync();
            return _mapper.Map<BooksDto>(model);
        }

        public async Task<BooksDto> Create(BooksDto dto)
        {
            var model = _mapper.Map<BooksDto>(dto);
            var saveChangedAsync = await _DatabaseContext.SaveChangesAsync();
            return _mapper.Map<BooksDto>(model);

        }

        public async Task<bool> Delete(int id)
        {
            var mode = _DatabaseContext.Books.FirstOrDefault(x => x.Id == id);
            if (mode != null)
            {
                _DatabaseContext.Remove(mode);
            }
            var saveChangedAsyns = await _DatabaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<BooksDto> Update(BooksDto dto)
        {
            throw new NotImplementedException();
            /*
           var model = _mapper.Map<Books>(dto);
           _DatabaseContext.Books.Update(model);
           var saveChangedAsync = await _DatabaseContext.SaveChangesAsync();
           return _mapper.Map(model, dto);
           */
        }
    }
}
