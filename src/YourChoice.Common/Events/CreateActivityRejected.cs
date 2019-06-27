namespace YourChoice.Common.Events
{
    public class CreateActivityRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        protected CreateActivityRejected()
        {
        }

        public CreateActivityRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}