using GongSolutions.Wpf.DragDrop;
using presenter.Models;

namespace presenter.Utilities
{
    public class PlaylistDropHandler : DefaultDropHandler
    {
        public override void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.TargetCollection is List<SongImage> || dropInfo.TargetItem is SongImage) return;

            base.DragOver(dropInfo);
        }
    }
}
