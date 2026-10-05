using SupportSystemApp.Domain.Domain_Models;
using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Ticket : BaseEntity
    {
        public string? TicketNumber { get; set; }

        [Required(ErrorMessage ="Must not be left empty!")]
        public string? Header { get; set; } //SUBJECT
        public string? Details { get; set; } //DESCRIPTION
        public string? Resolution { get; set; }
        public Guid? TicketStatusId { get; set; }
        public TicketStatus? Status { get; set; }
        public Guid? TicketPriorityId { get; set; }
        public TicketPriority? Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueBy { get; set; }
        public DateTime? ResolvedAt { get; set; }

        [Required(ErrorMessage ="Please choose requester!")]
        public string RequesterId { get; set; } //OPENED BY ID
        public virtual SupportSystemAppUser? OpenedBy { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public Guid? SubcategoryId { get; set; }
        public virtual Subcategory? Subcategory { get; set; }
        public Guid? CategoryItemId { get; set; }
        public virtual CategoryItem? CategoryItem { get; set; }

        public string? TechnitianId { get; set; }
        public virtual SupportSystemAppUser? AssignedTo { get; set; } //TECHNITIAN
        public Guid? SiteId { get; set; }
        public virtual Site? Site { get; set; }
        public Guid? SupportGroupId { get; set; }
        public virtual SupportGroup? SupportGroup { get; set; }
        public Guid? ServiceCategoryId { get; set; }
        public virtual Service_Category? ServiceCategory { get; set; }
        public Guid? TicketModeId { get; set; }
        public virtual TicketMode? TicketMode { get; set; }
        public Guid? TicketTypeId { get; set; }
        public virtual TicketType? TicketType { get; set; }
        public Guid? ImpactId { get; set; }
        public virtual Impact? Impact { get; set; }
        public Guid? UrgencyId { get; set; }
        public virtual Urgency? Urgency { get; set; }
        public Guid? Service_CategoryId { get; set; }
        public virtual Service_Category? Service_Category { get; set; }

        public virtual ICollection<TicketTask>? TicketTasks { get; set; }
        public virtual ICollection<Note>? Notes { get; set; }
        public virtual ICollection<Attachment>? Attachments { get; set; }

    }
}
