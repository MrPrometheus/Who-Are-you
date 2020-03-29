using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MInstaller", menuName = "Installers/MInstaller")]
public class MInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DialogController>().AsSingle();
    }
}
