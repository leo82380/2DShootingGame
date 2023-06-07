using UnityEngine;
using DG.Tweening;

public class PingPongMovement : MonoBehaviour
{
    public Vector3 targetPosition; // 이동할 목표 위치
    public float moveDuration = 1.0f; // 이동하는 데 걸리는 시간
    public Ease moveEase = Ease.Linear; // 이동 애니메이션의 이징 타입

    private void Start()
    {
        // 시작할 때 이동 애니메이션 시작
        StartPingPongMovement();
    }

    private void StartPingPongMovement()
    {
        // 게임 오브젝트를 targetPosition으로 이동하고 왔다갔다 반복하는 애니메이션 시작
        transform.DOMove(targetPosition, moveDuration)
            .SetEase(moveEase)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
