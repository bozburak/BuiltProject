using AutoMapper;
using MultiTierProject.Core.AutoMapper.DTOs;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Core.AutoMapper.Mapping
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
