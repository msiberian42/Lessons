using System;
using System.Collections.Generic;

public class RepositoriesBase
{
    private Dictionary<Type, Repository> repositoriesMap;
    private SceneConfig sceneConfig;

    public RepositoriesBase(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
    }

    public void CreateAllRepositories()
    {
        this.repositoriesMap = this.sceneConfig.CreateAllRepositories();
    }

    public void SendOnCreateAllRepositories()
    {
        var allRepositories = this.repositoriesMap.Values;
        foreach (var repository in allRepositories)
        {
            repository.OnCreate();
        }
    }
    public void InitializeAllRepositories()
    {
        var allRepositories = this.repositoriesMap.Values;
        foreach (var repository in allRepositories)
        {
            repository.Initialize();
        }
    }
    public void SendOnStartAllRepositories()
    {
        var allRepositories = this.repositoriesMap.Values;
        foreach (var repository in allRepositories)
        {
            repository.OnStart();
        }
    }

    public T GetRepository<T>() where T : Repository
    {
        var type = typeof(T);
        return (T)this.repositoriesMap[type];
    }
}
