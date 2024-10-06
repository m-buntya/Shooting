using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBom : MonoBehaviour
{
    [SerializeField] float angle; // �p�x
    [SerializeField] float speed; // ���x
    Vector3 velocity; // �ړ���
    public int bulletDamage;
    public UltButton ultButton;  // UltButton�X�N���v�g�ւ̎Q��

    void Start()
    {
        // X�����̈ړ��ʂ�ݒ肷��
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y�����̈ړ��ʂ�ݒ肷��
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        //�e�̕�����ݒ肷��
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        // UltButton�������I�Ɏ擾
        if (ultButton == null)
        {
            ultButton = FindObjectOfType<UltButton>();
        }
        // 5�b��ɍ폜
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        // ���t���[���A�e���ړ�������
        transform.position += velocity * Time.deltaTime;
    }

    public void Init(float input_angle, float input_speed)
    {
        Debug.Log("Init Called: angle = " + input_angle + ", speed = " + input_speed); // �f�o�b�O���O
        angle = input_angle;
        speed = input_speed;
        // X�����̈ړ��ʂ�ݒ肷��
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y�����̈ړ��ʂ�ݒ肷��
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        //�e�̕�����ݒ肷��
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[�ɓ��������ꍇ�A�_���[�W��^����
        if (other.CompareTag("Player"))
        {
            HPBarController playerHP = other.GetComponent<HPBarController>();
            if (playerHP != null)
            {
                Debug.Log(bulletDamage);
                playerHP.TakeDamage(bulletDamage);  // �_���[�W��^����
            }

            // �G�l�~�[�̒e��j��
            Destroy(gameObject);
        }

        // �v���C���[�̒e�ƏՓ˂����ꍇ�A�����̒e��j��
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // �v���C���[�̒e��j��
            Destroy(gameObject);       // �G�l�~�[�̒e��j��

            // Ult�Q�[�W��0.5����������
            if (ultButton != null)
            {
                ultButton.AddDamage(0.5f);  // 0.5�����Z
            }
        }
    }
}