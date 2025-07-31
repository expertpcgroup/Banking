namespace Banking.Response
{
    public interface IResponse<T> where T : class
    {
        public string Message { get; set; }
        public bool Result { get; set; }
        public DateTime TimeStamp { get; set; }
        public IList<T>? Payload { get; set; }
    }
}
