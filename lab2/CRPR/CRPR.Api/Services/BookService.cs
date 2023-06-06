using CRPR.Api.Data;
using CRPR.Api.Interfaces;
using CRPR.Api.Models.Requests;
using CRPR.Api.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace CRPR.Api.Services;

public class BookService : IBookService
{
    private readonly DataContext _context;

    public BookService(DataContext context) => _context = context;

    public async Task<bool> CreateBookAsync(BookCreateRequest model)
    {
        var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            AuthorName = model.AuthorName,
            ImageUrl = model.ImageUrl,
            Description = model.Description,
            Title = model.Title
        };

        await _context.AddAsync(book);
        var result = await _context.SaveChangesAsync();
        
        return result > 0;
    }

    public async Task<BookResponse> GetBookByIdAsync(string bookId)
    {
        var entity = await _context.Books
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.Id == bookId);
        
        return new BookResponse
        {
            Id = entity.Id,
            AuthorName = entity.AuthorName,
            ImageUrl = entity.ImageUrl,
            Description = entity.Description,
            Title = entity.Title
        };
    }
        

    public async Task<List<BookResponse>> GetBooksAsync()
    {
        var books = await _context.Books
            .AsNoTracking()
            .ToListAsync();

        return books.Select(entity => new BookResponse
        {
            Id = entity.Id,
            AuthorName = entity.AuthorName,
            ImageUrl = entity.ImageUrl,
            Description = entity.Description,
            Title = entity.Title
        }).ToList();
    }
}