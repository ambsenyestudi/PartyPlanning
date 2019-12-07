using System;

namespace PartyPlanning.Domain.Entites
{
    public abstract class IdValue: IEquatable<IdValue>
    {
        public Guid Id { get; protected set; }
        public IdValue()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(IdValue other) =>
            other != null &&
            this.Id != Guid.Empty && other.Id != Guid.Empty &&
            this.Id == other.Id;
    }
}
