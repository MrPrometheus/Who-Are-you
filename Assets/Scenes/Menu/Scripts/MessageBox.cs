using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class MessageBox : MonoBehaviour
{
    [SerializeField] private GameObject _question;
    [SerializeField] private GameObject _message;
    [SerializeField] private GameObject _saveBar;

    private string answer = "";

    /// <summary>
    /// Спросить что то
    /// </summary>
    /// <param name="qestion">Вопрос</param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public async Task<bool> Question(string qestion, string yes = "Да", string no = "Нет")
    {
        _question.SetActive(true);
        _question.transform.Find("Text").GetComponent<Text>().text = qestion;
        _question.transform.Find("ButtonYes").GetComponent<Text>().text = yes;
        _question.transform.Find("ButtonNo").GetComponent<Text>().text = no;
        while (answer == "") { await Task.Yield(); }
        _question.SetActive(false);
        switch (answer)
        {
            case "yes": ReleseAnswer();  return true;
            case "no": ReleseAnswer();  return false;
            default: ReleseAnswer();  throw new System.Exception("некорректный ответ");
        }
    }
    /// <summary>
    /// Вывести сообщение
    /// </summary>
    /// <param name="message"></param>
    /// <param name="ok"></param>
    /// <returns></returns>
    public async Task Message(string message, string ok = "Ок")
    {
        _message.SetActive(true);
        _message.transform.Find("Text").GetComponent<Text>().text = message;
        _message.transform.Find("ButtonOk").Find("Text").GetComponent<Text>().text = ok;
        while (answer == "") { await Task.Yield(); }
        ReleseAnswer();
        _message.SetActive(false);
    }

    public async void SaveAnim()
    {
        _saveBar.SetActive(true);
        Animation saveBarAnim = _saveBar.GetComponent<Animation>();
        saveBarAnim.Play("UpAndDown");
        _saveBar.transform.Find("Bar").GetComponent<Animation>().Play("Rotate");
        while (saveBarAnim.isPlaying) { await Task.Yield(); }
        _saveBar.SetActive(false);
    }


    private void ReleseAnswer()
    {
        answer = "";
    }

    public void Answer(string answer)
    {
        this.answer = answer;
    }

    
}
