import { useEffect } from "react";
import { useState } from "react/cjs/react.development"
import { GetUserResults } from "../Api";
import { Preloader } from "../components/common/Preloader";

export const Result = () => {
    const [testsResults, setTestsResults] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        if (testsResults.length) {
            setIsLoading(false);
        }
    }, [testsResults])

    useEffect(() => {
        GetUserResults()
            .then(data => {
                setTestsResults(data);
            })
            .catch(error => console.log(error));
    }, []);

    return isLoading ? <Preloader /> : (
        <>
            <div className="p-3 text-center fs-3 fw-bold">
                Your results
            </div>
            <div className="row">
                <div className="col-12">
                    <table class="table table-warning table-hover table-striped text-center">
                        <thead>
                            <tr>
                                <th>Test Name</th>
                                <th>Percentages</th>
                                <th>Number of correct answers</th>
                            </tr>
                        </thead>
                        <tbody>
                            {testsResults.map(testResult => {
                                const {test, result} = testResult;

                                return (<tr key={test.id}>
                                    <th className="col-4">
                                        {test.name}
                                    </th>
                                    <th className="col-4">
                                        {(result*100).toFixed(2)}
                                    </th>
                                    <th className="col-4">
                                        {test.questionCount * result} / {test.questionCount}
                                    </th>
                                </tr>)
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
        </>
    )
}