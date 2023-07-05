using System;
using UnityEngine;

public class Timer
{
    public event Action<float> OnTimerValueChangedEvent;
    public event Action OnTimerFinishedEvent;

    public TimerType type { get; }
    public float remainingSeconds { get; private set; }
    public bool isPaused { get; private set; }

    public Timer (TimerType type)
    {
        this.type = type;
    }

    public Timer (TimerType type, float seconds)
    {
        this.type = type;
        SetTime(seconds);
    }

    public void SetTime(float seconds)
    {
        remainingSeconds = seconds;
        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }
    public void Start()
    {
        if (remainingSeconds == 0)
        {
            Debug.LogError("TIMER: You are trying to start timer with remaining seconds equal 0");
            OnTimerFinishedEvent?.Invoke();
        }

        isPaused = false;
        Subscribe();
        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }
    public void Start (float seconds)
    {
        SetTime(seconds);
        Start();
    }
    public void Pause()
    {
        isPaused = true;
        Unsubscribe();
        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }
    public void Unpause()
    {
        isPaused = false;
        Subscribe();
        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }
    public void Stop()
    {
        Unsubscribe();
        remainingSeconds = 0;

        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
        OnTimerFinishedEvent?.Invoke();
    }
    private void Subscribe()
    {
        switch (type)
        {
            case TimerType.UpdateTick:
                TimeInvoker.instance.OnUpdateTimeTickedEvent += OnUpdateTick;
                break;
            case TimerType.UpdateTickUnscaled:
                TimeInvoker.instance.OnUpdateTimeUnscaledTickedEvent += OnUpdateTick;
                break;
            case TimerType.OneSecTick:
                TimeInvoker.instance.OnOneSecondTickedEvent += OnOneSecondTick;
                break;
            case TimerType.OneSecTickUnscaled:
                TimeInvoker.instance.OnOneSecondUnscaledTimeTickedEvent += OnOneSecondTick;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void Unsubscribe() 
    {
        switch (type)
        {
            case TimerType.UpdateTick:
                TimeInvoker.instance.OnUpdateTimeTickedEvent -= OnUpdateTick;
                break;
            case TimerType.UpdateTickUnscaled:
                TimeInvoker.instance.OnUpdateTimeUnscaledTickedEvent -= OnUpdateTick;
                break;
            case TimerType.OneSecTick:
                TimeInvoker.instance.OnOneSecondTickedEvent -= OnOneSecondTick;
                break;
            case TimerType.OneSecTickUnscaled:
                TimeInvoker.instance.OnOneSecondUnscaledTimeTickedEvent -= OnOneSecondTick;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void OnUpdateTick(float deltaTime)
    {
        if (isPaused) 
            return;

        remainingSeconds -= deltaTime;
        CheckFinish();
    }
    private void OnOneSecondTick()
    {
        if (isPaused) 
            return;

        remainingSeconds -= 1f;
        CheckFinish();
    }
    private void CheckFinish()
    {
        if (remainingSeconds <= 0) 
            Stop();
        else
            OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }
}
