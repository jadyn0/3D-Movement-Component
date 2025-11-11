using UnityEngine;

public class PhysicsPlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        float motion = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        
    }
}
