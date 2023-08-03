using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ObjectDatabaseSO : ScriptableObject
{
    public List<ObjectData> objectData;

    [Serializable]
    public class ObjectData
    {
       [field: SerializeField]

       public string Name { get; private set; }
        [field: SerializeField]

        public int ID { get; private set; }
        [field: SerializeField]

        public GameObject prefab { get; private set; }
    }
}
