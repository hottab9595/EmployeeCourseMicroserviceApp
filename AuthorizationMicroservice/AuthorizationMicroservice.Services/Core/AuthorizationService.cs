using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AuthorizationMicroservice.Db.Interfaces;
using AuthorizationMicroservice.Db.Models;
using AuthorizationMicroservice.Services.Interfaces;
using AuthorizationMicroservice.Services.Models.RabbitMQ;
using AuthorizationMicroservice.Services.Models.Service;
using AutoMapper;
using Common.RabbitMQ.Interfaces;

namespace AuthorizationMicroservice.Services.Core
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
        public AuthorizationService(IUnitOfWork db, IMapper mapper, IRabbitMqSender<RabbitMqAuthorizePublishModel> rabbitMqSender) : base(db)
        {
            this.mapper = mapper;
            this.rabbitMqSender = rabbitMqSender;
        }

        private IMapper mapper;
        private IRabbitMqSender<RabbitMqAuthorizePublishModel> rabbitMqSender;


        public async Task<UserModel> RegisterNewUserAsync(UserModel userModel)
        {
            User newUser = mapper.Map<User>(userModel);
            db.Users.Add(newUser);

            await db.SaveAsync();

            return mapper.Map<UserModel>(db.Users.Get(newUser.Id));
        }

        public UserModel Authorize(UserModel userModel)
        {
            RabbitMqAuthorizePublishModel authorizePublishModel = new RabbitMqAuthorizePublishModel
            {
                Login = userModel.Login
            };

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                rabbitMqSender.SendMessage(authorizePublishModel);
            }

            return mapper.Map<UserModel>(db.Users.FindBy(x => x.Login == userModel.Login && x.Password == userModel.Password)
                .FirstOrDefault());
        }

        public void RefreshToken()
        {
            throw new System.NotImplementedException();
        }
    }
}