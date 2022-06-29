<template>
  <div id="app">
    <Header/>
    <main>
      <Navigation 
        :navigationItems="technologyNames"
        @nav-click="onMenuClick"
        @on-create-subject="onCreateSubject"
      />
       <!-- @nav-click е къстъм евента, който сме именували и изпратили от чайлд компонента. Заедно с евента, автоматично от чайлда ще дойде и ай дито, защото сме го подали в чайлда като параметър, след името на евента ( this.$emit('nav-click', id) ). Така, всеки път, когато се кликне на евента @click в чайлда, ще знаем и тук, че е кликнато и ще изпълним тук метода, който сме указали в скобите. Понеже ай дито се подава от чайлда, тук - долу в метода onMenuClick(id), id ще си го вземе от тук през евента. -->
      
      <div class="main-content">
        <Subjects
          :technologies="tutorials.technologies"
          :selectedTechnologiesId="selectedTechnologiesId"
          :selectedSubjectName="selectedSubjectName"
          @subject-click="onSubjectClick"
        />
        <Content>
          <NewSubject 
            v-if="isCreateSubject"
            :technologies="technologyNames"
            @on-save="onSubjectSave"
          />

          <div v-else v-html="selectedContent"></div>
        </Content>
      </div>
    </main>

    <Footer/>
  </div>
</template>

<script>
import Header from './components/core/Header-comp.vue';
import Navigation from './components/core/Navigation-comp.vue';
import Subjects from './components/core/Subjects-comp.vue';
import Content from './components/core/Content-comp.vue';
import Footer from './components/core/Footer-comp.vue';
import NewSubject from './components/New-subject-comp.vue';

import jsonData from './assets/tutorials.json';
const defaultMenuId = jsonData.technologies[0].id;

export default {
  name: 'App',
  components: {
    Header, 
    Navigation, //Това е горе менюто в синьо, където са изброени езиците за програмиране.
    Subjects, // Това са от страни в ляво, под Navigation, самите теми за съответния език.
    Content, Footer, NewSubject
  },
  data() {
    return {
      tutorials: jsonData,
      selectedTechnologiesId: defaultMenuId,
      selectedSubjectName: '',
      isCreateSubject: false
    };
  },
  computed: {
    technologyNames() {
      return this.tutorials.technologies.map(t => ({
        id: t.id,
        name: t.name
      }));
    },
    selectedContent() {
      const { subjects } = this.tutorials.technologies.find(t => t.id == this.selectedTechnologiesId);
      const subject = subjects.find(s => s.name == this.selectedSubjectName);
      return subject ? subject.content : ''; //При цъкане горе в менютата, първоначално нямаме subject и затова, за да не гърми с undefined, му казваме само ако имаме subject, тогава да върне subject.content, иначе връща празен стринг.
    }
  },
  methods: {
    test() {
      console.log(this.tutorials);
    },
    onMenuClick(id) { //Това id си идва от горе от евента. Подава се заедно с него.
      this.selectedTechnologiesId = id;
      this.selectedSubjectName = '';
      this.isCreateSubject = false;
      console.log('selectedTechnologiesId: ', this.selectedTechnologiesId);
    },
    onSubjectClick(subjectName) { //Тук това subjectName също идва от горе заедно с евента.
      this.selectedSubjectName = subjectName;
      this.isCreateSubject = false;
    },
    onCreateSubject() {
      this.isCreateSubject = true;
      this.selectedSubjectName = '';
    },
    onSubjectSave(technology, newSubject) {
      const { technologies } = this.tutorials;
      const selectedTech = technologies.find(t => t.id == technology);
      selectedTech.subjects.push(newSubject);
      this.isCreateSubject = false;
    }
  },
  created() {
    this.test();
  }
};
</script>
  
<style>

</style>
