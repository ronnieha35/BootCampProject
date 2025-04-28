using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketService.Interface;
using TicketService.Models;

namespace TicketService.Repository
{
    public class CommentRepository : ICommentRepository
    {
        List<Comment> _comments = new List<Comment>();
        public void AddComment(Comment comment)
        {

            _comments.Add(comment);
            Console.WriteLine($"Comentario N° '{comment.Id}' creado con éxito.");
        }

        public List<Comment> GetAll()
        {
            return _comments;
        }
    }
}
