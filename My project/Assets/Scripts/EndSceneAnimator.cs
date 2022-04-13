using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneAnimator : MonoBehaviour
{
    public bool isAI;
    public Animator myAnimator;

    public GameObject jumpTarget;

    public GameObject goFightCloud;
    private void OnEnable() {
        if (isAI) {
            PlayShock();
        } else {
            PlayEndCatch();
        }
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
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Girl_Slap") {
            myAnimator.SetTrigger("trigSlap");
        }
    }

    public void PlayEndCatch() {
        if (myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "root_Boy_Fall_V2 (IN_PLACE)") {
            StartCoroutine(DelayedCatch());
        }
    }

    IEnumerator DelayedCatch() {

        myAnimator.SetTrigger("trigCatch");
        transform.LookAt(jumpTarget.transform);
        yield return new WaitForSeconds(0.45f);
        while (Vector3.Distance(transform.position, jumpTarget.transform.position) > 0.25f) {
            transform.position = Vector3.MoveTowards(transform.position, jumpTarget.transform.position, 10f * Time.deltaTime);
            yield return 0;
        }

        goFightCloud.SetActive(true);
        goFightCloud.transform.position = transform.position;
        //yield return new WaitForSeconds(1f);
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
    public void PlayShock() {
        Debug.LogError("Play Shock");
        myAnimator.SetTrigger("trigShock");
    }
    void SetYPosOnDead(float p_yOffset = 1.4f) {
        Vector3 pos = myAnimator.transform.localPosition;
        pos.y /= p_yOffset;
        myAnimator.transform.localPosition = pos;
    }
}
