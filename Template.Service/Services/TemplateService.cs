using Template.Service.IServices;

namespace Template.Service.Services;

public class TemplateService : ITemplateService
{
    //private readonly IAuthorRepository _authorRepository;
    //private readonly IBookAuthorRepository _bookAuthorRepository;
    //private readonly IMapper _mapper;
    //public TemplateService(
    //    IAuthorRepository authorRepository,
    //    IBookAuthorRepository bookAuthorRepository,
    //    IMapper mapper)
    //{
    //    _authorRepository = authorRepository;
    //    _bookAuthorRepository = bookAuthorRepository;
    //    _mapper = mapper;
    //}

    //public async Task<AuthorResponse> CreateAuthor(CreateAuthorRequest createAuthorRequest)
    //{
    //    var author = new Author()
    //    {
    //        Id = Guid.NewGuid(),
    //        BirthDate = createAuthorRequest.BirthDate,
    //        Firstname = createAuthorRequest.Firstname,
    //        LastName = createAuthorRequest.LastName,
    //        IsDeleted = false,
    //    };
    //    await _authorRepository.AddAsync(author);
    //    return _mapper.Map<AuthorResponse>(author);
    //}
    //public async Task<AuthorResponse> UpdateAuthor(EditAuthorRequest editAuthorRequest)
    //{
    //    var author = await _authorRepository.GetByIdAsync(editAuthorRequest.AuthorID);
    //    ValidationHelper.AuthorValidation(author);

    //    author.BirthDate = editAuthorRequest.BirthDate;
    //    author.Firstname = editAuthorRequest.Firstname;
    //    author.LastName = editAuthorRequest.LastName;

    //    await _authorRepository.UpdateAsync(author);
    //    return _mapper.Map<AuthorResponse>(author);
    //}

    //public async Task<bool> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest)
    //{
    //    var author = await _authorRepository.GetByIdAsync(deleteAuthorRequest.Id);
    //    ValidationHelper.AuthorValidation(author);

    //    if (author.IsDeleted)
    //        throw new BadRequestException("Author with this id doesn't exist");

    //    var bookauthor = await _bookAuthorRepository.LoadAsync();
    //    if (bookauthor.Any(x => x.Id == deleteAuthorRequest.Id && x.IsDeleted == false))
    //        throw new BadRequestException($"Please Delete all books firstly, in order to delete  {author.Firstname} {author.LastName} author");

    //    author.IsDeleted = true;
    //    await _authorRepository.UpdateAsync(author);

    //    return true;
    //}

    //public async Task<AuthorResponse?> GetAuthorById(Guid id)
    //{
    //    var author = await _authorRepository.GetByIdAsync(id) ?? throw new Exception("author not found");
    //    return new AuthorResponse()
    //    {
    //        Firstname = author.Firstname,
    //        LastName = author.LastName,
    //        Id = author.Id
    //    };
    //}

    //public async Task<IEnumerable<AuthorResponse>?> GetAllAuthors()
    //{
    //    var result = await _authorRepository.LoadAsync();

    //    if (result.Any())
    //    {
    //        return result.Select(x => new AuthorResponse()
    //        {
    //            Firstname = x.Firstname,
    //            LastName = x.LastName,
    //            Id = x.Id
    //        });
    //    }
    //    return null;
    //}

    //public async Task<IEnumerable<AuthorResponse>?> SearchAuthor(string FirstName)
    //{
    //    var Authors = await _authorRepository.LoadAsync() ?? throw new NotFoundException("Authors not foud");

    //    var filtedAuthors = Authors.Where(x => x.IsDeleted == false && x.Firstname == FirstName)?.ToList() ?? throw new NotFoundException("Authors not foud");

    //    return filtedAuthors.Select(x => new AuthorResponse()
    //    {
    //        Id = x.Id,
    //        Firstname = x.Firstname,
    //        LastName = x.LastName,
    //    });
    //}
}