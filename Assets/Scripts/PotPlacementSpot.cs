using UnityEngine;
using UnityEngine.EventSystems;

namespace Sweet_And_Salty_Studios
{
    public class PotPlacementSpot : MonoBehaviour, IInteractable, IDropHandler
    {
        #region VARIABLES

        private Vector2 defaultSize;
        private Vector2 highlightedSize;

        private RectTransform rectTransform;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            defaultSize = rectTransform.localScale;
            highlightedSize = defaultSize * 1.1f;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            LeanTween.scale(rectTransform, highlightedSize, 0.05f);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerClick(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.scale(rectTransform, defaultSize, 0.05f);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("On Drop: " + eventData.selectedObject);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS


        #endregion CUSTOM_FUNCTIONS
    }
}

