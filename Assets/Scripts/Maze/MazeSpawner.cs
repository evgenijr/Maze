using System.Threading.Tasks;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Vector2 FinishPosition { get; private set; }
    [SerializeField] private int Size;

    [SerializeField] private Transform MazeParent;

    [SerializeField] private GameObject CellPrefab;

    public float SpawnMazeOffset { get; private set; }
    public MazeGeneratorCell[,] SetUpMaze()
    {
        SpawnMazeOffset = (Size - 1) / 2;
        MazeGenerator generator = new MazeGenerator(Size, Size);
        MazeGeneratorCell[,] maze = generator.GenerateMaze();
        FinishPosition = generator.CalculateMazeExit(maze);
        return maze;
    }
    public async void GenerateAsync()
    {
        SpawnMazeOffset = (Size - 1) / 2;
        var temp = await Task.Run(() => 
        {
            MazeGenerator generator = new MazeGenerator(Size, Size);
            MazeGeneratorCell[,] maze = generator.GenerateMaze();
            FinishPosition = generator.CalculateMazeExit(maze);
            return maze;
        });

        SpawnMaze(temp);
    }
    public void SpawnMaze(MazeGeneratorCell[,] maze)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell cell = Instantiate(CellPrefab, new Vector2(x - SpawnMazeOffset, y - SpawnMazeOffset), Quaternion.identity, MazeParent).GetComponent<Cell>();
                cell.WallBottom.SetActive(maze[x, y].WallBottom);
                cell.WallLeft.SetActive(maze[x, y].WallLeft);
            }
        }
        Debug.Log("Complete");
    }
}
