using BuildingBlocks.CrossCutting.Correlation;

namespace Template.Infrastructure.Services
{
    internal class CustomCorrelationIdAccessor : ICorrelationIdAccessor
    {
        //Stub so I can remember where this is
        //Most recent service registration wins.
        //The defaults are in BuildingBlocks and registered first
        //If you want to override them, do it in your project after the BuildingBlocks are registered.
        public string? GetCorrelationId()
        {
            throw new NotImplementedException();
        }

        public void SetCorrelationId(string correlationId)
        {
            throw new NotImplementedException();
        }
    }
}
