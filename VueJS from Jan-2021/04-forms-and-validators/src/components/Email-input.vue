<template>
    <div class="form-group">
        <label for="email">Email from component</label>
        <input 
            type="text" 
            id="email2" 
            class="form-control"
            :value="email"
            @change="inputHandler"
        />
    </div>
</template>

<script>
    export default {
        props: {
            email: {
                type: String,
                required: true
            }
        },
        methods: {
            inputHandler(event) {
                this.$emit('on-input', event.target.value);
            }
        }
    }
</script>
<style>

</style>