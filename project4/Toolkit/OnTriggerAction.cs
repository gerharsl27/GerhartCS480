using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("SoXR Toolkit/On Trigger Action")]
public class OnTriggerAction : MonoBehaviour
{
    [Tooltip("Only objects with this tag will set off the trigger. Use MainCamera for the player.")]
    public string triggerTagName = "MainCamera";
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTagName))
        {
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTagName))
        {
            onExit.Invoke();
        }
    }
}
