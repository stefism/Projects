import { getAllTopics } from '../api/data.js';
import { html, until } from '../lib.js';

const topicsTemplate = (topicsPromise) => html`
<h1>Topics</h1>
<div>
${until(topicsPromise, html`<p class="spinner">Loading...</p>`)}
</div>`;

const topicPreviewCard = (topic) => html`
<article class="preview drop">
    <header><a href="/Forum/topic/${ topic._id }">${ topic.title }</a></header>
    <div>by ${ topic.author.username || topic.author.email } | 11 Comments</div>
</article>
`;

export function topicsPage(context) {
    context.render(topicsTemplate(loadTopics()));
}

async function loadTopics() {
    const topics = await getAllTopics();

    return topics.map(topicPreviewCard);
}