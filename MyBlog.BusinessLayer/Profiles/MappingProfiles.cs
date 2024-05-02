using AutoMapper;
using MyBlog.BusinessLayer.Dto;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Profiles
{
   public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            

            CreateMap<Message, ListMessageDto>()
           .ForMember(dest => dest.ReceiverEmail, opt => opt.MapFrom(src => src.Receiver.Email)).ForMember(dest => dest.SenderEmail, opt => opt.MapFrom(src => src.Sender.Email))
           .ReverseMap();





        }
    }
}
