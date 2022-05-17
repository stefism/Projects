import { createItem } from '../api/data.js';
import { html } from '../lib.js';
import { getAllFormEntriesAsObject, verifyFormFields } from '../util.js';

export const createTemplate = (onSubmit, filledValues, item) => html`
<div class="row space-top">
    <div class="col-md-12">
        ${item != undefined ? html`<h1>Edit Furniture</h1>` : html`<h1>Create New Furniture</h1>`}
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                ${filledValues && filledValues.make.errorMsg ? html`<div class="form-group error">${filledValues.make.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${'form-control' + (filledValues && filledValues.make.errorMsg ? ' is-invalid' : ' is-valid')} id="new-make" type="text" name="make" .value="${item != undefined ? item.make : ''}">
            </div>
            <div class="form-group has-success">
                ${filledValues && filledValues.model.errorMsg ? html`<div class="form-group error">${filledValues.model.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (filledValues && filledValues.model.errorMsg ? ' is-invalid' : ' is-valid')} id="new-model" type="text" name="model" .value="${item != undefined ? item.model : ''}">
            </div>
            <div class="form-group has-danger">
                ${filledValues && filledValues.year.errorMsg ? html`<div class="form-group error">${filledValues.year.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (filledValues && filledValues.year.errorMsg ? ' is-invalid' : ' is-valid')} id="new-year" type="number" name="year" .value="${item != undefined ? item.year : ''}">
            </div>
            <div class="form-group">
                ${filledValues && filledValues.description.errorMsg ? html`<div class="form-group error">${filledValues.description.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (filledValues && filledValues.description.errorMsg ? ' is-invalid' : ' is-valid')} id="new-description" type="text" name="description" .value="${item != undefined ? item.description : ''}">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                ${filledValues && filledValues.price.errorMsg ? html`<div class="form-group error">${filledValues.price.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (filledValues && filledValues.price.errorMsg ? ' is-invalid' : ' is-valid')} id="new-price" type="number" name="price" .value="${item != undefined ? item.price : ''}">
            </div>
            <div class="form-group">
                ${filledValues && filledValues.img.errorMsg ? html`<div class="form-group error">${filledValues.img.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control' + (filledValues && filledValues.img.errorMsg ? ' is-invalid' : ' is-valid')} id="new-image" type="text" name="img" .value="${item != undefined ? item.img : ''}">
            </div>
            <div class="form-group">
                ${filledValues && filledValues.material.errorMsg ? html`<div class="form-group error">${filledValues.material.errorMsg}</div>` : null}
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class=${'form-control' + (filledValues && filledValues.material.errorMsg ? ' is-invalid' : ' is-valid')} id="new-material" type="text" name="material" .value="${item != undefined ? item.material : ''}">
            </div>
            <input type="submit" class="btn btn-primary" value=" ${item != undefined ? 'Edit' : 'Create'}" />
        </div>
    </div>
</form>
`;

export function createPage(context) {
    context.render(createTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const formElementEntries = getAllFormEntriesAsObject(formData);
        
        const filledValues = verifyFormFields(formElementEntries);

        if(Object.values(filledValues).some(v => v.errorMsg)) {
            context.render(createTemplate(onSubmit, filledValues));
            return;
        }

        try {
            const result = await createItem(formElementEntries);
        
            context.updateUserNav();
            context.page.redirect('/details/' + result.id);
        } catch (error) {
            alert(error);
        }
    }
}