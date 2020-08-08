using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sweet_And_Salty_Studios
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanel : MonoBehaviour, IInteractable, IDraggable
    {
        #region VARIABLES

        private RectTransform rectTransform;
        protected CanvasGroup canvasGroup;

        #endregion VARIABLES

        #region PROPERTIES

        protected RectTransform RectTransform
        {
            get
            {
                if(rectTransform == null)
                {
                    rectTransform = GetComponent<RectTransform>();
                }

                return rectTransform;
            }
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        protected virtual void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnCancel(BaseEventData eventData)
        {

        }

        public void OnDeselect(BaseEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            var position = RectTransform.anchoredPosition;

            RectTransform.anchoredPosition += eventData.delta;

            if(IsRectTransformInsideSreen(RectTransform) == false)
            {
                RectTransform.anchoredPosition = position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
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

        public IEnumerator Open()
        {
            var animationID = StartOpenAnimation(0.25f);

            yield return new WaitUntil(() => LeanTween.isTweening(animationID));
        }

        protected virtual int StartOpenAnimation(float animationDuration)
        {
            return LeanTween.scale(RectTransform, Vector3.one, animationDuration)
                .setOnStart(() =>
                {
                    gameObject.SetActive(true);
                    canvasGroup.blocksRaycasts = false;

                })
                .setFrom(new Vector3(0, 0, 1))
                .setEaseOutCubic()
                .setOnComplete(() =>
                {
                    canvasGroup.blocksRaycasts = true;
                }).id;
        }

        protected virtual int StartCloseAnimation(float aniamtionDuration)
        {
            return LeanTween.scale(RectTransform, new Vector3(0, 0, 1), aniamtionDuration)
            .setOnComplete(() =>
            {
                gameObject.SetActive(false);
            })
            .id;
        }

        public IEnumerator Close()
        {
            canvasGroup.blocksRaycasts = false;

            var animationID = StartCloseAnimation(0.25f);

            yield return new WaitUntil(() => LeanTween.isTweening(animationID));
        }

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

