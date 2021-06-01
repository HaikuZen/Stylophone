// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using ObjCRuntime;
using Stylophone.Common.Interfaces;
using Stylophone.Common.ViewModels;
using Stylophone.iOS.Services;
using Stylophone.iOS.ViewControllers;
using UIKit;

namespace Stylophone.iOS
{
    [Register("NavigationController")]
    public class NavigationController : UINavigationController, IUINavigationControllerDelegate
	{
        private PlaybackViewController _playbackViewController;

		public NavigationController (IntPtr handle) : base (handle)
		{
		}

        void ReleaseDesignerOutlets()
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            var concreteNavService = (NavigationService)Ioc.Default.GetRequiredService<INavigationService>();
            concreteNavService.NavigationController = this;

            Delegate = this;

            _playbackViewController = UIStoryboard.FromName("NowPlaying", null)
                .InstantiateInitialViewController() as PlaybackViewController;

            //concreteNavService.PlaybackViewController = _playbackViewController;

            // Add the compact view of the playback VC as an overlay
            var compactView = _playbackViewController.CompactView;
            compactView.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(compactView);

            // Add some layout constraints to affix it to the bottom
            var constraints = new List<NSLayoutConstraint>();

            constraints.Add(compactView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, -16));
            constraints.Add(compactView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor, 32));
            constraints.Add(compactView.RightAnchor.ConstraintEqualTo(View.RightAnchor, -32));
            constraints.Add(compactView.HeightAnchor.ConstraintEqualTo(128));

            NSLayoutConstraint.ActivateConstraints(constraints.ToArray());

            // Navigate to the queue
            concreteNavService.Navigate<QueueViewModel>();
        }


        [Export("navigationController:willShowViewController:animated:")] 
        public void WillShowViewController(UINavigationController navigationController, [Transient] UIViewController viewController, bool animated)
        {
            // If the navigation occurred through the back button instead of the sidebar,
            // The NavigationService doesn't intervene and can't call the Navigated event.
            // We call it manually here instead.
            var navService = Ioc.Default.GetRequiredService<INavigationService>() as NavigationService;
            navService.Navigate(navService.CurrentPageViewModelType);
        }
    }
}
