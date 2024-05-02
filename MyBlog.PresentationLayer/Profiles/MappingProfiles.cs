using AutoMapper;
using MyBlog.BusinessLayer.Dto;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
        
            CreateMap<ListMessageDto, ListMessageModel>().ReverseMap();
            CreateMap<Message, ListMessageModel>().ReverseMap();

            CreateMap<object, ChartData>()
          .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.GetType().GetProperty("CategoryName").GetValue(src)))
          .ForMember(dest => dest.BlogCount, opt => opt.MapFrom(src => src.GetType().GetProperty("BlogCount").GetValue(src)));




        }
    }
}
