using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EffectsController : MonoBehaviour
{
    private Image Blackout;
    public Sprite[] turingCondition;
    public AudioClip VoiceWolfGeneration;
    private AudioSource audioSource;
    private static float Speed = 1.0f;


    private void Awake()
    {
        Blackout = GetComponent<Image>();
        Blackout.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator BlackoutProcess()
    {
        // включаем фон и сбрасываем alfa на 0
        Blackout.enabled = true;
        Blackout.color -= new Color(0, 0, 0, Blackout.color.a);
        // и медленно прибавляем alfa
        while (Blackout.color.a < 1)
        {
            Blackout.color += new Color(0, 0, 0, 1) * 0.01f * Speed;
            yield return null;
        }
    }

    public IEnumerator LighteningProcess()
    {
        // включаем фон и сбрасываем alfa на 1
        Blackout.enabled = true;
        Blackout.color += new Color(0, 0, 0, 1 - Blackout.color.a);
        // и медленно убавляем alfa
        while (Blackout.color.a > 0)
        {
            Blackout.color -= new Color(0, 0, 0, 1) * 0.01f * Speed;
            yield return null;
        }
        Blackout.enabled = false;
    }

    public IEnumerator SetDay(float delay)
    {
        // говорим, что нужно будет телепортнуть игрока к кровати
        ReloadDoor.isTeleportToPoint = true;
        // и показать анимацию засветление экрана
        ReloadAndAnimDoor.isBlackoutAnimation = true;
        yield return null; // чисто для того, чтобы это оставалось IEnumerator
        SceneManager.LoadScene("bashnya");
    }

    public IEnumerator SetNight()
    {
        // размер камеры ставим на 10
        Camera.main.orthographicSize = 10;
        // проигрываем звук превращения
        audioSource.clip = VoiceWolfGeneration;
        audioSource.Play();
        // кружочек с превращением волка
        GameObject circle = Blackout.gameObject.transform.GetChild(0).gameObject;
        circle.SetActive(true);
        // начинаем листать состояния превращения
        Image tureingImg = circle.transform.GetChild(0).GetComponent<Image>();
        for (int i = 0; i < turingCondition.Length; i++)
        {
            tureingImg.sprite = turingCondition[i];
            yield return new WaitForSeconds(2);
        }
        // выключаем кружочек с превращениями
        circle.SetActive(false);

    }
}
