using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性值
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private float timeValChangeDirection = 4; //改变方向的时间计时器，一开始就移动
    private float v;
    private float h;

    //引用
    private SpriteRenderer sr; //声明sr的类型
    public Sprite[] tankSprite; //声明精灵(sprite)数组 上 右 下 左
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    //public GameObject shieldPrefab;

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
        //攻击的时间间隔
        if (timeVal > 1f)
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
        if(timeValChangeDirection >= 2f)
        {
            int num = Random.Range(0, 8);//往下面走的几率最大
            if(num > 5)
            {
                v = -1;
                h = 0;
            }
            else if(num == 0)   //往上走的几率最小
            {
                v = 1;
                h = 0;
            }
            else if(num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else
            {
                h = 1;
                v = 0;
            }
            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }
        //v = Input.GetAxis("Vertical");
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

        //h = Input.GetAxis("Horizontal");
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

        //实例化函数 第一个参数为object，第二个为位置，第三个为旋转
        Debug.Log("Enemy's bullet" + bulletEulerAngles);
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(bulletEulerAngles));
        timeVal = 0;



    }

    //玩家的死亡方法
    private void Die()
    {
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

}
