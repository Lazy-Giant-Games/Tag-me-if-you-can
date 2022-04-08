using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace TagMeIfYouCan {
    public class MainMenuUIController : MVCUIController, MainMenuUIView.IListener {
        [SerializeField]
        private MainMenuUIModel m_mainMenuUIModel;
        private MainMenuUIView m_mainMenuUIView;

        [SerializeField]
        private IngameUIController m_ingameUIController;
        [SerializeField]
        private PlayerController m_playerController;

        [SerializeField]
        private CommandControlledBot m_ai;

        [SerializeField]
        private AIAnimationSequence m_aiBoyAnimation;
        [SerializeField]
        private AIAnimationSequence m_aiGirlAnimation;

        public GameObject runnerObject;

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

                m_aiBoyAnimation.onTurnDone += OnReadyPlayTrigger;
            });
        }

        #region IngameUIView.IListener
        public void OnClickPlay() {
            HideUI();
            m_ingameUIController.InstantiateUI();
            
            CameraController.GameStarted = true;
            m_aiBoyAnimation.PlayShock();
            m_aiGirlAnimation.PlayShock();
        }
        #endregion

        void OnReadyPlayTrigger() {
            m_aiBoyAnimation.onTurnDone -= OnReadyPlayTrigger;
            StartCoroutine(OnReadyPlay());
        }

        IEnumerator OnReadyPlay() {
            runnerObject.SetActive(true);
            m_ai.StartPlay();
            m_aiBoyAnimation.transform.parent.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            
			m_playerController.enabled = true;
            m_playerController.animator.PlayRun();
            
        }
    }
}