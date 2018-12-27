using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性值
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private bool isDefended = true;
    private float defendTimeVal = 3;//玩家无敌时间

    //引用
    private SpriteRenderer sr; //声明sr的类型
    public Sprite[] tankSprite; //声明精灵(sprite)数组 上 右 下 左
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject shieldPrefab;

    private void Awake()  //在awake里面就拿到引用
    {
        sr = GetComponent<SpriteRenderer>(); //使用GetComponent方法，在awake里面拿到SpriteRender的引用
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //保护是否处于无敌状态
        if (isDefended)
        {
            shieldPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
                shieldPrefab.SetActive(false);
            }
        }
        //攻击CD
        if (timeVal > 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate() //固定物理帧声明周期函数
    {
        Move();
    }

    private void Move() //坦克的移动方法
    {
        float v = Input.GetAxis("Vertical");
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
        //transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        //输入乘以速度乘以时间， 第二个参数是以什么坐标轴来移动
        //transform.Translate(Vector3.right * h, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
        //transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);//right是x轴，up是y轴，forward是z轴
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

    }

    //坦克的攻击方法
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //实例化函数 第一个参数为object，第二个为位置，第三个为旋转
            Debug.Log(transform.eulerAngles);
            Debug.Log(bulletEulerAngles);
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(bulletEulerAngles));
            timeVal = 0;
        }
    }

    //玩家的死亡方法
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

}
