using CRPR.Api.Interfaces;
using CRPR.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CRPR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService) => _bookService = bookService;
    
    [HttpPost]
    public async Task<IActionResult> CreateBookAsync(BookCreateRequest request) 
        => Ok(await _bookService.CreateBookAsync(request));

    [HttpGet("single")]
    public async Task<IActionResult> GetBookByIdAsync(string bookId) 
        => Ok(await _bookService.GetBookByIdAsync(bookId));
    
    [HttpGet("all")]
    public async Task<IActionResult> GetBooksAsync() 
        => Ok(await _bookService.GetBooksAsync());
}