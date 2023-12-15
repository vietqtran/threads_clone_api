using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Enums;
using Threads.Domain.Relations;

namespace Threads.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public ThreadType ThreadType { get; set; }
        public ReplyAudience ReplyAudience { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<RepostPost> RepostPosts { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}
