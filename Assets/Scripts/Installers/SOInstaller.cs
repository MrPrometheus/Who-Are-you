using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller
{
    public DialogData dialogData;

    public override void InstallBindings()
    {
        Container.BindInstance(dialogData).AsSingle();
    }
}
