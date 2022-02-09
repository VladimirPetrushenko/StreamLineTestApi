import { useContext } from "react/cjs/react.development";
import { AppContext } from "../common/Context";

export const Answer = ({ inputName, value, indexQuestion }) => {
    const { setAnswer, answers } = useContext(AppContext);
    const answer = makeFirstLetterUpperCase(value);

    const handleChecked = () => {
        setAnswer(indexQuestion, value);
    }

    return (
        <label className="p-5">
            <input
                type="radio"
                name={inputName}
                onChange={handleChecked}
                className="me-1"
                checked={answers.length && value.length && answers[indexQuestion].includes(value)}
            />
            {answer === "" ? "Without anything" : answer}
        </label>
    );
}

function makeFirstLetterUpperCase(sourceString) {
    if (sourceString.trim() === "") {
        return "";
    }
    let value = [...sourceString];
    value[0] = value[0].toUpperCase();
    return value.join('');
}
