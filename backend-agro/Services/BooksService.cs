using backend_agro.DTO.Request;
using backend_agro.DTO.Response;
using backend_agro.Repositorys.Interface;
using backend_agro.Services.Interface;

namespace backend_agro.Services;
public class BooksService : IBooksService
{
    IBooksRepository _repository;

    public BooksService(IBooksRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<BookResponse> GetAll()
        => from book in _repository.GetAll() select new BookResponse(book);

    public BookResponse GetById(int id)
    {
        var book = _repository.Get(id);

        if (book is null)
            throw new Exceptions.NotFoundBookException();

        return new BookResponse(book);
    }

    public IEnumerable<BookResponse> GetByParameters(BooksQueryParameters parameters)
    {
        var booksFiltered = parameters.Filtered(from book in _repository.GetAll() select new BookResponse(book));

        if (booksFiltered.Count() == 0)
            throw new Exceptions.NotFoundBookException();

        return booksFiltered;
    }

    public ShippingResponse ShippingPrice(int id)
    {
        double percentage = 0.2;

        var book = GetById(id);

        if (book is null)
            throw new Exceptions.NotFoundBookException();

        ShippingResponse shipping = new ShippingResponse()
        {
            id = book.id,
            price = percentage * book.price,
            book_price = book.price,
        };

        shipping.total_price = shipping.price + book.price;

        return shipping;
    }
}