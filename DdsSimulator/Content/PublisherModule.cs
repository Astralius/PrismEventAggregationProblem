using Content.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Content
{
    public class PublisherModule : IModule
    {
        public PublisherModule(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("PublisherPane", typeof(PublisherView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ReceiverView>("Received");
        }

        public void OnInitialized(IContainerProvider containerProvider) { }
    }
}
