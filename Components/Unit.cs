using UnityEngine;

[SelectionBase]
[DisallowMultipleComponent]
[AddComponentMenu("Arcanix/Unit")]
[RequireComponent(typeof(CapsuleCollider))]
public sealed class Unit : MonoBehaviour
{
    [SerializeField]
    ClampedInt health = new ClampedInt(100, 1f);
    
    [SerializeField]
    Skill[] skills;

    [SerializeField]
    public Vector3 SkillShotAnchor // Provisoir
    {
        get
        {
            return transform.position + Vector3.forward + Vector3.up;
        }
    }

    // This function is called on Component Placement/Replacement
    void Reset()
    {

    }

    public void UseSkillShot(SkillShot skill)
    {
        foreach(var each in skills)
        {

        }
    }

    private void OnMouseDrag()
    {
        Debug.Log("Lol");
    }

    private void OnValidate()
    {

    }
}
