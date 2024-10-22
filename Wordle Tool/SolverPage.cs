using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Wordle_Tool
{
    public partial class SolverPage : Form
    {
        static Label[,] words;
        SolveWordle solve;

        public SolverPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Forms.MainMenu.StartPosition = FormStartPosition.Manual;
            Forms.MainMenu.Location = this.Location;
            Forms.MainMenu.Show();

            this.Hide();
        }

        private void SolverPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SolverPage_Load(object sender, EventArgs e)
        {
            words = new Label[6, 5];

            int x = 50, y = 50;

            for (int i = 0; i < 6; i++)
            {
                for (int a = 0; a < 5; a++)
                {
                    Label label = new Label();
                    label.Text = "";
                    label.Location = new Point(x, y);
                    label.BackColor = WordleColours.black;
                    label.Size = new Size(50, 50);
                    label.Font = new Font("Arial", 33, FontStyle.Bold);
                    label.ForeColor = Color.White;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Click += LabelClicked;

                    words[i, a] = label;

                    this.Controls.Add(label);

                    x += 55;
                }

                y += 55;
                x = 50;
            }

            solve = new SolveWordle(ref words);
        }

        private void LabelClicked(object sender, EventArgs e)
        {
            solve.LetterClicked((Label)sender);
        }

        private void NextWordButton_Clicked(object sender, EventArgs e)
        {
            solve.NextWordButtonClicked();
        }

        private void ResetSolverButton_Clicked(object sender, EventArgs e)
        {
            solve = new SolveWordle(ref words);
        }

        private void startingWordButton_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "Starting word options";
            form.BackColor = Color.FromArgb(20, 20, 20);
            form.Size = new Size(250, 100);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            form.Show();

            TextBox entryBox = new TextBox();
            Button acceptEntryButton = new Button();

            entryBox.Location = new Point(10, 10);
            acceptEntryButton.Location = new Point(130, 10);
            acceptEntryButton.BackColor = Color.White;
            acceptEntryButton.Text = "Enter";
            
            form.Controls.Add(entryBox);
            form.Controls.Add(acceptEntryButton);

            acceptEntryButton.Click += AcceptEntryButton_Click;
        }

        private void AcceptEntryButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class SolveWordle
    {
        Label[,] words;
        string startWord = "salet";
        int currentRow = 0;
        List<char> unusedLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList<char>();
        List<char> greyLetters = new List<char>();
        List<string> possibleWords = WordLists.answersList;
        char[] greenLetters = new char[5] { ' ', ' ', ' ', ' ', ' ' };
        char[,] yellowLetters = new char[6, 5];
        List<char> yellowLettersList = new List<char>();
        List<string> usedWords = new List<string>();

        public SolveWordle(ref Label[,] words)
        {
            this.words = words;
            ClearAll();
            SetRow(startWord, 0);
        }

        private void SetRow(string s, int row)
        {
            for (int i = 0; i < s.Length; i++)
            {
                words[row, i].Text = s[i].ToString().ToUpper();
                words[row, i].BackColor = WordleColours.grey;
            }

            RemoveUsedLetters(s);
            usedWords.Add(s);
            possibleWords.Remove(s);
        }

        private void ClearAll()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    words[i, j].Text = null;
                    words[i, j].BackColor = WordleColours.black;
                }
            }
        }

        private void RemoveUsedLetters(string s)
        {
            foreach (char c in s)
            {
                unusedLetters.Remove(c);
            }
        }

        public void LetterClicked(Label l)
        {
            if (l.BackColor == WordleColours.grey)
            {
                l.BackColor = WordleColours.yellow;
            }
            else if (l.BackColor == WordleColours.yellow)
            {
                l.BackColor = WordleColours.green;
            }
            else if (l.BackColor == WordleColours.green)
            {
                l.BackColor = WordleColours.grey;
            }
        }

        private void CollectGreyLetters(int row)
        {
            for (int i = 0; i < 5; i++)
            {
                if (words[row, i].BackColor == WordleColours.grey
                    && !greyLetters.Contains(words[row, i].Text.ToLower()[0])
                    && !greenLetters.Contains(words[row, i].Text.ToLower()[0])
                    && !yellowLettersList.Contains(words[row, i].Text.ToLower()[0]))
                {
                    greyLetters.Add(words[row, i].Text.ToLower()[0]);
                }
            }
        }

        private void CollectYellowLetters(int row)
        {
            for (int i = 0; i < 5; i++)
            {
                if (words[row, i].BackColor == WordleColours.yellow)
                {
                    yellowLetters[row, i] = words[row, i].Text.ToLower()[0];
                    yellowLettersList.Add(words[row, i].Text.ToLower()[0]);
                }
            }
        }

        private void CollectGreenLetters(int row)
        {
            for (int i = 0; i < 5; i++)
            {
                if (words[row, i].BackColor == WordleColours.green)
                {
                    greenLetters[i] = words[row, i].Text.ToLower()[0];
                }
            }
        }

        public void NextWordButtonClicked()
        {
            if (currentRow <= 4)
            {
                CollectGreenLetters(currentRow);
                CollectYellowLetters(currentRow);
                CollectGreyLetters(currentRow);


                RemoveImpossibleWordsFromWordList();


                currentRow++;
                SetRow(BestNextWord(), currentRow);
            }
        }

        public void RemoveImpossibleWordsFromWordList()
        {
            List<string> newPossibleWords = new List<string>();

            foreach (string s in possibleWords)
            {
                bool possible = true;

                for (int i = 0; i < 5; i++)
                {
                    // check green letters against all words
                    if (s[i] != greenLetters[i] && greenLetters[i] != ' ')
                    {
                        possible = false;
                        break;
                    }
                    // check if word contains a grey letter
                    else if (greyLetters.Contains(s[i]))
                    {
                        possible = false;
                        break;
                    }
                }

                // check yellow letters
                foreach (char c in yellowLetters)
                {
                    if (!s.Contains(c) && char.IsLetter(c))
                    {
                        possible = false;
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (s[j] == yellowLetters[i, j])
                        {
                            possible = false;
                        }
                    }
                }

                if (possible)
                {
                    newPossibleWords.Add(s);
                }
            }

            possibleWords = newPossibleWords;
        }

        private string BestNextWord()
        {
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            foreach (string s in possibleWords)
            {
                foreach (char c in s)
                {
                    if (!letterCount.ContainsKey(c))
                    {
                        letterCount.Add(c, 1);
                    }
                    else
                    {
                        letterCount[c]++;
                    }
                }
            }

            int bestScore = 0;
            string bestWord = "";

            foreach (string s in possibleWords)
            {
                int currentScore = 0;

                foreach (char c in s)
                {
                    if (letterCount.ContainsKey(c))
                    {
                        currentScore += letterCount[c];
                    }
                }

                if (currentScore > bestScore && !usedWords.Contains(s))
                {
                    bestScore = currentScore;
                    bestWord = s;
                }
            }

            if (possibleWords.Count == 1)
                return possibleWords.First();

            return bestWord;
        }
    }
}
