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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 closestPoint = ray.GetPoint((_character.transform.position.z - Camera.main.gameObject.transform.position.z));
            _combat.BasicCast(closestPoint.normalized);
        }
    }
}
