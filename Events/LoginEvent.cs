using Prism.Events;

namespace PaskiPlacowe.Events
{
    internal class LoginEvent : PubSubEvent<LoginD>
    {
    }
    internal class LoginD
    {
        public string Login { get; set; }
    }
}