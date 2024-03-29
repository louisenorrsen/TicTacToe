﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;


        /// <summary>
        /// True if a player has won
        /// </summary>
        private bool mPlayerWon;


        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        /// <summary>
        /// Count number of rounds
        /// </summary>

        private int roundsPlayed = 1;
        private int player1points = 0;
        private int player2points = 0;

        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            NewGame();

        }

        #endregion

        /// <summary>
        /// Starts a new game and clears all values back to default
        /// </summary>

        private void NewGame()
        {
            // Adds one Round to the counter 
            
            counterRounds.Content = roundsPlayed;

            // Create a new blank array of free cells
            mResults = new MarkType[9];

            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            // Make sure Player 1 starts the game
            mPlayer1Turn = true;

            //Iterate every button on the grid
            Container.Children.OfType<Button>().Cast<Button>().ToList().ForEach(button =>
            {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.Gainsboro;
                button.Foreground = Brushes.DarkSlateGray;
            });

            // Make sure no player has won
            mPlayerWon = false;

            // Make sure the game has not finished
            mGameEnded = false;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on the click after it finished
            if (mGameEnded) { NewGame(); return; }

            // Cast the sender to a button
            var button = (Button)sender;

            // Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + ((row - 1) * 3);

            // Don't do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free) return;

            // Set the cell value based on which players turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            // Change color on noughts
            if (!mPlayer1Turn) button.Foreground = Brushes.OrangeRed;

            // Toggle the players turn
            mPlayer1Turn ^= true;

            // Check for a winner
            CheckForWinner();
        }

        /// <summary>
        /// Checks if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal Wins
            // Check for horizontal winns
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.PeachPuff;
            }
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.PeachPuff;
            }
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {

                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.PeachPuff;
            }
            #endregion

            #region Vertical Wins

            // Check for vertical winns
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {

                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.PeachPuff;
            }
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {

                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.PeachPuff;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {

                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.PeachPuff;
            }

            #endregion

            #region Diagonal Wins
            // Check for diagonal wins

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {

                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.PeachPuff;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {

                if (mPlayer1Turn) { player2points++; }
                else { player1points++; }
                player1Points.Content = player1points;
                player2Points.Content = player2points;
                roundsPlayed++;
                mPlayerWon = true;
                mGameEnded = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.PeachPuff;
            }

            #endregion
            if (!mResults.Any(result => result == MarkType.Free) && !mPlayerWon)
            {
                mGameEnded = true;
                Container.Children.OfType<Button>().Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.PeachPuff;                    
                });
                roundsPlayed++;
            }
        }
    }
}
