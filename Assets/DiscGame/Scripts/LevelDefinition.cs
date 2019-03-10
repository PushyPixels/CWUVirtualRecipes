using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelDefinition
{
    [System.Serializable]
    public enum ObjectType
    {
        PushNode,
        PullNode,
        Goal
    }

    [System.Serializable]
    public class ObjectData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public ObjectType type;
        public float magnitude;
    }

    public List<ObjectData> objectData = new List<ObjectData>();
}
