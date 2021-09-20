using System.Threading.Tasks;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private int Size;

    [SerializeField] private Transform Maze;

    [SerializeField] private GameObject CellPrefab;

    private float offset;
    public void Generate()
    {
        offset = (Size - 1) / 2;
        MazeGenerator generator = new MazeGenerator(Size, Size);
        MazeGeneratorCell[,] maze = generator.GenerateMaze();
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell cell = Instantiate(CellPrefab, new Vector2(x - offset, y - offset), Quaternion.identity, Maze).GetComponent<Cell>();
                cell.WallBottom.SetActive(maze[x, y].WallBottom);
                cell.WallLeft.SetActive(maze[x, y].WallLeft);
            }
        }
        Debug.Log("Complete");
    }
    public async void GenerateAsync()
    {
        offset = (Size - 1) / 2;
        var temp = await Task.Run(() => 
        {
            MazeGenerator generator = new MazeGenerator(Size, Size);
            MazeGeneratorCell[,] maze = generator.GenerateMaze();
            return maze;
        });

        for (int x = 0; x < temp.GetLength(0); x++)
        {
            for (int y = 0; y < temp.GetLength(1); y++)
            {
                Cell cell = Instantiate(CellPrefab, new Vector2(x - offset, y - offset), Quaternion.identity, Maze).GetComponent<Cell>();
                cell.WallBottom.SetActive(temp[x, y].WallBottom);
                cell.WallLeft.SetActive(temp[x, y].WallLeft);
            }
        }
        Debug.Log("Complete");
    }
}
