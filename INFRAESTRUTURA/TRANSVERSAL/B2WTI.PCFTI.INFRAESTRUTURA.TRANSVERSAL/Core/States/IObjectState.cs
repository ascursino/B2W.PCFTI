
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.States
{
    using System.ComponentModel.DataAnnotations.Schema;

    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
