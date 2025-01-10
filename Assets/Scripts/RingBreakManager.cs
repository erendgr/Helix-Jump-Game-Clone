using UnityEngine;

public class RingBreakManager : MonoBehaviour
{

    public GameObject[] pieces;
    public Transform target;
    
    public float radius = 5f;
    public float force = 200f;

    
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.position.y);
    }

    private void Update()
    {
        if (target.position.y < transform.position.y)
        {
            GameManager.numberOfPassedRings++;
            FindObjectOfType<AudioManager>().Play("Whoosh");
            
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].GetComponent<Rigidbody>().isKinematic = false;
                pieces[i].GetComponent<Rigidbody>().useGravity = true;
                
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (var newColliders in colliders)
                {
                    Rigidbody rb = newColliders.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, radius);
                    }
                }
                //pieces[i].GetComponent<MeshCollider>().enabled = false;
                pieces[i].transform.parent = null;
                Destroy(pieces[i].gameObject, 2f);
                Destroy(gameObject, 5f);
            }
            this.enabled = false;
        }
    }

    void Explode()
    {
        
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].GetComponent<Rigidbody>().isKinematic = false;
            pieces[i].GetComponent<Rigidbody>().useGravity = true;
                
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (var newColliders in colliders)
            {
                Rigidbody rb = newColliders.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }
        }
    }

}