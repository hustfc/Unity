using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("唤醒");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        var temp = 1 + 1;
        Debug.Log(temp);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
    }

    private void OnEnable()  //激活的时候被调用
    {
        Debug.Log("对象激活");
    }
    private void OnDisable()
    {
        Debug.Log("对象休眠");
    }
    private void OnDestroy()
    {
        Debug.Log("对象销毁");
    }
}
