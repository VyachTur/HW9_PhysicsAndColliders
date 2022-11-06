using UnityEngine;

public class SphereNonGravity : MonoBehaviour
{
    private Rigidbody rigidbodyOnCollider;

    private void OnTriggerEnter(Collider other)
    {
        GravityOn(other, false);
        SetDrag(0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        GravityOn(other, true);
        SetDrag(0f);
    }

    private void GravityOn(Collider other, bool isOn)
    {
        rigidbodyOnCollider = other.GetComponent<Rigidbody>();

        if (rigidbodyOnCollider)
            rigidbodyOnCollider.useGravity = isOn;
    }

    private void SetDrag(float drag)
    {
        rigidbodyOnCollider.drag = drag;
    }
}
