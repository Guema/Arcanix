using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SkillShot : Skill
{
    [SerializeField]
    Effect effect;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float range = 30f;


    public void Launch(Unit unit, Vector3 direction)
    {
        //var projectile = Instantiate(this.projectile, origin.position, origin.rotation);
        //Physics.OverlapSphereNonAlloc()
        unit.StartCoroutine(LaunchProjectile(unit.SkillShotAnchor, direction, Instantiate(projectile)));
    }

    IEnumerator LaunchProjectile(Vector3 pos, Vector3 direction, GameObject projectile = null)
    {
        Vector3 tar = pos + direction.normalized * range;

        if (projectile)
            projectile.transform.LookAt(tar);

        YieldInstruction y = new WaitForEndOfFrame();

        while (pos != tar)
        {
            pos = Vector3.MoveTowards(pos, tar, speed);
            if (projectile)
                projectile.transform.position = pos;
            yield return null;
        }
        DestroyObject(projectile);
        yield break;
    }
}