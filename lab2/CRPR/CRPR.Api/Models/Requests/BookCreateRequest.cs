namespace CRPR.Api.Models.Requests;

public class BookCreateRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string AuthorName { get; set; }
    public string ImageUrl { get; set; }
}