using System;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Toders.RestrictedContentFolders.Models.Blocks;
using Toders.RestrictedContentFolders.Models.Media;

namespace Toders.RestrictedContentFolders.Models.Folders
{
    [ContentType(GUID = "964063f0-613b-4ce5-85a0-2d11fee0b905")]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(TeaserBlock) })]
    public class TeaserContentFolder : ContentFolder
    {
    }

    [ContentType(GUID = "e730c883-f9b7-4d5e-b309-a00070159771")]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ImageFile) })]
    public class ImageContentFolder : ContentFolder
    {
    }
}
