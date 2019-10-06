using UnityEngine;

//아이템
public class BBalyer : MonoBehaviour
{
    public float range = 50.0f;
    public GameObject target;       //처먹을 놈

    public float moveSpeed = 100.0f;    //이동 속도

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //타겟방향
            Vector3 dirToTarget = this.target.transform.position - this.transform.position;

            //타겟과의 거리
            float distToTarget = dirToTarget.magnitude;

            if (distToTarget <= this.range)
            {
                //타겟방향 정규화
                dirToTarget *= 1.0f / distToTarget;

                float t = Mathf.Clamp01(distToTarget / this.range);
                float invT = 1.0f - t;

                //초당 평균이동
                float moveDelta = this.moveSpeed * Time.deltaTime * invT;

                this.transform.Translate(dirToTarget * moveDelta, Space.World);
            }
        }
    }

    //testcode
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(this.transform.position, this.range);
    }
}