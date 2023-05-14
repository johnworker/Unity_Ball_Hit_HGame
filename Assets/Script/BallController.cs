using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("�t��")]
    public float speed;
    [Header("�̤p��V")]
    public float minDirection = 0.5f;

    [Header("��V")]
    private Vector3 direction;
    [Header("����")]
    private Rigidbody rb;

    void Start()
    {
        // ���o�o�Ӫ������ê�l��
        this.rb = GetComponent<Rigidbody>();

        this.ChooseDirection();
    }

    void Update()
    {
        // ��k1
        // �����m �W�[����  ��V * �t�� * ����ɶ�
        // transform.position += direction * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // �w�q�o�Ӫ�����鲾�ʦ�m(��������m + ��V * �t�� * �C�@�w����ɶ�)
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �o�Ӫ�������Ĳ�o�ƥ�� ��VZ�b�ܬۤ�
        if (other.CompareTag("���"))
        {
            direction.z = -direction.z;
        }

        // �o�Ӫ����y��Ĳ�o�ƥ�� 
        if (other.CompareTag("Racket"))
        {
            // �w�q�T���V�q �s��V = (�y���m - ��L�����m).�k�@��
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            // �s��V.x�b = �p��.�Х�(�s��V.x�b) * �p��.�̤j��(�p��.�����(�s��V.x�b), ������.�̤p��V);
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            // �s��V.z�b = �p��.�Х�(�s��V.z�b) * �p��.�̤j��(�p��.�����(�s��V.z�b), ������.�̤p��V);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            // ��V ���w �s��V
            direction = newDirection;
        }
    }

    private void ChooseDirection()
    {
        // �B�I�� �Х�X = �p��.�Х�(�H����);
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        // �B�I�� �Х�Z = �p��.�Х�(�H����);
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        // �w�q�o�Ӫ����V X�b0.5f , Z�b0.5f
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);

    }
}
