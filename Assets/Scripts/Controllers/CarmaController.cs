using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarmaController : MonoBehaviour
{
    [SerializeField]
    private Text KarmaTextCount;
    private GameObject KarmaObj;
    private static int currentCarma = 0;

    private void Start()
    {
        WolfAnimController.UdpateKarma += UpdateKarma;
        DayController.DayHasCome += DayController_DayHasCome;
        DayController.BlackOutAnimEnd += DayController_BlackOutAnimEnd;
        KarmaObj = transform.GetChild(0).gameObject;
        KarmaObj.SetActive(false);
        KarmaTextCount.text = currentCarma + "";
    }

    private void DayController_BlackOutAnimEnd()
    {
        KarmaObj.SetActive(true);
    }

    private void DayController_DayHasCome()
    {
        KarmaObj.SetActive(false);
    }

    private void OnDestroy()
    {
        WolfAnimController.UdpateKarma -= UpdateKarma;
        DayController.DayHasCome -= DayController_DayHasCome;
        DayController.BlackOutAnimEnd -= DayController_BlackOutAnimEnd;
    }

    public void UpdateKarma(int newKarma)
    {
        currentCarma -= newKarma;
        KarmaTextCount.text = currentCarma + "";
    }
}
