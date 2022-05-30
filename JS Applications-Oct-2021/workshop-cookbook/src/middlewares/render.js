import { render } from '../lib.js';

const root = document.querySelector('main');

function boundRender(content) {
    render(content, root);
}

export default function decorateContext(context, next) {
    context.render = boundRender;
    next();
}