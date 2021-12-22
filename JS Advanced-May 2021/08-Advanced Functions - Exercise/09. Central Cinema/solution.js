function solve() {
    let onScreenButton = document.querySelector('#container button');
    onScreenButton.addEventListener('click', addMovieOnScreen);

    function addMovieOnScreen(e) {
        e.preventDefault();

        let movieProperties = document.querySelectorAll('#container input');

        let moviesOnScreen = document.querySelector('#movies ul');
        moviesOnScreen.addEventListener('click', archiveMovies)
        
        let movieName = movieProperties[0].value;
        let movieHall = movieProperties[1].value;
        let ticketPrice = movieProperties[2].value;

        if(movieName == '' || movieHall == '' || ticketPrice == '' || isNaN(ticketPrice)) {
            return;
        }

        let moviesUl = document.querySelector('#movies ul');
        
        let movieLi = document.createElement('li');

        let movieNameSpan = document.createElement('span');
        movieNameSpan.textContent = movieName;
        
        let hall = document.createElement('strong');
        hall.textContent = `Hall: ${movieHall}`;

        movieLi.appendChild(movieNameSpan);
        movieLi.appendChild(hall);

        let div = document.createElement('div');

        let price = document.createElement('strong');
        price.textContent = Number(ticketPrice).toFixed(2);

        let input = document.createElement('input');
        input.placeholder = 'Ticket Sold';

        let archiveButton = document.createElement('button');
        archiveButton.textContent = 'Archive';

        div.appendChild(price);
        div.appendChild(input);
        div.appendChild(archiveButton);

        movieLi.appendChild(div);

        moviesUl.appendChild(movieLi);

        movieProperties[0].value = '';
        movieProperties[1].value = '';
        movieProperties[2].value = '';
    }

    function archiveMovies(e) {
        if(e.target.tagName != 'BUTTON') {
            return;
        }

        let archiveUl = document.querySelector('#archive ul');
        
        let archiveSection = document.getElementById('archive');
        archiveSection.addEventListener('click', manageArchive);
        
        let filmLi = e.target.parentNode.parentNode;

        let movieName = filmLi.querySelector('span').textContent;
        let ticketPrice = filmLi.querySelector('div strong').textContent;
        let ticketSold = filmLi.querySelector('div input').value;
        let totalAmount = Number(ticketPrice) * Number(ticketSold);

        if(isNaN(ticketSold) || ticketSold == ''){
            return;
        }

        let archiveLi = document.createElement('li');

        let movieNameSpan = document.createElement('span');
        movieNameSpan.textContent = movieName;

        let totalAmountStrong = document.createElement('strong');
        totalAmountStrong.textContent = `Total amount: ${totalAmount.toFixed(2)}`;

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';

        archiveLi.appendChild(movieNameSpan);
        archiveLi.appendChild(totalAmountStrong);
        archiveLi.appendChild(deleteButton);

        archiveUl.appendChild(archiveLi);
        filmLi.remove();
    }

    function manageArchive(e) {
        if(e.target.tagName != 'BUTTON') {
            return;
        }

        if(e.target.textContent == 'Clear') {
            let movieItems = Array.from(document.querySelectorAll('#archive ul li'));
            movieItems.forEach(item => item.remove());
        } else {
            let currentMovie = e.target.parentNode;
            currentMovie.remove();
        }
    }
}