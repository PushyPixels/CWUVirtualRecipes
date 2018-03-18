using UnityEngine;
using UnityEngine.Events;
using VRTK;

public class VRTK_Usable : VRTK_InteractableObject
{
    public UnityEvent eventsToTrigger;

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        Debug.Log("Usable triggered!");
        eventsToTrigger.Invoke();
    }

    protected void Start()
    {

    }
}