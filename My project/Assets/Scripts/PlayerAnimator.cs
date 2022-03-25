using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    public Animator myAnimator;
    private GroundDetector m_groundDetector;
    public bool isPlayer;

    public static bool isNearEnemy;
	private void Awake() {
        m_groundDetector = GetComponentInChildren<GroundDetector>();
    }
	public void PlayIdle() {
        myAnimator.SetTrigger("trigIdle");
    }

    public void PlayRun() {
        if (isPlayer) {
            if (isNearEnemy) {
                PlayTagRun();
            } else {
                if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root") {
                    myAnimator.SetTrigger("trigRun");
                }
            }
        }
    }

    public void PlayTagRun() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Esc_Slide_All") {
            myAnimator.SetTrigger("trigSlide");
        }
    }
    public void PlayFalling() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump_Down_C_Loop") {
            myAnimator.SetTrigger("trigFalling");
        }
    }

    public void PlayHighJump() {
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
            myAnimator.SetTrigger("trigSlide");
        }
        
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
        ContinueToRunning(m_groundDetector.isGrounded);

    }
}
