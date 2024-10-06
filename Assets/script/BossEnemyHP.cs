using UnityEngine;
using UnityEngine.UI;

public class EnemyBossHP : MonoBehaviour
{
    public Image hpBarFill;  // HP�o�[�̃t�B������
    public int maxHP = 100;  // �{�X�̍ő�HP
    private int currentHP;   // �{�X�̌��݂�HP
    private Enemy04C bossEnemy;  // �{�X��HP���Ǘ�����X�N���v�g

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();

        // Enemy04C �X�N���v�g���擾
        bossEnemy = GetComponent<Enemy04C>();

        // HP�Ǘ��X�N���v�g��������Ȃ��ꍇ�̃G���[�`�F�b�N
        if (bossEnemy == null)
        {
            Debug.LogError("Enemy04C �X�N���v�g��������܂���I");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);  // HP��0����maxHP�͈͓̔��Ɏ��߂�
        UpdateHPBar();  // HP�o�[���X�V

        if (currentHP <= 0)
        {
            // �{�X�����񂾏ꍇ�AEnemy04C��OnBossDeath���\�b�h���Ăяo��
            if (bossEnemy != null)
            {
                bossEnemy.OnBossDeath();
            }
        }
    }

    void UpdateHPBar()
    {
        hpBarFill.fillAmount = (float)currentHP / maxHP;
    }
}