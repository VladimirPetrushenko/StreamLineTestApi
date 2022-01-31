import { Answer } from "./Answer"

export const Answers = ({questionId, answers, indexQuestion}) => {
    return <div className="text-center fs-3">
        {answers.map(answer => {
            return <Answer key={answer.id} inputName = {`question${questionId}`} {...answer} indexQuestion = {indexQuestion}/>
        })}
    </div>
}