import { useEffect } from "react"
import { useNavigate } from "react-router-dom";
import { useState } from "react/cjs/react.development"
import { GetAllQuestions, PostCreateTestWithConstructor } from "../Api"
import { Preloader } from "../components/common/Preloader";

export const TestsConstructor = () => {
    const [questions, setQuestions] = useState([]);
    const [checkbox, setCheckbox] = useState([]); 
    const [isLoading, setLoading] = useState(true);

    let navigate = useNavigate();

    const handleChange = (event) => {
        let a = [...checkbox];
        a[event.target.id] = event.target.checked;
        setCheckbox(a);
    }

    useEffect(() => {
        if(questions){
            setLoading(false);
            fill(setCheckbox, questions.length);
        }
    }, [questions])

    useEffect(() => {
        GetAllQuestions().then(data => setQuestions(data));
    }, []);
    
    const submit = () => {
        const result = {
            name: "submit test",
            questions: questions.filter((q, i) => checkbox[i])
        }
        console.log(result);
        PostCreateTestWithConstructor(result);
        navigate("/tests");
    }

    return isLoading ? <Preloader /> : (
        <div>
            {questions && questions.map((question, index) => {
                return (<div key={question.id}> 
                    {question.value} {question.id}
                    <input type="checkbox" name={index} id={index} checked={checkbox[index]} onChange={handleChange} />
                </div>);
            })}
            <button className="btn btn-primary m-2" onClick={submit}>Submit</button>
        </div>
    )
}

function fill(setCheckbox, length){
    const result = [];
    for(let i = 0; i < length; i++){
        result.push(false);
    }

    setCheckbox(result);
}