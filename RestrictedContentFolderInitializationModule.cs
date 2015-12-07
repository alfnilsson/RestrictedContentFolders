using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Forms.Models.Folders;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace EPiServer.Forms.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(Web.InitializationModule))]
    public class RestrictedContentFolderInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            IContentRepository contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            ContentReference siteAssetFolder = ContentReference.SiteBlockFolder;
            IEnumerable<ContentFolder> children = contentRepository.GetChildren<ContentFolder>(siteAssetFolder).ToList();

            CreateSpecificFolder<TeaserContentFolder>(children, "Teaser folder", siteAssetFolder, contentRepository);
            CreateSpecificFolder<ImageContentFolder>(children, "Image folder", siteAssetFolder, contentRepository);
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }

        private void CreateSpecificFolder<T>(IEnumerable<ContentFolder> children, string teaserFolderName, ContentReference siteAssetFolder, IContentRepository contentRepository) where T : IContent
        {
            if (children.Any(child => child.Name == teaserFolderName))
            {
                return;
            }

            var teaserFolder = contentRepository.GetDefault<T>(siteAssetFolder);
            teaserFolder.Name = teaserFolderName;
            contentRepository.Save(teaserFolder, SaveAction.Publish, AccessLevel.NoAccess);
        }
    }
}
