using Bookify.Data;

namespace Bookify.Models
{
    public class User_Type
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid? TypeId { get; set; }
        public Type? Type { get; set; }

        public static User_Type GetUserTypeByUserId(Guid userId, BookifyDbContext bookifyDbContext)
        {
            var ut = bookifyDbContext.User_Types.FirstOrDefault(ut => ut.UserId == userId);

            if (ut == null)
                return null;

            return ut;
        }

        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.User_Types.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}
