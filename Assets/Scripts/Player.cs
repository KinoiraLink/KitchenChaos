using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private const int DIRECTION = 1;

    private bool isWalking;

    [SerializeField]private GameInput gameInput;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        
        isWalking = moveDir !=Vector3.zero;

        //转向
        transform.forward = Vector3.Slerp(transform.forward,moveDir,rotateSpeed * Time.deltaTime);
    }

    public bool IsWalking() {
        return isWalking;
    }
}
