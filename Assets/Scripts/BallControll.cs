using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] private float _force;
    public float _deadTime = .3f;
    private bool _canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        _canJump = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_canJump)
        {
            if (collision.gameObject.CompareTag("safe"))
            {
                Debug.Log("safe");
                _rb.AddForce(Vector3.up * _force);
                _canJump = false;
                StartCoroutine(WaitToJump());
            }
            if (collision.gameObject.CompareTag("danger"))
            {
                Debug.Log("game over");
                Time.timeScale = 0;
            }
            if (collision.gameObject.CompareTag("end"))
            {
                Debug.Log("Finished");
            }
        }


    }

    IEnumerator WaitToJump()
    {
        yield return new WaitForSeconds(_deadTime);
        _canJump = true;
    }
}
