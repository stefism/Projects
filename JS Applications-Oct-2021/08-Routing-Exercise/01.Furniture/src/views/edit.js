import { editItem, getById } from '../api/data.js';
import { getAllFormEntriesAsObject, verifyFormFields } from '../util.js';
import { createTemplate } from './create.js';
import { until, html } from '../lib.js';

export async function editPage(context) {
    const item = await loadItem(context);
    const itemTemplate = createTemplate(onSubmit, null, item);
    
    context.render(itemTemplate);

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const formElementEntries = getAllFormEntriesAsObject(formData);
        const filledValues = verifyFormFields(formElementEntries);

        if(Object.values(filledValues).some(v => v.errorMsg)) {
            context.render(createTemplate(onSubmit, filledValues, item));
            return;
        }

        await editItem(context.params.id, formElementEntries);
        context.page.redirect('/details/' + context.params.id);
    }
}

async function loadItem(context) {
    const item = await getById(context.params.id);
    return item;
}