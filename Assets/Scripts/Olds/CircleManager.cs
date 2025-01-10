using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleManager : MonoBehaviour
{
    [SerializeField] private GameObject piecePrefab;
    [SerializeField] private CircleController circlePrefab;
    
    private const float FullAngle = 360;

    [SerializeField] private int editorCreateCirlcleAmount;
    [SerializeField] private float verticalDistance;

    //[SerializeField] private List<CircleContoller> allCirlcles = new();
    
    [ContextMenu(nameof(EditorCreate))]
    public void EditorCreate()
    {
        Create(editorCreateCirlcleAmount);
    }

    private void Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var current = Instantiate(circlePrefab);
            current.transform.position = new Vector3(0, i * verticalDistance, 0);
            var random = Random.Range(2, 5);
            current.PrepareSimple(random);
        }
    }


    private GameObject CreateCircleFromPiece()
    {
        var parent = new GameObject()
        {
            transform = {name = "Parent"}
        };
        
        int amount = 12;
        for (int i = 0; i < amount; i++)
        {
            var current = Instantiate(piecePrefab, parent.transform, true);
            var rotation = current.transform.rotation;
            rotation.eulerAngles = new Vector3(0, FullAngle/amount * i, 0);
            current.transform.rotation = rotation;
        }
        return parent;
    }
}
