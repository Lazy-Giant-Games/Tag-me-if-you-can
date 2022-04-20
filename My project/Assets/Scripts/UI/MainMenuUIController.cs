using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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

        [SerializeField]
        private CommandControlledBot m_ai;

        [SerializeField]
        private AIAnimationSequence m_aiBoyAnimation;
        [SerializeField]
        private AIAnimationSequence m_aiGirlAnimation;

        public GameObject runnerObject;
        public GameObject speedLines;

        public List<GameObject> emojis = new List<GameObject>();

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
            
            
            m_aiBoyAnimation.PlayShock();
            m_aiGirlAnimation.PlayShock();
            emojis.ForEach((eachObject) => eachObject.SetActive(true));
        }
        #endregion

        void OnReadyPlayTrigger() {
            m_aiBoyAnimation.onTurnDone -= OnReadyPlayTrigger;
            StartCoroutine(OnReadyPlay());
            ClikManager.Instance.CallClikEventGameStart();
        }

        IEnumerator OnReadyPlay() {
            yield return new WaitForSeconds(0.5f);
            runnerObject.SetActive(true);
            m_ai.StartPlay();
            m_aiBoyAnimation.transform.parent.gameObject.SetActive(false);
            CutSceneCamera.Instance.GoToFPSCamera();
            yield return new WaitForSeconds(0.5f);
            CameraController.GameStarted = true;
            speedLines.SetActive(true);
            m_playerController.GetComponent<CameraController>().enabled = true;
            m_playerController.enabled = true;
            
            
            m_playerController.animator.PlayRun();
            
        }
    }
}