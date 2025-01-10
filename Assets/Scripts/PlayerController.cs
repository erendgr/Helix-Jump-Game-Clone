using System.Net.Mail;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float bounceForce;
    public GameObject splitPrefab;
    public GameManager gameManager;
    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
        audioManager.Play("Land");
        
        Vector3 splitRot = new Vector3(90, 0, 0);
        GameObject split = Instantiate(splitPrefab, new Vector3(transform.position.x, transform.position.y - 0.218f, transform.position.z), Quaternion.Euler(splitRot));
        split.transform.localScale = Vector3.one * Random.Range(0.5f, 0.9f);
        split.transform.parent = other.gameObject.transform;

        Destroy(split, 5f);

        if (other.gameObject.CompareTag("Black"))
        {
            GameManager.gameOver = true;
            audioManager.Play("GameOver");
        }
        else if (other.gameObject.CompareTag("Finish") && !GameManager.levelComplete)
        {
            GameManager.levelComplete = true;
            audioManager.Play("LevelWin");
        }
        
    }
}