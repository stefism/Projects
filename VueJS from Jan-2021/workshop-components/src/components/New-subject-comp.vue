<template>
  <div>
    <div class="form-group">
        <input v-model="title" placeholder="Technology subject..." type="text" id="subject" />
    </div>

    <VueEditor v-model="content"/>
    <!-- v-model - two way data binding - каквото променим в едитора, то се следи и автоматично ще се презапише в нашата променлива content. -->
    
    <select v-model="technology" name="technologies" id="technologies">
        <!-- Тук като байндваме v-model към technology, това явно е свързано с value на option-ните и затова, долу в пропертито technology (в data() метода, където го ретърнваме), трябва да му зададем дефолтна стойност и тази стойност ще играе ролята на selected атрибута. Ако го оставим дефолтно да е празен стринг, няма да имаме нищо в селект менюто. -->
        <option value="default">Select a technology...</option>
        <option 
            v-for="tech in technologies"
            :key="tech.id" 
            :value="tech.id"
        >
            {{ tech.name }}
        </option>
    </select>
    <button class="btn" @click="onSave">Create</button>
    <h3>Content preview</h3>
    <div v-html="content" class="content-preview">
        <!-- Понеже текстовия едитор връща всичко като стринг, получаваме и html-а като стринг. Затова ако напишем <p>{{ content }}</p>, тук всичко ще се покаже като стринг. Няма да има форматирането от html-а. За да може да го интерполираме да си бъде като html, му задаваме горе на параграфа атрибут, който идва от Vue - v-html и така всичко тук, ще се изобразява като html. Директивата v-html не работи с template tag. -->
    </div>
  </div>
</template>

<script>
import { VueEditor } from 'vue2-editor';
export default {
    components: {
        VueEditor
    },
    props: {
        technologies: {
            type: Array,
            required: true
        }
    },
    data() {
        return {
            content: '',
            title: '',
            technology: 'default'
        }
    },
    methods: {
        onSave() {
            if(this.technology == 'default' || this.technology == '') {
                return;
            }

            const newSubject = {
                name: this.title,
                content: this.content
            };

            this.$emit('on-save', this.technology, newSubject);
        }
    }
}
</script>

<style>

</style>