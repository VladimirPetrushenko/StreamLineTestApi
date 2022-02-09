import { useContext, useEffect } from "react"
import { GetLogout } from "../../Api";
import { AppContext } from "../../components/common/Context"

export const Logout = () => {
    const {moveTo, setIsAuth} = useContext(AppContext);

    useEffect(() => {
        GetLogout()
        .then(data => {
            setIsAuth(false);
            moveTo("login");
        });
    }, []);

    return <></>
}