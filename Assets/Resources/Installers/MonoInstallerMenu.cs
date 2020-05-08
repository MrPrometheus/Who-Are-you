using Zenject;

public class MonoInstallerMenu : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MySceneController>().AsSingle();
        Container.Bind<SaveManager>().AsSingle();
        Container.Bind<JSONSaver>().AsSingle();
    }
}