using Prism.Events;
using System;

namespace Infrastructure.Events
{
    /// <summary>
    /// A simple event representing a request to display data for selected type.
    /// </summary>
    public class SelectTypeEvent : PubSubEvent<Type> { }
}
