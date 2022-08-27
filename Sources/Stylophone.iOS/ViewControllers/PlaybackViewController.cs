// This file has been autogenerated from a class added in the UI designer.

using System;
using System.ComponentModel;
using Strings = Stylophone.Localization.Strings.Resources;
using Foundation;
using CommunityToolkit.Mvvm.DependencyInjection;
using SkiaSharp;
using Stylophone.Common.Helpers;
using Stylophone.Common.ViewModels;
using Stylophone.iOS.Helpers;
using Stylophone.iOS.ViewModels;
using UIKit;
using Pop = ARSPopover.iOS;

namespace Stylophone.iOS.ViewControllers
{
	public partial class PlaybackViewController : UIViewController, IViewController<PlaybackViewModel>
	{
		public PlaybackViewController (IntPtr handle) : base (handle)
		{
		}

        public PlaybackViewModel ViewModel { get; private set; }
		public PropertyBinder<PlaybackViewModel> Binder { get; private set; }
        public PropertyBinder<LocalPlaybackViewModel> LocalPlaybackBinder { get; private set; }
        private PropertyBinder<TrackViewModel> _trackBinder;

        private UILabel upNextView = new UILabel();

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            // PlaybackVM is transient, so we need to initialize it explicitly.
            ViewModel = Ioc.Default.GetRequiredService<PlaybackViewModel>();
            Binder = new(ViewModel);
            LocalPlaybackBinder = new(ViewModel.LocalPlayback);

            ViewModel.PropertyChanged += OnVmPropertyChanged;
            NavigationItem.TitleView = upNextView;
            upNextView.TextAlignment = UITextAlignment.Right;
            upNextView.Lines = 2;
            upNextView.AdjustsFontForContentSizeCategory = true;
            upNextView.AdjustsFontSizeToFitWidth = true;
            upNextView.AdjustsLetterSpacingToFitWidth = true;
            NavigationItem.RightBarButtonItem = CreateSettingsButton();

            // Bind
            var negateBoolTransformer = NSValueTransformer.GetValueTransformer(nameof(ReverseBoolValueTransformer));
            var intToStringTransformer = NSValueTransformer.GetValueTransformer(nameof(IntToStringValueTransformer));

            // Compact View Binding
            Binder.Bind<bool>(CompactView, "hidden", nameof(ViewModel.IsTrackInfoAvailable), valueTransformer: negateBoolTransformer);

            CompactView.PrevButton.PrimaryActionTriggered += (s, e) => ViewModel.SkipPrevious();
            CompactView.NextButton.PrimaryActionTriggered += (s, e) => ViewModel.SkipNext();
            CompactView.PlayPauseButton.PrimaryActionTriggered += (s, e) => ViewModel.ChangePlaybackState();
            CompactView.ShuffleButton.PrimaryActionTriggered += (s, e) => ViewModel.ToggleShuffle();

            CompactView.OpenFullScreenButton.PrimaryActionTriggered += (s, e) => ViewModel.NavigateNowPlaying();

            // Volume Popover Binding
            LocalPlaybackBinder.Bind<bool>(LocalPlaybackView, "hidden", nameof(ViewModel.LocalPlayback.IsEnabled), valueTransformer: negateBoolTransformer);

            LocalMuteButton.PrimaryActionTriggered += (s, e) => ViewModel.LocalPlayback.ToggleMute();
            LocalPlaybackBinder.Bind<int>(LocalVolumeSlider, "value", nameof(ViewModel.LocalPlayback.Volume), true);
            LocalPlaybackBinder.Bind<int>(LocalVolume, "text", nameof(ViewModel.LocalPlayback.Volume), valueTransformer: intToStringTransformer);

            ServerMuteButton.PrimaryActionTriggered += (s, e) => ViewModel.ToggleMute();
            Binder.Bind<double>(ServerVolumeSlider, "value", nameof(ViewModel.MediaVolume), true);
            Binder.Bind<double>(ServerVolume, "text", nameof(ViewModel.MediaVolume), valueTransformer: intToStringTransformer);
            
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.TintColor = UIColor.LabelColor;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NavigationController.NavigationBar.TintColor = null;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TrackSlider.TouchDragInside += (s, e) =>
            {
                ViewModel.TimeListened = Miscellaneous.FormatTimeString(TrackSlider.Value * 1000);
                ViewModel.OnPlayingSliderMoving();
            };
            TrackSlider.ValueChanged += (s, e) =>
            {
                ViewModel.OnPlayingSliderChange();
            };

            var upNextTransformer = NSValueTransformer.GetValueTransformer(nameof(NextTrackToStringValueTransformer));

            // Full View Binding
            Binder.Bind<string>(ElapsedTime, "text", nameof(ViewModel.TimeListened));
            Binder.Bind<string>(RemainingTime, "text", nameof(ViewModel.TimeRemaining));
            Binder.Bind<double>(TrackSlider, "value", nameof(ViewModel.CurrentTimeValue), true);
            Binder.Bind<double>(TrackSlider, "maximumValue", nameof(ViewModel.MaxTimeValue));
            Binder.Bind<TrackViewModel>(upNextView, "text", nameof(ViewModel.NextTrack), valueTransformer:upNextTransformer);
            UpdateFullView(ViewModel.CurrentTrack);

