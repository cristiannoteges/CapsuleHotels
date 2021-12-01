using CapsuleHotels.Model.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Abstract
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
