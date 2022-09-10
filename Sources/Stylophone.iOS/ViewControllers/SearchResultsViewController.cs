// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using CommunityToolkit.Mvvm.DependencyInjection;
using Stylophone.Common.ViewModels;
using Stylophone.iOS.Helpers;
using Stylophone.iOS.ViewModels;
using Strings = Stylophone.Localization.Strings.Resources;
using UIKit;
using Stylophone.Localization.Strings;

namespace Stylophone.iOS.ViewControllers
{
	public partial class SearchResultsViewController : UITableViewController, IViewController<SearchResultsViewModel>
	{
		public SearchResultsViewController (IntPtr handle) : base (handle)
		{
		}

        public SearchResultsViewModel ViewModel => Ioc.Default.GetRequiredService<SearchResultsViewModel>();
        public PropertyBinder<SearchResultsViewModel> Binder => new(ViewModel);

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Title = string.Format(Resources.SearchResultsFor, ViewModel.QueryText);

            // Don't display large title for search results as they're usually too long
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Always;

            Title = SearchResultsViewModel.GetHeader();

            var negateBoolTransformer = NSValueTransformer.GetValueTransformer(nameof(ReverseBoolValueTransformer));
            Binder.Bind<bool>(EmptyView, "hidden", nameof(ViewModel.IsSourceEmpty),
                valueTransformer: negateBoolTransformer);
            Binder.Bind<bool>(SearchInProgressView, "hidden", nameof(ViewModel.IsSearchInProgress),
                valueTransformer: negateBoolTransformer);


            var trackDataSource = new TrackTableViewDataSource(TableView, ViewModel.Source, GetRowContextMenu, GetRowSwipeActions);
            TableView.DataSource = trackDataSource;
            TableView.Delegate = trackDataSource;

            // Segmented Control
            SearchSegmentedControl.SetTitle(Strings.SearchTracksToggle, 0);
            SearchSegmentedControl.SetTitle(Strings.SearchArtistsToggle, 1);
            SearchSegmentedControl.SetTitle(Strings.SearchAlbumsToggle, 2);

            SearchSegmentedControl.PrimaryActionTriggered += SearchSegmentedControl_PrimaryActionTriggered;
        }

        private void SearchSegmentedControl_PrimaryActionTriggered(object sender, EventArgs e)
        {
            switch (SearchSegmentedControl.SelectedSegment)
            {
                case 0: ViewModel.SearchTracks = true; return;
                case 1: ViewModel.SearchArtists = true; return;
                case 2: ViewModel.SearchAlbums = true; return;
            }
        }

        void IPreparableViewController.Prepare(object parameter)
        {
            ViewModel.Initialize(parameter as string);
        }

        private UIMenu GetRowContextMenu(NSIndexPath indexPath)
        {
            // The common commands take a list of objects
            var trackList = new List<object>();

            if (TableView.IndexPathsForSelectedRows == null)
            {
                trackList.Add(ViewModel?.Source[indexPath.Row]);
            }
            else
            {
                trackList = TableView.IndexPathsForSelectedRows.Select(indexPath => ViewModel?.Source[indexPath.Row])
                .ToList<object>();
            }

            var queueAction = Binder.GetCommandAction(Strings.ContextMenuAddToQueue, "plus", ViewModel.AddToQueueCommand, trackList);
            var albumAction = Binder.GetCommandAction(Strings.ContextMenuViewAlbum, "opticaldisc", ViewModel.ViewAlbumCommand, trackList);
            var playlistAction = Binder.GetCommandAction(Strings.ContextMenuAddToPlaylist, "music.note.list", ViewModel.AddToPlaylistCommand, trackList);

            return UIMenu.Create(new[] { queueAction, albumAction, playlistAction });
        }

        private UISwipeActionsConfiguration GetRowSwipeActions(NSIndexPath indexPath, bool isLeadingSwipe)
        {
            // The common commands take a list of objects
            var trackList = new List<object>();
            trackList.Add(ViewModel?.Source[indexPath.Row]);

            var action = isLeadingSwipe ? Binder.GetContextualAction(UIContextualActionStyle.Normal, Strings.ContextMenuAddToQueue, ViewModel.AddToQueueCommand, trackList)
                : Binder.GetContextualAction(UIContextualActionStyle.Normal, Strings.ContextMenuAddToPlaylist, ViewModel.AddToPlaylistCommand, trackList);

            return UISwipeActionsConfiguration.FromActions(new[] { action });
        }
    }
}
