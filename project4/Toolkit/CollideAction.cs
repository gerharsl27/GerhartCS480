using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("SoXR Toolkit/Collide Action")]
public class CollideAction : MonoBehaviour
{
    [Tooltip("Only objects with this tag will trigger the event on collision.")]
    public string colliderTagName = "Grabbable";
    public UnityEvent onCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(colliderTagName))
        {
            onCollision.Invoke();
        }
    }
}
