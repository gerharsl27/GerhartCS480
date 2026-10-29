using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("SoXR Toolkit/Timed Action")]
public class TimedAction : MonoBehaviour
{
    [Tooltip("The countdown length in seconds.")]
    public float duration = 10f;
    [Tooltip("If checked, countdown begins as soon as scene starts.")]
    public bool startOnAwake;
    [Tooltip("If checked, timer restarts after completion.")]
    public bool repeat;
    [Tooltip("how many times to repeat. Set to 0 to repeat forever.")]
    public int repeatCount;
    public UnityEvent onTimerComplete;
    private float elapsedTime = 0f;
    private bool isRunning = false;
    private int currRepetitions = 0;

    private void Start()
    {
        if (startOnAwake)
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= duration)
        {
            onTimerComplete.Invoke();

            if (repeat)
            {
                currRepetitions++;
                if (repeatCount > 0 && currRepetitions >= repeatCount)
                {
                    StopTimer();
                }
                else
                {
                    elapsedTime = 0f;
                }
            }
            else
            {
                StopTimer();
            }
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
        currRepetitions = 0;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
        elapsedTime = 0f;
    }
}
