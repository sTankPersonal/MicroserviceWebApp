namespace BuildingBlocks.SharedKernel.Streams
{
    public abstract record FileStreams
    {
        public string FileName { get; } = String.Empty;
        public Stream OpenStream { get; } = Stream.Null;
        public string ContentType { get; } = String.Empty;
    }
}
