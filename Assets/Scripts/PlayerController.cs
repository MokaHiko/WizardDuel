using Cinemachine.Utility;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(CharacterCombat))]
public class PlayerController : MonoBehaviour
{
    private Character _character;
    private CharacterCombat _combat;

    private void Start()
    {
        _character = GetComponent<Character>();
        _combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            _character.MoveTowards(new Vector2(input.x, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character.Jump();
        }


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _character.transform.position.z - Camera.main.transform.position.z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 mouseDir = (worldMousePosition - _character.transform.position).normalized;

        float theta = Mathf.Atan2(mouseDir.y, mouseDir.x);
        _character.CastArm.rotation = Quaternion.Euler(0, 0, theta * Mathf.Rad2Deg);
        if(Input.GetMouseButtonDown(0))
        {
            _combat.BasicCast((worldMousePosition - _character.transform.position).normalized);
        }
    }
}
