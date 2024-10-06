using UnityEngine;

public class BossBom0 : MonoBehaviour
{
    public float speed = 2f;  // �e�̑��x
    private Vector3 moveDirection;  // �ړ��������

    void Start()
    {
        // �v���C���[�I�u�W�F�N�g��T���āA���̍��W���^�[�Q�b�g�ʒu�ɐݒ�
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Vector3 targetPosition = playerObject.transform.position;  // ���ˎ��Ɉ�x�����v���C���[�̍��W���擾

            // �e�̌������^�[�Q�b�g�̕����ɐݒ�
            moveDirection = (targetPosition - transform.position).normalized;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }

        // 5�b��ɒe���폜
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // �ݒ肵�������ɐi�ݑ�����
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}