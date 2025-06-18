namespace WpfIoTSimulatorApp.Models
{
    // JSON 전송용 객체
    internal class CheckResult
    {
        public string ClientId { get; set; }
        public string Timestamp { get; set; }
        public string Result { get; set; }
    }
}