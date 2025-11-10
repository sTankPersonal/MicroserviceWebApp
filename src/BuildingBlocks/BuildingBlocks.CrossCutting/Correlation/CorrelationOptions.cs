using BuildingBlocks.SharedKernel.Utils;

namespace BuildingBlocks.CrossCutting.Correlation
{
    public class CorrelationOptions
    {
        private string _headerName = string.Empty;
        public string HeaderName
        {
            get => _headerName.ThrowIfNullOrEmpty($"{nameof(CorrelationOptions)}.{nameof(HeaderName)}");
            set => _headerName = value;
        }

    }
}
