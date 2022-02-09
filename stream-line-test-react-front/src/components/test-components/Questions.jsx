import { useState, useContext, useEffect } from "react";
import { Button } from "../common/Buttom";
import { AppContext } from "../common/Context";
import { Question } from "./Question";

export const Questions = ({ questions, submit }) => {
    const [currentQuestion, setCurrentQuestion] = useState(0);
    const [isDisplay, setDisplay] = useState(true);
    const {initAnswers, answers} = useContext(AppContext);

    const nextCurrentQuestion = () => {
        if (currentQuestion < questions.length - 1) {
            setCurrentQuestion(currentQuestion + 1);
        }
        
        if(currentQuestion === questions.length - 2){
            setDisplay((prevValue) => prevValue = false);
        }
    }
    
    const previousCurrentQuestion = () => {
        if (currentQuestion > 0) {
            setCurrentQuestion((prevValue) => prevValue - 1);
            setDisplay(true);
        }
    }
    
    const setQuestion = (index) => {
        setCurrentQuestion(index);
    }

    useEffect(()=>{
        initAnswers(questions.length);
    }, [questions.length])

    return questions.length && (
        <div className="row h-100">
            <div className="col-md-10">
                <div className="row h-100 border-end border-2">
                    <div className="col pe-0">
                        <Question indexQuestion={currentQuestion} {...questions[currentQuestion]} />
                    </div>
                    <div className="col-12 align-self-end">
                        <div className="row justify-content-between p-3 ps-4">
                            <Button
                                onClick={previousCurrentQuestion}
                                id={"PreviousQuestionButton"}
                                className={"btn btn-primary col-4"} 
                                value={"Previous Question"}
                            />
                            <Button 
                                onClick={isDisplay ? nextCurrentQuestion : submit} 
                                id={"NextQuestionButton"} 
                                className={"btn btn-primary col-4"} 
                                value={isDisplay ? "Next question" : "Submit"}
                            />
                        </div>
                    </div>
                </div>
            </div>
            <div className="col-md-2">
                <div className="btn-group-vertical h-100 w-100 pb-2 ">
                    {
                        answers.map((answer, index) => {
                            const className = "p-2 btn mb-1 ";
                            const param = answer.trim() === "" ? "btn-warnign" : "btn-success";

                            return (
                                <Button 
                                    onClick={() => setQuestion(index)} 
                                    key={index} 
                                    className={className + param}
                                    value = {`question ${index + 1}`}
                                />
                            )
                        })
                    }
                </div>
            </div>
        </div>
    );
}