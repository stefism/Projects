const newRecipeForm = document.querySelector('form');
        newRecipeForm.addEventListener('submit', addRecipe);

        async function addRecipe(e) {
            e.preventDefault();

            const formData = new FormData(newRecipeForm);

            const name = formData.get('name').trim();
            const img = formData.get('img').trim();
            const ingredients = formData.get('ingredients').split('\n');
            const steps = formData.get('steps').split('\n');

            const authToken = sessionStorage.getItem('authToken');

            const url = 'http://localhost:3030/data/recipes';

            try {
                const responce = await fetch(url, {
                    method: 'post',
                    headers: {
                        'Content-Type': 'application/json',
                        'X-Authorization': authToken
                    },
                    body: JSON.stringify({ name, img, ingredients, steps })
                });

                if (responce.status != 200) {
                    const error = await responce.json();
                    throw new Error(`Error: ${error.message}`);
                }

                const result = await responce.json();

                window.location = '/index.html';
            } catch (error) {
                alert(error.message);
            }
        }