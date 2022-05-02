using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace TagMeIfYouCan {
    public class PostGameUIController : MVCUIController, PostGameUIView.IListener {
        [SerializeField]
        private PostGameUIModel m_postGameUIModel;
        private PostGameUIView m_postGameUIView;

        [SerializeField]
        private IngameUIController m_ingameUIController;

        private bool m_isWon;

        #region Mono Calls
        private void OnEnable() {
            FallingGameOver.OnFalling += ShowFailScreen;
            //GroundDetector.OnFatalFall += OnFell;
            EnemyProgressBar.OnCaptured += OnCapture;
            CommandControlledBot.onRunnerDone += ShowFailScreen;
            PlayerWin.forcedFailScreen += ShowFailScreen;
        }

		private void OnDisable() {
            CommandControlledBot.onRunnerDone -= ShowFailScreen;
            FallingGameOver.OnFalling -= ShowFailScreen;
            //GroundDetector.OnFatalFall -= OnFell;
            EnemyProgressBar.OnCaptured -= OnCapture;
            PlayerWin.forcedFailScreen -= ShowFailScreen;
        }
		private void Start() {
            InstantiateUI();
        }

        private void OnDestroy() {
            m_postGameUIView.Unsubscribe(this);
        }
        #endregion
        //Call this function to Instantiate the UI, on the callback you can call initialization code for the said UI
        [ContextMenu("Instantiate UI")]
        public override void InstantiateUI() {
            PostGameUIView.Create(_canvas, m_postGameUIModel, (p_ui) => {
                m_postGameUIView = p_ui;
                m_postGameUIView.Subscribe(this);

                InitUI(p_ui.UIModel, p_ui);
                HideUI();
            });
        }

        public void ShowFailScreen() {
            StartCoroutine(DelayedLoseUIDisplay());            
        }

        IEnumerator DelayedLoseUIDisplay() {
            ClikManager.Instance.CallClikEventGameLose();
            yield return new WaitForSeconds(2.5f);
            m_ingameUIController.HideUI();
            ShowUI();
            m_postGameUIView.ShowLoseUI();
        }

        void OnCapture() {
            StartCoroutine(DelayedUIDisplay());
            m_isWon = true;
        }

        IEnumerator DelayedUIDisplay() {
            ClikManager.Instance.CallClikEventGameWin();
            yield return new WaitForSeconds(2.5f);
            m_ingameUIController.HideUI();
            ShowUI();
            m_postGameUIView.ShowWinUI();
        }

        #region IngameUIView.IListener
        public void OnClickPlay() {
            if (m_isWon) {
                GameManager.Instance.GoToNextLevel();
            } else {
                GameManager.Instance.LoadCurrentScene();
            }
        }
        #endregion
    }
}