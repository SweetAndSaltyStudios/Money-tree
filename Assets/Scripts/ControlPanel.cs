using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class ControlPanel : UIPanel
    {
        #region VARIABLES

        public float StartHeight;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        protected override int StartOpenAnimation(float animationDuration)
        {
            return LeanTween.moveY(RectTransform, 0, animationDuration)
                .setOnStart(() =>
                {
                    gameObject.SetActive(true);
                    canvasGroup.blocksRaycasts = false;
                })
                .setFrom(StartHeight)
                .setEaseOutElastic()
                .setEaseOutBounce()
                .setOnComplete(() =>
                {
                    canvasGroup.blocksRaycasts = true;
                }).id;
        }

        protected override int StartCloseAnimation(float animationDuration)
        {
            return LeanTween.moveY(RectTransform, StartHeight, animationDuration)
            .setOnComplete(() =>
            {
                gameObject.SetActive(false);
            })
            .id;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}

