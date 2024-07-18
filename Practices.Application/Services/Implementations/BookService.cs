using AutoMapper;
using Practices.Application.DTOs;
using Practices.Application.Services.Interfaces;
using Practices.Domain.Entities;
using Practices.Domain.UnitOfWorkInterface;

namespace Practices.Application.Services.Implementations;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public BookService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthorWithBooksDTO?> GetAuthorWithBooksById(int id, CancellationToken cancellation)
    {
        var author = await _unitOfWork.Authors.GetById(id);
        if (author == null) return null;
        return _mapper.Map<AuthorWithBooksDTO>(author);
    }

    public async Task<BookDTO?> GetBookById(int id,CancellationToken cancellation)
    {
        var book = await _unitOfWork.Books.GetById(id);
        if (book == null) return null;
        return _mapper.Map<BookDTO>(book);
    }

    public async Task<AuthorWithBooksDTO?> CreateAuthor(CreateAuthorDTO authorDTO,CancellationToken cancellation)
    {
        var existingAuthor = await _unitOfWork.Authors.GetByName(authorDTO.Name, cancellation);
        if(existingAuthor != null) return null;

        var authorEntity = _mapper.Map<Author>(authorDTO);
        _unitOfWork.Authors.Add(authorEntity);
        await _unitOfWork.SaveChangesAsync(cancellation);

        return _mapper.Map<AuthorWithBooksDTO>(authorEntity);
    }

    public async Task<BookDTO?> CreateBook(int authorId,CreateBookDTO bookDTO,CancellationToken cancellation)
    {
        var author = await _unitOfWork.Authors.GetById(authorId);
        if(author == null) return null;

        var bookEntity = _mapper.Map<Book>(bookDTO);
        _unitOfWork.Books.AddBook(authorId,bookEntity);
        await _unitOfWork.SaveChangesAsync(cancellation);

        return _mapper.Map<BookDTO>(bookEntity);
    }
}
