namespace SmartWallet.CustomException
{
    /// <summary>
    /// Summary description for CustomException
    /// </summary>
    public class UserCustomException : ApplicationException
    {
        public int StatusCode { get; set; }

        public UserCustomException(string error, int statusCode) : base(error)
        {
            StatusCode = statusCode;
        }
    }
}
