import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useState } from "react/cjs/react.development";
import { GetUpdateTestById, PutUpdateTest } from "../Api";
import { TestsCreator } from "../components/test-creator-components/TestsCreator";
import { Preloader } from "../components/common/Preloader";

export const UpdateTest = () => {
    const [isCreate, setIsCreate] = useState(false);
    const [questions, setQuestions] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [name, setName] = useState("");
    const { id } = useParams();

    const startUpdate = () => {
        if (name.trim() !== '') {
            setIsCreate(true);
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
        });
    }, [id]);

    return (
        isLoading ?
            <Preloader /> :
            <TestsCreator
                name={name}
                setName={setName}
                isCreate={isCreate}
                setStartPage={startUpdate}
                questions={questions}
                setQuestions={setQuestions}
                method={PutUpdateTest}
            />
    );
}