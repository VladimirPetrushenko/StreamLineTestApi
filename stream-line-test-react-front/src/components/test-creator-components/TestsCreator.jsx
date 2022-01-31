import { EMPTYQUESTION } from "../constants/constant";
import { QuestionsCreator } from "./QuestionsCreator";

export const TestsCreator = (props) => {
    const { 
        setStartPage, 
        name, 
        setName, 
        questions, 
        setQuestions, 
        isCreate, 
        method 
    } = props;

    const addQuestion = () => {
        commonSet(a => a.push(EMPTYQUESTION()));
    }

    const setQuestion = (index, value) => {
        commonSet(a => a[index] = value);
    }

    const commonSet = (method) => {
        let a = [...questions];
        method(a);
        setQuestions(a);
    }

    const removeQuestion = (index) => {
        if (questions.length <= 1) {
            alert("You must have at least 1 question");
        }
        else {
            let a = [...questions];
            a = a.filter((item, i) => i !== index);
            setQuestions(a);
        }
    }

    const submit = () => {
        const value = {
            name: name,
            questions: questions
        }

        console.log(value);

        method(value).then(data => console.log(data.status));
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
                <button className="btn btn-primary p-3 text-center" onClick={setStart}>Send me</button>
            </div>
        );
    }

    const mainPage = () => {
        return (
            <div className="p-3">
                <div className="mb-3">
                    {questions.map((question, index) => {
                        return <QuestionsCreator
                            key={index}
                            qIndex={index}
                            question={question}
                            removeQuestion={() => removeQuestion(index)}
                            setQuestion={setQuestion}
                        />;
                    })}
                </div>
                <div>
                    <button className="btn btn-primary me-2" onClick={addQuestion}>Add question</button>
                </div>
                <div className="pe-5">
                    <button className="start-100 btn btn-primary position-relative" onClick={submit}>Submit</button>
                </div>
            </div>
        );
    }

    return isCreate ? mainPage() : startPage(setStartPage);
}