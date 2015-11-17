﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sorry.Properties;

namespace Sorry
{
    class Display: Form
    {
        public Display()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            int boardRight = 200, boardTop = 50;
            baseBoard = new Board();

            BoardPicture = new Label();

            BoardPicture.Location = new System.Drawing.Point(boardRight, boardTop);
            BoardPicture.Size = new System.Drawing.Size(200, 200);
            Image boardPic = Resources.GameBoard;
            BoardPicture.Size = new Size(boardPic.Width, boardPic.Height);
            BoardPicture.Image = boardPic;

            CardPicture = new Button();

            CardPicture.Location = new System.Drawing.Point(50, 50);
            CardPicture.Size = new System.Drawing.Size(200, 200);
            Image deckPic = Resources.Deck;
            CardPicture.Size = new Size(deckPic.Width, deckPic.Height);
            CardPicture.Image = deckPic;
            // 
            // GameDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 556);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Display";
            this.Text = "Sorry";
            this.ResumeLayout(false);
            this.Controls.Add(BoardPicture);
            this.Controls.Add(CardPicture);

            // 
            // Board
            // 
            BoardButtons = new List<List<Button>>();
            int buttonSize = 31;
            for (int i = 0; i < baseBoard.board.Length; i++)
            {
                int buttonT = boardTop, buttonR = boardRight,jrfactor=0,jtfactor=0;
                BoardButtons.Add(new List<Button>());
                BoardButtons[i].Add(new System.Windows.Forms.Button());

                if (baseBoard.board.Length / 4 > i) {
                    buttonR=boardRight + i * buttonSize;
                    buttonT = boardTop;
                    jtfactor = 1;
                }
                else if (baseBoard.board.Length / 2 > i) {
                    buttonR = boardRight + (baseBoard.board.Length / 4 * buttonSize);
                    buttonT = boardTop + i % 15 * buttonSize;
                    jrfactor = -1;
                }
                else if (baseBoard.board.Length * 3 / 4 > i) {
                    buttonR=boardRight + ((baseBoard.board.Length / 4) - i % 15) * buttonSize;
                    buttonT=boardTop + baseBoard.board.Length / 4 * buttonSize;
                    jtfactor = -1;
                }
                else {
                    buttonT = boardTop + ((baseBoard.board.Length / 4) - i % 15) * buttonSize;
                    buttonR = boardRight;
                    jrfactor = 1;
                }
                BoardButtons[i][0].Location = new System.Drawing.Point(buttonR, buttonT); 
                BoardButtons[i][0].Name = "Square" + i;
                BoardButtons[i][0].Size = new System.Drawing.Size(buttonSize, buttonSize);
                BoardButtons[i][0].TabIndex = 0;
                //Board[i].Text = "Square" + i;
                BoardButtons[i][0].UseVisualStyleBackColor = true;
                this.Controls.Add(BoardButtons[i][0]);

                if (baseBoard.board[i].Length > 1) {
                    for (int j = 1; j < baseBoard.board[i].Length; j++) {
                        BoardButtons[i].Add(new System.Windows.Forms.Button());
                        BoardButtons[i][j].Location = new System.Drawing.Point(buttonR+jrfactor*j*32, buttonT+ jtfactor * j * buttonSize);
                        BoardButtons[i][j].Name = "Square" + i;
                        BoardButtons[i][j].Size = new System.Drawing.Size(buttonSize, buttonSize);
                        BoardButtons[i][j].TabIndex = 0;
                        //Board[i].Text = "Square" + i;
                        BoardButtons[i][j].UseVisualStyleBackColor = true;
                        this.Controls.Add(BoardButtons[i][j]);

                    }

                }

            }

            BoardPicture.SendToBack();

        }

        private List<List<System.Windows.Forms.Button>> BoardButtons;
        private Board baseBoard;
        private Label BoardPicture;
        private Button CardPicture;


    }
}
