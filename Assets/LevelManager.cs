using System.Collections;
using System.Collections.Generic;
using System.IO;             
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public string levelDefinitionFileName;

    LevelDefinition levelDefinition = new LevelDefinition();

    [System.Serializable]
    public class ObjectDefinition
    {
        public LevelDefinition.ObjectType type;
        public GameObject prefab;
    }

    public ObjectDefinition[] objectDefinitions;

    public Dictionary<LevelDefinition.ObjectType,GameObject> objectDefinitionDictionary = new Dictionary<LevelDefinition.ObjectType,GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(ObjectDefinition def in objectDefinitions)
        {
            objectDefinitionDictionary.Add(def.type,def.prefab);
        }
        if(!string.IsNullOrEmpty(levelDefinitionFileName))
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, levelDefinitionFileName + ".json");
            if(File.Exists(filePath))
            {
                levelDefinition = JsonUtility.FromJson<LevelDefinition>(File.ReadAllText(filePath));
                foreach(LevelDefinition.ObjectData data in levelDefinition.objectData)
                {
                    GameObject obj = Instantiate(objectDefinitionDictionary[data.type],data.position,data.rotation);
                    obj.transform.localScale = data.scale;
                    if(data.type == LevelDefinition.ObjectType.PullNode || data.type == LevelDefinition.ObjectType.PushNode)
                    {
                        obj.GetComponent<ForceBall>().force = data.magnitude;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        levelDefinition.objectData.Clear();
        foreach(SaveMe saveable in SaveMe.saveables)
        {
            LevelDefinition.ObjectData objectData = new LevelDefinition.ObjectData();
            objectData.position = saveable.transform.position;
            objectData.scale = saveable.transform.localScale;
            objectData.type = saveable.type;

            if(saveable.type == LevelDefinition.ObjectType.Goal)
            {
            }
            else if(saveable.type == LevelDefinition.ObjectType.PullNode)
            {
                objectData.magnitude = saveable.GetComponent<ForceBall>().force;
            }
            else if(saveable.type == LevelDefinition.ObjectType.PushNode)
            {
                objectData.magnitude = saveable.GetComponent<ForceBall>().force;
            }

            levelDefinition.objectData.Add(objectData);
        }

        if(string.IsNullOrEmpty(levelDefinitionFileName))
        {
            levelDefinitionFileName = System.Guid.NewGuid().ToString();
        }
        string filePath = Path.Combine(Application.streamingAssetsPath, levelDefinitionFileName + ".json");

        File.WriteAllText(filePath,JsonUtility.ToJson(levelDefinition));
    }
}
