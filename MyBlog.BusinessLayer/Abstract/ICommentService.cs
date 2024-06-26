﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetCommentsByBlog(int id);
        List<Comment> TGetCommentsByWriter(int id);
        public List<Comment> GetAllWithUserArticleComments();
    }
}
