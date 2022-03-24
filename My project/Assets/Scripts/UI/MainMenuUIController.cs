using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace TagMeIfYouCan {
    public class MainMenuUIController : MVCUIController, MainMenuUIView.IListener {
        [SerializeField]
        private MainMenuUIModel m_mainMenuUIModel;
        private MainMenuUIView m_mainMenuUIView;

        [SerializeField]
        private IngameUIController m_ingameUIController;
        [SerializeField]
        private PlayerController m_playerController;

        #region Mono Calls
        private void Start() {
            InstantiateUI();
        }

		private void OnDestroy() {
            m_mainMenuUIView.Unsubscribe(this);
        }
		#endregion
		//Call this function to Instantiate the UI, on the callback you can call initialization code for the said UI
		[ContextMenu("Instantiate UI")]
        public override void InstantiateUI() {
            MainMenuUIView.Create(_canvas, m_mainMenuUIModel, (p_ui) => {
                m_mainMenuUIView = p_ui;
                m_mainMenuUIView.Subscribe(this);
                
                InitUI(p_ui.UIModel, p_ui);
            });
        }

        #region IngameUIView.IListener
         public void OnClickPlay() { HideUI(); m_ingameUIController.InstantiateUI(); m_playerController.enabled = true; }
        #endregion
    }
}