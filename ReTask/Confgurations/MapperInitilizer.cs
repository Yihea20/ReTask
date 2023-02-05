using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReTask.Models;
using ReTask.Models.ViewModel;

namespace ReTask.Confgurations
{
    public class MapperInitilizer:Profile
    {
        public MapperInitilizer()
        {
            CreateMap<News,NewsDTO>().ReverseMap();
            CreateMap<NewsDTO, News>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserDTO, User>().ReverseMap();

        }
    }
}
