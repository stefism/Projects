import { html } from 'https://unpkg.com/lit-html?module';
import commentTemplate from './comment.js';

const articleTemplate = (onSubmit, article) => html`
<article>
<input type="text" ?disabled=${article.disabled} .value=${article.color} />
    <h3>${article.title}</h3>
    <div class=${article.color}>
        <p>${article.content}</p>
    </div>
    <footer>Author: ${article.author}</footer>
    <div class="comments">
        <form @submit=${onSubmit}>
            <textarea name="comment"></textarea>
            <button>Submit comment</button>
        </form>

        <ul>
            ${article.comments.map(commentTemplate)}
        </ul>
    </div>
</article>`;

export default articleTemplate;