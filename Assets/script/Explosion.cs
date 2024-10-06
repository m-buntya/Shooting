using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 3f;  // �����͈̔�
    public int damageAmount = 5;        // �_���[�W��
    public string enemyTag = "Enemy";   // �G�l�~�[�̃^�O (�S�ẴG�l�~�[�ɂ��̃^�O�����Ă���)

    private void Start()
    {
        // �����͈͓̔��ɂ���R���C�_�[�����ׂČ��o
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            // �^�O�ŃG�l�~�[���ǂ������m�F
            if (hitCollider.CompareTag(enemyTag))
            {
                // �����ŃG�l�~�[�Ƀ_���[�W��^���鏈�����Ăяo��
                Debug.Log("�G�l�~�[�������͈͂ɓ���܂����I");

                // �e�G�l�~�[�Ƀ_���[�W��^���郁�\�b�h�����݂��邱�Ƃ����肵�ČĂяo��
                hitCollider.SendMessage("TakeDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
                // SendMessageOptions.DontRequireReceiver ���g�����ƂŁA�Y�����\�b�h���Ȃ��ꍇ�ł��G���[�ɂȂ�Ȃ�
            }

            // �G�̒e�ɓ����������m�F���Ĕj��
            if (hitCollider.CompareTag("EnemyBullet"))
            {
                Debug.Log("�G�̒e�������͈͂ɓ���܂����I�j�󂵂܂��B");
                Destroy(hitCollider.gameObject);  // �G�̒e��j��
            }
        }

       
        
            ParticleSystem ps = GetComponent<ParticleSystem>();
            Destroy(gameObject, ps.main.duration); // �p�[�e�B�N�����Đ��I����ɃI�u�W�F�N�g��j��
        
    }

    // �f�o�b�O�p�ɁA�����͈͂��G�f�B�^��ŕ\��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}