using CommunityToolkit.Mvvm.Messaging.Messages;

namespace chron_expression_web.Client.Messages
{
    public class Message : ValueChangedMessage<string>
{
    public Message(string value) : base(value)
    {

    }
}
}
