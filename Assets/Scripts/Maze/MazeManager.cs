using System.Threading.Tasks;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private MazeSpawner Spawner;
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private GameObject FinishObject;

    private float OffsetForSpawn;
    private Vector2 FinishPosition;
    private void Start()
    {
        LevelManager.LevelEvent += OnNotify;
    }
    public async void SetUpMaze()
    {
        var tempMaze = await Task.Run(() =>
        {
            return Spawner.SetUpMaze();
        });
        
        Spawner.SpawnMaze(tempMaze);

        FinishPosition = Spawner.GetFinishPosition(tempMaze);
        OffsetForSpawn = Spawner.SpawnMazeOffset;

        PlaceFinishAndPlayer();
    }

    private void PlaceFinishAndPlayer()
    {
        FinishObject.transform.localPosition = new Vector3(FinishPosition.x - OffsetForSpawn + .5f, FinishPosition.y - OffsetForSpawn + .5f, 0f);
        PlayerObject.transform.localPosition = new Vector3(-OffsetForSpawn + .5f, -OffsetForSpawn + .5f, 0f);
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.LEFT_SWIPE:
                {

                    break;
                }
            case Notifications.RIGHT_SWIPE:
                {

                    break;
                }
            case Notifications.LEVEL_RESTART:
                {
                    SetUpMaze();
                    break;
                }
        }
    }
}