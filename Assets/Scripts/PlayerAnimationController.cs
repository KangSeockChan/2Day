using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAnimationController : NetworkBehaviour
{
    public Animator playerAnimator;
    public bool IsMove;
    public bool IsRun;
    public GameObject bodyMesh;

    private void Move()
    {
        bool IsKey = false;
        bool IsHorizontal = false;
        bool IsVertical = false;

        if (Input.GetKey(KeyCode.A))
        {
            IsKey = true;
            IsHorizontal = true;
            playerAnimator.SetFloat("playerMoveHorizontal", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            IsKey = true;
            IsHorizontal = true;
            playerAnimator.SetFloat("playerMoveHorizontal", -1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            IsKey = true;
            IsVertical = true;
            playerAnimator.SetFloat("playerMoveVertical", 1);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            IsKey = true;
            IsVertical = true;
            playerAnimator.SetFloat("playerMoveVertical", -1);
        }

        // ------
        if (!IsKey)
        {
            playerAnimator.SetBool("IsMove", false);
        }
        else
        {
            playerAnimator.SetBool("IsMove", true);
        }
        // -------
        if (!IsVertical)
            playerAnimator.SetFloat("playerMoveVertical", 0);
        if (!IsHorizontal)
            playerAnimator.SetFloat("playerMoveHorizontal", 0);

        if (IsVertical && IsHorizontal)
        {
            playerAnimator.SetFloat("playerMoveHorizontal", playerAnimator.GetFloat("playerMoveHorizontal") * 0.5f);
            playerAnimator.SetFloat("playerMoveVertical", playerAnimator.GetFloat("playerMoveVertical") * 0.5f);
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("IsRun", true);
        }
        else
        {
            playerAnimator.SetBool("IsRun", false);
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            bodyMesh.gameObject.SetActive(true);
            return;
        }
        else
        {
            bodyMesh.gameObject.SetActive(false);
        }

        Move();
        Run();
    }
}