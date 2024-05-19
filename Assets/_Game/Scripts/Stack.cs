using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip pickStackSound;
    public AudioClip buildBridgeSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DashPickup")
        {
            HandlingEatStack(other);
            GameManager.Instance.IncrementScore();
            if (AudioSource && pickStackSound)
            {
                AudioSource.PlayOneShot(pickStackSound);
            }
        }

        if (other.CompareTag("Bridge"))
        {
            if (StackManager.Instance.DashParent.transform.childCount == 1)
            {
                GameManager.Instance.SetIsGameOver(true);
                if (AudioSource && buildBridgeSound)
                {
                    AudioSource.PlayOneShot(buildBridgeSound);
                }
            }
            else
            {
                HandlingWithBridge(other);
            }
        }

        if (other.CompareTag("FinnalWall"))
        {
            GameManager.Instance.SetIsFinnal(true);
        }
    }

    private void HandlingEatStack(Collider other)
    {
        other.gameObject.tag = "normal";
        StackManager.Instance.PickDash(other.gameObject);
        other.gameObject.AddComponent<Rigidbody>();
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        other.gameObject.AddComponent<Stack>();
        Destroy(this);
    }

    private void HandlingWithBridge(Collider other)
    {
        StackManager.Instance.RemoveTile();
        GameObject bridgeChild = other.transform.GetChild(0).gameObject;
        if (bridgeChild != null)
        {
            bridgeChild.SetActive(true);
        }
        other.tag = "Untagged";
        other.isTrigger = false;
    }
}
