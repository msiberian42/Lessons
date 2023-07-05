using UnityEngine;

public class TimerTester : MonoBehaviour
{
    [SerializeField] private TimerType _type;
    [SerializeField] private float _timerSeconds;

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(_type, _timerSeconds);
        _timer.OnTimerValueChangedEvent += OnTimerValueChanged;
        _timer.OnTimerFinishedEvent += OnTimerFinished;
    }
    private void OnTimerValueChanged(float remainingSeconds)
    {
        Debug.Log($"Timer ticked. Remaining seconds: {remainingSeconds}");
    }
    private void OnTimerFinished()
    {
        Debug.Log($"Timer finished");
    }

    private void OnDestroy()
    {
        _timer.OnTimerValueChangedEvent -= OnTimerValueChanged;
        _timer.OnTimerFinishedEvent -= OnTimerFinished;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            StartTimerClicked();

        if (Input.GetKeyDown(KeyCode.Space))
            PauseTimerClicked();

        if (Input.GetKeyDown(KeyCode.S))
            StopTimerClicked();
    }
    private void StartTimerClicked()
    {
        _timer.Start();
    }
    private void PauseTimerClicked()
    {
        if (_timer.isPaused)
            _timer.Unpause();
        else
            _timer.Pause();
    }
    private void StopTimerClicked()
    {
        _timer.Stop();
    }
}
