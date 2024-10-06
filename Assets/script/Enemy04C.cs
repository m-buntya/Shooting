using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���Ǘ����s�����߂ɒǉ�
using System.Collections;  // �R���[�`�����g�����߂ɕK�v

public class Enemy04C : MonoBehaviour
{
    public GameObject EnemyBom;
    private float fireRate;
    private float nextFireTime = 0f;
    public GameObject explosionEffect;
    public GameObject DieEffect;
    public UltButton UltButton;

    private EnemyBossHP enemyBossHP;  // EnemyBossHP �X�N���v�g���Q�Ƃ��邽�߂̕ϐ�

    void Start()
    {
        // �����I�u�W�F�N�g�ɂ��� EnemyBossHP �R���|�[�l���g���擾
        enemyBossHP = GetComponent<EnemyBossHP>();

        // HP�Ǘ��X�N���v�g��������Ȃ��ꍇ�̃G���[�`�F�b�N
        if (enemyBossHP == null)
        {
            Debug.LogError("EnemyBossHP �X�N���v�g��������܂���I");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�Փ˂����I�u�W�F�N�g: " + collision.gameObject.name);

        // �v���C���[�̒e�ɓ��������ꍇ
        if (collision.CompareTag("Bullet"))
        {
            // �_���[�W��^���鏈��
            ApplyDamage(1);  // 1�_���[�W��^����

            // �e���j�󂷂�
            Destroy(collision.gameObject);
        }

        // �v���C���[�̕K�E�Z�ɓ��������ꍇ
        if (collision.CompareTag("Ult"))
        {
            Debug.Log("�K�E�Z��������܂����I");
            ApplyDamage(20);  // 20�_���[�W��^����
        }
    }

    // �_���[�W��^���鏈��
    private void ApplyDamage(int damageAmount)
    {
        // EnemyBossHP �X�N���v�g��ʂ��ă_���[�W�������s��
        if (enemyBossHP != null)
        {
            enemyBossHP.TakeDamage(damageAmount);
        }

        // �_���[�W��UltButton�ɒʒm
        if (UltButton != null)
        {
            UltButton.AddDamage(damageAmount);  // �_���[�W�����Z
        }
    }

    // �{�X��HP��0�ɂȂ�����j�󂷂鏈��
    public void OnBossDeath()
    {
        if (explosionEffect != null)
        {
            Instantiate(DieEffect, transform.position, Quaternion.identity);
        }

        // 2�b�҂��Ă���V�[���J�ڂ���R���[�`�����J�n
        StartCoroutine(WaitAndLoadScene());
    }

    // 2�b�҂��Ă���Q�[���N���A�V�[���ɑJ�ڂ���R���[�`��
    private IEnumerator WaitAndLoadScene()
    {
        // 2�b�ԑ҂�
        yield return new WaitForSeconds(2f);

        // �V�[���J��
        SceneManager.LoadScene("GameClear"); 
    }
}