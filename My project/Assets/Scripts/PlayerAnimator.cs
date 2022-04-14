using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimator : MonoBehaviour {
    public Animator myAnimator;
    private GroundDetector m_groundDetector;
    public bool isPlayer;

    public static bool isNearEnemy;
    public bool isOnHighJump;

    public GameObject goFakeHands;

    public GameObject goReachingHands;
    private Animator m_reachingHandsAnimator;
    public bool forceDontShowFakeHands;

    public ObstacleFeedback feedbacker;
	private void Awake() {
        m_groundDetector = GetComponentInChildren<GroundDetector>();
        if (isPlayer) {
            m_reachingHandsAnimator = goReachingHands.GetComponent<Animator>();
        }   
    }
	public void PlayIdle(AIMovement p_ai = null) {
        //HideFakeHands();
        if (p_ai != null) { //for AI
            if (!p_ai.IsCaptured) {
                myAnimator.SetTrigger("trigIdle");
            }
        } else { // for Player
            myAnimator.SetTrigger("trigIdle");
        }
    }
    public void PlayShock() {
        myAnimator.SetTrigger("trigShock");
    }
    public void PlayRoll() {
        myAnimator.SetTrigger("trigRoll");
    }
    public void PlayRun() {
        if (isPlayer) {
            if (PlayerWin.IsWon) {
                return;
            }
            if (CutSceneCamera.IsOnCutScene) {
                HideFakeHands();
                return;
            }
            if (isNearEnemy) { //play tag run animation here replace code below if and call PlayTagRun()
                //Debug.LogError("HERE");
                //if (!goReachingHands.activeSelf) {
                //    HideFakeHands();
                //    goReachingHands.SetActive(true);
                //}
                
                //if (m_reachingHandsAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Hand_Reaching") {
                //    Debug.LogError(m_reachingHandsAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " -- "); 
                    //m_reachingHandsAnimator.SetTrigger("trigReach");
                //}
            } else {

                if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root" && !isOnHighJump) {
                    myAnimator.SetTrigger("trigRun");
                }
            }
        } else {
            if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root" && !isOnHighJump) {
                myAnimator.SetTrigger("trigRun");
            }
        }
    }
    public void PlayHighJump() {
        if (isPlayer) {
            feedbacker.PlayObstacleFeedback();
        }
        isOnHighJump = true;
        myAnimator.SetTrigger("trigHighJump");
    }

    public void PlayLowJump() {
        if (isPlayer) {
            feedbacker.PlayObstacleFeedback();
        }
        myAnimator.SetTrigger("trigLowJump");
    }

    public void PlayClimb() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Wall_Vertical_Boost") {
            myAnimator.SetTrigger("trigClimb");
        }
    }

    public void PlayClimbExit() {
        myAnimator.SetTrigger("trigClimbExit");
    }

    public void PlaySlide() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            if (isPlayer) {
                feedbacker.PlayObstacleFeedback();
            }
            isOnHighJump = false;
            myAnimator.SetTrigger("trigSlide");
            myAnimator.SetBool("isSliding", true);
        }
    }

    public void PlayVault() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            if (isPlayer) {
                feedbacker.PlayObstacleFeedback();
            }
            isOnHighJump = false;
            myAnimator.SetTrigger("trigSlide");
        }
    }
    public void SlideOffAfterSec(float p_timer) {
        StartCoroutine(SlideOff(p_timer));
	}
    IEnumerator SlideOff(float p_timer) {
        yield return new WaitForSeconds(p_timer);
        myAnimator.SetBool("isSliding", false);
    }
    public void WallRunLeft() {
        myAnimator.SetTrigger("trigWallRunLeft");
    }
    public void WallRunRight() {
        myAnimator.SetTrigger("trigWallRunRight");
    }
    public void ContinueToRunning(bool p_continue) {
        myAnimator.SetBool("isGrounded", p_continue);
    }
    public void ContinueToSliding() {
        myAnimator.SetBool("isClimbSlide", true);
    }
	private void Update() {
        if (isPlayer) {
            if (Input.GetKey(KeyCode.X)) {
                if (!goReachingHands.activeSelf) {
                    HideFakeHands();
                    goReachingHands.SetActive(true);
                }
                if (m_reachingHandsAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Hand_Reaching") {
                    m_reachingHandsAnimator.SetTrigger("trigReach");
                }
                return;
            } else {
                goReachingHands.SetActive(false);
            }
        }
        
        if (!CameraController.GameStarted) {
            return;
        }
        if (isPlayer) {
            if (forceDontShowFakeHands) {
                goReachingHands.gameObject.SetActive(false);
				HideFakeHands();
                return;
            }
            if (myAnimator.GetBool("isSliding")) {
                HideFakeHands();
                return;
            } else {
                ShowFakeHands();
            }
            if (m_groundDetector.isGrounded && !PlayerWin.IsWon) {
                ShowFakeHands();
            } else {
                HideFakeHands();
            }
        }
        
        if (isPlayer) {
            ContinueToRunning(m_groundDetector.isGrounded);
        }
    }

    public void HideFakeHands() {
        goFakeHands.SetActive(false);
    }
    public void ShowFakeHands() {
        goReachingHands.SetActive(false);
        goFakeHands.SetActive(true);
    }
}