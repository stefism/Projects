let reposUlElement = document.getElementById('repos');

function loadRepos() {
	let inputElement = document.getElementById('username');

	fetch(`https://api.github.com/users/${inputElement.value}/repos`)
		.then(responce => {
			console.log(responce);
			if (!responce.ok) {
				throw new Error(`${responce.status} ${responce.statusText}`);
			}

			return responce.json();
		})
		.then(data => processData(data)) //.then(processData)
		.catch(error => processData(error)); //.then(processData)
}

function processData(data) {
	console.log(data);
	if (!Array.isArray(data)) {
		removeLiElements();
		appendLiElementToUl('', `User not found. ${data}`);
	} else if(data.length == 0) {
		removeLiElements();
		appendLiElementToUl('', 'This user is no repos.');
	} else {
		removeLiElements();
		data.forEach(repo => {
			appendLiElementToUl(repo.html_url, repo.full_name);
		});
	}
}

function appendLiElementToUl(href, textContent) {
	let repoLiElement = document.createElement('li');

	let repoAnchor = document.createElement('a');
	repoAnchor.href = href;
	repoAnchor.textContent = textContent;
	repoAnchor.target = '_blank';

	repoLiElement.appendChild(repoAnchor);
	reposUlElement.appendChild(repoLiElement);
}

function removeLiElements() {
	document.getElementById('repos').replaceChildren();
}