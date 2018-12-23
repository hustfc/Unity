using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");//接受水平输入，范围为-1到1
        var v = Input.GetAxis("Vertical");
        rigid.AddForce(Vector3.right * h + Vector3.forward * v);
    }
}
