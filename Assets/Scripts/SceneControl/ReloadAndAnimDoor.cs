using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAndAnimDoor : ReloadDoor
{
    /// <summary>
    /// контроллер эффектов
    /// </summary>
    public EffectsController EffectsControllerBG;
    /// <summary>
    /// Указатель того, что нужно показать анимацию затемнения (засветления)
    /// </summary>
    public static bool isBlackoutAnimation;

    protected override void Start()
    {
        base.Start();
        if (isTeleportToPoint && isBlackoutAnimation)
        {
            StartCoroutine(EffectsControllerBG.LighteningProcess());
            isBlackoutAnimation = false;
        }
    }
}
