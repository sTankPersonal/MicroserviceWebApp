using BuildingBlocks.SharedKernel.Exceptions;

namespace Template.Domain.Exceptions
{
    public class ExampleException : BaseDomainException
    {
        //Utilize this exception to represent domain-specific errors related to ExampleEntity operations.
        //Override the Default Exception Service to allow custom handling of this exception type.
        public ExampleException(string message) : base(message) { }
    }
}
