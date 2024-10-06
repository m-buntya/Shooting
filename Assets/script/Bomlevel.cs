using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomlevel : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public float fireRate = 0.1f;   // ���ˊԊu
    public int numberOfBullets = 10; // ��x�ɔ��˂���e�̐�
    public float spreadAngle = 30f; // �e�̍L����p�x
    public float bulletSpeed = 5f;  // �e�̃X�s�[�h
    private float nextFireTime = 0f;

    void Update()
    {
        // ���ɒe�𔭎˂��鎞�Ԃ𒴂��Ă��邩�m�F
        if (Time.time >= nextFireTime)
        {
            FireBullet();  // �e�𔭎�
            nextFireTime = Time.time + fireRate;  // ���ɔ��˂��鎞�Ԃ�ݒ�
        }
    }

    void FireBullet()
    {
        float startAngle = -spreadAngle / 2; // ���[����n�߂�p�x
        float angleStep = spreadAngle / (numberOfBullets - 1); // �e�e�̊p�x�̊Ԋu

        for (int i = 0; i < numberOfBullets; i++)
        {
            float currentAngle = startAngle + i * angleStep; // �e�e�̊p�x���v�Z
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // �e�𐶐�
            BossBom bulletScript = bullet.GetComponent<BossBom>(); // �e�̃X�N���v�g���擾

            if (bulletScript != null)
            {
                bulletScript.Init(currentAngle + 90f, -bulletSpeed); // �p�x���������ɒ����i90�x�ǉ��j
            }
        }
    }
}