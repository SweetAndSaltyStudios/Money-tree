using UnityEngine;
using UnityEngine.EventSystems;

namespace Sweet_And_Salty_Studios
{
    public class Pot : MonoBehaviour, IInteractable, IDraggable
    {
        #region VARIABLES

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
        }

        public void OnCancel(BaseEventData eventData)
        {
        }

        public void OnDeselect(BaseEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            var position = rectTransform.anchoredPosition;

            rectTransform.anchoredPosition += eventData.delta;

            if(IsRectTransformInsideSreen(rectTransform) == false)
            {
                rectTransform.anchoredPosition = position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        // We have 2 same functions...
        private bool IsRectTransformInsideSreen(RectTransform rectTransform)
        {
            var corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);

            var visibleCorners = 0;
            var rect = new Rect(0, 0, Screen.width, Screen.height);

            for(int i = 0; i < corners.Length; i++)
            {
                if(rect.Contains(corners[i]))
                {
                    visibleCorners++;
                }
            }

            return visibleCorners == 4;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}

