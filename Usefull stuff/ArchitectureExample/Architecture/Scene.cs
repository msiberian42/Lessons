using System.Collections;
using UnityEngine;

public class Scene
{
    private InteractorsBase interactorsBase;
    private RepositoriesBase repositoriesBase;
    private SceneConfig sceneConfig;

    public Scene(SceneConfig sceneConfig) 
    {
        this.sceneConfig = sceneConfig;
        this.interactorsBase = new InteractorsBase(sceneConfig);
        this.repositoriesBase = new RepositoriesBase(sceneConfig);
    }

    public Coroutine InitializeAsync()
    {
        return Coroutines.StartRoutine(this.InitializeRoutine());
    }

    public IEnumerator InitializeRoutine()
    {
        interactorsBase.CreateAllInteractors();
        repositoriesBase.CreateAllRepositories();
        yield return null;

        interactorsBase.SendOnCreateAllInteractors();
        repositoriesBase.SendOnCreateAllRepositories();
        yield return null;

        interactorsBase.InitializeAllInteractors();
        repositoriesBase.InitializeAllRepositories();
        yield return null;

        interactorsBase.SendOnStartAllInteractors();
        repositoriesBase.SendOnStartAllRepositories();
    }

    public T GetRepository<T>() where T : Repository
    {
        return this.repositoriesBase.GetRepository<T>();
    }
    public T GetInteractor<T>() where T : Interactor
    {
        return this.interactorsBase.GetInteractor<T>();
    }
}
