using AutoMapper;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Dto;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
   
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _MessageDal;
        private readonly IMapper _mapper;

        public MessageManager(IMessageDal MessageDal, IMapper mapper)
        {
            _MessageDal = MessageDal;
            _mapper = mapper;
        }

        public void DraftDeletebyİd(int id)
        {
            _MessageDal.DraftDeletebyİd(id);
        }

        public ListMessageDto GetDraftMessagebyİd(int? id)
        {
            var Message = _MessageDal.GetDraftMessagebyİd(id);
            return _mapper.Map<ListMessageDto>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyDraftSenderId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbyDraftSenderId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);

        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyReadId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbyReadId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyReceiverId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbyReceiverId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbySenderId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbySenderId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbySpamId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbySpamId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyTrashId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbyTrashId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyİmportId(int id)
        {
            var Message = _MessageDal.GetSendandReceiverMessagenameListAllbyİmportId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public List<ListMessageDto> GetSendandReceiverMessagenameListAllLast3byReceiverId(int id)
        {
            var Message =  _MessageDal.GetSendandReceiverMessagenameListAllLast3byReceiverId(id);
            return _mapper.Map<List<ListMessageDto>>(Message);
        }

        public void TDelete(int id)
        {
            _MessageDal.Delete(id);
        }

        public Message TGetById(int id)
        {
            return _MessageDal.GetById(id);
        }

        public ListMessageDto TGetByIddto(int id)
        {
            var Message = _MessageDal.GetByIdMessageId(id);
            return _mapper.Map<ListMessageDto>(Message);
        }

        public List<Message> TGetListAll()
        {
            return _MessageDal.GetListAll();
        }

        public void TInsert(Message entity)
        {

            _MessageDal.Insert(entity);

        }

        public void TUpdate(Message entity)
        {
            _MessageDal.Update(entity);
        }
    }
}
