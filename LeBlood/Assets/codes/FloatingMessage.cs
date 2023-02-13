using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingMessage : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private TMP_Text _damageValue;

    public float InitialYVelocity = 7f;
    public float InitialXVelocityRange = 3f;
    public float LifeTime = 0.8f;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
        _damageValue = GetComponentInChildren<TMP_Text>();
    }

    private void Start(){
        _rigidbody.velocity = new Vector2(Random.Range(-InitialXVelocityRange,InitialXVelocityRange),InitialYVelocity);
        Destroy (gameObject,LifeTime);
    }

    public void SetMessage(string msg){
        _damageValue.SetText(msg);
    }
}
