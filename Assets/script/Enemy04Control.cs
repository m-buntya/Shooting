using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;      // �G�l�~�[�̈ړ����x
    public float stopDistance = 9f;   // �ړ����鋗��
    private float initialY;           // �����ʒu��Y���W



void Start()
    {
        // �G�l�~�[�̏���Y���W���L�^����
        initialY = transform.position.y;
    }

    void Update()
    {
        // �G�l�~�[����~�ʒu�ɓ��B���Ă��Ȃ��ꍇ�Ɉړ�������
        if (transform.position.y > initialY - stopDistance)
        {
            MoveDown();
        }
    }

    // �G�l�~�[��Y�������ɉ��Ɉړ������郁�\�b�h
    void MoveDown()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}