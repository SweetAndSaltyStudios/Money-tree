using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class UIManager : MonoBehaviour
    {
        #region VARIABLES

        public UIPanel StartingPanel;

        private UIPanel currentlyOpenPanel;

        private Coroutine iSwitchPanel_Coroutine;

        private WaitForSeconds betweenSwitchDelay;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            var panels = FindObjectsOfType<UIPanel>();

            for(int i = 0; i < panels.Length; i++)
            {
                panels[i].gameObject.SetActive(false);
            }

            betweenSwitchDelay = new WaitForSeconds(0);
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);

            SwitchPanel(StartingPanel);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void SwitchPanel(UIPanel panel)
        {
            if(panel == null)
            {
                return;
            }

            if(iSwitchPanel_Coroutine != null)
            {
                Debug.LogWarning("ISwitchPanel... Running already!");
            }

            iSwitchPanel_Coroutine = StartCoroutine(ISwitchPanel(panel));
        }

        private IEnumerator ISwitchPanel(UIPanel panel)
        {
            if(panel == null)
            {
                yield break;
            }

            if(currentlyOpenPanel != null)
            {
                yield return currentlyOpenPanel.Close();
            }

            yield return betweenSwitchDelay;

            currentlyOpenPanel = panel;
            yield return currentlyOpenPanel.Open();

            iSwitchPanel_Coroutine = null;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}

