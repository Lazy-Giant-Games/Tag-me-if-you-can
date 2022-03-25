using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace TagMeIfYouCan {
    public class IngameUIController : MVCUIController, IngameUIView.IListener {
        [SerializeField]
        private IngameUIModel m_ingameUIModel;
        private IngameUIView m_ingameUIView;

        public Transform enemyTransform;
        public Transform playerTransform;
        private float m_targetDistance = 10f;
        private float m_maxDistance = 100f;

        #region Mono Calls

        private void OnDestroy() {
            m_ingameUIView.Unsubscribe(this);
        }
        #endregion
        //Call this function to Instantiate the UI, on the callback you can call initialization code for the said UI
        [ContextMenu("Instantiate UI")]
        public override void InstantiateUI() {
            IngameUIView.Create(_canvas, m_ingameUIModel, (p_ui) => {
                m_ingameUIView = p_ui;
                m_ingameUIView.Subscribe(this);

                InitUI(p_ui.UIModel, p_ui);
            });
        }

		private void Update() {
            if (m_ingameUIView != null) {
                float fillAmount = m_targetDistance / Vector3.Distance(playerTransform.position, enemyTransform.position);
                fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
                m_ingameUIView.UpdateNearProgressBarValue(fillAmount);
            }
        }

		#region IngameUIView.IListener
		public void OnClickRestart() { SceneManager.LoadScene("LevelScene"); }
        #endregion
    }
}