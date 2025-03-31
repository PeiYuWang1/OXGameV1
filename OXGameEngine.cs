using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGameV1
{
    public class OXGameEngine
    {
        private char[,] gameMarkers;

        public OXGameEngine()
        {
            gameMarkers = new char[3, 3];
            ResetGame();
        }

        public void SetMarker(int x, int y, char player)
        {
            if (IsValidMove(x, y))
            {
                gameMarkers[x, y] = player;
            }
            else
            {
                throw new ArgumentException("Invalid move!");
            }
        }

        public void ResetGame()
        {
            gameMarkers = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameMarkers[i, j] = ' ';
                }
            }
        }

        public char IsWinner()
        {
            // 檢查橫向
            for (int i = 0; i < 3; i++)
            {
                if (gameMarkers[i, 0] != ' ' && gameMarkers[i, 0] == gameMarkers[i, 1] && gameMarkers[i, 1] == gameMarkers[i, 2])
                {
                    return gameMarkers[i, 0];
                }
            }

            // 檢查縱向
            for (int j = 0; j < 3; j++)
            {
                if (gameMarkers[0, j] != ' ' && gameMarkers[0, j] == gameMarkers[1, j] && gameMarkers[1, j] == gameMarkers[2, j])
                {
                    return gameMarkers[0, j];
                }
            }

            // 檢查對角線
            if (gameMarkers[0, 0] != ' ' && gameMarkers[0, 0] == gameMarkers[1, 1] && gameMarkers[1, 1] == gameMarkers[2, 2])
            {
                return gameMarkers[0, 0];
            }

            if (gameMarkers[0, 2] != ' ' && gameMarkers[0, 2] == gameMarkers[1, 1] && gameMarkers[1, 1] == gameMarkers[2, 0])
            {
                return gameMarkers[0, 2];
            }

            return ' '; // 沒有贏家出現
        }

        public bool IsValidMove(int x, int y)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
            {
                return false;
            }

            if (gameMarkers[x, y] != ' ')
            {
                return false;
            }

            return true;
        }

        public char GetMarker(int x, int y)
        {
            return gameMarkers[x, y];
        }

        // 其他遊戲相關的方法...
    }
}
