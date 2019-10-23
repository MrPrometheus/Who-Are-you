using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web;
using System;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

public class DialCreator : MonoBehaviour
{
    public InputField InputField;
    public bool keke;

    private void Update()
    {
        if (keke) { Keke(); keke = false; }
    }

    private void Keke()
    {
        Question a = new Question
        {
            question = "Привет, меня зовут Вудс. Я тут так кое-чем занимаюсь, сможешь помочь?",
            answers = new string[] { "Да", "Нет", "Наверное" },
            pointsForQuestion = new int[] { 1, 0, 0 }
        };
        Question b = new Question
        {
            question = "Привет, меня зовут Вудс. Я тут так кое-чем занимаюсь, сможешь помочь?",
            answers = new string[] { "Да", "Нет", "Наверное" },
            pointsForQuestion = new int[] { 1, 0, 0 }
        };
        DialogSet dialogSet = new DialogSet() { DialogSets = new Dialog[]{ new Dialog { dialog = new Question[] {a,b} } } };
        dialogSet.DialogSets = new Dialog[1];
        dialogSet.DialogSets[0] = new Dialog();
        dialogSet.DialogSets[0].dialog = new Question[2] { a, b};
        dialogSet.CountBallsForNextLevel = 2;
        InputField.text = JsonHelper.ToJson<Question>(dialogSet.DialogSets[0].dialog);
    }
}
