using Microsoft.EntityFrameworkCore;
using recipes.Data;
using recipes.Models;

namespace recipes.Repositories
{
    public class SessionRepository
    {
        private readonly DataContext Context;

        public SessionRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task AddUser(User user)
        {
            await this.Context.Users.AddAsync(user);
            await this.Context.SaveChangesAsync();
        }

        public async Task<User?> FetchUserByName(string username)
        {
            User? user = await this.Context.Users.SingleOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}