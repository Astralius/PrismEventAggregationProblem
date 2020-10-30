using Infrastructure;
using Infrastructure.Events;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;
using Type = System.Type;

namespace Content.ViewModels
{
    public class PublisherViewModel
    {
        private readonly IEventAggregator eventAggregator;

        public PublisherViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.AvailableTypes.Add(typeof(SomeClass));
            this.LoadTypeCommand = new DelegateCommand<Type>(this.LoadType);
        }

        public BindingList<Type> AvailableTypes { get; } = new BindingList<Type>();

        public DelegateCommand<Type> LoadTypeCommand { get; set; }

        // that's where I try to publish. This gets called, but never received in the other module (Navigation).
        private void LoadType(Type type) => this.eventAggregator.GetEvent<SelectTypeEvent>().Publish(type);
    }
}
