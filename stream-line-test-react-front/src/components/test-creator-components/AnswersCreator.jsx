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

    return(
        <>
            <input type="text" placeholder="Enter your answer" className="me-1 mt-2 mb-2" onChange = {handleChangeAnswer} value={answer}/>
            <input 
                type="radio" 
                name={inputName} 
                className="me-1"
                onChange={handleChangeIsRight} 
                checked = {isRight}
            />
            <button onClick={removeAnswer} className="p-1 mb-1 btn btn-danger me-4">X</button>
        </>
    )
}