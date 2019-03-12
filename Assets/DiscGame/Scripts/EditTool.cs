using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.ArtificialBased;

public class EditTool : MonoBehaviour
{
    public VRTK_InteractableObject linkedObject;
    public Transform projectileSpawnPoint;
    public LayerMask layerMask;
    public VRTK_ArtificialSlider slider;
    public TextMesh valueText;

    private bool used = false;
    private Editable currentEditTarget;

    protected virtual void OnEnable()
    {
        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        }
    }

    protected virtual void OnDisable()
    {
        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(used)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(projectileSpawnPoint.position,projectileSpawnPoint.forward,out hitInfo, 100.0f, layerMask))
            {
                Editable editable = hitInfo.collider.GetComponent<Editable>();
                if(editable && editable != currentEditTarget)
                {
                    if(currentEditTarget)
                    {
                        currentEditTarget.DeactivateEditIcon();
                    }
                    currentEditTarget = editable;
                    currentEditTarget.ActivateEditIcon();
                    slider.SetStepValue(currentEditTarget.value);
                    valueText.text = currentEditTarget.value.ToString();
                }
            }
            used = false;
        }

        if(currentEditTarget)
        {
            currentEditTarget.value = slider.GetStepValue();
            valueText.text = currentEditTarget.value.ToString();
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        used = true;
    }

}
