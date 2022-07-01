<template>
  <div>
    <div v-if="forField == 'password'">
        <div v-if="vData.password.$error" class="alert alert-danger">
            <p v-if="!vData.password.required">Field {{forField}} is required.</p>
            <p v-if="!vData.password.minLength">Field {{forField}} must have min {{ vData.password.$params.minLength.min }} characters.</p>
            <p v-if="!vData.password.maxLength">Field {{forField}} must have max {{ vData.password.$params.maxLength.max }} characters.</p>
        </div>
    </div>
    <div v-else-if="forField == 'repass'">
        <div v-if="vData.password.$model != vData.repass.$model" class="alert alert-danger">
            <p>Passwords is not match.</p>
        </div>
    </div>
    <div v-else-if="forField == 'email'">
        <div v-if="vData.email.$error" class="alert alert-danger">
            <p v-if="!vData.email.required">Field {{forField}} is required.</p>
            <p v-if="!vData.email.email">Entered {{forField}} is not valid.</p>
        </div>
    </div>
    <div v-else-if="forField == 'age'">
        <div v-if="vData.age.$error" class="alert alert-danger">
            <p v-if="!vData.age.required">Field {{forField}} is required.</p>
            <p v-if="!vData.age.minValue">Min value for {{forField}} must be a {{vData.age.$params.minValue.min}}.</p>
        </div>
    </div>
    <div v-else-if="forField == 'description'">
        <div v-if="vData.description.$error" class="alert alert-danger">
            <p v-if="!vData.description.required">Field {{forField}} is required.</p>
            <p v-if="!vData.description.minLength">Mix length must be a {{vData.description.$params.minLength.min}} characters.</p>
            <p v-if="!vData.description.maxLength">Max length must be a {{vData.description.$params.maxLength.max}} characters.</p>
        </div>
    </div>
    <div v-else>
        <div class="alert alert-warning">
            <p>Field name in Validator component is wrong or not exist.</p>
        </div>
    </div>
  </div>
</template>

<script>
export default {
    props: {
        vData: {
            type: Object,
            required: true
        },
        forField: {
            type: String,
            required: true
        }
    }
}
</script>

<style>

</style>