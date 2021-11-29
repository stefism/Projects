function editElement(element, stringMatch, replacer) {
    let content = element.textContent;
    content = content.replace(stringMatch, replacer);
    
    element.textContent = content;
}