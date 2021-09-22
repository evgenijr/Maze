using System.Threading.Tasks;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField]private MazeSpawner Spawner;
    [SerializeField]private GameObject PlayerObject;
    [SerializeField] private GameObject FinishObject;

    private float SpawnOffset;
    private Vector2 FinishPosition;

    public async void MazeSetUp()
    {
        var tempMaze = await Task.Run(() =>
        {
            return Spawner.SetUpMaze();
        });
        
        Spawner.SpawnMaze(tempMaze);
        SpawnOffset = Spawner.SpawnMazeOffset;
        FinishPosition = Spawner.FinishPosition;
        PlayerObject.transform.localPosition = new Vector3(-SpawnOffset + .5f, -SpawnOffset + .5f, 0f);
        FinishObject.transform.localPosition = new Vector3(FinishPosition.x - SpawnOffset + .5f, FinishPosition.y - SpawnOffset + .5f, 0f);
    }
}