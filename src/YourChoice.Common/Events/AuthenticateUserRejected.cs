namespace YourChoice.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}