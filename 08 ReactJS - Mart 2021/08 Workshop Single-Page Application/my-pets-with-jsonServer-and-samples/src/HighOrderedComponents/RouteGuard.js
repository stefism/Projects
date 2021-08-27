import { useContext } from "react"
import { useHistory } from "react-router-dom";
import AuthContext from "../components/Contexts/AuthContext"

const RouteGuard = (Component) => {
    const RouteGuardedComponent = (props) => {
        const { isAuthenticated } = useContext(AuthContext);
        const history = useHistory();

        if (!isAuthenticated) {
            history.push('/login');
            return null;
        }

        return <Component {...props} />
    }

    return RouteGuardedComponent;
}

export default RouteGuard;