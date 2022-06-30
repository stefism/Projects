<template>
    <div class="form-group">
        <label for="email">Email from component with v-model</label>
        <input 
            type="text" 
            id="email3" 
            class="form-control"
            :value="value"
            @change="inputHandler"
        />
    </div>
</template>

<script>
/*  
    When used on a component, v-model instead does this:
    <custom-input
      v-bind:value="searchText"
      v-on:input="searchText = $event">
    </custom-input>

    Имайки предвид това, ако искаме да ползваме v-model в нашия къстъм компонент, трябва долу в пропс, като проперти да върнем проперти с името value, а като $emit трябва да върнем 'input' евент.
    Така обаче не можем да ползваме модифайерите на v-model и ако искаме да слушаме за @change - горе трябва да сложим @change като евент, но долу да си остане в метода 'input'.
 */

    export default {
        props: {
            value: {
                type: String,
                required: true
            }
        },
        methods: {
            inputHandler(event) {
                this.$emit('input', event.target.value);
            }
        }
    }
</script>
<style>

</style>