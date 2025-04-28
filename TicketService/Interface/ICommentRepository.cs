using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Interface
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        public List<Comment> GetAll();

        
    }
}
