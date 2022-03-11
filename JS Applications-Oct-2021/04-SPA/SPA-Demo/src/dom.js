const main = document.querySelector('main');

export function showSection(section) {
    main.replaceChildren(section);
}

export async function request(url, options) {
    const responce = await fetch(url, options);

    if(options && options.body != undefined) {
        Object.assign(options, {
            headers: {
                'Content-Type': 'applications/json'
            }
        });
    }

    if(responce.ok != true) {
        const error = await responce.json();
        // alert(error.message);
        throw new Error(error.message);
    }

    const data = await responce.json();

    return data;
}

export function getFormElementValuesAsObject(form) {
    const formData = new FormData(form);

    return [...formData.entries()].reduce((acc, [key, value]) => Object.assign(acc, {[key]: value}), {});
}

export function createDomElement(type, attributes, ...content) {
    const domElement = document.createElement(type);

    for(let [attr, value] of Object.entries(attributes || {})) {
        if(attr.substring(0, 2) == 'on') {
            domElement.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            domElement[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if(typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            domElement.appendChild(node);
        } else {
            domElement.appendChild(e);
        }
    });

    return domElement;
}