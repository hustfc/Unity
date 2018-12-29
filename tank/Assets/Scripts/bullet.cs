using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float moveSpeed = 10;
    public bool isPlayerBullet; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //第二个参数默认为space.self，如果是世界坐标系，需要填space.world
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World); //沿着y轴移动
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break; 
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);

                }
                break;
            case "Wall":
                Destroy(collision.gameObject);//销毁墙
                Destroy(gameObject);//销毁自身
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
