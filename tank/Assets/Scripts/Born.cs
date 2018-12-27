using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerPrefab;
    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BornTank()
    {
        Instantiate(PlayerPrefab, transform.position, Quaternion.identity);//无旋转
    }
}
