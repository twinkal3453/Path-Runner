using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[] ObsticlePrefabs;

    private Transform playerTransform;
    private float spawnZ = -0.0f;
    private float tileLength = 15.0f;
    private float safeZone = 25.0f;
    private int amnTilesOnScreen = 5;
    private int lastprefabIndex = 0;

    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    private void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            if(i < 2)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }


    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastprefabIndex;
        while (randomIndex == lastprefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);
        }
        lastprefabIndex = randomIndex;
        return randomIndex;
    }
}
