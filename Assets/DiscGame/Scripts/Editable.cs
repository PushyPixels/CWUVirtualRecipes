using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editable : MonoBehaviour
{
    public float value;
    public GameObject editIcon;

    public void ActivateEditIcon()
    {
        if(editIcon)
        {
            editIcon.SetActive(true);
        }
    }

    public void DeactivateEditIcon()
    {
        if(editIcon)
        {
            editIcon.SetActive(false);
        }
    }
}
