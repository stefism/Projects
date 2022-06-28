<template>
  <div id="app">
    <Header/>
    <main>
      <Navigation/>
      <div class="main-content">
        <Subjects/>
        <Content/>
      </div>
    </main>
    <Footer/>
  </div>
</template>

<script>
import Header from './components/core/Header-comp.vue';
import Navigation from './components/core/Vavigation-comp.vue';
import Subjects from './components/core/Subjects-comp.vue';
import Content from './components/core/Content-comp.vue';
import Footer from './components/core/Footer-comp.vue';

export default {
  name: 'App',
  components: {
    Header, Navigation, Subjects, Content, Footer
  }
}
</script>

<style>

</style>
