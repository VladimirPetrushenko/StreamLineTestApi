export const AnswersCreator = ({id, answer, setIsRight, isRight, aIndex, setAnswer, inputName, removeAnswer}) => {

    const handleChangeAnswer = (event) => {
        const value = {
            id: id,
            value: event.target.value,
            isRight: isRight
        }

        setAnswer(aIndex, value);
    }

    const handleChangeIsRight = () => {
        setIsRight(aIndex);
    }

    return (
        <div className="mt-2 col-4 row">
            <div className="col-9">
                <input 
                    type="text" 
                    placeholder="Enter your answer" 
                    className="form-control" 
                    onChange = {handleChangeAnswer} 
                    value={answer}
                />
            </div>
            <div className="col-1 mt-2 form-check">
                <input 
                    type="radio" 
                    name={inputName} 
                    className="form-check-input"
                    onChange={handleChangeIsRight} 
                    checked = {isRight}
                />
            </div>
            <button 
                className="btn btn-danger p-1 col-1"
                onClick={removeAnswer} 
            >
                <i class="bi bi-dash-circle"></i>
            </button>
        </div>
    );
}