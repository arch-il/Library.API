using Library.API.Database.Context;
using Library.API.Database.Entities;
using Library.API.Interfaces;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _db;
        private readonly ILogger<BookService> _logger;

        public BookService(LibraryContext db, ILogger<BookService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<CustomResponseModel<IEnumerable<ViewBookModel>>> GetAll()
        {
            try
            {
                var books = await _db.Books.ToListAsync();

                var bookViewModels = new List<ViewBookModel>();

                foreach (var book in books)
                {
                    bookViewModels.Add(new ViewBookModel()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author,
                        ReleaseDate = book.ReleaseDate,
                        NumberOfPages = book.NumberOfPages,
                        Description = book.Description
                    });
                }

                return new CustomResponseModel<IEnumerable<ViewBookModel>>()
                {
                    StatusCode = 200,
                    Result = bookViewModels
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new CustomResponseModel<IEnumerable<ViewBookModel>>()
                {
                    StatusCode = 400,
                    Message = "Something went wrong!"
                };
            }
        }
        

        public async Task<CustomResponseModel<ViewBookModel>> Get(int id)
        {
            try
            {
                var book = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);

                if (book == null)
                    return new CustomResponseModel<ViewBookModel>()
                    {
                        StatusCode = 404,
                        Message = "Not Found!"
                    };

                var viewBookModel = new ViewBookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    ReleaseDate = book.ReleaseDate,
                    NumberOfPages = book.NumberOfPages,
                    Description = book.Description
                };

                return new CustomResponseModel<ViewBookModel>()
                {
                    StatusCode = 200,
                    Result = viewBookModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new CustomResponseModel<ViewBookModel>()
                {
                    StatusCode = 400,
                    Message = "Something went wrong!"
                };
            }
        }
        public async Task<CustomResponseModel<ViewBookModel>> Create(CreateBookModel createBookModel)
        {
            try
            {
                var book = new Book()
                {
                    Name = createBookModel.Name,
                    Author = createBookModel.Author,
                    ReleaseDate = createBookModel.ReleaseDate,
                    NumberOfPages = createBookModel.NumberOfPages,
                    Description = createBookModel.Description
                };

                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();

                var viewBookModel = new ViewBookModel()
                {
                    Name = createBookModel.Name,
                    Author = createBookModel.Author,
                    ReleaseDate = createBookModel.ReleaseDate,
                    NumberOfPages = createBookModel.NumberOfPages,
                    Description = createBookModel.Description
                };

                return new CustomResponseModel<ViewBookModel>()
                {
                    StatusCode = 200,
                    Result = viewBookModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new CustomResponseModel<ViewBookModel>()
                {
                    StatusCode = 400,
                    Message = "Something went wrong!"
                };
            }
        }
        public async Task<CustomResponseModel<ViewBookModel>> Delete(int id)
        {
            try
            {
                var book = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);

                if (book == null)
                    return new CustomResponseModel<ViewBookModel>()
                    {
                        StatusCode = 404,
                        Message = "Not Found!"
                    };

                _db.Remove(book);
                await _db.SaveChangesAsync();

                var viewBookModel = new ViewBookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    ReleaseDate = book.ReleaseDate,
                    NumberOfPages = book.NumberOfPages,
                    Description = book.Description
                };

                return new CustomResponseModel<ViewBookModel>()
                {
                    StatusCode = 200,
                    Result = viewBookModel
                };


            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new CustomResponseModel<ViewBookModel>()
                {
                    StatusCode = 400,
                    Message = "Something went wrong!"
                };
            }
        }
    }
}
