<template>
  <div id="app">
    <Header/>
    <main>
      <Navigation 
        :navigationItems="technologyNames"
        @nav-click="onMenuClick"
      />
       <!-- @nav-click е къстъм евента, който сме именували и изпратили от чайлд компонента. Заедно с евента, автоматично от чайлда ще дойде и ай дито, защото сме го подали в чайлда като параметър, след името на евента ( this.$emit('nav-click', id) ). Така, всеки път, когато се кликне на евента @click в чайлда, ще знаем и тук, че е кликнато и ще изпълним тук метода, който сме указали в скобите. Понеже ай дито се подава от чайлда, тук - долу в метода onMenuClick(id), id ще си го вземе от тук през евента. -->
      
      <div class="main-content">
        <Subjects
          :technologies="tutorials.technologies"
          :selectedMenuId="selectedMenuId"
          :selectedSubjectName="selectedSubjectName"
          @subject-click="onSubjectClick"
        />
        <Content/>
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

import jsonData from './assets/tutorials.json';

export default {
  name: 'App',
  components: {
    Header, 
    Navigation, //Това е горе менюто в синьо, където са изброени езиците за програмиране.
    Subjects, // Това са от страни в ляво, под Navigation, самите теми за съответния език.
    Content, 
    Footer
  },
  data() {
    return {
      tutorials: jsonData,
      selectedMenuId: jsonData.technologies[0].id,
      selectedSubjectName: ''
    };
  },
  computed: {
    technologyNames() {
      return this.tutorials.technologies.map(t => ({
        id: t.id,
        name: t.name
      }));
    },
  },
  methods: {
    test() {
      console.log(this.tutorials);
    },
    onMenuClick(id) { //Това id си идва от горе от евента. Подава се заедно с него.
      this.selectedMenuId = id;
      this.selectedSubjectName = '';
      console.log('selectedMenuId: ', this.selectedMenuId);
    },
    onSubjectClick(subjectName) { //Тук това subjectName също идва от горе заедно с евента.
      this.selectedSubjectName = subjectName;
    }
  },
  created() {
    this.test();
  }
};
</script>
  
<style>

</style>
