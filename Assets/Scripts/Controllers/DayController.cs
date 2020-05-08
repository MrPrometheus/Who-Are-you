using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum TimeOfDay {Night, Day}
public delegate void Void();
public delegate IEnumerator Enumerate();

public class DayController : MonoBehaviour
{
    public float Speed;
    public float NightDelay;
    public float DayDelay;
    public float TransivityDelay = 0.5f;
    public float NightIntensivity;
    public float TransitionIntensivity;
    public float DayIntensivity;
    public float TuringBetweenDelay = 1.5f;
    public EffectsController EffectsControllerBG;
    
    public static event Void DayHasCome;
    public static event Void NightHasCome;
    public static event Void BlackOutAnimEnd;
    private Light Sun;

    private static bool toDay = true;
    private static bool isDelay = false;
    private static bool isTransition = true;

    private float timeStartOfDelay;
    private static float currentIntensivity = 0.71f;
    private static float lastDelay = 0;
    
    private void Start()
    {
        Sun = GetComponent<Light>();
        Sun.intensity = currentIntensivity;
        Camera.main.orthographicSize = 5;
        // если мы запустили день и были на задержке (зашли в дом), то ставим день на оставшееся от задержки время
        if (isDelay) StartCoroutine(Delay(DayDelay - lastDelay));
        Debug.Log(lastDelay);
    } 
    void Update()
    {
        if (!isDelay)
            if (toDay) // Наступление дня
                if (Sun.intensity < DayIntensivity)
                {
                    Sun.intensity += 0.001f * Speed;
                    currentIntensivity = Sun.intensity;
                    // если мы не в процессе перерождения и интенсивность солнца переходящего значения
                    if (!isTransition && Sun.intensity > TransitionIntensivity)
                    {
                        isTransition = true;
                        // запускаем цикл превращений, которые надо показать перед тем, как вызвать событие день
                        StartCoroutine(BlackoutEvent(EffectsControllerBG.SetDay(TransivityDelay), DayHasCome));
                    }
                }
                // день наступл, включаем задержку дня
                else
                {
                    toDay = false;
                    isTransition = false;
                    StartCoroutine(Delay(DayDelay));
                }
            else   // Наступление ночи
                if (Sun.intensity > NightIntensivity)
                {
                    Sun.intensity -= 0.001f * Speed;
                    // если мы не в процессе перерождения и интенсивность солнца переходящего значения
                    if (!isTransition && Sun.intensity < TransitionIntensivity)
                    {
                        isTransition = true;
                        // запускаем цикл превращений, которые надо показать перед тем, как вызвать событие день
                        StartCoroutine(BlackoutEvent(EffectsControllerBG.SetNight(), NightHasCome));
                    }
                }
                // ночь наступали, включаем задержку ночи
                else
                {
                    lastDelay = 0;
                    toDay = true;
                    isTransition = false;
                    StartCoroutine(Delay(NightDelay));
                }
    }
    private void OnDestroy()
    {
        lastDelay = Time.time - timeStartOfDelay + lastDelay;
    }

    // аниация смены дня/ночи   
    private IEnumerator BlackoutEvent(IEnumerator func, Void Event)
    {
        yield return EffectsControllerBG.BlackoutProcess();
        yield return func;
        if (Event != null) Event();
        yield return EffectsControllerBG.LighteningProcess();
        if (BlackOutAnimEnd != null) BlackOutAnimEnd();
    }
    // задержка для дня и ночи 
    private IEnumerator Delay(float delaySec)
    {
        timeStartOfDelay = Time.time;
        isDelay = true;
        yield return new WaitForSeconds(delaySec);
        isDelay = false;
    }
   
}
