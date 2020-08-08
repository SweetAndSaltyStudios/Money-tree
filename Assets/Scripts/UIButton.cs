using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Sweet_And_Salty_Studios
{
    public class UIButton : MonoBehaviour, IInteractable
    {
        #region VARIABLES

        [Space]
        [Header("Events")]
        public UnityEvent OnClick_Event;

        [Space]
        [Header("Sprites")]
        public Sprite Button_Default_Sprite;
        public Sprite Button_Highlighted_Sprite;
        public Sprite Button_Pressed_Sprite;
        public Sprite Button_Disabled_Sprite;

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

        public void OnPointerClick(PointerEventData eventData)
        {        
            OnClick_Event.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            LeanTween.scale(rectTransform, highlightedSize, 0.05f);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

        }

        public void OnPointerExit(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            LeanTween.scale(rectTransform, defaultSize, 0.05f);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}

