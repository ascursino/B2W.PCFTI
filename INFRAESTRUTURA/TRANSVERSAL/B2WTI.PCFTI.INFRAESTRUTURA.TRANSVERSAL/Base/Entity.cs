
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base
{
    using Core.States;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
