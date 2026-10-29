using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("SoXR Toolkit/Sequence Action")]
public class SequenceAction : MonoBehaviour
{
    [Tooltip("The list of UnityEvents to run one after another.")]
    public UnityEvent[] steps;
    [Tooltip("Seconds to wait before this step fires.")]
    public float[] stepDelays;

    private int currentStep = 0;
    private float elapsedTime = 0f;
    private bool isRunning = false;

    private void Update()
    {
        if (!isRunning) return;
        if (steps == null || currentStep >= steps.Length)
        {
            StopSequence();
            return;
        }

        float currentDelay = 0f;
        if (stepDelays != null && currentStep < stepDelays.Length)
        {
            currentDelay = stepDelays[currentStep];
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= currentDelay)
        {
            steps[currentStep].Invoke();
            currentStep++;
            elapsedTime = 0f;
        }
    }

    public void StartSequence()
    {
        currentStep = 0;
        elapsedTime = 0f;
        isRunning = true;
    }

    public void StopSequence()
    {
        isRunning = false;
        currentStep = 0;
        elapsedTime = 0f;
    }
}
