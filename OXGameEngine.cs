using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGameV1
{
    internal class OXGameEngine
    {
        // 二維字元陣列來紀錄玩家的下子
        private char[,] board;

        // 建構子，初始化遊戲盤面
        public OXGameEngine()
        {
            board = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
        }

        // (a) 設定玩家的 Marker
        public void SetMarker(int x, int y, char player)
        {
            if (IsValidMove(x, y))
            {
                board[x, y] = player;
            }
        }

        // (b) 重置遊戲
        public void ResetGame()
        {
            board = new char[3, 3]
            {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
            };
        }

        // (c) 判斷是否有贏家
        public char IsWinner()
        {
            // 檢查橫排、直排及對角線
            for (int i = 0; i < 3; i++)
            {
                // 檢查橫排
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
                    return board[i, 0];
                // 檢查直排
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
                    return board[0, i];
            }

            // 檢查對角線
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
                return board[0, 0];
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
                return board[0, 2];

            // 若無贏家，回傳空白字元
            return ' ';
        }

        // (d) 取得指定位置的 Marker
        public char GetMarker(int x, int y)
        {
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                return board[x, y];
            }
            return ' '; // 若索引不合法則回傳空白字元
        }

        // (e) 判斷指定位置是否還未下子
        public bool IsEmpty(int x, int y)
        {
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                return board[x, y] == ' ';
            }
            return false;
        }

        // (f) 判斷指定位置是否是有效的下子位置
        public bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3 && IsEmpty(x, y);
        }
    }
}
