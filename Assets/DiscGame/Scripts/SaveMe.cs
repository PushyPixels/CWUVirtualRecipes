using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMe : MonoBehaviour
{
    public static List<SaveMe> saveables = new List<SaveMe>();
    public LevelDefinition.ObjectType type;

    // Start is called before the first frame update
    void Start()
    {
        saveables.Add(this);
    }

    void OnDestroy()
    {
        saveables.Remove(this);
    }
}
