using UnityEngine;

public class Skill : MonoBehaviour
{
    public float speed = 5f;              // �ړ����x
    private Vector2 moveDirection;        // �ړ�����
    private Vector2 initialPosition;      // �����ʒu
    public float maxDistance = 6f;        // �ő�ړ����� 
    public GameObject explosionPrefab;    // �����v���n�u
    private bool hasStopped = false;      // �X�L������~���Ă��邩�������t���O

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
        initialPosition = transform.position;  // �X�L�����������ꂽ�ʒu���L�^
    }

    void Update()
    {
        if (!hasStopped)
        {
            float traveledDistance = Vector2.Distance(initialPosition, transform.position);
            if (traveledDistance < maxDistance)
            {
                // �X�L�����ړ�������
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
            else
            {
                // �ړ����ő勗���ɒB�������~
                StopSkill();
            }
        }
    }

    // �X�L���̈ړ����~����
    void StopSkill()
    {
        speed = 0f;
        hasStopped = true;
    }

    // �X�L������~������ɂ���Bullet�ɓ�����悤�ɂ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasStopped && other.CompareTag("Bullet"))  // ��~���Bullet�ƏՓ˂��m�F
        {
            // �����v���n�u�𐶐�
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("�G�t�F�N�g�̊m�F");
            // �X�L�����̂�j��
            Destroy(gameObject);
        }
        if (hasStopped && other.CompareTag("Ult"))  // ��~���Ultt�ƏՓ˂��m�F
        {
            // �����v���n�u�𐶐�
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("�G�t�F�N�g�̊m�F");
            // �X�L�����̂�j��
            Destroy(gameObject);
        }
    }
}