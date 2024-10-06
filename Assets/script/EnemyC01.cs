using UnityEngine;

public class EnemyC01 : MonoBehaviour
{
    public Entity_Enemy1 enemyData;  // ScriptableObject�̎Q��
    public GameObject EnemyBom;
    private int enemyHP;
    private float fireRate;
    private float nextFireTime = 0f;
    public GameObject explosionEffect;
    public GameObject DieEffect;
    public UltButton UltButton;
    private GM gm;
   

    private void Start()
    {
  
        // ScriptableObject����f�[�^��ݒ肷��
        if (enemyData != null && enemyData.sheets.Count > 0)
        {
            var sheet = enemyData.sheets[0];  // 1�̃V�[�g���擾
            if (sheet.list.Count > 0)
            {
                var enemyParams = sheet.list[0];  // 1�̃p�����[�^���擾
                enemyHP = (int)enemyParams.HP;
                fireRate = (float)enemyParams.fireRate; ;
            }
            else
            {
                // �f�t�H���g�l��ݒ肷��ꍇ
                enemyHP = 3;
                fireRate = 1.5f;
            }
        }
        else
        {
            // �f�t�H���g�l��ݒ肷��ꍇ
            enemyHP = 3;
            fireRate = 1.5f;
        }
        gm = FindObjectOfType<GM>();
        if (gm == null)
        {
            Debug.LogError("GameManager ��������܂���B");
        }

        if (UltButton == null)
        {
            UltButton = FindObjectOfType<UltButton>();

            if (UltButton == null)
            {
                Debug.LogError("UltButton ��������܂���B");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�Փ˂����I�u�W�F�N�g: " + collision.gameObject.name);
        // �v���C���[�̒e�ɓ��������ꍇ
        if (collision.CompareTag("Bullet"))
        {
            // enemyHP�����������鏈��
            enemyHP--;
            // �_���[�W��UltButton�ɒʒm
            if (UltButton != null)
            {
               UltButton.AddDamage(1); // �_���[�W�����Z
            }

            // �G�l�~�[��HP��0�ɂȂ�����j�󂷂�
            if (enemyHP <= 0)
            {
                if (explosionEffect != null)
                {
                    Instantiate(DieEffect, transform.position, Quaternion.identity);
                }
                NotifyGameManager();  // �G���|���ꂽ���Ƃ�ʒm
                Destroy(gameObject); // �G�l�~�[��j��
            }

            // �e���j�󂷂�
            Destroy(collision.gameObject);
        }
        // �v���C���[�̕K�E�Z�ɓ��������ꍇ
        if (collision.CompareTag("Ult"))
        {
            Debug.Log("�K�E�Z��������܂����I");
            // enemyHP�����������鏈��
            enemyHP = enemyHP-20;

            // �G�l�~�[��HP��0�ɂȂ�����j�󂷂�
            if (enemyHP <= 0)
            {
                if (explosionEffect != null)
                {
                    Instantiate(DieEffect, transform.position, Quaternion.identity);
                }
                NotifyGameManager();  // �G���|���ꂽ���Ƃ�ʒm
                Destroy(gameObject); // �G�l�~�[��j��
            }
        }
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        Debug.Log(gameObject.name + " �� " + damageAmount + " �_���[�W���󂯂܂����B �c��HP: " + enemyHP);
        if (enemyHP <= 0)
        {
            if (explosionEffect != null)
            {
                Instantiate(DieEffect, transform.position, Quaternion.identity);
               
            }
            NotifyGameManager();  // �G���|���ꂽ���Ƃ�ʒm
            Destroy(gameObject); // �G�l�~�[��j��
        }
    }

    private void NotifyGameManager()
    {
        // GameManager�ɓG���|���ꂽ���Ƃ�ʒm����
        if (gm != null)
        {
            gm.EnemyDefeated();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ��莞�Ԃ��Ƃɒe�𔭎�
        if (Time.time >= nextFireTime)
        {
            Instantiate(EnemyBom, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }
}