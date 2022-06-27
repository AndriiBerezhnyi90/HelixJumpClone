using UnityEngine;

[RequireComponent(typeof(SphereCollider),typeof(BallJumper))]
public class BallCollitionHandler : MonoBehaviour
{
    private BallJumper _ballJumper;

    private void Start()
    {
        _ballJumper = GetComponent<BallJumper>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _ballJumper.Jump();
    }
}