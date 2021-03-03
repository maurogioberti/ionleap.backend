using Neoris.Ionleap.CrossCutting.Utils.Date;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Ionleap.ResourceAccess.Entities.Infrastructure
{
    public class BaseEntity : IEntity
    {
        [Key]
        [Column("Id")]
        public int Identity { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        [Column("UserCreatedId")]
        public int UserCreatedIdentity { get; set; }

        [Column("UserModifiedId")]
        public int? UserModifiedIdentity { get; set; }

        private DateTime _dateCreated;

        public DateTime DateCreated
        {
            get => _dateCreated;
            set
            {
                if(value == default)
                    _dateCreated = DateTimeManager.ApplicationServerDateTime;
            }

        }

        public DateTime? DateModified { get; set; }
    }
}
