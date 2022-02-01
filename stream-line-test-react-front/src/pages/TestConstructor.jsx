import { useContext, useEffect } from "react"
import { useState } from "react/cjs/react.development"
import { GetAllQuestions, PostCreateTestWithConstructor } from "../Api"
import { AppContext } from "../components/common/Context";
import { Preloader } from "../components/common/Preloader";

export const TestsConstructor = () => {
    const [questions, setQuestions] = useState([]);
    const [checkbox, setCheckbox] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [isCreating, setIsCreating] = useState(false);
    const [name, setName] = useState("");
    const { moveTo } = useContext(AppContext);

    const handleChange = (event) => {
        let a = [...checkbox];
        a[event.target.id] = event.target.checked;
        setCheckbox(a);
    }

    const submit = () => {
        const result = {
            name: name,
            questions: questions.filter((q, i) => checkbox[i])
        }
        PostCreateTestWithConstructor(result)
            .then(data => {
                setIsLoading(true);
                setTimeout(() => moveTo("/tests"), 300);
            })
            .catch(error => console.log(error));
    }

    const startPage = (setStart) => {
        return (
            <div className="text-center pt-5">
                <div className="mb-3">
                    <input
                        type="text"
                        name="TestName"
                        id="EnterTestName"
                        placeholder="Enter test's name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </div>
                <button className="btn btn-primary p-3 text-center" onClick={() => setIsCreating(true)}>Send me</button>
            </div>
        );
    }

    useEffect(() => {
        if (questions) {
            setIsLoading(false);
            fill(setCheckbox, questions.length);
        }
    }, [questions])

    useEffect(() => {
        GetAllQuestions()
            .then(data => setQuestions(data))
            .catch(error => console.log(error));
    }, []);

    return !isCreating ? startPage() :
        (
            isLoading ? <Preloader /> :
                (
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
        );
}

function fill(setCheckbox, length) {
    const result = [];
    for (let i = 0; i < length; i++) {
        result.push(false);
    }

    setCheckbox(result);
}