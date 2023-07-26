using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehaviour> behavioursMap;
    private IPlayerBehaviour behaviourCurrent;

    private void Start()
    {
        this.InitBehaviours();
        this.SetBehaviourByDefault();
    }

    private void InitBehaviours()
    {
        this.behavioursMap = new Dictionary<Type, IPlayerBehaviour>();

        this.behavioursMap[typeof(PlayerBehaviourActive)] = new PlayerBehaviourActive();
        this.behavioursMap[typeof(PlayerBehaviourAgressive)] = new PlayerBehaviourAgressive();
        this.behavioursMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle();
    }
    private void SetBehaviour(IPlayerBehaviour newBehaviour)
    {
        if (this.behaviourCurrent != null)
            this.behaviourCurrent.Exit();

        this.behaviourCurrent = newBehaviour;
        this.behaviourCurrent.Enter();
    }

    private void SetBehaviourByDefault()
    {
        this.SetBehaviourIdle();
    }

    private IPlayerBehaviour GetBehavior<T>() where T : IPlayerBehaviour
    {
        var type = typeof(T);
        return this.behavioursMap[type];
    }

    private void Update()
    {
        if (this.behaviourCurrent != null)
            this.behaviourCurrent.Update();
    }

    public void SetBehaviourIdle()
    {
        var type = this.GetBehavior<PlayerBehaviourIdle>();
        this.SetBehaviour(type);
    }
    public void SetBehaviourAgressive()
    {
        var type = this.GetBehavior<PlayerBehaviourAgressive>();
        this.SetBehaviour(type);
    }
    public void SetBehaviourActive()
    {
        var type = this.GetBehavior<PlayerBehaviourActive>();
        this.SetBehaviour(type);
    }
}
