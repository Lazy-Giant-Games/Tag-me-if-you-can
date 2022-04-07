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

    public bool forceDontShowFakeHands;
	private void Awake() {
        m_groundDetector = GetComponentInChildren<GroundDetector>();
    }
	public void PlayIdle() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigIdle");
    }

    public void PlayRoll() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigRoll");
    }

    public void PlayRun() {
        if (isPlayer) {
            if (isNearEnemy) { //play tag run animation here replace code below if and call PlayTagRun()
                if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root" && !isOnHighJump) {
                    myAnimator.SetTrigger("trigRun");
                }
                if (!goFakeHands.activeSelf) {
                    //ShowFakeHands();
                }
            } else {
                if (!goFakeHands.activeSelf) {
                    //ShowFakeHands();
                }
                if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root" && !isOnHighJump) {
                    myAnimator.SetTrigger("trigRun");
                }
            }
        } else {
            if (!goFakeHands.activeSelf) {
                //ShowFakeHands();
            }
            if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root" && !isOnHighJump) {
                myAnimator.SetTrigger("trigRun");
            }
        }
    }

    public void PlayTagRun() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            myAnimator.SetTrigger("trigSlide");
        }
    }
    public void PlayFalling() {
        //HideFakeHands();
        Debug.LogError(isOnHighJump);
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump_Down_C_Loop" && !isOnHighJump) {
            myAnimator.SetTrigger("trigFalling");
        }
    }

    public void PlayHighJump() {
        //HideFakeHands();
        isOnHighJump = true;
        myAnimator.SetTrigger("trigHighJump");
    }

    public void PlayLowJump() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigLowJump");
    }

    public void PlayClimb() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Wall_Vertical_Boost") {
            //HideFakeHands();
            myAnimator.SetTrigger("trigClimb");
        }
    }

    public void PlayClimbExit() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigClimbExit");
    }

    public void PlaySlide() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            //HideFakeHands();
            isOnHighJump = false;
            myAnimator.SetTrigger("trigSlide");
            myAnimator.SetBool("isSliding", true);
        }
    }

    public void PlayVault() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            //HideFakeHands();
            isOnHighJump = false;
            myAnimator.SetTrigger("trigSlide");
        }
    }

    public void SlideOffAfterSec(float p_timer) {
        StartCoroutine(SlideOff(p_timer));
	}

    IEnumerator SlideOff(float p_timer) {
        //forceDontShowFakeHands = true;
        yield return new WaitForSeconds(p_timer);
        myAnimator.SetBool("isSliding", false);
        //forceDontShowFakeHands = false;
    }
    public void WallRunLeft() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigWallRunLeft");
    }

    public void WallRunRight() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigWallRunRight");
    }

    public void ContinueToRunning(bool p_continue) {
        myAnimator.SetBool("isGrounded", p_continue);
    }

    public void ContinueToSliding() {
        myAnimator.SetBool("isClimbSlide", true);
    }

	private void Update() {

        if (!CameraController.GameStarted) {
            return;
        }
        if (forceDontShowFakeHands) {
            HideFakeHands();
            return;
        } 
        if (myAnimator.GetBool("isSliding")) {
            HideFakeHands();
            return;
        } else {
            goFakeHands.SetActive(true);
        }
        if (m_groundDetector.isGrounded) {
            ShowFakeHands();
        } else {
            HideFakeHands();
        }
        if (isPlayer) {
            ContinueToRunning(m_groundDetector.isGrounded);
        }
    }

    public void HideFakeHands() {
        goFakeHands.SetActive(false);
    }
    public void ShowFakeHands() {
        goFakeHands.SetActive(true);
    }
}