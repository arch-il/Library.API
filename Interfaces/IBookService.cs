using Library.API.Models;

namespace Library.API.Interfaces
{
    public interface IBookService
    {
        Task<CustomResponseModel<IEnumerable<ViewBookModel>>> GetAll();
        Task<CustomResponseModel<ViewBookModel>> Get(int id);
        Task<CustomResponseModel<ViewBookModel>> Create(CreateBookModel createBookModel);
        Task<CustomResponseModel<ViewBookModel>> Delete(int id);
    }
}
