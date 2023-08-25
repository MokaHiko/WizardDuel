using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalBook : MonoBehaviour
{
    [SerializeField] public ElementInfo ElementInfo;

    [SerializeField] private GameObject _pickUpEffect;

    [Header("Animation")]
    [SerializeField] private float _amplitude;
    [SerializeField] private float _rate;


    public void Start()
    {
        StartCoroutine(Bob());
    }

    private IEnumerator Bob()
    {
        float timeElapsed = 0;
        while(true)
        {
            timeElapsed += Time.deltaTime;
            transform.position += new Vector3(0, _amplitude, 0) * Mathf.Sin(timeElapsed * _rate);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterCombat>(out var combat))
        {
            combat.SetElementInfo(ElementInfo);
            Instantiate(_pickUpEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
