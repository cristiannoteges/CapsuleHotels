using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
