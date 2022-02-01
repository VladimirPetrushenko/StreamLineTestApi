import { createContext, useState } from "react";
import { useNavigate } from "react-router-dom";

export const AppContext = createContext();

export const MyContext = (props) => {
    const [answers, setAnswers] = useState([]);
    const [userName, setUserName] = useState("");
    const [isAuth, setIsAuth] = useState(false);

    const initArrayAnswers = (length) => {
        const result = [];
        for(let i = 0; i < length; i++){
            result.push('');
        }
        setAnswers(result);
    }
    
    const navigate = useNavigate();

    const moveTo = (path) => {
        navigate(`/${path}`);
    }

    const moveToLogin = () => {
        moveTo("login");
    }

    const setQuestionAnswer = (index, answer) => {
        setAnswers(answers.map((qa, i) => i !== index ? qa : answer));
    }

    const value = {
        answers: answers,
        setAnswer: setQuestionAnswer,
        initAnswers: initArrayAnswers,
        isAuth, setIsAuth, moveTo, moveToLogin,
        userName, setUserName
    };

    return <AppContext.Provider value={value}>
        {props.children}
    </AppContext.Provider>
}
