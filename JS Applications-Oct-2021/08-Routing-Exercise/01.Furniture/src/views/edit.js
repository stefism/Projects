import { editItem, getById } from '../api/data.js';
import { getAllFormEntriesAsObject, verifyFormFields } from '../util.js';
import { createTemplate } from './create.js';
import { until, html } from '../lib.js';

let currentItem;

export async function editPage(context) {
    const editTemplate = (loadItemPromise) => html`
        <div>
        ${until(loadItemPromise, html`Loading...`)}
        </div>`
    ;
    
    context.render(editTemplate(loadItem(context, onSubmit)));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const formElementEntries = getAllFormEntriesAsObject(formData);
        const filledValues = verifyFormFields(formElementEntries);

        if(Object.values(filledValues).some(v => v.errorMsg)) {
            context.render(editTemplate(loadItem(context, onSubmit, filledValues, formElementEntries)));
            return;
        }

        try {
            await editItem(context.params.id, formElementEntries);
            context.page.redirect('/details/' + context.params.id);
        } catch (error) {
            alert(error);
        }
    }
}

async function loadItem(context, onSubmit, filledValues, formElementEntries) {
    let item;

    if(filledValues && Object.values(filledValues).some(v => v.errorMsg)) {
        item = currentItem;

        for (const key in item) {
            item[key] = formElementEntries[key];
        }
    } else {
        item = await getById(context.params.id);
        currentItem = item;
    }

    const itemTemplate = createTemplate(onSubmit, filledValues, item);
    return itemTemplate;
}