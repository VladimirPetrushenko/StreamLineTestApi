import { createContext, useState } from "react";

export const AppContext = createContext();

export const MyContext = (props) => {
    const [answers, setAnswers] = useState([]);

    const initArrayAnswers = (length) => {
        const result = [];
        for(let i = 0; i < length; i++){
            result.push('');
        }
        setAnswers(result);
    }

    const setQuestionAnswer = (index, answer) => {
        setAnswers(answers.map((qa, i) => i !== index ? qa : answer));
    }

    const value = {
        answers: answers,
        setAnswer: setQuestionAnswer,
        initAnswers: initArrayAnswers,
    };

    return <AppContext.Provider value={value}>
        {props.children}
    </AppContext.Provider>
}
