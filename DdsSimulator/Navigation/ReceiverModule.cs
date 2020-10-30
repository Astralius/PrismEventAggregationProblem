using Infrastructure.Events;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Type = System.Type;

namespace Navigation
{
    public class ReceiverModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ReceiverModule(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            eventAggregator.GetEvent<SelectTypeEvent>().Subscribe(this.OnTypeSelected);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }

        public void OnInitialized(IContainerProvider containerProvider) { }

        private void OnTypeSelected(Type type) // this should be called once event is received, but it is never received :(
        {
            this.regionManager.RequestNavigate("ReceiverPane", "Received");  // the type argument is not important for this demo
        } 
    }
}
