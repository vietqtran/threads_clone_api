using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Relations;

namespace Threads.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<Repost> Reposts { get; set; }
        public virtual ICollection<UserPollOptions> UserPollOptions { get; set; }
        public virtual ICollection<UserFollow> Followers { get; set; }
        public virtual ICollection<UserFollow> Followeds { get; set; }
        public virtual ICollection<UserBlock> Blockers { get; set; }
        public virtual ICollection<UserBlock> Blockeds { get; set; }
        public virtual ICollection<Search> Searches { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual RefreshToken RefreshToken { get; set; }
    }
}
