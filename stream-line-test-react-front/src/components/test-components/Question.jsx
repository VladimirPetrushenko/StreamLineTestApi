import { Answers } from "./Answers"

export const Question = (props) => {
    const { value, id } = props;
    
    return (
        <>
            <div className="text-center font-weight fs-3 p-5 bg-warning bg-opacity-75">
                {value}
            </div>
            <div>
                <Answers questionId={id} {...props} />
            </div>
        </>
    );
}