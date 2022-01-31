export const Preloader = () => {
    return (
    <div 
        className="spinner-border position-absolute start-50 bottom-50" 
        role="status"
        style={{width: "7rem", height: "7rem"}}
    >
        <span className="sr-only"></span>
    </div>
    )
}