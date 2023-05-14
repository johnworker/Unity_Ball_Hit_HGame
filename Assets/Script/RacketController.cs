using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [Header("�t��")]
    public float speed;
    [Header("���s��")]
    public KeyCode left;
    [Header("���s�k")]
    public KeyCode right;

    [Header("����")]
    private Rigidbody rb;

    void Start()
    {
        // ���o����
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �}�� ���U��(�k) ���w ���� ���s�� �� ���s�k
        bool pressedLeft = Input.GetKey(this.left);
        bool pressedRight = Input.GetKey(this.right);

        // �p�G���U��
        if (pressedLeft)
        {
            // ����.�t�� = �T���V�q.�e�� * �t��;
            rb.velocity = Vector3.forward * speed;
        }
        // �p�G���U�k
        if (pressedRight)
        {
            // ����.�t�� = �T���V�q.��� * �t��;
            rb.velocity = Vector3.back * speed;
        }
        // �p�G�S���U���M�k
        if(!pressedLeft && !pressedRight)
        {
            // ����.�t�� = �T���V�q.�k�s
            rb.velocity = Vector3.zero;
        }
    }
}
