using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    public GameObject DashParent;
    public GameObject PreDash;

    public void PickDash(GameObject dash)
    {
        dash.transform.SetParent(DashParent.transform);
        dash.transform.position = new Vector3(PreDash.transform.position.x, PreDash.transform.position.y - 0.2f, PreDash.transform.position.z);
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        PreDash = dash;
        BoxCollider boxCollider = PreDash.GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y, 30f);
    }

    public void RemoveTile()
    {
        if (DashParent.transform.childCount > 1)
        {
            GameObject lowestStack = DashParent.transform.GetChild(0).gameObject;
            Destroy(lowestStack);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        }
    }
}
