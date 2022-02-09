import { useContext, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useState } from "react/cjs/react.development";
import { GetUpdateTestById, PutUpdateTest } from "../Api";
import { TestsCreator } from "../components/test-creator-components/TestsCreator";
import { Preloader } from "../components/common/Preloader";
import { AppContext } from "../components/common/Context";

export const UpdateTest = () => {
    const [isCreating, setIsCreating] = useState(false);
    const [questions, setQuestions] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [name, setName] = useState("");
    const { id } = useParams();
    const { moveToLogin } = useContext(AppContext);

    const startUpdate = () => {
        if (name.trim() !== '') {
            setIsCreating(true);
        }
        else {
            alert("Please, enter test's name");
        }
    }

    useEffect(() => {
        GetUpdateTestById(id).then(data => {
            setName(data.name);
            setQuestions(data.questions);
            setIsLoading(false);
        })
        .catch(error => {
            moveToLogin();
        });
    }, [id, moveToLogin]);

    return (
        isLoading ?
            <Preloader /> :
            (<>
                <div className="text-center fs-1 fw-bold">Create test</div>
                <TestsCreator
                    name={name}
                    setName={setName}
                    isCreating={isCreating}
                    setStartPage={startUpdate}
                    questions={questions}
                    setQuestions={setQuestions}
                    method={PutUpdateTest}
                />
            </>)
    );
}