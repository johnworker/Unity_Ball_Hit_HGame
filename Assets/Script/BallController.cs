using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("速度")]
    public float speed;
    [Header("最小方向")]
    public float minDirection = 0.5f;

    [Header("方向")]
    private Vector3 direction;
    [Header("鋼體")]
    private Rigidbody rb;

    void Start()
    {
        // 取得這個物件剛體並初始化
        this.rb = GetComponent<Rigidbody>();

        this.ChooseDirection();
    }

    void Update()
    {
        // 方法1
        // 物體位置 增加移動  方向 * 速度 * 間格時間
        // transform.position += direction * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // 定義這個物件鋼體移動位置(物件鋼體位置 + 方向 * 速度 * 每一針間格時間)
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 這個物件跟牆壁觸發事件時 方向Z軸變相反
        if (other.CompareTag("牆壁"))
        {
            direction.z = -direction.z;
        }

        // 這個物件跟球拍觸發事件時 
        if (other.CompareTag("Racket"))
        {
            // 定義三維向量 新方向 = (球體位置 - 其他物體位置).歸一化
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            // 新方向.x軸 = 計算.標示(新方向.x軸) * 計算.最大值(計算.絕對值(新方向.x軸), 此物件.最小方向);
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            // 新方向.z軸 = 計算.標示(新方向.z軸) * 計算.最大值(計算.絕對值(新方向.z軸), 此物件.最小方向);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            // 方向 指定 新方向
            direction = newDirection;
        }
    }

    private void ChooseDirection()
    {
        // 浮點數 標示X = 計算.標示(隨機值);
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        // 浮點數 標示Z = 計算.標示(隨機值);
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        // 定義這個物件方向 X軸0.5f , Z軸0.5f
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);

    }
}
