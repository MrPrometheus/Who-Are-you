using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public delegate void Scores(int score);

public class DialogController : MonoBehaviour
{
    public int OpenPanelSpeed = 5;
    [Inject]
    private JoysticController _joysticController;
    [SerializeField]
    private Text Name;
    [SerializeField]
    private Text Question;
    [SerializeField]
    private Image HeadOfNps;
    [SerializeField]
    private GameObject[] Buttons;
    [SerializeField]
    private Text[] Answers;
    [SerializeField]
    private string[] VariansForLeave;

    public event Scores EndDialog;
    
    bool isAnswered = false;
    float startScaleY;
    int currentAnswere = -1;
    int nextAnswere = 0;
    int currentScore = 0;
    

    private void Start()
    {
        startScaleY = transform.localScale.y;
        transform.localScale -= new Vector3(0, 1) * startScaleY;
        Answers = new Text[Buttons.Length];
        for (int i = 0; i < Answers.Length; i++)
            Answers[i] = Buttons[i].transform.GetChild(0).GetComponent<Text>();
        DayController.NightHasCome += DayController_NightHasCome;
    }

    // елси пришла ночь, то завершаем диалог
    private void DayController_NightHasCome()
    {
        Click(-1);
    }

    public void StartDialog(Dialog dialog,string Name, Sprite head)
    {
        _joysticController.currentJoystick.gameObject.SetActive(false);
        this.Name.text = Name;
        HeadOfNps.sprite = head;
        nextAnswere = 0;
        StartCoroutine(StartDialogEnumerator(dialog));
        StartCoroutine(open());
    }

    IEnumerator StartDialogEnumerator(Dialog dialog)
    {
        _joysticController.currentJoystick.gameObject.SetActive(false);
        while (true)
        {
            Question.text = dialog.QusetionSet[nextAnswere].NPCQuestion;
            int j = 0;
            for (; j < dialog.QusetionSet[nextAnswere].Answers.Length; j++)
            {
                Answers[j].text = (j+1) + ". " + dialog.QusetionSet[nextAnswere].Answers[j];
                Buttons[j].gameObject.SetActive(true);
            }
            //Answers[j].text = (j + 1) + " " + VariansForLeave[Random.Range(0, VariansForLeave.Length)];
            //Buttons[j].gameObject.SetActive(true);
            //j++;
            for (; j < Buttons.Length-1; j++)
            {
                Buttons[j].gameObject.SetActive(false);
            }
            isAnswered = false;
            while (!isAnswered) yield return null;
            if (currentAnswere == -1)
            { Off(); break; }
            currentScore += dialog.QusetionSet[nextAnswere].PointsForQuestion[currentAnswere];
            nextAnswere = dialog.QusetionSet[nextAnswere].NextQuestionNumber[currentAnswere];
            if (nextAnswere < 0 || nextAnswere > dialog.QusetionSet.Length - 1)
            { Off(); break; }

        }

    }

    // выбор варинта ответа на вопрос непися
    public void Click(int num)
    {
        isAnswered = true;
        currentAnswere = num;
    }

    // закончить диалог
    public void Off()
    {
        EndDialog(currentScore);
        currentScore = 0;
        _joysticController.currentJoystick.gameObject.SetActive(true);
        StartCoroutine(close());
    }
    
    IEnumerator close()
    {
        while(transform.localScale.y >= 0)
        {
            transform.localScale -= new Vector3 (0, 1) * 0.01f * OpenPanelSpeed;
            yield return null;
        }
        
    }

    IEnumerator open()
    {
        while (transform.localScale.y <= startScaleY)
        {
            transform.localScale += new Vector3(0, 1) * 0.01f * OpenPanelSpeed;
            yield return null;
        }

    }
}
