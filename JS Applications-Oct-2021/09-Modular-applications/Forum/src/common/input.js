import { html, classMap } from '../lib.js';

export const input = (label, type, name, value = '', hasError) => html`
<label class=${classMap({ error: hasError })}>
    <span>${label}</span>
    <input type=${type} name=${name} .value=${value}>
</label>
`;