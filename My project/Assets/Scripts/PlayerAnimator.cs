using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    public Animator myAnimator;
    private GroundDetector m_groundDetector;
    public bool isPlayer;

    public static bool isNearEnemy;
    public bool isOnHighJump;
	private void Awake() {
        m_groundDetector = GetComponentInChildren<GroundDetector>();
    }
	public void PlayIdle() {
        myAnimator.SetTrigger("trigIdle");
    }

    public void PlayRoll() {
        myAnimator.SetTrigger("trigRoll");
    }

    public void PlayRun() {
        if (isPlayer) {
            if (isNearEnemy) {
                PlayTagRun();
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

    public void PlayTagRun() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            myAnimator.SetTrigger("trigSlide");
        }
    }
    public void PlayFalling() {
        Debug.LogError(isOnHighJump);
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump_Down_C_Loop" && !isOnHighJump) {
            myAnimator.SetTrigger("trigFalling");
        }
    }

    public void PlayHighJump() {
        isOnHighJump = true;
        myAnimator.SetTrigger("trigHighJump");
    }

    public void PlayLowJump() {
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
            isOnHighJump = false;
            myAnimator.SetTrigger("trigSlide");
            myAnimator.SetBool("isSliding", true);
        }
    }

    public void PlayVault() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
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
            ContinueToRunning(m_groundDetector.isGrounded);
        }
    }
}