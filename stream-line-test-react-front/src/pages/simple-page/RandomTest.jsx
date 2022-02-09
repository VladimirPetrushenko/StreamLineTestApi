import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useState } from "react/cjs/react.development";
import { GetAllTests } from "../../Api";
import { Preloader } from "../../components/common/Preloader";

export const RandomTest = () => {
    const [tests, setTests] = useState([]);
    let navigate = useNavigate();

    useEffect(() => {
        GetAllTests()
            .then(data => {
                setTests(data);
            });
    }, []);

    if (tests.length) {
        setTimeout(() => {
            navigate(`/tests/${tests[Math.floor(Math.random() * tests.length)].id}`);
        }, 200);
    }

    return <Preloader />;
}