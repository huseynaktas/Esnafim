using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Domain.Entities
{
    public class BusinessComment
    {
        public int BusinessCommentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public string IsSpam { get; set; }
    }
}
