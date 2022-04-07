using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Glass will be shattered when Player steps in the trigger.
public class Trigger : MonoBehaviour
{

    // Target Glass
    public ShatterableGlass Glass;

	private void Awake() {
        Glass = GetComponent<ShatterableGlass>();

    }

	void OnTriggerEnter(Collider Intruder)
    {
        // Check if Intruder is Player:
        if (Intruder.gameObject.GetComponent<PlayerInput>() != null)
        {
            //Intruder.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Intruder.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            // Do not attepmt to shatter glass, if Glass already Destroyed().
            if (Glass)
                Glass.Shatter(Vector2.zero, Glass.transform.forward * 20f);
            // Destroy() trigger itself.
            Destroy(gameObject);
        }
    }
}
