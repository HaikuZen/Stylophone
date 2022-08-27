// This file has been autogenerated from a class added in the UI designer.

using System;
using CoreGraphics;
using Foundation;
using CommunityToolkit.Mvvm.DependencyInjection;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using Stylophone.Common.ViewModels;
using Stylophone.iOS.Helpers;
using Stylophone.iOS.Services;
using Stylophone.iOS.ViewModels;
using UIKit;

namespace Stylophone.iOS.ViewControllers
{
	public partial class CompactPlaybackView : UIView
	{
        private PropertyBinder<TrackViewModel> _propertyBinder;

        public CompactPlaybackView (IntPtr handle) : base (handle)
		{
		}

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            Hidden = true;

            // Round off CompactView edges and give it a shadow
            CornerRadiusContainer.Layer.CornerRadius = 12;
            CornerRadiusContainer.Layer.MasksToBounds = true;

            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOpacity = 0.5F;
            Layer.ShadowOffset = new CGSize(0, 0);
            Layer.ShadowRadius = 4;

            AlbumArt.Layer.CornerRadius = 8;
        }

        internal void Bind(TrackViewModel currentTrack)
        {
            if (currentTrack == null)
            {
                return;
            }

            // Bind trackData
            _propertyBinder?.Dispose();
            _propertyBinder = new PropertyBinder<TrackViewModel>(currentTrack);

            TrackTitle.Text = currentTrack.Name;
            ArtistName.Text = currentTrack.File?.Artist;

            var imageConverter = NSValueTransformer.GetValueTransformer(nameof(SkiaToUIImageValueTransformer));
            var colorConverter = NSValueTransformer.GetValueTransformer(nameof(SkiaToUIColorValueTransformer));

            _propertyBinder.Bind<SKImage>(AlbumArt, "image", nameof(currentTrack.AlbumArt), valueTransformer: imageConverter);
            _propertyBinder.Bind<SKImage>(AlbumBackground, "image", nameof(currentTrack.AlbumArt), valueTransformer: imageConverter);
            _propertyBinder.Bind<SKColor>(BackgroundTint, "backgroundColor", nameof(currentTrack.DominantColor), valueTransformer: colorConverter);
            _propertyBinder.Bind<SKColor>(CircularProgressView, nameof(CircularProgressView.BackgroundCircleColor),
                nameof(currentTrack.DominantColor), valueTransformer: colorConverter);
        }
    }
}
