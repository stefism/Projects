import { notify } from '../lib/notify.js';

export default function initialize() { //Дефолтния експорт при импорт можем да го преименуваме и да му дадем друго име, защото можем да имаме само един дефолтен експорт.
    return function(context, next) {
        context.notify = notify;
        next();
    }
}