import { getUserData } from '../util.js';

export default function initialize() {
    let user = null;
    updateSession();

    return function (context, next) {
        context.updateSession = updateSession;
        context.user = user;

        next();
    };

    function updateSession() {
        user = getUserData();
    }
}