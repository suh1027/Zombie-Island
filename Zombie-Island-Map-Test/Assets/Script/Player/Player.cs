using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int hp; // 체력
    [SerializeField]
    private int stamina; // 스테미너
    [SerializeField]
    private int hungry; // 배고픔
    [SerializeField]
    private int thirsty; // 목마름
    [SerializeField]
    private float moveSpeed; // 움직임 속도 제한
    [SerializeField]
    private float jumpPower;

    private Vector3 lastPos;
    private Quaternion lastRot;

    // Flags
    private bool isMove;
    private bool isJump;
    private bool isShoot;

    // 컴포넌트 받기
    [SerializeField]
    private Rigidbody myRigid; // 리지드바디
    [SerializeField]
    private CapsuleCollider myCollider; // 콜라이더
    // [SerializeField]
    // private Camera viewCamera;
    [SerializeField]
    private Animator anim; // 애니메이터
    [SerializeField]
    RifleController rifleController;

    private void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        rifleController = GetComponent<RifleController>();
        // viewCamera = Camera.main; // 메인카메라
    }

    private void Update() // Update 와 FixedUpdate 의 차이는 알지만 왜 Fixed Update를 사용했는지?
    {
        // #1. 이동 (모바일에서는 컨트롤러 사용)
        Move();
        MoveCheck();

        // #2. 점프 (모바일에서 버튼으로 구현) 
        Jump();

        // #3. 공격
        Attack();
    }

    private void Move()
    {
        if (!isShoot)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) // 이부분을 어떻게 처리할지 생각
            {
                float x = Input.GetAxisRaw("Horizontal");
                float z = Input.GetAxisRaw("Vertical");

                Vector3 moveInput = new Vector3(x, 0, z); // 움직임 벡터
                Vector3 velocity = moveInput.normalized * moveSpeed;
                myRigid.MovePosition(myRigid.position + velocity * Time.deltaTime);

                // 이동하는 방향으로 자연스럽게(Lerp) 앞을 보도록 Rotate 하게 만들기

                transform.rotation = Quaternion.Lerp(lastRot, Quaternion.LookRotation(moveInput), 0.1f);

                lastRot = transform.rotation;

            }
        }
        // Quaternion.LookRatation(moveInput)이 zero 가 되서 다시 돌아가는 버그
        // transform.rotation = Quaternion.Euler(lastPos);
    }

    // Idle 상태인지 Walk 상태인지 구분
    private void MoveCheck() // 움직이는지 체크하는 함수
    {
        if (Vector3.Distance(lastPos, transform.position) >= 0.01f) // 경사진곳에서도 체크되도록 살짝의 여유
        {
            anim.SetBool("isRun", true);
            isMove = true;
        }
        else
        {
            anim.SetBool("isRun", false); // 애니메이션이 자연스럽지가 않아...
            isMove = false;
        }
        lastPos = transform.position;
    }

    private void Jump()
    {
        //isJump = Physics.Raycast(transform.position,Vector3.down, myCollider.bounds.extents.y);
        // 점프중일때 점프 못하도록 설정 생각해보기
        if (isJump) { 
            if (Input.GetKeyDown(KeyCode.Space)) {
                myRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }

    private void Attack()
    {
        if (Input.GetButton("Fire1"))
        {
            isShoot = true;
            anim.SetTrigger("Shoot");
            rifleController.Shoot();
        }
        else
            isShoot = false;
    }
}
