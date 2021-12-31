using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        ShootBall();
    }

    private void ShootBall()
    {
        _rigidbody.AddForce(GunController.Instance.transform.forward*10f,ForceMode.VelocityChange);
        Destroy(this.gameObject,5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            GunController.Instance.UpdateScore();
            Destroy(this.gameObject);
        }
    }
}
