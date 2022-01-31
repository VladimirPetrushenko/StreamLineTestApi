export const Button = (props) => {
    const {onClick, id, className, value} = props;

    return (
        <button
            onClick={onClick}
            id={id}
            className={className}
        >
            {value}
        </button>
    )
}