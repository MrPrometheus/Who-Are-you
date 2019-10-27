using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public GameObject pointerImage;
    public Transform target;
    public float dist = 100f;

    // Start is called before the first frame update
    void Start()
    {
        pointerImage.SetActive(true);
    }
    
    void Update()
    {
        Vector3 direction =  (target.position - transform.position).normalized * dist;
        int x = (Screen.width / 2);
        int y = (Screen.height / 2);
        Vector3 position = new Vector3(x, y);
        pointerImage.transform.position = position + direction;
        
        // get the angle
        Vector3 norTar = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle);
        pointerImage.transform.rotation = rotation;
    }
}
