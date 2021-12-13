function lockedProfile() {
    let profiles = Array.from(document.getElementsByClassName('profile'));

    profiles.forEach(p => {
        p.addEventListener('click', (e) => {
            if(e.target.tagName == 'BUTTON'){
                let lockButton = p.querySelector('input');
                let hiddenDiv = p.querySelector('div');
                
                if(!lockButton.checked && e.target.textContent == 'Show more') {
                    hiddenDiv.style.display = 'block';
                    e.target.textContent = 'Hide it';
                } else if(!lockButton.checked && e.target.textContent == 'Hide it') {
                    hiddenDiv.style.display = 'none';
                    e.target.textContent = 'Show more';
                }
            }
        });
    });
}