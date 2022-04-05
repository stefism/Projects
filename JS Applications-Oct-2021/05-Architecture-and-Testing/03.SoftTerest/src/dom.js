export function showSection(section) {
    main.replaceChildren(section);
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