using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.ValueObjects;

namespace VoiceMod.Common.Entities
{
    public abstract class BaseEntity
    {
        public EntityId Id { get; protected set; }

        public BaseEntity(EntityId id)
        {
            Id = id;
        }
    }
}
