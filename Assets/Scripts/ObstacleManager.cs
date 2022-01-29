using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    List<GameObject> instancedPrefabs;

    [SerializeField] GameObject segmentParent;
    [SerializeField] GameObject segmentPrefab;
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] float segmentPrefabSize = 1f;

    [SerializeField] float segmentsPerLane = 6f;
    [SerializeField] public float lanes = 4f;

    // Start is called before the first frame update
    void Start()
    {
        instancedPrefabs = new List<GameObject>();
        GenerateCourse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGenerateNewPartOfCourse()
    {

    }

    void GenerateCourse()
    {
        for (var i = 0; i < lanes; ++i)
        {
            for (var j = 0; j < segmentsPerLane; j++)
            {
                var obj = Instantiate(segmentPrefab, segmentParent.transform);
                obj.transform.position = new Vector3(i, 0f, j);
                instancedPrefabs.Add(obj);
            }
            GenerateObstacle(new Vector3(i, 0f, segmentsPerLane - 1f));
        }
    }

    void GenerateObstacle(Vector3 pos)
    {
        var obj = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], segmentParent.transform);
        obj.transform.position = pos;
        instancedPrefabs.Add(obj);
    }
}
