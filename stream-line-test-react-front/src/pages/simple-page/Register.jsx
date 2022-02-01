import { useState, useContext } from "react/cjs/react.development"
import { PostCreateUser } from "../../Api";
import { AppContext } from "../../components/common/Context";

export const Register = () => {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const {setUserName} = useContext(AppContext);
    
    const handleChange = (event) => {
        set(event.target.name, event.target.value);
    }

    const set = (name, value) => {
        if (name === "name") {
            setName(value);
        }
        else if (name === "email") {
            setEmail(value);
        }
        else if (name === "password") {
            setPassword(value);
        }
    }

    const submit = () => {
        const userCreateDto = {
            name: name,
            email: email,
            password: password
        }

        console.log(userCreateDto);
        PostCreateUser(userCreateDto)
            .then(data => {
                setUserName(name);
            })
            .catch(error => console.log(error));
    }

    return <div className="p-5">
        <label>
            Name:
            <input type="text" className="m-2" value={name} name="name" onChange={handleChange} /> 
            </label>
        <label>
            Email:
            <input type="text" className="m-2" value={email} name="email" onChange={handleChange} />
        </label>
        <label>
            Password
            <input type="password" className="m-2" value={password} name="password" onChange={handleChange} />
        </label>
        <button className="btn btn-primary" onClick={submit}>
            Register
        </button>
    </div>
}