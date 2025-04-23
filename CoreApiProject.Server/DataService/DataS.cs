using CoreApiProject.Server.Models;

using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.DataService
{
    public class DataS : IDataService.IData
    {
        private readonly MyDbContext _context;

        public DataS(MyDbContext context)
        {

            _context = context;

        }


        public List<Movie> GetMovies()
        {

            var gets = _context.Movies.ToList();
            return gets;

        }

        public List<Movie> GetMoviesByCategory(int categoryId)
        {

            var movies = _context.Movies.Where(m => m.CategoryId == categoryId).ToList();

            return movies;


        }

        public List<MovieCategory> GetAllCategories()
        {
            return _context.MovieCategories.ToList();
        }




    

       
        public List<User> GetAllUsers()
        {
            var AllUsers = _context.Users.ToList();

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
                //categoriesQuery = categoriesQuery.Where(c => c.IsVisible);
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


        public void DeleteCategory(int id, bool isAdmin)
        {
            var category = _context.MovieCategories.Find(id);

            if (category != null)
            {
                if (isAdmin)
                {
                    // فقط المشرف يمكنه حذف الفئة أو إخفاؤها
                    category.IsVisible = false; // إخفاء الفئة بدلاً من حذفها
                    _context.SaveChanges();
                }
                //else
                //{
                //    throw new UnauthorizedAccessException("Only admin can delete or hide categories.");
                //}
            }
        }



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

        public bool AddFeedBack(ContactDTO FeedBack)
        {

            if(FeedBack == null)
            {  return false; }


            var Contact = new ContactU();

            Contact.Name = FeedBack.name;
            Contact.Email = FeedBack.email;
            Contact.Phone = FeedBack.phone;
            Contact.Subject = FeedBack.subject;
            Contact.Message = FeedBack.message;
            Contact.SubmissionDate = DateTime.Now;




            _context.ContactUs.Add(Contact);
            _context.SaveChanges();

            return true;


        }

        public List<ContactU> GetContacts()
        {
           
            var AllData = _context.ContactUs.ToList();

            return AllData;

        }


        public bool AddNewRoom(RoomDTO room)
        {
            var NewRoom = new Room
            {
                RoomName = room.RoomName,
                Capacity = room.Capacity,
                RoomDescription = room.RoomDescription,
                Image = room.Image // ✅ URL string
            };

            _context.Rooms.Add(NewRoom);
            _context.SaveChanges();

            return true;
        }



        public List<Room> GetAllRooms()
        {

            var AllData = _context.Rooms.ToList();

            return AllData;

        }



        public bool AddAvailability(RoomAvailabilityDTO Addava)
        {
            if (Addava == null) return false;

            try
            {
                var NewAVA = new RoomAvailability
                {
                    //RoomId = Addava.RoomId,
                    //PrivateRoomId = Addava.PrivateRoomId,
                    AvailableDay = Addava.AvailableDay,
                    StartTime = TimeOnly.Parse(Addava.StartTime!),
                    EndTime = TimeOnly.Parse(Addava.EndTime!),
                    //IsAvailable = true
                };

                _context.RoomAvailabilities.Add(NewAVA);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }




        // PrivateRoom

        public List<PrivateBookingViewDTO> GetAll()
        {
            try
            {
                var privateBookings = _context.PrivateBookings
                    .Include(pb => pb.PrivateRoom)  // تأكد من تحميل بيانات الغرفة الخاصة
                    .Include(pb => pb.Movie)        // تأكد من تحميل بيانات الفيلم
                    .Include(pb => pb.User)         // تأكد من تحميل بيانات المستخدم
                    .Select(pb => new PrivateBookingViewDTO
                    {
                        Id = pb.Id,
                        MovieName = pb.Movie != null ? pb.Movie.Title : "No Movie",   // اسم الفيلم
                        RoomName = pb.PrivateRoom != null ? pb.PrivateRoom.Vipname : "No Room", // اسم الغرفة
                        BookingDate = pb.BookingDate.HasValue ? DateOnly.FromDateTime(pb.BookingDate.Value) : DateOnly.MinValue,  // تحويل DateTime إلى DateOnly
                        TotalPrice = pb.TotalPrice ?? 0,   // السعر
                        PaymentStatus = pb.PaymentStatus ?? "Unknown",  // حالة الدفع
                        Status = pb.Status ?? "Pending"    // حالة الحجز
                    }).ToList();

                return privateBookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<PrivateBookingViewDTO>();
            }
        }








        //public PrivateBookingDTO GetById(int id)
        //{
        //    var booking = _context.PrivateBookings.FirstOrDefault(b => b.Id == id);
        //    if (booking == null) return null;

        //    return new PrivateBookingDTO
        //    {
        //        Id = booking.Id,
        //        UserId = booking.UserId,
        //        PrivateRoomId = booking.PrivateRoomId,
        //        MovieId = booking.MovieId,
        //        StartTime = booking.StartTime,
        //        EndTime = booking.EndTime,
        //        TotalPrice = booking.TotalPrice,
        //        PaymentMethod = booking.PaymentMethod
        //    };

        //}

        //public void Add(PrivateBookingDTO dto)
        //{
        //    var booking = new PrivateBooking
        //    {
        //        UserId = dto.UserId,
        //        PrivateRoomId = dto.PrivateRoomId,
        //        MovieId = dto.MovieId,
        //        StartTime = dto.StartTime,
        //        EndTime = dto.EndTime,
        //        TotalPrice = dto.TotalPrice,
        //        PaymentMethod = dto.PaymentMethod
        //    };

        //    _context.PrivateBookings.Add(booking);
        //    _context.SaveChanges();
        //}

        //public void Update(int id, PrivateBookingDTO dto)
        //{
        //    var existing = _context.PrivateBookings.FirstOrDefault(b => b.Id == id);
        //    if (existing == null) return;

        //    existing.UserId = dto.UserId;
        //    existing.PrivateRoomId = dto.PrivateRoomId;
        //    existing.MovieId = dto.MovieId;
        //    existing.StartTime = dto.StartTime;
        //    existing.EndTime = dto.EndTime;
        //    existing.TotalPrice = dto.TotalPrice;
        //    existing.PaymentMethod = dto.PaymentMethod;

        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var booking = _context.PrivateBookings.FirstOrDefault(b => b.Id == id);
        //    if (booking != null)
        //    {
        //        _context.PrivateBookings.Remove(booking);
        //        _context.SaveChanges();
        //    }
        //}







        // Private Room operations
        public List<PrivateRoomDTO1> GetAllPrivateRooms()
        {
            return _context.PrivateRooms
                .Include(pr => pr.RoomAvailabilities) // تأكد من تضمين البيانات المرتبطة
                .ThenInclude(ra => ra.Room)  // تأكد من تضمين البيانات المرتبطة بالغرف
                .Select(pr => new PrivateRoomDTO1
                {
                    //Id = pr.Id,
                    //// إزالة roomId لأنه تم حذفه من قاعدة البيانات
                    //RoomName = pr.RoomAvailabilities != null && pr.RoomAvailabilities.Any()
                    //    ? pr.RoomAvailabilities.FirstOrDefault().Room != null
                    //        ? pr.RoomAvailabilities.FirstOrDefault().Room.RoomName
                    //        : null
                    //    : null,
                    VIPName = pr.Vipname,
                    VIPDescription = pr.Vipdescription,
                    VIPPrice = pr.Vipprice ?? 0,
                    Capacity = pr.Capacity ?? 0
                })
                .ToList();
        }







        public void AddPrivateRoom(PrivateRoomDTO1 dto)
        {
            var privateRoom = new PrivateRoom
            {
                Vipname = dto.VIPName,
                Vipdescription = dto.VIPDescription,
                Vipprice = dto.VIPPrice,
                Capacity = dto.Capacity,
                RoomAvailabilities = dto.Availability.Select(a => new RoomAvailability
                {
                    AvailableDay = a.AvailableDay,
                    //StartTime = a.StartTime,
                    //EndTime = a.EndTime
                }).ToList()
            };

            _context.PrivateRooms.Add(privateRoom);
            _context.SaveChanges();
        }




        public List<PrivateRoomWithAvailabilityDto> GetPrivateRoomsWithAvailability()
        {
            var result = _context.PrivateRooms
                .Include(r => r.RoomAvailabilities)
                .Select(r => new PrivateRoomWithAvailabilityDto
                {
                    Id = r.Id,
                    // إزالة RoomName بناءً على البيانات المرتبطة (من RoomAvailabilities أو طرق أخرى)
                    RoomName = r.RoomAvailabilities != null && r.RoomAvailabilities.Any()
                        ? r.RoomAvailabilities.FirstOrDefault().Room != null
                            ? r.RoomAvailabilities.FirstOrDefault().Room.RoomName
                            : null
                        : null,

                    VipName = r.Vipname,               // تأكد من صحة اسم الحقل في DB
                    VipDescription = r.Vipdescription, // تأكد من صحة اسم الحقل في DB
                    VipPrice = r.Vipprice ?? 0,        // تأكد من أنه Nullable عشان تستخدم ?? 0
                    Capacity = r.Capacity ?? 0,        // تأكد من أنه Nullable عشان لا يحدث مشكلة

                    // لا يتم تضمين RoomId هنا لأنه تم حذفه من قاعدة البيانات
                    Availability = r.RoomAvailabilities.Select(a => new RoomAvailabilityDTO
                    {
                        //Id = a.Id,
                        //// إزالة RoomId هنا لأنه غير موجود بعد الآن
                        //PrivateRoomId = a.PrivateRoomId,
                        AvailableDay = a.AvailableDay,
                        //StartTime = a.StartTime,
                        //EndTime = a.EndTime
                    }).ToList()
                })
                .ToList();

            return result;
        }



        public void AddPrivateRoomWithAvailability(PrivateRoomWithAvailabilityDto dto)
        {
            var privateRoom = new PrivateRoom
            {
                Vipname = dto.VipName,
                Vipdescription = dto.VipDescription,
                Vipprice = dto.VipPrice,
                Capacity = dto.Capacity
            };



            _context.PrivateRooms.Add(privateRoom);
            _context.SaveChanges(); // يحفظ الغرفة أولاً

            // الآن نضيف الـ Availability
            foreach (var availability in dto.Availability)
            {
                var roomAvailability = new RoomAvailability
                {
                    PrivateRoomId = privateRoom.Id,
                    AvailableDay = availability.AvailableDay,
                    //StartTime = availability.StartTime,
                    //EndTime = availability.EndTime
                };

                _context.RoomAvailabilities.Add(roomAvailability);
            }
        }
        public void Delete(int id)
        {
            var booking = _context.PrivateBookings.FirstOrDefault(b => b.Id == id);
            if (booking != null)
            {
                _context.PrivateBookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        ///////////////Registeration//////////////////
        public bool SignUp(SignUpDTO user)
        {
            var dbUser = new Models.User();
            dbUser.FullName = user.FullName;
            dbUser.Email = user.Email;
            dbUser.Password = user.Password;
            dbUser.Phone = user.Phone;
            dbUser.Role = "User";  // هنا السطر المهم

            _context.Users.Add(dbUser);
            _context.SaveChanges();
            return true;


        }

        ///////////////LOGIN//////////////////
        public User? LogIn(LoginDTO user, IHttpContextAccessor httpContextAccessor)
        {
            var foundUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (foundUser != null)
            {
                return foundUser;
            }

            _context.SaveChanges(); // نحفظ كل الأوقات بعد ما نضيفها
        
            return null;
        }





    }


}
