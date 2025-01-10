using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] ringPrefabs;
    public float verticalDistance;
    public int ringAmount;
    public GameObject parent;
    
    void Start()
    {
        GenerateLevel(ringAmount);
    }


    public void GenerateLevel(int amount)
    {
        
        for (int i = 0; i < amount; i++)
        {
            GameObject ringPrefab = ringPrefabs[Random.Range(0, ringPrefabs.Length)];
            Vector3 ringPosition = new Vector3(0, i *  verticalDistance, 0);
            GameObject newRing = Instantiate(ringPrefab, ringPosition, Quaternion.identity);
            newRing.transform.parent = parent.transform;
            
        }
        
    }
}