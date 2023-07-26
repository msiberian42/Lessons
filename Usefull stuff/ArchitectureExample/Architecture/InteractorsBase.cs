using System;
using System.Collections.Generic;

public class InteractorsBase
{
    private Dictionary<Type, Interactor> interactorsMap;
    private SceneConfig sceneConfig;

    public InteractorsBase(SceneConfig sceneConfig) 
    { 
        this.sceneConfig = sceneConfig;
    }

    public void CreateAllInteractors()
    {
        interactorsMap =  this.sceneConfig.CreateAllInteractors();
    }

    public void SendOnCreateAllInteractors()
    {
        var allInteractors = this.interactorsMap.Values;
        foreach ( var interactor in allInteractors )
        {
            interactor.OnCreate();
        }
    }
    public void InitializeAllInteractors()
    {
        var allInteractors = this.interactorsMap.Values;
        foreach ( var interactor in allInteractors )
        {
            interactor.Initialize();
        }
    }
    public void SendOnStartAllInteractors()
    {
        var allInteractors = this.interactorsMap.Values;
        foreach (var interactor in allInteractors)
        {
            interactor.OnStart();
        }
    }

    public T GetInteractor<T>() where T : Interactor
    {
        var type = typeof(T);
        return (T)this.interactorsMap[type];
    }
}
