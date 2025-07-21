using UnityEngine;

[CreateAssetMenu(menuName = "Parkour System/ New Parkour Action")]
public class ParkourAction : ScriptableObject
{
    [SerializeField] private string animName;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    public bool CheckIfPossible(ObstacleHitData hitData, Transform player)
    {
        float height = hitData.heightHit.point.y - player.position.y;
        if (height < minHeight || height > maxHeight) return false;
        return true;
    }

    public string AnimName => animName;
}