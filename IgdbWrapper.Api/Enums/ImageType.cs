using System.ComponentModel;

namespace IgdbWrapper.Api.Enums
{
    /// <summary>
    /// Enumeration that describes the type of image you can get from IGDB.
    /// <remarks>See https://igdb.github.io/api/references/images/ for more info.</remarks>
    /// </summary>
    public enum ImageType
    {
        /// <summary>
        /// Small cover image (size: 90 x 128)
        /// </summary>
        [Description("cover_small")]
        CoverSmall,

        /// <summary>
        /// Big cover image (size: 227 x 320)
        /// </summary>
        [Description("cover_big")]
        CoverBig,

        /// <summary>
        /// Medium screenshot image (size: 569 x 320)
        /// </summary>
        [Description("screenshot_med")]
        ScreenShotMedium,

        /// <summary>
        /// Big screenshot image (size: 889 x 500)
        /// </summary>
        [Description("screenshot_big")]
        ScreenShotBig,

        /// <summary>
        /// Huge screenshot image (size: 1280 x 720)
        /// </summary>
        [Description("screenshot_huge")]
        ScreenShotHuge,

        /// <summary>
        /// Medium logo image (size: 284 x 160)
        /// </summary>
        [Description("logo_med")]
        LogoMedium,

        /// <summary>
        /// Thumbnail image (size: 90 x 90)
        /// </summary>
        [Description("thumb")]
        Thumbnail,

        /// <summary>
        /// Micro image (size: 35 x 35)
        /// </summary>
        [Description("micro")]
        Icon,

        /// <summary>
        /// 720P image (size: 1280 x 720)
        /// </summary>
        [Description("720p")]
        SevenTwentyP,

        /// <summary>
        /// 1080P image (size: 1920 x 1080)
        /// </summary>
        [Description("1080p")]
        TenEightyP,
    }
}