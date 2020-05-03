using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent pathFinder;
    Transform target;
    Player targetEntity;

    float nextAttackTime;
    float betweenAttackTime = 1;

    float attackDelayPush; // 손을 뻗을때 딜레이
    float attackDelayBack; // 손을 뺄떄 딜레이

    [SerializeField] float attackSpeed = 3;
    float targetColliderRadius;
    float enemyColliderRadius;
    float attackRange = 0.5f;

    bool hasTarget;

    private void Start()
    {
        

        pathFinder = GetComponent<NavMeshAgent>();

        if(GameObject.FindGameObjectWithTag("Player") != null) // tag Player를 찾음
        {
            hasTarget = true; // flag 값 true

            target = GameObject.FindGameObjectWithTag("Player").transform;

            targetColliderRadius = target.GetComponent<CapsuleCollider>().radius;
            enemyColliderRadius = GetComponent<CapsuleCollider>().radius; // 캡슐콜라이더의 반지름을 받아옴

            targetEntity = target.GetComponent<Player>(); // ???????? 뭐지?

            StartCoroutine(UpdatePath());
        }
    }

    private void Update()
    {
        if(hasTarget)
            Attack();
    }

    private void Attack()
    {
        if(Time.time > nextAttackTime)
        {
            float DstToTarget = (target.position - transform.position).sqrMagnitude; 
            // 제곱근 형태로 받아 Float 변수에 넣을수 있도록 하는건가?
            // 일정 거리 내로 들어왔을때 공격하는 Coroution 실행
            if (DstToTarget < Mathf.Pow(attackRange + enemyColliderRadius + targetColliderRadius , 2)) 
                // player의 collider radius + enemy 의 collider radius + Attack Range 의 제곱의 거리 내로 들어왔을때
                // AttackCoroutine 실행
            { 
                nextAttackTime = Time.time + betweenAttackTime;
                StartCoroutine(AttackCoroutine()); 
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        pathFinder.enabled = false; // pathfinder를 잠시 꺼둠

        float percent = 0;
        bool hasAppliedDamage = false; // 공격확인용 flag

        Vector3 originPos = transform.position;
        Vector3 dstToTarget = (target.position - transform.position).normalized;
        Vector3 attackPos = target.position - dstToTarget * (enemyColliderRadius + targetColliderRadius);

        while (percent <= 1)
        {
            if(percent >= 0.5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                //데미지를 줌 (0.5초뒤)
            }

            percent += Time.deltaTime + attackSpeed; // 여긴 왜 deltaTime?
            // 보간값을 사용해서 enemy 공격모션 이동시 lerp값 지정
            float interpolation = (Mathf.Pow(percent, 2) + percent) * 4; // 이해하기 살짝 어려움
            transform.position = Vector3.Lerp(originPos, attackPos, interpolation);
            // Attack Animation

            yield return null;

        }

        pathFinder.enabled = true;        
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (hasTarget)
        {
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            Vector3 targetPos = target.position - dirToTarget;

            pathFinder.SetDestination(target.position); // navmeshfloor로 설정했을때 -> 맵 한계가 있음

            yield return new WaitForSeconds(refreshRate);
        }

        
    }


}
