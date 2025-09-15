using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using Presenter.Models;

namespace Presenter.WPF.Utilities
{
    public class PlaylistDropHandler : DefaultDropHandler
    {
        public override void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.TargetCollection is List<SongImage> || dropInfo.TargetItem is SongImage) return;


            base.DragOver(dropInfo);
        }

        public override void Drop(IDropInfo dropInfo)
        {
            base.Drop(dropInfo);

            var playlist = dropInfo.TargetCollection.TryGetList();
            if (playlist != null && playlist.Count == 1)
                playlist.Add(new Song { Title = "End" });
        }
    }
}
