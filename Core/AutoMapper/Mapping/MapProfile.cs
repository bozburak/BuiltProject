using AutoMapper;
using Core.AutoMapper.DTOs;
using Core.Models;

namespace Core.AutoMapper.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
