using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCeation : MonoBehaviour
{
    public GameObject[] item; //定义存放gameobject的数组
    //0.老家 1.墙 2.障碍  3.河流 4.草 5.出生效果 6.空气墙
    private List<Vector3> itemPosition = new List<Vector3>();//已经有东西位置的列表
    private int numOfObject = 80; //随机化物体的数量
    private void Awake()
    {
        InitialMap();
    }

    private void InitialMap()
    {
        //实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);//物体 坐标 无旋转
        //墙围着老家
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        //实例化外围墙
        for (int i = -11; i <= 11; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -8; i <= 8; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }
        //初始化玩家
        GameObject go = Instantiate(item[5], new Vector3(-2, -8, 0), Quaternion.identity);
        itemPosition.Add(new Vector3(-2, -8, 0)); //防止出生地生成物体
        go.GetComponent<Born>().createPlayer = true;

        //初始化敌人，不需要设置bool值，因为默认的false
        CreateItem(item[5], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[5], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[5], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 4f, 5f);  //方法名，延时，每隔多久调用一次

        //实例化随机物体
        int j = 0;
        while (j < numOfObject)
        {
            Vector3 createPosion = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (IsIntheList(createPosion) == false)
            {
                CreateItem(item[Random.Range(1, 5)], createPosion, Quaternion.identity);
                j += 1;
            }
        }
    }

    private void CreateItem(GameObject createGameObject, Vector3 createPosion, Quaternion createRotaion)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosion, createRotaion);
        itemGo.transform.SetParent(gameObject.transform);
        itemPosition.Add(createPosion);//产生的位置放在列表里面
    }

    private bool IsIntheList(Vector3 position)
    {
        for (int i = 0; i < itemPosition.Count; i++)
        {
            if (itemPosition[i] == position)
            {
                return true;
            }
        }
        return false;
    }

    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);//因为有三个位置需要生成敌人
        Vector3 EnemyPos;
        if (num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else
        {
            EnemyPos = new Vector3(10, 8, 0);
        }
        CreateItem(item[5], EnemyPos, Quaternion.identity);
    }
}
