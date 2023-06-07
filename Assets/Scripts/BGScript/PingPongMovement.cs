using UnityEngine;
using DG.Tweening;

public class PingPongMovement : MonoBehaviour
{
    public Vector3 targetPosition; // �̵��� ��ǥ ��ġ
    public float moveDuration = 1.0f; // �̵��ϴ� �� �ɸ��� �ð�
    public Ease moveEase = Ease.Linear; // �̵� �ִϸ��̼��� ��¡ Ÿ��

    private void Start()
    {
        // ������ �� �̵� �ִϸ��̼� ����
        StartPingPongMovement();
    }

    private void StartPingPongMovement()
    {
        // ���� ������Ʈ�� targetPosition���� �̵��ϰ� �Դٰ��� �ݺ��ϴ� �ִϸ��̼� ����
        transform.DOMove(targetPosition, moveDuration)
            .SetEase(moveEase)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
