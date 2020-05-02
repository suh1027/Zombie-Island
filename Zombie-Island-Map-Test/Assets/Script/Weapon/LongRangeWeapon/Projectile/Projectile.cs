using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed; // 총알의 속도
    [SerializeField] private float damage;
    
    float lifeTime = 3;
    float skinWidth = .1f;
    
    public LayerMask collisionMask; // 어떤 오브젝트와 충돌할지 결정하는 마스크

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0) // 총알이 생성됬을때 어떤 충돌체 오브젝트와 이미 겹친(충돌한) 상태일때-> 뭐든 하나라도 충돌된 상태
        {
            OnHitObject(initialCollisions[0]);
        }
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime; // 잘 이해는 안가는 부분
        transform.Translate(Vector3.forward * moveDistance);
    }

    public void setSpeed(float _newSpeed) // projectile 의 속도를 세팅
    {
        speed = _newSpeed;
    }
    
    private void CheckCollision(float _moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, _moveDistance + skinWidth , collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    private void OnHitObject(RaycastHit _hit)
    {
        // Damage를 준후 Destroy
        GameObject.Destroy(gameObject);
    }
    private void OnHitObject(Collider c)
    {
        // Damage를 준후 Destroy
        GameObject.Destroy(gameObject);
    }
}
