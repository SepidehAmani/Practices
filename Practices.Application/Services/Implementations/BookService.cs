using AutoMapper;
using Practices.Application.DTOs;
using Practices.Application.Services.Interfaces;
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
}
