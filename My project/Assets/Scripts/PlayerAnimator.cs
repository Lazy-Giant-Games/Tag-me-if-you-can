using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAnimator : MonoBehaviour {
    public Animator myAnimator;
    private GroundDetector m_groundDetector;
    public bool isPlayer;

    public static bool isNearEnemy;
    public bool isOnHighJump;

    public GameObject goFakeHands;
    private Animator m_fakeHandsAnimator;

    public GameObject goReachingHands;
    private Animator m_reachingHandsAnimator;

    public bool forceDontShowFakeHands;

    
	private void Awake() {
        m_groundDetector = GetComponentInChildren<GroundDetector>();
        if (isPlayer) {
            m_fakeHandsAnimator = goFakeHands.GetComponent<Animator>();
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

    public void PlayRoll() {
        //HideFakeHands();
        myAnimator.SetTrigger("trigRoll");
    }

    public void PlayRun() {
        if (isPlayer) {
            if (PlayerWin.IsWon) {
                PlayEndAnimationAI();
                return;
            }
            if (CutSceneCamera.IsOnCutScene) {
                HideFakeHands();
                //goReachingHands.SetActive(false);
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
                if (!goFakeHands.activeSelf) {
                    //ShowFakeHands();
                }
                if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Mvm_Boost_Root" && !isOnHighJump) {
                    //.LogError("BBBB " + m_reachingHandsAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
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

    bool m_forceReachingHands = false;
	private void Update() {
        if (isPlayer) {
            if (Keyboard.current.xKey.isPressed) {
                if (!goReachingHands.activeSelf) {
                    HideFakeHands();
                    goReachingHands.SetActive(true);
                }
                if (m_reachingHandsAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Hand_Reaching") {
                    Debug.LogError(m_reachingHandsAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " -- ");
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

    public void PlayEndAnimationAI() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Boy_Fall_V2") {
            myAnimator.SetTrigger("trigEnd");
        }
    }

    IEnumerator DelayedCaughtAI() {
        yield return new WaitForSeconds(0.75f);
        SetYPosOnDead();
    }
    public void PlayEndSlap() {
        HideFakeHands();
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Girl_Slap") {
            myAnimator.SetTrigger("trigSlap");
        }
    }

    public void PlayEndCatch() {
        HideFakeHands();
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Boy_Fall_V2 (IN_PLACE)") {
            StartCoroutine(DelayedCatch());
        }
    }

    IEnumerator DelayedCatch() {
        yield return new WaitForSeconds(0.45f);
        myAnimator.SetTrigger("trigCatch");
        AIMovement am = GameObject.FindObjectOfType<AIMovement>();
        transform.LookAt(am.transform);
        LeanTween.move(transform.gameObject, am.transform.GetChild(1).GetChild(0).Find("Eyes").position, 0.65f).setOnComplete(() => {
            //SetYPosOnDead(1.25f); 
            
            
        });
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void SetYPosOnDead(float p_yOffset = 1.4f) {
        Vector3 pos = myAnimator.transform.localPosition;
        pos.y /= p_yOffset;
        myAnimator.transform.localPosition = pos;
    }
}