using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DialogSOInstaller", menuName = "Installers/DialogSOInstaller")]
public class DialogSOInstaller : ScriptableObjectInstaller
{
    public DialogData dialogData;

    public override void InstallBindings()
    {
        Container.BindInstance(dialogData).AsSingle();
    }
}
