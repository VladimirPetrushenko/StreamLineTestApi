import { useEffect } from "react";
import { Link } from "react-router-dom";
import { useState } from "react/cjs/react.development";
import { GetAllTests } from "../../Api";
import { Preloader } from "../../components/common/Preloader";

export const AllTests = ({ link = "tests" }) => {
    const [tests, setTests] = useState([]);

    useEffect(() => {
        GetAllTests().then(data => setTests(data));
    }, [])

    return (tests.length ? (
        <div className="ps-4 row col-12">
            {tests.map(test => {
                return (
                    <div key={test.id} className="col-sm-3 ps-2 mt-3 d-flex justify-content-around">
                        <div key={test.id} className="card" style={{ width: "18rem", height: "23rem" }}>
                            <img className="card-img-top" src={"https://placeimg.com/640/480/any"} alt={"test images"} />
                            <div className="card-body">
                                <h5 className="card-title"> {test.name} </h5>
                            </div>
                            <div className="card-footer border-0 text-center">
                                <Link to={`/${link}/${test.id}`} className="btn btn-primary ">Start</Link>
                            </div>
                        </div>
                    </div>
                )
            })}
        </div>
    ) : <Preloader />);
}