export const TestResult = ({test, answers, results}) => {
    const result = compilationOfTheResult(test, answers, results);
    console.log(result);
    return (
        <div className="pt-3 text-center pb-2">
            <h1 className="mb-4">
                {test.name}
            </h1>
            {result.questions.map((question, index) =>{
                return (
                    <div key={question.id} className={question.isRight ? "text-success" : "text-danger"}>
                        {index + 1}. {question.value}
                        <p>
                            {question.answers.map((answer, index) => {
                                return (
                                    <span key={answer.id} className="m-2">{answer.yours && '✓'} {index + 1}. {answer.value}</span>
                                )
                            })}
                        </p>
                    </div>
                )
            })}
        </div>
    )
}

function compilationOfTheResult(test, answer, results){
    const testCopy = JSON.parse(JSON.stringify(test));

    for(let i = 0; i < testCopy.questions.length; i++){
        const question = testCopy.questions[i];
        for(let j = 0; j < question.answers.length; j++){
            if(answer[i].trim() === ''){
                continue;
            }
            if(question.answers[j].value.includes(answer[i])){
                testCopy.questions[i].answers[j].yours = true;
            }
        }
        testCopy.questions[i].isRight = results[i];
    }

    return testCopy;
}