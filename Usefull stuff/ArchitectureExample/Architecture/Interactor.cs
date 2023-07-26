public abstract class Interactor
{
    public virtual void OnCreate() { } //  огда все репо и интеракторы созданы

    public virtual void Initialize() { } //  огда все репо и интеракторы сделали OnCreate
    public virtual void OnStart() { } //  огда все репо и интеракторы проинициализированы
}
