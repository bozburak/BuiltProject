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
        }
    }
}
