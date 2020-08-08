using UnityEngine.EventSystems;

namespace Sweet_And_Salty_Studios
{
    public interface IDraggable: IBeginDragHandler, IDragHandler, IEndDragHandler, IDeselectHandler, ICancelHandler
    {

    }
}

