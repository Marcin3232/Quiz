﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Quiz
{

    class Quiz
    {
        private string path = "questions.txt";
        public List<Question> Questions { get; set; }

        public Player Player { get; set; }
        public Quiz()
        {
            LoadQuestionFromFile(path);
        }
        private void LoadQuestionFromFile(string filePath)
        {

            var lines = File.ReadAllLines(filePath);
            var counter = 0;
            Questions = new List<Question>();

            var currentQuestion = new Question();

            foreach (var line in lines)
            {
                if (counter == 5)
                {
                    counter = 0;
                }
                if (counter == 0)
                {
                    currentQuestion.Title = line;
                }
                if (counter == 1)
                {
                    currentQuestion.AnswerA = line;
                }
                if (counter == 2)
                {
                    currentQuestion.AnswerB = line;
                }
                if (counter == 3)
                {
                    currentQuestion.AnswerC = line;
                }
                if (counter == 4)
                {
                    currentQuestion.RightAnswerLetter = line[0].ToString();
                    currentQuestion.Score = 1;
                    var newQuestion = new Question
                    {
                        Title = currentQuestion.Title,
                        AnswerA = currentQuestion.AnswerA,
                        AnswerB = currentQuestion.AnswerB,
                        AnswerC = currentQuestion.AnswerC,
                        RightAnswerLetter = currentQuestion.RightAnswerLetter,
                        Score = currentQuestion.Score

                    };
                    Questions.Add(newQuestion);
                }

                counter++;
            }

        }
        public void Start()
        {
            Player = new Player();

            Console.WriteLine("Podaj swoje imie:");
            Player.Name = Console.ReadLine();
            Player.Score = 0;
            Player.CurrentQuestion = 1;
            for (var i = 0; i < Questions.Count; i++)
            {

                var score = ShowQuestion(Player.CurrentQuestion);
                Player.Score += score;
                Player.CurrentQuestion++;
            }
            Console.WriteLine("Ukończono quiz");
            Console.WriteLine("Twoja liczba punktów: ", Player.Score);
        }

        public int ShowQuestion(int questionCounter)
        {
            var currentQuestionToShow = Questions[questionCounter - 1];
            Console.WriteLine("Pytanie: " + currentQuestionToShow.Title);
            Console.WriteLine("A: " + currentQuestionToShow.AnswerA);
            Console.WriteLine("B: " + currentQuestionToShow.AnswerB);
            Console.WriteLine("C: " + currentQuestionToShow.AnswerC);

            var userResponse = Console.ReadLine();
            if (userResponse == currentQuestionToShow.RightAnswerLetter)
            {
                return currentQuestionToShow.Score;
            }
            Console.WriteLine("Błędnie podana odpowiedź");
            return 0;

        }

        internal class UserControlStartGame
        {
        }
    }


}
