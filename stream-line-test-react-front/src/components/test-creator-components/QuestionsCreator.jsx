import { useEffect } from "react";
import { useState } from "react/cjs/react.development";
import { EMPTYANSWER } from "../constants/constant";
import { AnswersCreator } from "./AnswersCreator";

export const QuestionsCreator = ({id, setQuestion, question, qIndex, removeQuestion }) => {
    const [answers, setAnswers] = useState(question.answers);

    const addAnswer = () => {
        commonSet(a => a.push(EMPTYANSWER()));
    }

    const setQuestionAnswer = (index, value) => {
        commonSet(a => a[index] = value);
    }

    const setQuestionAnswerIsRight = (index) => {
        commonSet(a => a.forEach((item, i) => {
            if (i === index) {
                item.isRight = true;
            }
            else {
                item.isRight = false;
            }
        }));
    }

    const commonSet = (method) => {
        const a = [...answers];
        method(a);
        setAnswers(a);
    }

    const removeAnswer = (index) => {
        if(answers.length <= 1){
            alert("You must have at least 1 answer");
        }
        else{
            let a = [...answers];
            a = a.filter((item, i) => i !== index);
            setAnswers(a);
        }
    }

    const setQuestionAndAnswersInTestCreator = (text) => {
        const value = {
            id: question.id,
            value: text,
            answers: answers,
            type: question.type
        }

        setQuestion(qIndex, value)
    }

    const handleQuestionInput = (event) => {
        setQuestionAndAnswersInTestCreator(event.target.value);
    }

    useEffect(() => {
        setQuestionAndAnswersInTestCreator(question.value);
    }, [answers])

    return (
        <div>
            <div>Enter your question</div>
            <div>
                <input type="text" placeholder="Enter your question" name="Question" id="" onChange={handleQuestionInput} value={question.value} />
            </div>
            <div>
                {answers.map((answer, index) => {
                    return (
                        <AnswersCreator
                            key={index}
                            {...answer}
                            aIndex={index}
                            setAnswer={setQuestionAnswer}
                            setIsRight={setQuestionAnswerIsRight}
                            removeAnswer={() => removeAnswer(index)}
                            inputName={`question${qIndex}`}
                        />
                    )
                })}
            </div>
            <div>
                <button className="btn btn-primary me-3" onClick={addAnswer}>Add Answer</button>
                <button className="btn btn-primary" onClick={removeQuestion}>Remove question</button>
            </div>
        </div>
    );
}