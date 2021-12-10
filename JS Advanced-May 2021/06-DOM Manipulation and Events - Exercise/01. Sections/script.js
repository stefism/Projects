function create(array){
    let content = document.getElementById('content');

    array.forEach(element => {
        let div = document.createElement('div');
        
        let p = document.createElement('p');
        p.textContent = element;
        p.style.display = 'none';

        div.appendChild(p);
        content.appendChild(div);
    });

    content.addEventListener('click', (e) => {
        e.target.firstChild.style.removeProperty('display');
    })
}