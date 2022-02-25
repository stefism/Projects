let loadPostsBtn = document.getElementById('btnLoadPosts');
loadPostsBtn.addEventListener('click', loadPostsAndComments);

let viewPostBtn = document.getElementById('btnViewPost');
viewPostBtn.addEventListener('click', showPostDetails);

let selectElement = document.getElementById('posts');

let finalPosts = '';
let finalComments = '';

async function loadPostsAndComments(e) {
    e.preventDefault();

    let [posts, comments] = await Promise.all([
        fetch('http://localhost:3030/jsonstore/blog/posts'),
        fetch('http://localhost:3030/jsonstore/blog/comments')
    ]);

    let [postResult, commentsResult] = await Promise.all([
        posts.json(), comments.json()
    ]);

    finalPosts = postResult;
    finalComments = commentsResult;

    showPosts(finalPosts);
}

function showPosts(postResult) {
    for (const key in postResult) {
        let optionElement = document.createElement('option');
        optionElement.value = key;
        optionElement.textContent = postResult[key].title;

        selectElement.appendChild(optionElement);
    }
}

function showPostDetails() {
    let postTitle = document.getElementById('post-title');
    let postBody = document.getElementById('post-body');
    let postCommentsUl = document.getElementById('post-comments');

    let selectedPost = finalPosts[selectElement.value];
    let commentsForCurrentPost = Object.entries(finalComments)
        .filter(c => c[1].postId == selectElement.value);

    postTitle.textContent = selectedPost.title;
    postBody.textContent = selectedPost.body;

    commentsForCurrentPost.forEach(c => {
        let liElement = document.createElement('li');
        liElement.textContent = c[1].text;

        postCommentsUl.appendChild(liElement);
    });
}