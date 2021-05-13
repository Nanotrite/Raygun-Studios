 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{


    [SerializeField]
    private LayerMask whatIsGround;

    public float _speed = 6f;
    public float JumpForce = 99999999;

    public Animator animator;

    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }





    void Update()
    {

        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, 0);


        var _move = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(_move * _speed * Time.deltaTime, 0, 0);

        animator.SetFloat("Speed", Mathf.Abs(_move));

        if (!Mathf.Approximately(0, _move))
            transform.rotation = _move > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
