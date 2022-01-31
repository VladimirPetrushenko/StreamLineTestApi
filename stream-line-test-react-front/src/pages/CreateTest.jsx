import { useState } from "react/cjs/react.development";
import { PostCreateTest } from "../Api";
import { TestsCreator } from "../components/test-creator-components/TestsCreator";
import { EMPTYQUESTION } from "../components/constants/constant";

export const CreateTest = () => {
    const [isCreate, setIsCreate] = useState(false);
    const [questions, setQuestions] = useState([]);
    const [name, setName] = useState("");

    const startCreate = () => {
        if (name.trim() !== '') {
            setIsCreate(true);
            let a = [EMPTYQUESTION()];
            setQuestions(a);
        }
        else {
            alert("Please, enter test's name");
        }
    }

    return (
        <TestsCreator
            name={name}
            setName={setName}
            isCreate={isCreate}
            setStartPage={startCreate}
            questions={questions}
            setQuestions={setQuestions}
            method={PostCreateTest}
        />
    );
}