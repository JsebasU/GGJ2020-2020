using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    public virtual void OnStartInteraction()
    {
        Debug.Log("Start interaction parent");
    }

    public virtual void OnCancelInteraction()
    {
        Debug.Log("End interaction parent");
    }
}
