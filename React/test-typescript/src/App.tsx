import React, { useState } from 'react';
import { fetchQuizQuestions } from './API';

import QuestionCard from './components/QuestionCard';
import { QuestionState, Difficulty } from './API'

export type AnswerObject = {
  question: string;
  answer: string;
  correct: boolean;
  correctAnswer: string;
}

const TOTAL_QUESTIONS = 10;

function App() {
  const [loading, setLoading] = useState(false);
  const [questions, setQuestions] = useState<QuestionState[]>([]);
  const [number, setNumber] = useState(0);
  const [userAnswers, setUserAnswers] = useState<AnswerObject[]>([]);
  const [score, setScore] = useState(0);
  const [gameOver, setGameOver] = useState(true);

  // console.log(questions);

  const startTrivia = async () => {
    setLoading(true);
    setGameOver(false);

    const newQuestions = await fetchQuizQuestions(
      TOTAL_QUESTIONS, Difficulty.EASY);

    setQuestions(newQuestions);
    setScore(0);
    setUserAnswers([]);
    setNumber(0);
    setLoading(false);
  };

  const checkAnswer = (event: React.MouseEvent<HTMLButtonElement>) => {
    if(!gameOver){
      // User answer
      const answer = event.currentTarget.value;
      
      // Check answer against correct answer
      const correct = questions[number].correct_answer === answer;

      // Add score if answer is correct
      if(correct) {
        setScore(prev => prev + 1);
      }

      // Save answer in the array for user answers
      const answerObject = {
        question: questions[number].question,
        answer, // eqivalent of answer: answer. If the same, this is the short syntax.
        correct,
        correctAnswer: questions[number].correct_answer,
      };
      setUserAnswers((prev) => [...prev, answerObject]);
    }
  };

  const nextQuestion = () => {
    // Move on to the next question, if is not the last question
    const nextQuestion = number + 1;

    if(nextQuestion === TOTAL_QUESTIONS) {
      setGameOver(true);
    } else {
      setNumber(nextQuestion);
    }
  };

  return (
    <div className="App">
      
      <h1>REACT QUIZ</h1>

      {gameOver || userAnswers.length === TOTAL_QUESTIONS ? (
        <button className="start" onClick={startTrivia}>Start</button>
      ) : null}
      
      {!gameOver ? <p className="score">Score: </p> : null}
      {loading && <p>Loading Questions ...</p>}
      
      {!loading && !gameOver && (
        <QuestionCard 
        questionNr={number + 1}
        totalQuestions={TOTAL_QUESTIONS}
        question={questions[number].question}
        answers={questions[number].answers}
        userAnswer={userAnswers ? userAnswers[number] : undefined}
        callback={checkAnswer}
      />
      )}
      
      {!gameOver && !loading && userAnswers.length === number + 1 // userAnswers.length === number + 1 => show it, if user clicked on the answer (show the next question, if user put it on the answer).
      && number !== TOTAL_QUESTIONS - 1 ? ( // number !== TOTAL_QUESTIONS - 1 => if we not on the last questions.
        <button className="next" onClick={nextQuestion}>Next Question</button>
      ) : null}
      
    </div>
  );
}

export default App;
