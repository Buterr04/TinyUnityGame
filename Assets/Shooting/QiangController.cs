using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiangController : MonoBehaviour
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
        if (collision.transform.name.Contains("ZiDan"))
        {
            //Destroy(gameObject);
            StartCoroutine(OnTrigger());
        }

    }

    IEnumerator OnTrigger()
    {
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }
}
