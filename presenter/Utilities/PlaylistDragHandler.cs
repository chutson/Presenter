using GongSolutions.Wpf.DragDrop;
using presenter.Models;

namespace presenter.Utilities
{
    public class PlaylistDragHandler : DefaultDragHandler
    {
        public override bool CanStartDrag(IDragInfo dragInfo)
        {
            if (dragInfo.SourceItem is SongImage)
                return false;

            return base.CanStartDrag(dragInfo);
        }
    }
}
