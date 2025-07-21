using UnityEngine;

[CreateAssetMenu(menuName = "Parkour System/ New Parkour Action")]
public class ParkourAction : ScriptableObject
{
    [SerializeField] private string animName;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private bool rotateToObstacle;

    public Quaternion TargetRotation { get; set; }

    public bool CheckIfPossible(ObstacleHitData hitData, Transform player)
    {
        float height = hitData.heightHit.point.y - player.position.y;
        if (height < minHeight || height > maxHeight) return false;
        if (rotateToObstacle)
        {
            TargetRotation = Quaternion.LookRotation(-hitData.forwardHit.normal);
        }
        return true;
    }

    public string AnimName => animName;
    public bool RotateToObstacle => rotateToObstacle;
}