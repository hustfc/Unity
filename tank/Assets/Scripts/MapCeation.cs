using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCeation : MonoBehaviour
{
    public GameObject[] item; //定义存放gameobject的数组
    //0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙
    private void Awake()
    {
        //实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);//物体 坐标 无旋转
        //墙围着老家
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
    }
    private void CreateItem(GameObject createGameObject, Vector3 createPosion, Quaternion createRotaion)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosion, createRotaion);
        itemGo.transform.SetParent(gameObject.transform);
    }
}
