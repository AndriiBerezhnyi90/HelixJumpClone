using UnityEngine;

[RequireComponent(typeof(SphereCollider),typeof(BallJumper))]
public class BallCollitionHandler : MonoBehaviour
{
    private SphereCollider _collider;
    private BallJumper _ballJumper;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _ballJumper = GetComponent<BallJumper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _ballJumper.Jump();
    }
}