            UpdateButton(PlayPauseButton, ViewModel.PlayButtonContent);
            UpdateButton(VolumeButton, ViewModel.VolumeIcon);
            UpdateButton(ServerMuteButton, ViewModel.VolumeIcon);
            UpdateButton(RepeatButton, ViewModel.RepeatIcon);
            UpdateButton(ShuffleButton, ViewModel.IsShuffleEnabled ? "shuffle.circle.fill" : "shuffle.circle");

            SkipPrevButton.PrimaryActionTriggered += (s, e) => ViewModel.SkipPrevious();
            SkipNextButton.PrimaryActionTriggered += (s, e) => ViewModel.SkipNext();
            PlayPauseButton.PrimaryActionTriggered += (s, e) => ViewModel.ChangePlaybackState();
            ShuffleButton.PrimaryActionTriggered += (s, e) => ViewModel.ToggleShuffle();
            RepeatButton.PrimaryActionTriggered += (s, e) => ViewModel.ToggleRepeat();
            VolumeButton.PrimaryActionTriggered += (s, e) => ShowVolumePopover(VolumeButton); 

            AlbumArt.Layer.CornerRadius = 8;
        }

        private void OnVmPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.CurrentTrack))
            {
                CompactView.Bind(ViewModel.CurrentTrack);
                UpdateFullView(ViewModel.CurrentTrack);
            }

            if (e.PropertyName == nameof(ViewModel.PlayButtonContent))
            {
                UpdateButton(CompactView.PlayPauseButton, ViewModel.PlayButtonContent);
                UpdateButton(PlayPauseButton, ViewModel.PlayButtonContent);
            }

            if (e.PropertyName == nameof(ViewModel.VolumeIcon))
            {
                UpdateButton(CompactView.VolumeButton, ViewModel.VolumeIcon);
                UpdateButton(VolumeButton, ViewModel.VolumeIcon);
                UpdateButton(ServerMuteButton, ViewModel.VolumeIcon);
            }

            if (e.PropertyName == nameof(ViewModel.IsShuffleEnabled))
            {
                var image = ViewModel.IsShuffleEnabled ? "shuffle.circle.fill" : "shuffle.circle";
                UpdateButton(CompactView.ShuffleButton, image);
                UpdateButton(ShuffleButton, image);
            }

            if (e.PropertyName == nameof(ViewModel.RepeatIcon))
            {
                UpdateButton(RepeatButton, ViewModel.RepeatIcon);
            }

            if (e.PropertyName == nameof(ViewModel.CurrentTimeValue))
            {
                var progress = (float)(ViewModel.CurrentTimeValue / ViewModel.MaxTimeValue);
                CompactView.CircularProgressView.Progress = progress * 100;
            }
        }

        private void UpdateFullView(TrackViewModel currentTrack)
        {
            // Don't bind if the view isn't loaded yet
            if (currentTrack == null || TrackTitle == null)
            {
                return;
            }

            // Bind trackData
            _trackBinder?.Dispose();
            _trackBinder = new PropertyBinder<TrackViewModel>(currentTrack);

            TrackTitle.Text = currentTrack.Name;
            ArtistName.Text = currentTrack.File?.Artist;
            AlbumName.Text = currentTrack.File?.Album;

            var imageConverter = NSValueTransformer.GetValueTransformer(nameof(SkiaToUIImageValueTransformer));
            var colorConverter = NSValueTransformer.GetValueTransformer(nameof(SkiaToUIColorValueTransformer));

            _trackBinder.Bind<SKImage>(AlbumArt, "image", nameof(currentTrack.AlbumArt), valueTransformer: imageConverter);
            _trackBinder.Bind<SKImage>(AlbumBackground, "image", nameof(currentTrack.AlbumArt), valueTransformer: imageConverter);
            _trackBinder.Bind<SKColor>(BackgroundTint, "backgroundColor", nameof(currentTrack.DominantColor), valueTransformer: colorConverter);
            //_trackBinder.Bind<SKColor>(PlayPauseButton, "tintColor", nameof(currentTrack.DominantColor), valueTransformer: colorConverter);
            
        }

        private void UpdateButton(UIButton button, string systemImg) =>
            button?.SetImage(UIImage.GetSystemImage(systemImg), UIControlState.Normal);

        private UIBarButtonItem CreateSettingsButton()
        {
            var addQueueAction = Binder.GetCommandAction(Strings.ContextMenuAddToPlaylist, "music.note.list", ViewModel.AddToPlaylistCommand);
            var viewAlbumAction = Binder.GetCommandAction(Strings.ContextMenuViewAlbum, "opticaldisc", ViewModel.ShowAlbumCommand);

            var barButtonMenu = UIMenu.Create(new[] { addQueueAction, viewAlbumAction });
            return new UIBarButtonItem(UIImage.GetSystemImage("ellipsis.circle"), barButtonMenu);
        }

        public void ShowVolumePopover(UIButton sourceButton, UIViewController sourceVc = null)
        {
            var sourceBounds = sourceButton.ImageView.Bounds;

            var popover = new Pop.ARSPopover
            {
                SourceView = sourceButton.ImageView,
                SourceRect = new CoreGraphics.CGRect(sourceBounds.Width/2, -4, 0, 0),
                ContentSize = ViewModel.LocalPlayback.IsEnabled ?
                    new CoreGraphics.CGSize(276, 176) : new CoreGraphics.CGSize(276, 96),
                ArrowDirection = UIPopoverArrowDirection.Down
            };

            popover.View.AddSubview(VolumePopover);

            if (sourceVc == null)
                sourceVc = this;

            sourceVc.PresentViewController(popover, true, null);
        }
    }
}
