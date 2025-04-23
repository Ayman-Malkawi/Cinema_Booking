    using System.Collections.Generic;
using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.Models;


namespace CoreApiProject.Server.IDataService
{
    public interface IData 
    {
        public List<Movie> GetMovies();

        public List<Movie> GetMoviesByCategory(int categoryId);
        public List<MovieCategory> GetAllCategories();

        public List<User> GetAllUsers();

        public User GetUserById(int id);
        public User? LogIn(LoginDTO user, IHttpContextAccessor httpContextAccessor);
        public void AddToBlacklist(BlacklistDTO dto);
        public void UpdateUser(User user);

        public List<MovieCategoryDTO> GetAllCategories(bool isAdmin);

        public void AddCategory(MovieCategoryDTO dto);
        public void DeleteCategory(int id, bool isAdmin);

        public void EditCategory(int id, MovieCategoryDTO dto);


        public bool AddNewRoom(RoomDTO room);

        public List<MovieDTO> GetAllMovies();

        public Movie GetMovieById(int id);

        public bool AddMovie(MovieDTO dto);


        public bool EditMovie(int id, MovieDTO dto);

        public bool ToggleMovieViable(int movieId);


        public void AddBooking(Booking booking);
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(int id);
        public void CancelBooking(int id);

        public bool AddFeedBack(ContactDTO FeedBack);


        public List<PrivateBookingViewDTO> GetAll();
        //public PrivateBookingDTO GetById(int id);

        //public void Add(PrivateBookingDTO dto);

        public List<ContactU> GetContacts();
        //public void Update(int id, PrivateBookingDTO dto);
        //public void Delete(int id);



        public List<PrivateRoomDTO1> GetAllPrivateRooms();

        public void AddPrivateRoom(PrivateRoomDTO1 dto);


        public List<PrivateRoomWithAvailabilityDto> GetPrivateRoomsWithAvailability();


        public void AddPrivateRoomWithAvailability(PrivateRoomWithAvailabilityDto dto);


        public List<Room> GetAllRooms();

        public bool AddAvailability(RoomAvailabilityDTO Addava);
        public bool SignUp(SignUpDTO user);
    }
}
