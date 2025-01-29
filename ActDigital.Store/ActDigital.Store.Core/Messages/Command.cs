using FluentValidation.Results;
using MediatR;

namespace ActDigital.Store.Core.Messages;

public class Command : Message, IRequest<bool>  
{
    public DateTime CommandDate { get; private set; }
    public ValidationResult ValidationResult { get; set; }
    
    public Command()
    {
        CommandDate = DateTime.Now;
    }
    
    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}