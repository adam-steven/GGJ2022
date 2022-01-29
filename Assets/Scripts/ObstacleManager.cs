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

    float currentAdvanceSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        instancedPrefabs = new List<GameObject>();
        GenerateCourse();
    }

    void BeginAdvancingToNextSegment(float speed)
    {

    }

    // Update is called once per frame
    void Update()
    {
        AdvanceCourse();
    }

    void AdvanceCourse()
    {
        segmentParent.transform.position = new Vector3(segmentParent.transform.position.x, segmentParent.transform.position.y, segmentParent.transform.position.z + currentAdvanceSpeed);
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
