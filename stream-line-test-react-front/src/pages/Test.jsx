import { useEffect, useState, useContext } from "react";
import { AppContext } from "../components/common/Context";
import { Preloader } from "../components/common/Preloader";
import { Questions } from "../components/test-components/Questions";
import { TestResult } from "../components/TestResult";
import { GetTestById, PostCheckTest } from "../Api"
import { useParams } from "react-router-dom";

export const Test = () => {
    const [test, setTest] = useState();
    const [results, setResults] = useState([]);
    const [isResult, setIsResult] = useState(false);
    const { answers } = useContext(AppContext);

    const { id } = useParams();

    const handleSubmit = () => {
        const requestData = {
            id: test.id,
            answers: answers
        }
        PostCheckTest(requestData).then(data => setResults(data));

        setIsResult(true);
    }

    useEffect(() => {
        GetTestById(id).then(data => {
            setTest(data);
        });
    }, [id]);

    return (
        !isResult ?
            (test ? <Questions {...test} submit={handleSubmit} /> : <Preloader />)
            : (<TestResult test={test} answers={answers} results={results} />)
    );
}