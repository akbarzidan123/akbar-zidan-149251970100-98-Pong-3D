using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int spd;
    [SerializeField]private KeyCode upKey;
    [SerializeField]private KeyCode downKey;
    [SerializeField]private KeyCode leftKey;
    [SerializeField]private KeyCode rightKey;
    private bool canMove = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            MovePaddle(GetInput()); 
        }
    }

    private Vector3 GetInput()
    {
        if(Input.GetKey(upKey))
        {
            // Debug.Log("atas");
            return  Vector3.forward * spd;
        }
        if(Input.GetKey(downKey))
        {
            // Debug.Log("bawah");
            return Vector3.back * spd;
        }
        if(Input.GetKey(rightKey))
        {
            // Debug.Log("kanan");
            return Vector3.right * spd;
        }
        if(Input.GetKey(leftKey))
        {
            // Debug.Log("kiri");
            return Vector3.left * spd;
        }
        return Vector3.zero;
    }
    private void MovePaddle(Vector3 move)
    {
        rb.velocity = move;
        rb.AddForce(rb.velocity);
    }
    public void InActivePaddle()
    {
        canMove = false;
        gameObject.SetActive(false);
    }
}
