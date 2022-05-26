import { createComment, getCommentsByTopicId, getTopicById } from '../api/data.js';
import { html, until } from '../lib.js';
import { getAllFormEntriesAsObject, getUserData } from '../util.js';

const detailsTemplate = (topicPromise) => html`
<h1>Topic details</h1>
${until(topicPromise, html`<p>Loading...</p>`)}
`;

const topicCard = (topic, isOwner, comments, onCommentSubmit) => html`
<div class="narrow drop">
    <h1>${topic.title}</h1>
    <p>${topic.description}</p>
    ${isOwner ? html`
        <div>
            <a class="action" href="/Forum/edit/${topic._id}">Edit</a>
            <a class="action" href="javascript:void(0)">Delete</a>
        </div>
    ` : html`
        <p>by ${ topic.author.username || topic.author.email }</p>
    `}
</div>
<div class="main">
    ${commentForm(onCommentSubmit)}
    ${comments.map(commentCard)}
</div>
`;

const commentCard = (comment) => html`
<article class="preview">
    <header>Author: ${comment.author.username || comment.author.email}</header>
    <p>${comment.description}</p>
</article>
`;

const commentForm = (onCommentSubmit) => html`
<article class="narrow drop">
    <header>Post new comment</header>
    <div class="topicContent">
        <form @submit=${onCommentSubmit}>
            <textarea name="description"></textarea>
            <input class="action" type="submit" value="Post">
        </form>
    </div>
</article>
`;

export function detailsPage(context) {
    context.render(detailsTemplate(loadTopic(context.params.id, onCommentSubmit)));

    async function onCommentSubmit(e) {
        e.preventDefault();

        const formData = getAllFormEntriesAsObject(e.target);

        if(formData.description == '') {
            alert('Cannot post empty comment.');
            return;
        }

        [...e.target.querySelectorAll('input, textarea')].forEach(i => i.disabled = true);

        formData.topicId = context.params.id;
        
        await createComment(formData);
        [...e.target.querySelectorAll('input, textarea')].forEach(i => i.disabled = false);
        
        context.render(detailsTemplate(loadTopic(context.params.id, onCommentSubmit)));
    }
}

async function loadTopic(id, onCommentSubmit) {
    const [topic, comments] = await Promise.all([
        getTopicById(id),
        getCommentsByTopicId(id)
    ]);
    
    const userData = getUserData();
    const isOwner = topic._ownerId == userData.id;

    return topicCard(topic, isOwner, comments, onCommentSubmit);
}