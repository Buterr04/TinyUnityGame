using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiDanController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Cube"))
        {
            ShottingController.Instance.SettingScore();
            //Destroy(gameObject);
           
        }
        StartCoroutine(OnTrigger());
    }

    IEnumerator OnTrigger()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
