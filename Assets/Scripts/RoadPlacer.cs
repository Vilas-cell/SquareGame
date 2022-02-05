using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlacer : MonoBehaviour
{
    public Transform player;
    public Road[] RoadPrefabs;
    public Road FirstRoad;

    private List<Road> spawnedRoads = new List<Road>();

    void Start()
    {
        spawnedRoads.Add(FirstRoad);
    }

   
    void Update()
    {
        if (player.position.z > spawnedRoads[spawnedRoads.Count - 1].End.position.z - 90)
        {
            SpawnRoad();

        }
    }
    private void SpawnRoad()
    {
       Road newRoad = Instantiate(RoadPrefabs[Random.Range(0, RoadPrefabs.Length)]);
       newRoad.transform.position = spawnedRoads[spawnedRoads.Count-1].End.position - newRoad.Begin.localPosition;
       spawnedRoads.Add(newRoad);
    }
}
