using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image fillImage;
    public float cooldownTime = 10f;
    private float currentCooldownTime = 0f;
    private bool isReady = false;
    // �X�L���I�u�W�F�N�g�̃v���n�u
    public GameObject skillPrefab;

    // �v���C���[�̈ʒu���Q�Ƃ��邽�߂̕ϐ�
    public GameObject player;
    void Update()
    {
        if (!isReady)
        {
            currentCooldownTime += Time.deltaTime;
            fillImage.fillAmount = currentCooldownTime / cooldownTime;

            if (currentCooldownTime >= cooldownTime)
            {
                isReady = true;
                fillImage.fillAmount = 1f;
            }
        }
    }
    public void OnSkillButtonPressd()
    {
        if (isReady)
        {
            Debug.Log("�X�L�������I");
            // �X�L�������s
            ExecuteUltimateAbility();

            // �J�E���g���Z�b�g
            isReady = false;
            currentCooldownTime = 0f;
            fillImage.fillAmount = 0f;
        }
    }
    private void ExecuteUltimateAbility()
    {
        // �v���C���[�̈ʒu���擾
        if (player != null && skillPrefab != null)
        {
            // �v���C���[�̈ʒu�ɃX�L���𐶐�
            Vector2 spawnPosition = player.transform.position;
            GameObject skill = Instantiate(skillPrefab, spawnPosition, Quaternion.identity);

            // �X�L���I�u�W�F�N�g�Ɉړ��������w��
            skill.GetComponent<Skill>().SetDirection(Vector2.up);  // ������Ɉړ�
        }
        else
        {
            Debug.LogError("�v���C���[�܂��̓X�L��Prefab���ݒ肳��Ă��܂���I");
        }
    }
}