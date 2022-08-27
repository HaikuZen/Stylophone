// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using CommunityToolkit.Mvvm.DependencyInjection;
using Stylophone.Common.ViewModels;
using Stylophone.iOS.Helpers;
using Stylophone.Localization.Strings;
using UIKit;

namespace Stylophone.iOS.ViewControllers
{
    public partial class SettingsViewController : UITableViewController, IViewController<SettingsViewModel>
    {

        public SettingsViewController(IntPtr handle) : base(handle)
        {
        }

        public SettingsViewModel ViewModel => Ioc.Default.GetRequiredService<SettingsViewModel>();
        public PropertyBinder<SettingsViewModel> Binder => new(ViewModel);

        public override async void AwakeFromNib()
        {
            base.AwakeFromNib();
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Always;
            Title = SettingsViewModel.GetHeader();

            // Init
            await ViewModel.EnsureInstanceInitializedAsync();
        }

        // Localization not covered by LocalizedLabel
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return (int)section switch
            {
                0 => Resources.SettingsServer,
                1 => Resources.SettingsLocalPlaybackHeader,
                2 => Resources.SettingsDatabase,
                3 => Resources.SettingsAnalytics,
                4 => Resources.SettingsAbout,
                _ => "",
            };
        }

        public override string TitleForFooter(UITableView tableView, nint section)
        {
            return (int)section switch
            {
                1 => Resources.SettingsLocalPlaybackText,
                2 => Resources.SettingsClearCacheDescription,
                3 => Resources.SettingsApplyOnRestart,
                _ => "",
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Value Transformers
            var negateBoolTransformer = NSValueTransformer.GetValueTransformer(nameof(ReverseBoolValueTransformer));
            var intToStringTransformer = NSValueTransformer.GetValueTransformer(nameof(IntToStringValueTransformer));

            // Bindings
            Binder.Bind<string>(ServerHostnameField, "text", nameof(ViewModel.ServerHost), true);
            Binder.Bind<int>(ServerPortField, "text", nameof(ViewModel.ServerPort), true,
                valueTransformer: intToStringTransformer);
            Binder.Bind<string>(ServerPasswordField, "text", nameof(ViewModel.ServerPassword), true);
            Binder.Bind<string>(ServerInfoLabel, "text", nameof(ViewModel.ServerStatus));

            Binder.Bind<bool>(ServerConnectionIndicator, "animating", nameof(ViewModel.IsCheckingServer));
            Binder.Bind<bool>(ServerConnectedBox, "hidden", nameof(ViewModel.IsCheckingServer));

            Binder.Bind<bool>(ServerConnectionFailed, "hidden", nameof(ViewModel.IsServerValid));
            Binder.Bind<bool>(ServerConnectionSuccess, "hidden", nameof(ViewModel.IsServerValid),
                valueTransformer: negateBoolTransformer);

            Binder.Bind<bool>(LocalPlaybackToggle, "enabled", nameof(ViewModel.IsStreamingAvailable));
            Binder.Bind<bool>(LocalPlaybackToggle, "on", nameof(ViewModel.IsLocalPlaybackEnabled), true);
            Binder.Bind<bool>(AnalyticsToggle, "on", nameof(ViewModel.EnableAnalytics), true);

            Binder.Bind<string>(VersionLabel, "text", nameof(ViewModel.VersionDescription));

            Binder.BindButton(ClearCacheButton, Resources.SettingsClearCache, ViewModel.ClearCacheCommand);
            Binder.BindButton(UpdateDatabaseButton, Resources.SettingsUpdateDatabase, ViewModel.RescanDbCommand);
            Binder.BindButton(RateButton, Resources.RateAppPromptTitle, ViewModel.RateAppCommand);

            GithubButton.SetTitle(Resources.SettingsGithub, UIControlState.Normal);
            GithubButton.PrimaryActionTriggered += (s, e) =>
                UIApplication.SharedApplication.OpenUrl(new NSUrl(Resources.SettingsGithubLink));

        }
    }

}
