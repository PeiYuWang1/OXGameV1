using OXGameV1;
using System.Windows.Forms;

namespace OXGame
{
    public partial class Form1 : Form
    {
        //
        private OXGameEngine oxEngine = new OXGameEngine();
        //
        private Button[,] oxButtons = new Button[3,3]; 
        //
        private String playerMarker = "X";

        private int counter = 0;
        //
        public Form1()
        {
            InitializeComponent();

            InitializeGame();
        }

        private void InitializeGame()
        {
            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++) 
                {
                    Button button = new Button();

                    button.Font = new Font("Microsoft JhengHei UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
                    button.Size = new Size(90, 90);
                    button.Location = new Point(30 + i*100 , 30 + j*100);
                    button.Margin = new Padding(2);
                    button.Name = "button" + i + j;  //
                    button.TabIndex = i*3 + j + 1;   //
                    button.UseVisualStyleBackColor = true;
                    button.Click += button1_Click;

                    // 註記按鈕對應的位置（x,y）
                    button.Tag = String.Format("{0},{1}", i, j);

                    this.Controls.Add(button);

                    oxButtons[i,j] = button;
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Casting sender to be a Button
            Button button = (Button)sender;
            // 註記按鈕對應的位置（x,y）
            //button.Tag = String.Format("{0},{1}", i, j);
            string[] xyPos = ((String)button.Tag).Split(",");
            int x = int.Parse(xyPos[0]);
            int y = int.Parse(xyPos[1]);
            //
            if (oxEngine.IsValidMove(x, y) == false)
            {
                MessageBox.Show("Wrong Move!", "XXX");
                return;
            }
            //
            oxEngine.SetMarker(x , y , playerMarker[0]);
            //
            button.Text = playerMarker;
            playerMarker = playerMarker == "X" ? "O" : "X";
            label2.Text = playerMarker;
            //
            counter++;
            //
            checkWinner();
        }

        private void checkWinner()
        {
            char winner = oxEngine.IsWinner();
            if (winner == ' ')
                return;
            //
            MessageBox.Show("Winner is :" + winner, "Game Over");
        }
    }
}