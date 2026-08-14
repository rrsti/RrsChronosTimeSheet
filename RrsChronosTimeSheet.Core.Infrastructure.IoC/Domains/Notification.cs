using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Infrastructure.IoC.Domains
{
    public class Notification
    {
        public string Message { get; }
        public Notification(string message)
        {
            Message = message;
        }
    }
}
