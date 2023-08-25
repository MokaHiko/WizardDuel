using UnityEngine;
public enum Element
{
    Uknown,
    Fire, 
    Ice, 
    Water,  
    Earth, 
    Air
}

[CreateAssetMenu(fileName = "Element")]
public class ElementInfo : ScriptableObject
{
    public GameObject BasicAttackProjectile;
}
