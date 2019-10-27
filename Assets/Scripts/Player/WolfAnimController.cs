using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void DKarma(int newKarma);

public class WolfAnimController : MonoBehaviour
{
   
    public Image BloodImage;

    public AudioClip Blood;
    public AudioClip Growl;

    public static event DKarma UdpateKarma;

    private Joystick joystick;
    private AudioSource audioSource;
    private Animator wolfAnim;
    private Move move;

    private Vector2 Direction { get { return move.Direction; } }
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private List<GameObject> targets = new List<GameObject>();
    private static float maxAlfaBlood = 0.8f;
    private bool attackInProgress = false;
    private bool attackIsEnd = true;

    void Start()
    {
        wolfAnim = GetComponent<Animator>();
        move = GetComponent<Move>();
        audioSource = GetComponent<AudioSource>();
        joystick = move.joystick;
        TriggerZone.Triger += TriggerZoneOnTriger;
    }
    private void OnDestroy()
    {
        TriggerZone.Triger -= TriggerZoneOnTriger;
    }
    void Update()
    {
        if (Direction.magnitude > 0) wolfAnim.SetBool(IsRunning, true);
        else if (!attackInProgress) wolfAnim.SetBool(IsRunning, false);
    }
    
    IEnumerator bloodAnimation()
    {
        yield return fillBlood();
        yield return new WaitForSeconds(1);
        yield return closeBlood();
    }
    IEnumerator fillBlood()
    {
        while(BloodImage.fillAmount != 1)
        {
            BloodImage.fillAmount += 0.04f;
            yield return null;
        }
    }
    IEnumerator closeBlood()
    {
        while (BloodImage.color.a > 0)
        {
            var c = BloodImage.color;
            BloodImage.color = new Color(c.r, c.g, c.b, c.a - 0.01f);
            yield return null;
        }
        BloodImage.fillAmount = 0;
        var cl = BloodImage.color;
        BloodImage.color = new Color(cl.r, cl.g, cl.b, maxAlfaBlood);
    }

    // метод, вызываемый аниамцией атаки
    private void EndAttack()
    {
        attackIsEnd = true;
    }
    private void Play(AudioClip clip)
    {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    private void TriggerZoneOnTriger(GameObject target)
    {
        joystick.isWork = false; // блокируем джостик
        if (attackInProgress) targets.Add(target);
        else StartAttac(target);
    }
    private void StartAttac(GameObject target)
    {
        attackInProgress = true;
        wolfAnim.SetBool(IsRunning, true);
        StartCoroutine(Attack(target));
    }
    IEnumerator Attack(GameObject target)
    {
        // поворот в сторону непися
        if (target.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        Play(Growl); // звук рычания
        attackIsEnd = false;
        // бежим к неписю
        while (Vector2.Distance(transform.position, target.transform.position) > 0.4f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * move.Speed);
            yield return null;
        }
        // либо едим, лобо бьем лапой непися
        string[] attackVariant = new string[] { "DoAttack", "DoEat" };
        wolfAnim.SetTrigger(attackVariant[Random.Range(0,attackVariant.Length)]);
        wolfAnim.SetBool(IsRunning, false);
        Play(Blood); // звук крови
        StartCoroutine(bloodAnimation()); // анимация крови на экране
        while (!attackIsEnd) // пока не закончилась анимация атаки
        {
            yield return null;
        }
        // если есть показатель кармы - обновляем ее
        if (UdpateKarma != null) UdpateKarma(target.GetComponent<TriggerZone>().karma);
        audioSource.Stop(); // заканчиваем звук крови
        
        Destroy(target); // удаляем цель (в будующем запускаем у цели анимацию смерти)
        // если есть еще цели
        if (targets.Count > 0)
        {
            // нападаем на следующего
            StartAttac(targets[0]);
            targets.RemoveAt(0);
        }
        // иначе заканчиваем атаку
        else
        {
            joystick.isWork = true; // разблокируем джостик
            attackInProgress = false;
        }
    }
}
