using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Comment {
        public int Id { get; set; }

        public Query Query { get; set; }
        public int QueryId { get; set; }

        public int ParentCommentId { get; set; }
        [ForeignKey("ParentCommentId")]
        public Comment CommentIt { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }

        public string UserComment { get; set; }

        public DateTime CommentTime { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}