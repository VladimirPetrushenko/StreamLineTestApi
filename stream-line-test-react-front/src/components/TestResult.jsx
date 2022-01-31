export const TestResult = ({test, answers, results}) => {
    const result = compilationOfTheResult(test, answers, results);

    return (
        <div className="pt-3 text-center pb-2">
            <h1 className="mb-4">
                {test.name}
            </h1>
            {result.questions.map((question, index) =>{
                return (
                    <div key={question.id} className={question.isRight ? "text-success" : "text-danger"}>
                        {index + 1}. {question.question}
                        <p>
                            {question.answers.map((answer, index) => {
                                return (
                                    <span key={answer.id} className="m-2">{answer.yours && '✓'} {index + 1}. {answer.answer}</span>
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
    const result = JSON.parse(JSON.stringify(test));

    for(let i = 0; i < result.questions.length; i++){
        const question = result.questions[i];
        for(let y = 0; y < question.answers.length; y++){
            if(answer[i].trim() === ''){
                continue;
            }
            if(question.answers[y].answer.includes(answer[i])){
                result.questions[i].answers[y].yours = true;
            }
        }
        result.questions[i].isRight = results[i];
    }

    return result;
}