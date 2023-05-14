using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [Header("速度")]
    public float speed;
    [Header("按鈕左")]
    public KeyCode left;
    [Header("按鈕右")]
    public KeyCode right;

    [Header("鋼體")]
    private Rigidbody rb;

    void Start()
    {
        // 取得鋼體
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 開關 壓下左(右) 指定 按鍵 按鈕左 或 按鈕右
        bool pressedLeft = Input.GetKey(this.left);
        bool pressedRight = Input.GetKey(this.right);

        // 如果壓下左
        if (pressedLeft)
        {
            // 鋼體.速度 = 三維向量.前方 * 速度;
            rb.velocity = Vector3.forward * speed;
        }
        // 如果壓下右
        if (pressedRight)
        {
            // 鋼體.速度 = 三維向量.後方 * 速度;
            rb.velocity = Vector3.back * speed;
        }
        // 如果沒壓下左和右
        if(!pressedLeft && !pressedRight)
        {
            // 鋼體.速度 = 三維向量.歸零
            rb.velocity = Vector3.zero;
        }
    }
}
