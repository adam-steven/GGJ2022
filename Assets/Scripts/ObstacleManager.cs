using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    List<GameObject> instancedPrefabs;

    [SerializeField] GameObject segmentParent;
    [SerializeField] GameObject segmentPrefab;
    [SerializeField] GameObject endOfSegmentPrefab;
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] public float segmentPrefabSize = 1f;

    [SerializeField] public float segmentsPerLane = 6f;
    [SerializeField] public float lanes = 4f;

    float currentAdvanceSpeed = 0f;

    TimeManager timeManager;
    bool hasBeenNotified;

    public float coursesGenerated = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        instancedPrefabs = new List<GameObject>();
        GenerateCourse();
    }

    public void SetAdvanceSpeed(float unitsPerSecond)
    {
        currentAdvanceSpeed = unitsPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        AdvanceCourse();
    }

    void AdvanceCourse()
    {
        segmentParent.transform.position = new Vector3(segmentParent.transform.position.x, segmentParent.transform.position.y, segmentParent.transform.position.z - (currentAdvanceSpeed* Time.deltaTime));
    }

    void OnGenerateNewPartOfCourse()
    {

    }

    void GenerateCourse(float zOffset=0)
    {
        hasBeenNotified = false;
        for (var i = 0; i < lanes; ++i)
        {
            for (var j = 0; j < segmentsPerLane; j++)
            {
                var obj = Instantiate(segmentPrefab, segmentParent.transform);
                obj.transform.position = new Vector3(i, 0f, j - zOffset);
                instancedPrefabs.Add(obj);
            }
            GenerateObstacle(new Vector3(i, 0f, segmentsPerLane - 1f - zOffset));
        }

        coursesGenerated++;
    }

    void GenerateObstacle(Vector3 pos)
    {
        var obj = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], segmentParent.transform);
        obj.transform.position = pos;
        instancedPrefabs.Add(obj);

        var endOfSegmentObj = Instantiate(endOfSegmentPrefab, segmentParent.transform);
        endOfSegmentObj.transform.position = pos;
        instancedPrefabs.Add(endOfSegmentObj);

        endOfSegmentObj.GetComponentInChildren<NotifyOnEnter>().FunctionName = nameof(NotifyCarHasReachedEndOfSegment);
        endOfSegmentObj.GetComponentInChildren<NotifyOnEnter>().ScriptToNotify = this;
    }

    void NotifyCarHasReachedEndOfSegment()
    {
        if (hasBeenNotified)
            return;

        hasBeenNotified = true;

        foreach (var go in instancedPrefabs)
            Destroy(go);
        
        timeManager.TransitionIntoNewObstacle();
        segmentParent.transform.position = Vector3.zero;
        GenerateCourse();
    }
}
