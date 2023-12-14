using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Enums;
using Threads.Domain.Relations;

namespace Threads.Domain.Entities
{
    public class Reply : BaseEntity
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid RepostId { get; set; }
        public Guid? PostId { get; set; }
        public ThreadType ThreadType { get; set; } = ThreadType.Reply;
        public ReplyAudience ReplyAudience { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<RepostReply> RepostReplies { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}
