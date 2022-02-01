import { useContext } from "react";
import { useState } from "react/cjs/react.development"
import { PostLoginUser } from "../../Api";
import { AppContext } from "../../components/common/Context";

export const Login = () => {
    const [password, setPassword] = useState("");
    const { setIsAuth, moveTo, userName, setUserName } = useContext(AppContext);

    const handleChange = (event) => {
        set(event.target.name, event.target.value);
    }

    const set = (name, value) => {
        if (name === "name") {
            setUserName(value);
        }
        else if (name === "password") {
            setPassword(value);
        }
    }

    const submit = () => {
        const userReadDto = {
            name: userName,
            password: password
        }

        PostLoginUser(userReadDto)
            .then(data =>{
                setIsAuth(true);
                moveTo("");
            })
            .catch(error => console.log(error));
    }

    return <div className="text-center vsc-initialized">
        <div className="form-signin">
            <h1 className="h3 mb-3 font-weight-normal">Please sign in</h1>
            <label className="sr-only">Name</label>
            <input type="text" className="form-control" placeholder="Name" value={userName} name="name" onChange={handleChange} />
            <label className="sr-only">Password</label>
            <input type="password" className="form-control" placeholder="Password" value={password} name="password" onChange={handleChange} />
            <button className="mt-4 btn btn-lg btn-primary btn-block" onClick={submit}>Login</button>
        </div>
    </div>
}