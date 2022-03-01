window.onload = manageNavbar();

        let logoutBtn = document.getElementById('logoutBtn');
        logoutBtn.addEventListener('click', logout);

        function manageNavbar() {
            const authToken = sessionStorage.getItem('authToken');
            
            const guestButtons = document.getElementById('guest');
            const userButtons = document.getElementById('user');

            if(authToken == null) {
                userButtons.style.display = 'none';
                guestButtons.style.display = 'inline-block';
            } else {
                userButtons.style.display = 'inline-block';
                guestButtons.style.display = 'none';
            }
        }

        async function logout(e) {
            e.preventDefault();

            const url = 'http://localhost:3030/users/logout';

            const options = { headers: {} };
            const authToken = sessionStorage.getItem('authToken');

            if(authToken != null) {
                options.headers['X-Authorization'] = authToken;
            }

            try {
                const responce = await fetch(url, options);
                sessionStorage.clear();

                window.location = '/index.html';
            } catch (error) {
                alert(error.message);
            }
        }