using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    public static List<SaveMe> savables = new List<SaveMe>();
    public LevelDefinition.ObjectType type;

    // Start is called before the first frame update
    void Start()
    {
        savables.Add(this);
    }
}
