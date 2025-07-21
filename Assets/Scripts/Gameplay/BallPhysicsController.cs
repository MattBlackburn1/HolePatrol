using UnityEngine;

public class BallPhysicsController : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField] private float forceMultiplier = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyForce(Vector3 direction)
    {
        rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }
    
    public bool IsMoving()
    {
        return rb.linearVelocity.magnitude > 0.05f;
    }

    public void StopMoving()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}