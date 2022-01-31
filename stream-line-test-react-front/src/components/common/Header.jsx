import { Link } from "react-router-dom";

export function Header() {
    return (
            <nav className="navbar navbar-expand-lg navbar-dark bg-success ps-3">
                <Link className="navbar-brand" to="/">English test</Link>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <Link to="/tests" className="nav-link">All tests</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/random-test" className="nav-link">Random test</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/test-update" className="nav-link">Update tests</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/tests-creator" className="nav-link">Create test</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/about" className="nav-link">About</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/contact" className="nav-link">Contact</Link>
                        </li>
                    </ul>
                    <ul className="navbar-nav mr-auto end-0">
                        <li className="nav-item">
                            <Link to="/login" className="nav-link">Login</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/register" className="nav-link">Register</Link>
                        </li>
                    </ul>
                </div>
            </nav>
        );
}