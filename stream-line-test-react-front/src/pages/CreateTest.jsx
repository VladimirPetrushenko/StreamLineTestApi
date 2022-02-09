import { useState } from "react/cjs/react.development";
import { PostCreateTest } from "../Api";
import { TestsCreator } from "../components/test-creator-components/TestsCreator";
import { EMPTYQUESTION } from "../components/constants/constant";

export const CreateTest = () => {
    const [isCreating, setIsCreating] = useState(false);
    const [questions, setQuestions] = useState([]);
    const [name, setName] = useState("");

    const startCreate = () => {
        if (name.trim() !== '') {
            setIsCreating(true);
            let a = [EMPTYQUESTION()]; 
            setQuestions(a);
        }
        else {
            alert("Please, enter test's name");
        }
    }

    return (
        <>
            <div className="text-center fs-1 fw-bold">Create test</div>
            <TestsCreator
                name={name}
                setName={setName}
                isCreating={isCreating}
                setStartPage={startCreate}
                questions={questions}
                setQuestions={setQuestions}
                method={PostCreateTest}
            />
        </>
    );
}