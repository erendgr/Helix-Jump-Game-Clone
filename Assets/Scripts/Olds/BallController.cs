using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector2 velocityLimit;
    private void FixedUpdate()
    {
        var vertical = myRigidbody.velocity;
        vertical.y = Mathf.Clamp(vertical.y, velocityLimit.x, velocityLimit.y);
        myRigidbody.velocity = vertical;
    }
}