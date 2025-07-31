namespace Banking.Response
{
    public class Response<T> : IResponse<T> where T : class
    {
        public string? Message { get; set; }
        public bool Result { get; set; }

        public IList<T>? Payload { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
