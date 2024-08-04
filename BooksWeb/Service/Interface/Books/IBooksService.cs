using Contract.Dto.Books;

namespace Service.Interface.Books
{
    public interface IBooksService
    {
        Task<IEnumerable<BooksDto>> All();
        Task<BooksDto> GetId(int id);
        Task<BooksDto> Update(BooksDto dto);
        Task<BooksDto> Create(BooksDto dto);
        Task<bool> Delete(int id);

    }
}
