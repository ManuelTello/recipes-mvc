using recipes.Data;
using recipes.Helpers;
using recipes.Models;
using recipes.Repositories;
using recipes.ViewModels.Session;

namespace recipes.Services
{
    public class SessionService
    {
        private readonly SessionRepository Repository;

        public SessionService(DataContext context)
        {
            this.Repository = new SessionRepository(context);
        }

        public async Task<Operation<User>> FetchUser(SignInViewModel model)
        {
            User? user = await this.Repository.FetchUserByName(model.Username);
            Operation<User> operation;

            if (user == null)
            {
                operation = new Operation<User>()
                {
                    Completed = false,
                    ErrorMessage = "User not found under this credentials."
                };
            }
            else
            {
                operation = new Operation<User>()
                {
                    Completed = true,
                    Payload = new List<User>() { user }
                };
            }

            return operation;
        }

        public async Task<Operation<User>> FetchUser(string username)
        {
            User? user = await this.Repository.FetchUserByName(username);
            Operation<User> operation;

            if (user == null)
            {
                operation = new Operation<User>()
                {
                    Completed = false,
                    ErrorMessage = "User not found under these credentials."
                };
            }
            else
            {
                operation = new Operation<User>()
                {
                    Completed = true,
                    Payload = new List<User>() { user }
                };
            }

            return operation;
        }

        public async Task<Operation<User>> AddUser(SignUpViewModel model)
        {
            User? userexist = await this.Repository.FetchUserByName(model.Username);
            Operation<User> operation;

            if (userexist == null)
            {
                User user = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                await this.Repository.AddUser(user);
                operation = new Operation<User>()
                {
                    Completed = true
                };
            }
            else
            {
                operation = new Operation<User>()
                {
                    Completed = false,
                    ErrorMessage = "User already exists."
                };
            }

            return operation;
        }
    }
}