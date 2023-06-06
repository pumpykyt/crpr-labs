using CRPR.Api.Models.Requests;
using CRPR.Api.Models.Responses;

namespace CRPR.Api.Interfaces;

public interface IBookService
{
    Task<bool> CreateBookAsync(BookCreateRequest model);
    Task<BookResponse> GetBookByIdAsync(string bookId);
    Task<List<BookResponse>> GetBooksAsync();
}