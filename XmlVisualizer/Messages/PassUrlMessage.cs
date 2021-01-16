using System;

namespace XmlVisualizer.Messages
{
    public class PassUrlMessage
    {
        public Action<string> Callback { get; set; }

        public PassUrlMessage(Action<string> callback)
        {
            Callback = callback;
        }
    }
}
