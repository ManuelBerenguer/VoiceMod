using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.Extensions;
using VoiceMod.Common.ValueObjects.Base;

namespace VoiceMod.Common.ValueObjects
{
    public class EntityId : ValueObject
    {
        private readonly Guid _id;

        public EntityId(Guid id)
        {
            if (!id.isValidForEntity())
                throw new ArgumentException("Entity id cannot be empty", nameof(id));

            _id = id;
        }

        public Guid Value() => _id;
    }
}
