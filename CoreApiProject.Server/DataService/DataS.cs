using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.DataService
{
    public class DataS : IData
    {
        private readonly MyDbContext _context;

        public DataS(MyDbContext context)
        {
            _context = context;
        }


       public List<User> GetAllUsers()
        {
           var AllUsers =  _context.Users.ToList();
           
            return AllUsers;
        
        }


        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }




        public void AddToBlacklist(BlacklistDTO dto)
        {
            var newEntry = new Blacklist
            {
                UserId = dto.UserId,
                Reason = dto.Reason
            };

            _context.Blacklists.Add(newEntry);
            _context.SaveChanges();
        }




        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FullName = user.FullName;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.Role = user.Role;
                _context.SaveChanges();
            }
        }







        // category 



        public List<MovieCategoryDTO> GetAllCategories(bool isAdmin)
        {
            var categoriesQuery = _context.MovieCategories.AsQueryable();

            // إذا كان المستخدم ليس مشرفًا، يتم تصفية الفئات بحيث يتم إظهار فقط الفئات التي تكون مرئية
            if (!isAdmin)
            {
                categoriesQuery = categoriesQuery.Where(c => c.IsVisible);
            }

            var categories = categoriesQuery.ToList();

            // تحويل الكائنات إلى DTO
            var categoryDTOs = categories.Select(category => new MovieCategoryDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                IsVisible = category.IsVisible // إذا أردت إرسال حالة الظهور
            }).ToList();

            return categoryDTOs;
        }





        public void AddCategory(MovieCategoryDTO dto)
        {
            var category = new MovieCategory
            {
                CategoryName = dto.CategoryName
            };

            _context.MovieCategories.Add(category);
            _context.SaveChanges();
        }


        //public void DeleteCategory(int id, bool isAdmin)
        //{
        //    var category = _context.MovieCategories.Find(id);

        //    if (category != null)
        //    {
        //        if (isAdmin)
        //        {
        //            // فقط المشرف يمكنه حذف الفئة أو إخفاؤها
        //            category.IsVisible = false; // إخفاء الفئة بدلاً من حذفها
        //            _context.SaveChanges();
        //        }
        //        else
        //        {
        //            throw new UnauthorizedAccessException("Only admin can delete or hide categories.");
        //        }
        //    }
        //}



        public void EditCategory(int id, MovieCategoryDTO dto)
        {
            var category = _context.MovieCategories.Find(id);
            if (category != null)
            {
                category.CategoryName = dto.CategoryName;
                _context.SaveChanges();
            }
        }







        // Movies 


        public List<MovieDTO> GetAllMovies()
        {
            var allMovies = _context.Movies
                                    .Include(m => m.Category)
                                     .Where(m => m.IsViable)
                                    .ToList();

            var movieDTOs = allMovies.Select(movie => new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration.Value,
                CategoryId = movie.CategoryId.Value,
                CategoryName = movie.Category != null ? movie.Category.CategoryName : "",
                ReleaseDate = movie.ReleaseDate.Value,
                Image = movie.Image,
                TicketPrice = movie.TicketPrice.Value,
                Rating = movie.Rating.Value
            }).ToList();

            return movieDTOs;

        }




        public bool AddMovie(MovieDTO dto)
        {
            Console.WriteLine("DTO CategoryId: " + dto.CategoryId);

            var category = _context.MovieCategories.FirstOrDefault(c => c.Id == dto.CategoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return false;  // Category not found
            }

            Console.WriteLine("Category found: " + category.CategoryName);

            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.Duration,
                CategoryId = dto.CategoryId,
                ReleaseDate = dto.ReleaseDate,
                Image = dto.Image,
                TicketPrice = dto.TicketPrice,
                Rating = dto.Rating,
                IsViable = true
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return true;
        }




        public bool EditMovie(int id, MovieDTO dto)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return false;

            var categoryExists = _context.MovieCategories.Any(c => c.Id == dto.CategoryId);
            if (!categoryExists)
                return false;

            // Update movie details
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.Duration = dto.Duration;
            movie.CategoryId = dto.CategoryId;
            movie.ReleaseDate = dto.ReleaseDate;
            movie.Image = dto.Image;
            movie.TicketPrice = dto.TicketPrice;
            movie.Rating = dto.Rating;

            _context.SaveChanges();
            return true;
        }


        public bool ToggleMovieViable(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
                return false;

            movie.IsViable = !movie.IsViable;
            _context.SaveChanges();
            return true;
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id); // بدون async/await
        }



        // Booking


        // إضافة الحجز
        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        // الحصول على جميع الحجوزات
        public List<Booking> GetAllBookings()
        {
            return _context.Bookings
                           .Include(b => b.User)
                           .Include(b => b.Room)
                           .Include(b => b.Movie)
                           .ToList();
        }

        // الحصول على حجز حسب الـ ID
        public Booking GetBookingById(int id)
        {
            return _context.Bookings
                           .FirstOrDefault(b => b.Id == id);
        }

        // إلغاء الحجز
        public void CancelBooking(int id)
        {
            var booking = GetBookingById(id);
            if (booking != null)
            {
                booking.Cancelled = true;
                booking.CancellationDate = DateTime.Now;
                _context.SaveChanges();
            }
        }



    }
}
