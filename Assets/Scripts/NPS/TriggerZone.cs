using UnityEngine;

public delegate void DTrigger(GameObject target);
public class TriggerZone : MonoBehaviour
{
    public static event DTrigger Triger;
    public float dayTriggerRadius;
    public float nightTrigerRadius;
    public int karma;
    public GameObject pointLight;

    private NpsAIRandomWalking randomWalking;
    private CircleCollider2D circleCollider;
    private bool isTriggered;

    private void Start()
    {
        DayController.DayHasCome += DayController_DayHasCome;
        DayController.NightHasCome += DayController_NightHasCome;
        circleCollider = GetComponent<CircleCollider2D>();
        randomWalking = GetComponent<NpsAIRandomWalking>();
    }

    private void DayController_NightHasCome()
    {
        circleCollider.radius = nightTrigerRadius;
        if (pointLight) pointLight.SetActive(true);
    }

    private void DayController_DayHasCome()
    {
        circleCollider.radius = dayTriggerRadius;
        if (pointLight) pointLight.SetActive(false);
    }

    private void OnDestroy()
    {
        DayController.DayHasCome -= DayController_DayHasCome;
        DayController.NightHasCome -= DayController_NightHasCome;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Werewolf"))
        {
            if (Triger != null && !isTriggered)
            {
                Triger(this.gameObject);
                isTriggered = true;
                // нас начинает убивать игрок - мы должны стоять )))
                if (randomWalking)
                {
                    randomWalking.isWorking = false;
                    randomWalking.isWalking = false;
                }
            }
        }
    }
}
