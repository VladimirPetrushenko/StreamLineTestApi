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

        setQuestion(qIndex, value);
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
            <div className="row g-2">
                <div className="col-11">
                    <input 
                        type="text" 
                        placeholder="Enter your question" 
                        name="Question" id="" 
                        onChange={handleQuestionInput} 
                        value={question.value} 
                        className="form-control"
                    />
                </div>
                <button className="btn btn-danger col-1" onClick={removeQuestion}><i class="bi bi-x-circle"></i></button>
            </div>
            <div className="row">
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
                <div className="col-3 mt-2">
                    <button className="btn btn-success" onClick={addAnswer}><i class="bi bi-plus-circle"></i></button>
                </div>
            </div>
        </div>
    );
}