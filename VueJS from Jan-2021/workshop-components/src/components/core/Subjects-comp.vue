<template>
  <aside class="content-navigation">
    <ul>
      <li v-for="(subject, index) in subjectsForTechnology" 
        :key="index" :class="{ active: isSubjectActive(subject.name) }">
        <a href="#" @click.prevent="onSubjectClick(subject.name)">{{ subject.name }}</a>
      </li>
    </ul>
  </aside>
</template>

<script>
export default {
 props: {
  technologies: {
    type: Array,
    required: true
  },
  selectedMenuId: {
    type: String,
    required: true
  },
  selectedSubjectName: {
    type: String,
    required: true
  }
 },
 computed: {
  subjectsForTechnology() {
    const { subjects }  = this.technologies.find(t => t.id == this.selectedMenuId);
    return subjects;
  }
 },
 methods: {
  onSubjectClick(subjectName) {
    this.$emit('subject-click', subjectName);
  },
  isSubjectActive(subjectName) {
    return this.selectedSubjectName == subjectName;
  }
 }
};
</script>

<style>

</style>