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
                setTimeout(() => moveTo("tests"), 300);
            })
            .catch(error => console.log(error));
    }

    const startPage = (setStart) => {
        return (
            <div className="text-center pt-3">
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

    const tableCell = (questions) => {
        const rows = [];
        
        const cells = questions.map((question, index) => {
            return (<>
                    <td className="text-center">{index + 1}</td>
                    <td className="ps-2">{question.value}</td>
                    <td className="text-center"><input className="col-3" type="checkbox" name={index} id={index} checked={checkbox[index]} onChange={handleChange} /></td>
                </>
            );
        });
        
        for(let i = 0; i < cells.length; i+= 2){
            const element = <tr key={i}>{cells[i]}{cells[i+1]}</tr>;

            rows.push(element);
        }
       
        return rows;
    }

    return <> 
        <div className="text-center fs-1 fw-bold">Test constructor</div>
        {
            !isCreating ? startPage() :
            (
                isLoading ? <Preloader /> :
                    (
                        <>
                            <table className="w-100 table-bordered border-success">
                                <thead className="text-center">
                                    <tr>
                                        <th scope="col" className="ps-3 pe-3">#</th>
                                        <th scope="col">Questions</th>
                                        <th scope="col" className="p-2">Choice</th>
                                        <th scope="col" className="ps-3 pe-3">#</th>
                                        <th scope="col">Questions</th>
                                        <th scope="col" className="p-2">Choice</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {questions && tableCell(questions)}
                                </tbody>
                            </table>
                            <button className="btn btn-primary m-2" onClick={submit}>Submit</button>
                        </>
                    )
            )
        }
        </>
}

function fill(setCheckbox, length) {
    const result = [];
    for (let i = 0; i < length; i++) {
        result.push(false);
    }

    setCheckbox(result);
}