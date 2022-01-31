export function Footer() {
    return (
        <footer className="bg-success text-dark bg-opacity-75 fixed-bottom">
            <div className="container">
                © {new Date().getFullYear()} Copyright Text
            </div>
        </footer>
    );
}