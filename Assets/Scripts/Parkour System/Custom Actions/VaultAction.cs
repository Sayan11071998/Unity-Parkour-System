using UnityEngine;

[CreateAssetMenu(menuName = "Parkour System/ Custom Action/New Vault Action")]
public class VaultAction : ParkourAction
{
    public override bool CheckIfPossible(ObstacleHitData hitData, Transform player)
    {
        if (!base.CheckIfPossible(hitData, player)) return false;

        var hitPoint = hitData.forwardHit.transform.InverseTransformPoint(hitData.forwardHit.point);

        if (hitPoint.z < 0f && hitPoint.x < 0f || hitPoint.z > 0f && hitPoint.x > 0f)
        {
            Mirror = true;
            matchBodyPart = AvatarTarget.RightHand;
        }
        else
        {
            Mirror = false;
            matchBodyPart = AvatarTarget.LeftHand;
        }

        return true;
    }
}