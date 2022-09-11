// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using CommunityToolkit.Mvvm.DependencyInjection;
using Stylophone.iOS.Helpers;
using Stylophone.iOS.ViewModels;
using Strings = Stylophone.Localization.Strings.Resources;
using UIKit;
using Stylophone.Common.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using CoreGraphics;
using System.Drawing;

namespace Stylophone.iOS.ViewControllers
{
    public partial class AlbumViewModelHolder : NSObject
    {
        public AlbumViewModel ViewModel;
    }

    public partial class LibraryViewController : UICollectionViewController, IUICollectionViewDelegateFlowLayout, IViewController<LibraryViewModel>, IUISearchBarDelegate
    {
        public LibraryViewController(IntPtr handle) : base(handle)
        {
        }

        public LibraryViewModel ViewModel => Ioc.Default.GetRequiredService<LibraryViewModel>();
        public PropertyBinder<LibraryViewModel> Binder => new(ViewModel);

        private UICollectionViewDiffableDataSource<NSString, AlbumViewModelHolder> _dataSource;

        public override async void AwakeFromNib()
        {
            base.AwakeFromNib();
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Always;
            Title = LibraryViewModelBase.GetHeader();


            var searchController = new UISearchController(searchResultsController: null);
            NavigationItem.SearchController = searchController;
            NavigationItem.HidesSearchBarWhenScrolling = false;
            searchController.ObscuresBackgroundDuringPresentation = false;
            searchController.SearchBar.Placeholder = Strings.LibrarySearchPlaceholder;
            searchController.SearchBar.Delegate = this;

            Binder.Bind<bool>(CollectionView.Subviews.First(), "hidden", nameof(ViewModel.IsSourceEmpty),
                valueTransformer: NSValueTransformer.GetValueTransformer(nameof(ReverseBoolValueTransformer)));

            await InitializeLibraryAsync();
        }
                
        private async Task InitializeLibraryAsync()
        {
            if (ViewModel.IsSourceEmpty)
                await ViewModel.LoadDataAsync();

            _dataSource = new UICollectionViewDiffableDataSource<NSString, AlbumViewModelHolder>(CollectionView,
                new UICollectionViewDiffableDataSourceCellProvider(GetAlbumViewCell));
            CollectionView.DataSource = _dataSource;
            CollectionView.PrefetchDataSource = ViewModel.PrefetchableCollection;
            CollectionView.PrefetchingEnabled = true;

            UpdateDataSource();

            // Start a timer to load visible items every sec -- a bit jank but eh
            var timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(1), (NSTimer obj) =>
            {
                // Make sure we load the displayed items -- We don't specify IndexPaths here, the method picks up visible items automatically
                CollectionView.PrefetchDataSource.PrefetchItems(CollectionView, new NSIndexPath[] { });
            });
            NSRunLoop.Current.AddTimer(timer, NSRunLoopMode.Common);
        }

        private void UpdateDataSource()
        {
            var snapshot = new NSDiffableDataSourceSectionSnapshot<AlbumViewModelHolder>();
            
            var items = ViewModel.FilteredSource.Select(vm => new AlbumViewModelHolder { ViewModel = vm }).ToArray();
            snapshot.AppendItems(items);

            _dataSource.ApplySnapshot(snapshot, new NSString("base"), true);
        }

        private UICollectionViewCell GetAlbumViewCell(UICollectionView collectionView, NSIndexPath indexPath, NSObject identifier)
        {
            var holder = identifier as AlbumViewModelHolder;
            // This identifier is set in IB
            var cell = CollectionView.DequeueReusableCell("albumCell", indexPath) as AlbumCollectionViewCell;
            cell.Initialize(holder.ViewModel);

            return cell;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var holder = _dataSource.GetItemIdentifier(indexPath);

            if (holder.ViewModel == null)
                return;
            else
                ViewModel.ItemClickCommand.Execute(holder.ViewModel);
        }

        public override UIContextMenuConfiguration GetContextMenuConfiguration(UICollectionView collectionView, NSIndexPath indexPath, CGPoint point)
        {
            var holder = _dataSource.GetItemIdentifier(indexPath);

            UIMenu menu = null;
            if (holder.ViewModel != null)
            {
                menu = GetMenuForViewModel(holder.ViewModel);
            }

            return UIContextMenuConfiguration.Create(null, null, new UIContextMenuActionProvider((arr) => menu));
        }

        private UIMenu GetMenuForViewModel(AlbumViewModel vm)
        {
            var playAction = Binder.GetCommandAction(Strings.ContextMenuPlay, "play.fill", vm.PlayAlbumCommand);
            var addToQueueAction = Binder.GetCommandAction(Strings.ContextMenuAddToQueue, "plus", vm.AddAlbumCommand);
            var addToPlaylistAction = Binder.GetCommandAction(Strings.ContextMenuAddToPlaylist, "music.note.list", vm.AddToPlaylistCommand);

            return UIMenu.Create(new[] { playAction, addToQueueAction, addToPlaylistAction });
        }

        private CGSize? _incomingSize;
        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);

            // Keep track of the incoming size, since when we invalidate the collectionview's size won't have updated yet
            _incomingSize = toSize;
            var invalidation = new UICollectionViewFlowLayoutInvalidationContext();
            invalidation.InvalidateFlowLayoutDelegateMetrics = true;

            CollectionView.CollectionViewLayout.InvalidateLayout(invalidation);
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var referenceSize = _incomingSize ?? collectionView.Frame.Size;
            var size = new CGSize(192, 192);

            if (referenceSize.Width < 600)
                size = new CGSize(148, 148);

            if (referenceSize.Width < 350)
                size = new CGSize(120, 120);

            return size;
        }

        [Export("searchBar:textDidChange:")]
        public void TextChanged(UISearchBar searchBar, string text)
        {
            ViewModel.FilterLibrary(text);
            UpdateDataSource();
        }

        [Export("searchBarCancelButtonClicked:")]
        public void CancelButtonClicked(UISearchBar searchBar)
        {
            ViewModel.FilterLibrary("");
            UpdateDataSource();
        }

    }
}
