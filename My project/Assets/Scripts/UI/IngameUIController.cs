using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace TagMeIfYouCan.UI {
    public class IngameUIController : MVCUIController, IngameUIView.IListener {
        [SerializeField]
        private IngameUIModel m_ingameUIModel;
        private IngameUIView m_ingameUIView;

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
                StartCoroutine(m_ingameUIView.ShowTutorialForSeconds(3f));
            });
        }

        public void DoFadeOut() {
            m_ingameUIView.FadeOut();
        }

		#region IngameUIView.IListener
		public void OnClickRestart() { SceneManager.LoadScene("GamePlayLevel"); }
        #endregion
    }
}