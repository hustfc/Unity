using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeVal;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(timeVal < 0.167f)
        {
            timeVal += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
