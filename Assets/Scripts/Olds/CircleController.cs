using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    public List<GameObject> pieces;
    
    public void PrepareSimple(int nonactiveAmount)
    {
        int index = Random.Range(0, pieces.Count);

        for (int i = 0; i < nonactiveAmount; i++)
        {
            var item = pieces[index];
            item.SetActive(false);
            index++;
            if (index >= pieces.Count)
            {
                index = 0;
            }
        }
    }
    
    public void PrepareSimple2(int nonactiveAmount)
    {
        for (int i = 0; i < nonactiveAmount; i++)
        {
            Debug.Log("b");
            int index = Random.Range(0, pieces.Count);
            var item = pieces[index];
            item.SetActive(false);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].GetComponent<Rigidbody>().isKinematic = false;
                pieces[i].GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}