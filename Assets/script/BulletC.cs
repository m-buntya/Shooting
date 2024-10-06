using UnityEngine;
using System.Collections;

public class BulletC : MonoBehaviour
{
    public float bulletSpeed = 5f; // �e�̑��x
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �G�l�~�[�̒e�ƏՓ˂����ꍇ�A�����̒e������
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject); // �G�l�~�[�̒e������
            Destroy(gameObject); // �v���C���[�̒e������
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g��Skill�^�O�������m�F
        if (collision.gameObject.CompareTag("Skill"))
        {
            // �Փ˂����ʒu�ɔ����𐶐�
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // �e��j��
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(0, 0.05f, 0);
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
