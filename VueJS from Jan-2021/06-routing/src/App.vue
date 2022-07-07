<template>
  <div id="app">
    <Navigation />
    <router-view />
    <!-- <router-view /> - тук ще се визуализират компонентите, който са включени в раутинга. След Като сме ги закачили към routes (което сме направили в index.js файла в папка router), не ги импортираме тук, а само слагаме този таг и те ще се показват в него, когато горе в адрес бара напишем съответния url. Този таг идва от vue-router библиотеката. -->
  </div>
</template>

<script>
import Navigation from "@/components/Navigation-comp.vue";
export default {
  name: "App",
  components: {
    Navigation
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>