using backend_agro.DTO.Request;
using backend_agro.DTO.Response;

namespace backend_agro.Services.Interface;
public interface IBooksService
{
    public IEnumerable<BookResponse> GetAll();

    public BookResponse GetById(int id);

    public IEnumerable<BookResponse> GetByParameters(BooksQueryParameters parameters);

    public ShippingResponse ShippingPrice(int id);

}