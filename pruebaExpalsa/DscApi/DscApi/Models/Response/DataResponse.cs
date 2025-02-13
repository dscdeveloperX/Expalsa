namespace DscApi.Models.Response
{
    public class DataResponse<T>
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<T> Data { get; set; }

    }
}
