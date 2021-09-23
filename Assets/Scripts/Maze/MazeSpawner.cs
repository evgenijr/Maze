using System.Threading.Tasks;
using UnityEngine;

    public class MazeSpawner : MonoBehaviour
    {
        [SerializeField] private int Size;

        [SerializeField] private Transform MazeParent;

        [SerializeField] private GameObject CellPrefab;


        private GameObject[,] MazeCells;
        private MazeGenerator generator;
        public float SpawnMazeOffset { get; private set; }
        private void Start()
        {
            if (Size == 0) Size = 9;
            SpawnMazeOffset = (Size - 1) / 2;
            MazeCells = new GameObject[Size, Size];
        }
        public MazeGeneratorCell[,] SetUpMaze()
        {
            generator = new MazeGenerator(Size, Size);
            MazeGeneratorCell[,] maze = generator.GenerateMaze();
            return maze;
        }
        public Vector2 GetFinishPosition(MazeGeneratorCell[,] Maze)
        {
            return generator.CalculateMazeExit(Maze);
        }
        private async void GenerateAsync()
        {
            var temp = await Task.Run(() =>
            {
                MazeGenerator generator = new MazeGenerator(Size, Size);
                MazeGeneratorCell[,] maze = generator.GenerateMaze();
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
                    Destroy(MazeCells[x, y]);
                    Cell cell = Instantiate(CellPrefab, new Vector2(x - SpawnMazeOffset, y - SpawnMazeOffset), Quaternion.identity, MazeParent).GetComponent<Cell>();
                    cell.WallBottom.SetActive(maze[x, y].WallBottom);
                    cell.WallLeft.SetActive(maze[x, y].WallLeft);
                    MazeCells[x, y] = cell.gameObject;
                }
            }
        }
    }